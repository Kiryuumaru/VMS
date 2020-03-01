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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
            textboxPassword.Select();
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textboxPassword.Text))
            {
                MessageBox.Show("Please enter password", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textboxPassword.Text = "";
                textboxPassword.Select();
            }
            else if (!PartialDB.TryPassword(textboxPassword.Text))
            {
                MessageBox.Show("Please enter correct password", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textboxPassword.Text = "";
                textboxPassword.Select();
            }
            else
            {
                new AdminDashboard().ShowDialog();
                Close();
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
