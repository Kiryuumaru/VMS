using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMS.Services
{
    public static partial class ML
    {
        private static readonly string HighGui110 = Path.Combine(Environment.CurrentDirectory, "highgui110.dll");
        private static readonly string CXCore110 = Path.Combine(Environment.CurrentDirectory, "cxcore110.dll");
        private static readonly string CV110 = Path.Combine(Environment.CurrentDirectory, "cv110.dll");
        private static readonly string CVAux110 = Path.Combine(Environment.CurrentDirectory, "cvaux110.dll");
        private static readonly string CVExtern = Path.Combine(Environment.CurrentDirectory, "cvextern.dll");
        private static readonly string OpenCVCalib3d220 = Path.Combine(Environment.CurrentDirectory, "opencv_calib3d220.dll");
        private static readonly string OpenCVContrib220 = Path.Combine(Environment.CurrentDirectory, "opencv_contrib220.dll");
        private static readonly string OpenCVCore220 = Path.Combine(Environment.CurrentDirectory, "opencv_core220.dll");
        private static readonly string OpenCVFeatures2d220 = Path.Combine(Environment.CurrentDirectory, "opencv_features2d220.dll");
        private static readonly string OpenCVFFmpeg220 = Path.Combine(Environment.CurrentDirectory, "opencv_ffmpeg220.dll");
        private static readonly string OpenCVFlann220 = Path.Combine(Environment.CurrentDirectory, "opencv_flann220.dll");
        private static readonly string OpenCVGpu220 = Path.Combine(Environment.CurrentDirectory, "opencv_gpu220.dll");
        private static readonly string OpenCVHighGui220 = Path.Combine(Environment.CurrentDirectory, "opencv_highgui220.dll");
        private static readonly string OpenCVImgproc220 = Path.Combine(Environment.CurrentDirectory, "opencv_imgproc220.dll");
        private static readonly string OpenCVLegacy220 = Path.Combine(Environment.CurrentDirectory, "opencv_legacy220.dll");
        private static readonly string OpenCVML220 = Path.Combine(Environment.CurrentDirectory, "opencv_ml220.dll");
        private static readonly string OpenCVObjDetect220 = Path.Combine(Environment.CurrentDirectory, "opencv_objdetect220.dll");
        private static readonly string OpenCVVideo220 = Path.Combine(Environment.CurrentDirectory, "opencv_video220.dll");
        private static readonly string HaarCascadeFrontalFaceDefault = Path.Combine(Environment.CurrentDirectory, "haarcascade_frontalface_default.xml");

        public static void Init(Action<string> log = null)
        {
            log?.Invoke("ML: Initializing . . .");
            if (!File.Exists(HighGui110)) File.WriteAllBytes(HighGui110, Properties.Resources.highgui110);
            if (!File.Exists(CXCore110)) File.WriteAllBytes(CXCore110, Properties.Resources.cxcore110);
            if (!File.Exists(CV110)) File.WriteAllBytes(CV110, Properties.Resources.cv110);
            if (!File.Exists(CVAux110)) File.WriteAllBytes(CVAux110, Properties.Resources.cvaux110);
            if (!File.Exists(CVExtern)) File.WriteAllBytes(CVExtern, Properties.Resources.cvextern);
            if (!File.Exists(OpenCVCalib3d220)) File.WriteAllBytes(OpenCVCalib3d220, Properties.Resources.opencv_calib3d220);
            if (!File.Exists(OpenCVContrib220)) File.WriteAllBytes(OpenCVContrib220, Properties.Resources.opencv_contrib220);
            if (!File.Exists(OpenCVCore220)) File.WriteAllBytes(OpenCVCore220, Properties.Resources.opencv_core220);
            if (!File.Exists(OpenCVFeatures2d220)) File.WriteAllBytes(OpenCVFeatures2d220, Properties.Resources.opencv_features2d220);
            if (!File.Exists(OpenCVFFmpeg220)) File.WriteAllBytes(OpenCVFFmpeg220, Properties.Resources.opencv_ffmpeg220);
            if (!File.Exists(OpenCVFlann220)) File.WriteAllBytes(OpenCVFlann220, Properties.Resources.opencv_flann220);
            if (!File.Exists(OpenCVGpu220)) File.WriteAllBytes(OpenCVGpu220, Properties.Resources.opencv_gpu220);
            if (!File.Exists(OpenCVHighGui220)) File.WriteAllBytes(OpenCVHighGui220, Properties.Resources.opencv_highgui220);
            if (!File.Exists(OpenCVImgproc220)) File.WriteAllBytes(OpenCVImgproc220, Properties.Resources.opencv_imgproc220);
            if (!File.Exists(OpenCVLegacy220)) File.WriteAllBytes(OpenCVLegacy220, Properties.Resources.opencv_legacy220);
            if (!File.Exists(OpenCVML220)) File.WriteAllBytes(OpenCVML220, Properties.Resources.opencv_ml220);
            if (!File.Exists(OpenCVObjDetect220)) File.WriteAllBytes(OpenCVObjDetect220, Properties.Resources.opencv_objdetect220);
            if (!File.Exists(OpenCVVideo220)) File.WriteAllBytes(OpenCVVideo220, Properties.Resources.opencv_video220);
            if (!File.Exists(HaarCascadeFrontalFaceDefault)) File.WriteAllText(HaarCascadeFrontalFaceDefault, Properties.Resources.haarcascade_frontalface_default);
        }
    }
}
