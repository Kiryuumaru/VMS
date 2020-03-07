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
using System.Drawing;

namespace VMS.Forms
{
    public partial class NewVisitor : Form
    {
        private readonly List<Image<Gray, byte>> capturedImages = new List<Image<Gray, byte>>();
        private readonly string nextId = Extension.Helpers.GenerateUID();

        private int leftId = -1;
        private int rightId = -1;

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
            Biometric.Standby();
            base.OnClosing(e);
        }

        private void StartCamera()
        {
            try
            {
                if (ML.FaceRecognition.Started) return;
                ML.FaceRecognition.Init();
                ML.FaceRecognition.Start(imageBoxFrameGrabber);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                            labelIndicator.ForeColor = Color.Green;
                        }));
                    }
                    else
                    {
                        Invoke(new MethodInvoker(delegate
                        {
                            labelIndicator.ForeColor = Color.DarkGray;
                        }));
                    }
                    Invoke(new MethodInvoker(delegate
                    {
                        labelIndicator.Text = "Face straight to the camera (" + capturedImages.Count + "/3)";
                        ((Button)sender).Enabled = true;
                    }));
                    MessageBox.Show("Face successfully detected", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Invoke(new MethodInvoker(delegate
                    {
                        MessageBox.Show("Face must be visible to camera", "Face Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        ((Button)sender).Enabled = true;
                    }));
                }
            });
        }

        private void ButtonScanBioLeft_Click(object sender, EventArgs e)
        {
            if (rightId == -1)
            {
                labelFingerRight.Text = "Right fingerprint not scanned";
                labelFingerRight.ForeColor = Color.DarkGray;
            }
            leftId = -1;
            int id = PartialDB.GetNextLeftFingerprintId();
            labelFingerLeft.Text = "Left fingerprint waiting to scan";
            labelFingerLeft.ForeColor = Color.DarkGray;
            Biometric.Set(id,
                delegate
                {
                    Invoke(new MethodInvoker(delegate
                    {
                        labelFingerLeft.Text = "Remove left finger";
                        labelFingerLeft.ForeColor = Color.DarkGray;
                    }));
                },
                delegate
                {
                    Invoke(new MethodInvoker(delegate
                    {
                        labelFingerLeft.Text = "Place left finger again to confirm";
                        labelFingerLeft.ForeColor = Color.DarkGray;
                    }));
                },
                delegate
                {
                    leftId = id;
                    Invoke(new MethodInvoker(delegate
                    {
                        labelFingerLeft.Text = "Left fingerprint scanned";
                        labelFingerLeft.ForeColor = Color.Green;
                    }));
                },
                delegate
                {
                    Invoke(new MethodInvoker(delegate
                    {
                        labelFingerLeft.Text = "Left fingerprint scan failed";
                        labelFingerLeft.ForeColor = Color.DarkGray;
                    }));
                });
        }

        private void ButtonScanBioRight_Click(object sender, EventArgs e)
        {
            if (leftId == -1)
            {
                labelFingerLeft.Text = "Left fingerprint not scanned";
                labelFingerLeft.ForeColor = Color.DarkGray;
            }
            rightId = -1;
            int id = PartialDB.GetNextRightFingerprintId();
            labelFingerRight.Text = "Right fingerprint waiting to scan";
            labelFingerRight.ForeColor = Color.DarkGray;
            Biometric.Set(id,
                delegate
                {
                    Invoke(new MethodInvoker(delegate
                    {
                        labelFingerRight.Text = "Remove right finger";
                        labelFingerRight.ForeColor = Color.DarkGray;
                    }));
                },
                delegate
                {
                    Invoke(new MethodInvoker(delegate
                    {
                        labelFingerRight.Text = "Place right finger again to confirm";
                        labelFingerRight.ForeColor = Color.DarkGray;
                    }));
                },
                delegate
                {
                    rightId = id;
                    Invoke(new MethodInvoker(delegate
                    {
                        labelFingerRight.Text = "Right fingerprint scanned";
                        labelFingerRight.ForeColor = Color.Green;
                    }));
                },
                delegate
                {
                    Invoke(new MethodInvoker(delegate
                    {
                        labelFingerRight.Text = "Right fingerprint scan failed";
                        labelFingerRight.ForeColor = Color.DarkGray;
                    }));
                });
        }

        private void ButtonRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textboxName.Text))
            {
                MessageBox.Show("Please input name", "No Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (string.IsNullOrEmpty(textboxContactNumber.Text))
            {
                MessageBox.Show("Please input contact number", "No Contact Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (!long.TryParse(textboxContactNumber.Text, out long contNum))
            {
                MessageBox.Show("Please input valid contact number", "Invalid Contact Number", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (comboBoxGender.SelectedIndex == 0)
            {
                MessageBox.Show("Please select gender", "No Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (comboBoxDestination.SelectedIndex == 0)
            {
                MessageBox.Show("Please select destination", "No Destination", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (capturedImages.Count < 3)
            {
                MessageBox.Show("Please take picture", "Incomplete Picture", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (leftId == -1)
            {
                MessageBox.Show("Please scan left fingerprint", "No Left Fingerprint", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (rightId == -1)
            {
                MessageBox.Show("Please scan right fingerprint", "No Right Fingerprint", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Destination destination = PartialDB.GetDestinations().FirstOrDefault(
                    item => item.Name.Equals((string)comboBoxDestination.SelectedItem));
                if (destination != null)
                {
                    destination.VisitCount++;
                    PartialDB.SetDestination(destination);
                    PartialDB.AddHistory(new History(textboxName.Text, destination.Name, DateTime.Now));
                }
                foreach (var img in capturedImages)
                {
                    ML.FaceRecognition.AddDataset(img, nextId.ToString());
                }
                PartialDB.SetUser(new User(
                    nextId,
                    textboxName.Text,
                    (string)comboBoxGender.SelectedItem,
                    Convert.ToInt64(textboxContactNumber.Text),
                    leftId,
                    rightId));
                MessageBox.Show("User registered successfully", "Registered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            capturedImages.Clear();
            StartCamera();
            buttonCapture.Text = "TAKE PICTURE";
            buttonCapture.Enabled = true;
            labelIndicator.ForeColor = Color.DarkGray;
            labelIndicator.Text = "Face straight to the camera (" + capturedImages.Count + "/3)";
            leftId = -1;
            rightId = -1;
            labelFingerRight.Text = "Right fingerprint not scanned";
            labelFingerRight.ForeColor = Color.DarkGray;
            labelFingerLeft.Text = "Left fingerprint not scanned";
            labelFingerLeft.ForeColor = Color.DarkGray;
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
