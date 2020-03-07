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

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            BiometricVerify();
        }

        private bool BiometricVerify()
        {
            if (string.IsNullOrEmpty(Biometric.Port))
            {
                new BiometricPortSelect().ShowDialog();
            }
            return !string.IsNullOrEmpty(Biometric.Port);
        }

        private void ButtonNew_Click(object sender, EventArgs e)
        {
            if (BiometricVerify()) new NewVisitor().ShowDialog();
        }

        private void ButtonOld_Click(object sender, EventArgs e)
        {
            if (BiometricVerify()) new OldVisitor().ShowDialog();
        }

        private void ButtonAdmin_Click(object sender, EventArgs e)
        {
            if (BiometricVerify()) new Admin().ShowDialog();
            //PartialDB.AddHistory(new History("Clynt daw", "LRC", DateTime.Now));
            //new Admin().ShowDialog();
        }
    }
}
