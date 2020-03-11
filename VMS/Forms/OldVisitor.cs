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
        private string userNameOverride = "";
        private readonly User[] users = PartialDB.GetUsers();

        public OldVisitor()
        {
            InitializeComponent();
            foreach (Destination destination in PartialDB.GetDestinations())
            {
                comboBoxDestination.Items.Add(destination.Name);
            }
            comboBoxDestination.SelectedIndex = 0;
            StartCamera();
            StartBiometric();
            ML.FaceRecognition.OnFaceRecognized = label =>
            {
                User user = users.FirstOrDefault(item => item.Id.Equals(label));
                if (user != null)
                {
                    Invoke(new MethodInvoker(delegate
                    {
                        if (userName.Equals(user.Name) || string.IsNullOrEmpty(userName))
                        {
                            labelGreetings.Text = "Welcome," + Environment.NewLine + user.Name + "!";
                            userName = user.Name;
                        }
                        else
                        {
                            labelOverride.Text = "New user detected: " + user.Name;
                            userNameOverride = user.Name;
                            panelOverride.Visible = true;
                        }
                    }));
                }
            };
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

        private void StartBiometric()
        {
            Biometric.Get(id =>
            {
                User user = users.FirstOrDefault(item => item.HasFingerId(Convert.ToInt32(id)));
                if (user != null)
                {
                    if (userName.Equals(user.Name) || string.IsNullOrEmpty(userName))
                    {
                        labelGreetings.Text = "Welcome," + Environment.NewLine + user.Name + "!";
                        userName = user.Name;
                    }
                    else
                    {
                        labelOverride.Text = "New user detected: " + user.Name;
                        userNameOverride = user.Name;
                        panelOverride.Visible = true;
                    }
                }
                StartBiometric();
            });
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(userName))
            {
                MessageBox.Show("No recognized user", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (comboBoxDestination.SelectedIndex == 0)
            {
                MessageBox.Show("Please select destination", "No Destination", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Destination destination = PartialDB.GetDestinations().FirstOrDefault(
                    item => item.Name.Equals((string)comboBoxDestination.SelectedItem));
                if (destination != null)
                {
                    destination.VisitCount++;
                    PartialDB.SetDestination(destination);
                    PartialDB.AddHistory(new History(userName, destination.Name, DateTime.Now));
                }
                MessageBox.Show("Successfully logged in", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }

        private void ButtonOverride_Click(object sender, EventArgs e)
        {
            Invoke(new MethodInvoker(delegate
            {
                labelGreetings.Text = "Welcome," + Environment.NewLine + userNameOverride + "!";
                userName = userNameOverride;
                panelOverride.Visible = false;
            }));
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
