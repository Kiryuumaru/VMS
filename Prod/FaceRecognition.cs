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
            // Pre trained haar cascade for frontal face
            private static readonly HaarCascade face = new HaarCascade("haarcascade_frontalface_default.xml");

            // Training images and labels for classification
            private static readonly List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>();
            private static readonly List<string> labels = new List<string>();

            // Frame grabber handler
            private static readonly EventHandler frameGrabberHandler = new EventHandler(FrameGrabber);

            // Camera frame grabber
            private static Capture grabber;

            // Image processing disposable placeholders
            private static Image<Bgr, byte> currentFrame;
            private static Image<Gray, byte> gray = null;
            private static Image<Gray, byte> result = null;
            private static Image<Gray, byte> trainedFace = null;

            // Verbous diagnostic variables for development
            private static MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_TRIPLEX, 0.5d, 0.5d);
            private static string currentDectection;
            private static int currentDectectionCount;
            private static ImageBox imageBoxFrameGrabber;

            public static Action<string> OnFaceRecognized;

            public static bool Started { get; private set; } = false;
            public static bool ShowLabel { get; set; } = false;

            // Initialize face recognition
            public static void Init()
            {
                ML.Init();
                if (!Directory.Exists(Extension.ImagesDir)) Directory.CreateDirectory(Extension.ImagesDir);
                try
                {
                    // Read all trained face
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
                }
            }

            // Start camera grabber and face recognition
            public static void Start(ImageBox frameGrabber)
            {
                imageBoxFrameGrabber = frameGrabber;
                grabber = new Capture(5);
                grabber.QueryFrame();
                Application.Idle += frameGrabberHandler;
                Started = true;
            }

            // Stop camera grabber and face recognition
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

            // Diagnostic method frame grab
            public static bool TryCaptureDetected(out Image<Gray, byte> image)
            {
                image = null;
                if (currentDectectionCount != 1 || !Started) return false;
                image = result.Copy();
                return true;
            }

            // Diagnostic method face classification on current frame
            public static bool TryGetRecognized(out string label)
            {
                label = "";
                if (currentDectectionCount != 1 || !Started) return false;
                label = currentDectection;
                return true;
            }

            // Add face to train method
            public static void AddDataset(Image<Gray, byte> image, string label, Action<string> log = null)
            {
                if (currentDectectionCount != 1)
                {
                    log?.Invoke("MLFaceRecognition: Multiple face detected");
                    return;
                }
                // Resize face image to 100x100 px 
                trainedFace = image.Resize(100, 100, INTER.CV_INTER_CUBIC);
                // Add to dynamic trained face
                trainingImages.Add(trainedFace);

                log?.Invoke("MLFaceRecognition: Adding " + label + " dataset . . .");

                // Image file indexer counting
                int index = 1;
                string filename;
                while (File.Exists(Path.Combine(Extension.ImagesDir, label + "_" + index.ToString("0000") + ".bmp")))
                {
                    index++;
                }
                // Save image on available index
                filename = label + "_" + index.ToString("0000") + ".bmp";
                trainedFace.Save(Path.Combine(Extension.ImagesDir, filename));

                log?.Invoke("MLFaceRecognition: Done");
            }

            // Per camera frame routine method
            private static void FrameGrabber(object sender, EventArgs e)
            {
                if (!Started) return;

                // Get current frame from camera
                currentFrame = grabber.QueryFrame().Resize(420, 340, INTER.CV_INTER_CUBIC);

                // Convert to grayscale
                gray = currentFrame.Convert<Gray, byte>();

                // Do haar cascade classifier on camera frame
                MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(
                  face,
                  1.2,
                  10,
                  HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                  new Size(20, 20));

                // Classify detected faces on frame
                currentDectectionCount = facesDetected[0].Length;
                foreach (MCvAvgComp f in facesDetected[0])
                {
                    // Crop face image area and convert to gray
                    result = currentFrame.Copy(f.rect).Convert<Gray, byte>().Resize(100, 100, INTER.CV_INTER_CUBIC);
                    // Draw red rectangle on face area
                    currentFrame.Draw(f.rect, new Bgr(Color.Red), 2);
                    //
                    if (trainingImages.ToArray().Length != 0)
                    {
                        // Eigen algorithm term criteria for recognizing face
                        MCvTermCriteria termCrit = new MCvTermCriteria(trainingImages.Count, 0.001);
                        // Create eigen recognizer object
                        EigenObjectRecognizer recognizer = new EigenObjectRecognizer(
                           trainingImages.ToArray(),
                           labels.ToArray(),
                           3000,
                           ref termCrit);

                        // Do recognize current face using eigen algorithm
                        currentDectection = recognizer.Recognize(result);

                        // Verbous diagnostic show name on recognizer
                        if (ShowLabel)
                        {
                            currentFrame.Draw(currentDectection, ref font, new Point(f.rect.X - 2, f.rect.Y - 2), new Bgr(Color.LightGreen));
                        }
                    }
                }

                // Update frame on UI
                imageBoxFrameGrabber.Image = currentFrame;

                // Update current recognizer state on UI
                if (currentDectectionCount == 1 && !string.IsNullOrEmpty(currentDectection))
                {
                    OnFaceRecognized?.Invoke(currentDectection);
                }
            }
        }
    }
}
