using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VMS.Services;

namespace VMS.Forms
{
    public partial class BiometricPortSelect : Form
    {
        public BiometricPortSelect()
        {
            InitializeComponent();
            foreach (string port in SerialPort.GetPortNames())
            {
                comboBoxPort.Items.Add(port);
            }
            comboBoxPort.SelectedIndex = 0;
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (comboBoxPort.SelectedIndex == 0)
            {
                MessageBox.Show("Please select port", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                Biometric.Init((string)comboBoxPort.SelectedItem);
                Close();
            }
        }
    }
}
