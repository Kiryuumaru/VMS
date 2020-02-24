using VMS.ViewModel;
using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMS.Services
{
    public static class ML
    {
        struct InceptionSettings
        {
            public const int ImageHeight = 224;
            public const int ImageWidth = 224;
            public const float Mean = 117;
            public const float Scale = 1;
            public const bool ChannelsLast = true;
        }

        public static readonly string AssetsDir = Path.Combine(Environment.CurrentDirectory, "Assets");
        public static readonly string ImagesDir = Path.Combine(AssetsDir, "Images");
        public static readonly string TempDir = Path.Combine(AssetsDir, "~Temp");
        public static readonly string TrainTags = Path.Combine(AssetsDir, "tags.tsv");
        public static readonly string Model = Path.Combine(AssetsDir, "model.pb");
        public static readonly string TransferModel = Path.Combine(AssetsDir, "transfer_model.zip");

        private static MLContext mlContext;
        private static ITransformer model;
        private static bool running = false;

        public static bool IsClassifyReady { get; private set; }

        public static void Init(Action<string> log)
        {
            if (running) return;
            running = true;

            log.Invoke("ML: Initializing . . .");

            IsClassifyReady = false;

            if (!File.Exists(Model))
            {
                log.Invoke("ML: Inception Model: Not ready");
                log.Invoke("ML: Extracting inception model . . .");
                Directory.CreateDirectory(AssetsDir);
                File.WriteAllBytes(Model, Properties.Resources.model);
            }
            else
            {
                log.Invoke("ML: Inception Model: Ready");
            }

            mlContext = new MLContext();

            try
            {
                model = mlContext.Model.Load(TransferModel, out DataViewSchema modelSchema);
                IsClassifyReady = true;
            }
            catch { }

            if (IsClassifyReady)
            {
                log.Invoke("ML: Transfer Model: Ready");
            }
            else
            {
                log.Invoke("ML: Transfer Model: Not ready");
            }

            log.Invoke("ML: Done");

            running = false;
        }

        private static string GenerateTempImageName()
        {
            if (!Directory.Exists(TempDir)) Directory.CreateDirectory(TempDir);
            int index = 1;
            while (File.Exists(Path.Combine(TempDir, "temp" + index.ToString("0000") + ".jpg")))
            {
                try
                {
                    Directory.Delete(Path.Combine(TempDir), true);
                    Directory.CreateDirectory(TempDir);
                    break;
                }
                catch
                {
                    index++;
                }
            }
            return Path.Combine(TempDir, "temp" + index.ToString("0000") + ".jpg");
        }

        public static void GenerateModel(Action<string> log)
        {
            if (running) return;
            running = true;

            IsClassifyReady = false;

            log.Invoke("ML: Generating transfer model . . .");

            if (!Directory.Exists(ImagesDir)) Directory.CreateDirectory(ImagesDir);

            if (File.Exists(Model))
            {
                List<string> tags = new List<string>();
                foreach (string file in Directory.EnumerateFiles(ImagesDir, "*.jpg"))
                {
                    string fileName = file.Substring(file.LastIndexOf("\\") + 1);
                    if (!fileName.Contains("_")) continue;
                    string label = fileName.Substring(0, fileName.LastIndexOf("_"));
                    tags.Add(fileName + "\t" + label);
                }
                File.WriteAllLines(TrainTags, tags);

                if (File.ReadAllLines(TrainTags).Length > 0)
                {
                    IEstimator<ITransformer> pipeline = mlContext.Transforms.LoadImages(outputColumnName: "input", imageFolder: ImagesDir, inputColumnName: nameof(ImageData.ImagePath))
                        .Append(mlContext.Transforms.ResizeImages(outputColumnName: "input", imageWidth: InceptionSettings.ImageWidth, imageHeight: InceptionSettings.ImageHeight, inputColumnName: "input"))
                        .Append(mlContext.Transforms.ExtractPixels(outputColumnName: "input", interleavePixelColors: InceptionSettings.ChannelsLast, offsetImage: InceptionSettings.Mean))
                        .Append(mlContext.Model.LoadTensorFlowModel(Model).
                            ScoreTensorFlowModel(outputColumnNames: new[] { "softmax2_pre_activation" }, inputColumnNames: new[] { "input" }, addBatchDimensionInput: true))
                        .Append(mlContext.Transforms.Conversion.MapValueToKey(outputColumnName: "LabelKey", inputColumnName: "Label"))
                        .Append(mlContext.MulticlassClassification.Trainers.LbfgsMaximumEntropy(labelColumnName: "LabelKey", featureColumnName: "softmax2_pre_activation"))
                        .Append(mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabelValue", "PredictedLabel"))
                        .AppendCacheCheckpoint(mlContext);

                    IDataView trainingData = mlContext.Data.LoadFromTextFile<ImageData>(path: TrainTags, hasHeader: false);

                    model = pipeline.Fit(trainingData);

                    mlContext.Model.Save(model, trainingData.Schema, TransferModel);

                    IsClassifyReady = true;

                    log.Invoke("ML: Done");
                }
                else
                {
                    log.Invoke("ML: No images found");
                }
            }
            else
            {
                log.Invoke("ML: Inception Model: not ready . . .");
            }

            running = false;
        }

        public static void AddDataset(Image image, string label, Action<string> log)
        {
            if (running) return;
            running = true;

            log.Invoke("ML: Adding " + label + " dataset . . .");

            int index = 1;
            string filename;
            while (File.Exists(Path.Combine(ImagesDir, label + "_" + index.ToString("0000") + ".jpg")))
            {
                index++;
            }
            filename = label + "_" + index.ToString("0000") + ".jpg";
            image.Save(Path.Combine(ImagesDir, filename), ImageFormat.Jpeg);

            log.Invoke("ML: Done");

            running = false;
        }

        public static ImagePrediction ClassifySingleImage(Image image, Action<string> log)
        {
            if (running) return null;
            running = true;

            if (!IsClassifyReady) return null;

            log.Invoke("ML: Test prediction started . . .");

            ImagePrediction imagePrediction = null;
            try
            {
                string filename = GenerateTempImageName();
                image.Save(filename, ImageFormat.Jpeg);

                var imageData = new ImageData()
                {
                    ImagePath = filename
                };

                var predictor = mlContext.Model.CreatePredictionEngine<ImageData, ImagePrediction>(model);

                imagePrediction = predictor.Predict(imageData);
                log.Invoke("ML: Test prediction result: Identified as " + imagePrediction.PredictedLabelValue + " with score " + (imagePrediction.Score.Max() * 100).ToString("00.00"));
            }
            catch (Exception ex)
            {
                log.Invoke("ML: Prediction error: " + ex.Message);
            }

            running = false;

            return imagePrediction;
        }
    }
}
