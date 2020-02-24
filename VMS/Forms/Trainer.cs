using VMS.Services;
using VMS.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VMS.Forms
{
    public partial class Trainer : Form
    {
        private Action<string> logger;
        private string path;
        protected bool validData;
        protected Image image;
        protected Thread getImageThread;

        public Trainer(Action<string> _logger)
        {
            InitializeComponent();
            logger = _logger;
            AllowDrop = true;
        }

        protected void LoadImage()
        {
            image = new Bitmap(path);
        }

        private bool GetFilename(out string filename, DragEventArgs e)
        {
            bool ret = false;
            filename = string.Empty;
            if ((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
            {
                if (e.Data.GetData("FileDrop") is Array data)
                {
                    if ((data.Length == 1) && (data.GetValue(0) is string))
                    {
                        filename = ((string[])data)[0];
                        string ext = Path.GetExtension(filename).ToLower();
                        if ((ext == ".jpg") || (ext == ".png"))
                        {
                            ret = true;
                        }
                    }
                }
            }
            return ret;
        }

        private void Trainer_DragEnter(object sender, DragEventArgs e)
        {
            validData = GetFilename(out string filename, e);
            if (validData)
            {
                path = filename;
                getImageThread = new Thread(new ThreadStart(LoadImage));
                getImageThread.Start();
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void Trainer_DragDrop(object sender, DragEventArgs e)
        {
            if (validData)
            {
                while (getImageThread.IsAlive)
                {
                    Application.DoEvents();
                    Thread.Sleep(0);
                }
                pictureBox.Image = image;
                image = null;
            }
        }

        private void ButtonPaste_Click(object sender, EventArgs e)
        {
            pictureBox.Image = Clipboard.GetImage();
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            pictureBox.Image = null;
        }

        private void ButtonFish1_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image == null) return;
            DialogResult result = MessageBox.Show("Are you sure to train this image as Parrot Fish (molmol)?", "Confirmation", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                Task.Run(delegate
                {
                    ML.AddDataset(pictureBox.Image, "molmol", logger);
                });
            }
        }

        private void ButtonFish2_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image == null) return;
            DialogResult result = MessageBox.Show("Are you sure to train this image as Rabbitfish (Kitong)?", "Confirmation", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                Task.Run(delegate
                {
                    ML.AddDataset(pictureBox.Image, "kitong", logger);
                });
            }
        }

        private void ButtonFish3_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image == null) return;
            DialogResult result = MessageBox.Show("Are you sure to train this image as Grouper (lapu-lapu)?", "Confirmation", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                Task.Run(delegate
                {
                    ML.AddDataset(pictureBox.Image, "lapu", logger);
                });
            }
        }

        private void ButtonTest_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image == null)
            {
                MessageBox.Show("Picture is empty", "Error", MessageBoxButtons.OK);
            }
            else if (!ML.IsClassifyReady)
            {
                MessageBox.Show("Classification model is not ready", "Error", MessageBoxButtons.OK);
            }
            else
            {
                Task.Run(delegate
                {
                    ImagePrediction prediction = ML.ClassifySingleImage(pictureBox.Image, logger);
                    if (prediction != null)
                    {
                        Invoke(new MethodInvoker(delegate
                        {
                            MessageBox.Show(
                                "Identified as \"" + prediction.PredictedLabelValue + "\" " +
                                "with score " + (prediction.Score.Max() * 100).ToString("##.00"),
                                "Result", MessageBoxButtons.OK);
                        }));
                    }
                });
            }
        }

        private void ButtonBuildModel_Click(object sender, EventArgs e)
        {
            Task.Run(delegate
            {
                ML.GenerateModel(logger);
            });
        }
    }
}
