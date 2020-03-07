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
    public partial class AdminHistory : Form
    {
        public AdminHistory()
        {
            InitializeComponent();
            foreach (History hist in PartialDB.GetHistory())
            {
                dataGridView.Rows.Add(hist.UserName, hist.Destination, hist.DateTime.ToString("MM/dd/yyyy HH:mm:ss"));
            }
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to clear history?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                PartialDB.ClearHistory();
                dataGridView.Rows.Clear();
                foreach (History hist in PartialDB.GetHistory())
                {
                    dataGridView.Rows.Add(hist.UserName, hist.Destination, hist.DateTime.ToString("MM/dd/yyyy HH:mm:ss"));
                }
            }
        }
    }
}
