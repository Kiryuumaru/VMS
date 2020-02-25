using VMS.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VMS.Forms
{
    public partial class OldVisitor : Form
    {
        private string userName = "";

        public OldVisitor()
        {
            InitializeComponent();
            foreach (Destination destination in PartialDB.GetDestinations())
            {
                comboBoxDestination.Items.Add(destination.Name);
            }
            comboBoxDestination.SelectedIndex = 0;
            StartCamera();
            ML.FaceRecognition.OnFaceRecognized = label =>
            {
                labelGreetings.Text = "Welcome," + Environment.NewLine + label + "!";
                userName = label;
            };
            ML.FaceRecognition.ShowLabel = false;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            ML.FaceRecognition.Stop();
            base.OnClosing(e);
        }

        private void StartCamera()
        {
            Task.Run(delegate
            {
                ML.FaceRecognition.Init();
                Invoke(new MethodInvoker(delegate
                {
                    ML.FaceRecognition.Start(imageBoxFrameGrabber);
                }));
            });
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(userName))
            {
                MessageBox.Show("No recognized user", "Invalid", MessageBoxButtons.OK);
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
                MessageBox.Show("Successfully logged in", "Success", MessageBoxButtons.OK);
                Close();
            }
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
