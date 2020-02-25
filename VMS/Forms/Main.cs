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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void ButtonNew_Click(object sender, EventArgs e)
        {
            new NewVisitor().ShowDialog();
        }

        private void ButtonOld_Click(object sender, EventArgs e)
        {
            new OldVisitor().ShowDialog();
        }

        private void ButtonAdmin_Click(object sender, EventArgs e)
        {
            new Admin().ShowDialog();
        }
    }
}
