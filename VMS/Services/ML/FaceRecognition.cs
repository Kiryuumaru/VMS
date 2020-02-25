using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV.UI;

namespace VMS.Services
{
    public static partial class ML
    {
        public static class FaceRecognition
        {
            private static readonly HaarCascade face = new HaarCascade("haarcascade_frontalface_default.xml");
            private static readonly List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>();
            private static readonly List<string> labels = new List<string>();
            private static readonly EventHandler frameGrabberHandler = new EventHandler(FrameGrabber);

            private static Capture grabber;
            private static Image<Bgr, Byte> currentFrame;
            private static Image<Gray, byte> gray = null;
            private static Image<Gray, byte> result = null;
            private static Image<Gray, byte> trainedFace = null;

            private static MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_TRIPLEX, 0.5d, 0.5d);
            private static string currentDectection;
            private static int currentDectectionCount;
            private static ImageBox imageBoxFrameGrabber;

            public static Action<string> OnFaceRecognized;

            public static bool Started { get; private set; } = false;
            public static bool ShowLabel { get; set; } = false;

            public static void Init()
            {
                ML.Init();
                if (!Directory.Exists(Extension.ImagesDir)) Directory.CreateDirectory(Extension.ImagesDir);
                try
                {
                    foreach (string file in Directory.EnumerateFiles(Extension.ImagesDir, "*.bmp"))
                    {
                        string fileName = file.Substring(file.LastIndexOf("\\") + 1);
                        if (!fileName.Contains("_")) continue;
                        string label = fileName.Substring(0, fileName.LastIndexOf("_"));
                        trainingImages.Add(new Image<Gray, byte>(Path.Combine(file)));
                        labels.Add(label);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                    //MessageBox.Show("Nothing in binary database, please add at least a face(Simply train the prototype with the Add Face Button).", "Triained faces load", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            public static void Start(ImageBox frameGrabber)
            {
                imageBoxFrameGrabber = frameGrabber;
                grabber = new Capture();
                grabber.QueryFrame();
                Application.Idle += frameGrabberHandler;
                Started = true;
            }

            public static void Stop()
            {
                Started = false;
                Application.Idle -= frameGrabberHandler;
                if (grabber != null)
                {
                    grabber.Dispose();
                    grabber = null;
                }
            }

            public static bool TryCaptureDetected(out Image<Gray, byte> image)
            {
                image = null;
                if (currentDectectionCount != 1 || !Started) return false;
                image = result.Copy();
                return true;
            }

            public static bool TryGetRecognized(out string label)
            {
                label = "";
                if (currentDectectionCount != 1 || !Started) return false;
                label = currentDectection;
                return true;
            }

            public static void AddDataset(Image<Gray, byte> image, string label, Action<string> log = null)
            {
                if (currentDectectionCount != 1)
                {
                    log?.Invoke("MLFaceRecognition: Multiple face detected");
                    return;
                }
                trainedFace = image.Resize(100, 100, INTER.CV_INTER_CUBIC);
                trainingImages.Add(trainedFace);

                log?.Invoke("MLFaceRecognition: Adding " + label + " dataset . . .");

                int index = 1;
                string filename;
                while (File.Exists(Path.Combine(Extension.ImagesDir, label + "_" + index.ToString("0000") + ".bmp")))
                {
                    index++;
                }
                filename = label + "_" + index.ToString("0000") + ".bmp";
                trainedFace.Save(Path.Combine(Extension.ImagesDir, filename));

                log?.Invoke("MLFaceRecognition: Done");
            }



            private static void FrameGrabber(object sender, EventArgs e)
            {
                if (!Started) return;

                currentFrame = grabber.QueryFrame().Resize(420, 340, INTER.CV_INTER_CUBIC);
                gray = currentFrame.Convert<Gray, byte>();

                MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(
                  face,
                  1.2,
                  10,
                  HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                  new Size(20, 20));

                currentDectectionCount = facesDetected[0].Length;
                foreach (MCvAvgComp f in facesDetected[0])
                {
                    result = currentFrame.Copy(f.rect).Convert<Gray, byte>().Resize(100, 100, INTER.CV_INTER_CUBIC);
                    currentFrame.Draw(f.rect, new Bgr(Color.Red), 2);

                    if (trainingImages.ToArray().Length != 0)
                    {
                        MCvTermCriteria termCrit = new MCvTermCriteria(trainingImages.Count, 0.001);

                        EigenObjectRecognizer recognizer = new EigenObjectRecognizer(
                           trainingImages.ToArray(),
                           labels.ToArray(),
                           3000,
                           ref termCrit);

                        currentDectection = recognizer.Recognize(result);

                        if (ShowLabel)
                        {
                            currentFrame.Draw(currentDectection, ref font, new Point(f.rect.X - 2, f.rect.Y - 2), new Bgr(Color.LightGreen));
                        }
                    }
                }

                imageBoxFrameGrabber.Image = currentFrame;

                if (currentDectectionCount == 1 && !string.IsNullOrEmpty(currentDectection))
                {
                    OnFaceRecognized?.Invoke(currentDectection);
                }
            }
        }
    }
}
