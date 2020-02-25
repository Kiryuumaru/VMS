using VMS.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;

namespace VMS.Forms
{
    public partial class NewVisitor : Form
    {
        private readonly List<Image<Gray, byte>> capturedImages = new List<Image<Gray, byte>>();

        public NewVisitor()
        {
            InitializeComponent();
            foreach (Destination destination in PartialDB.GetDestinations())
            {
                comboBoxDestination.Items.Add(destination.Name);
            }
            comboBoxGender.SelectedIndex = 0;
            comboBoxDestination.SelectedIndex = 0;
            StartCamera();
            labelIndicator.Text = "Face straight to the camera (0/3)";
            ML.FaceRecognition.ShowLabel = false;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            ML.FaceRecognition.Stop();
            base.OnClosing(e);
        }

        private void StartCamera()
        {
            if (ML.FaceRecognition.Started) return;
            Task.Run(delegate
            {
                ML.FaceRecognition.Init();
                Invoke(new MethodInvoker(delegate
                {
                    ML.FaceRecognition.Start(imageBoxFrameGrabber);
                }));
            });
        }

        private void ButtonCapture_Click(object sender, EventArgs e)
        {
            ((Button)sender).Enabled = false;
            Task.Run(delegate
            {
                if (ML.FaceRecognition.TryCaptureDetected(out Image<Gray, byte> image))
                {
                    capturedImages.Add(image);
                    if (capturedImages.Count >= 3)
                    {
                        ML.FaceRecognition.Stop();
                        Invoke(new MethodInvoker(delegate
                        {
                            ((Button)sender).Text = "COMPLETE";
                        }));
                    }
                    else
                    {
                        Invoke(new MethodInvoker(delegate
                        {
                            ((Button)sender).Enabled = true;
                        }));
                    }
                    Invoke(new MethodInvoker(delegate
                    {
                        labelIndicator.Text = "Face straight to the camera (" + capturedImages.Count + "/3)";
                    }));
                    MessageBox.Show("Face successfully detected", "Success", MessageBoxButtons.OK);
                }
                else
                {
                    Invoke(new MethodInvoker(delegate
                    {
                        ((Button)sender).Text = "TAKE PICTURE (FAILED)";
                        ((Button)sender).Enabled = true;
                    }));
                }
            });
        }

        private void ButtonRegister_Click(object sender, EventArgs e)
        {
            if (capturedImages.Count < 3)
            {
                MessageBox.Show("Please take picture", "Incomplete Picture", MessageBoxButtons.OK);
            }
            else if (string.IsNullOrEmpty(textboxName.Text))
            {
                MessageBox.Show("Please input name", "No Name", MessageBoxButtons.OK);
            }
            else if (comboBoxDestination.SelectedIndex == 0)
            {
                MessageBox.Show("Please select destination", "No Destination", MessageBoxButtons.OK);
            }
            else
            {
                Destination destination = PartialDB.GetDestinations().FirstOrDefault(
                    item => item.Name.Equals((string)comboBoxDestination.SelectedItem));
                if (destination != null)
                {
                    destination.VisitCount++;
                    PartialDB.SetDestination(destination);
                }
                foreach (var img in capturedImages)
                {
                    ML.FaceRecognition.AddDataset(img, textboxName.Text);
                }
                MessageBox.Show("User registered successfully", "Registered", MessageBoxButtons.OK);
                Close();
            }
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            capturedImages.Clear();
            StartCamera();
            buttonCapture.Text = "TAKE PICTURE";
            buttonCapture.Enabled = true;
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
