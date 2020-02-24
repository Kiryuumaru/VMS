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
        private string path;
        protected bool validData;

        public Main()
        {
            InitializeComponent();
            AllowDrop = true;
            Task.Run(delegate
            {
                ML.Init(Log);
            });
        }

        private void Log(string line)
        {
            line = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + " " + line;
            try
            {
                if (!string.IsNullOrEmpty(textBoxlog.Text)) textBoxlog.AppendText(Environment.NewLine);
                textBoxlog.AppendText(line);
            }
            catch
            {
                try
                {
                    Invoke(new MethodInvoker(delegate
                    {
                        if (!string.IsNullOrEmpty(textBoxlog.Text)) textBoxlog.AppendText(Environment.NewLine);
                        textBoxlog.AppendText(line);
                    }));
                }
                catch { }
            }
        }

        private void ButtonTrain_Click(object sender, EventArgs e)
        {
            new Trainer(Log).Show();
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
                        if (ext == ".mp4")
                        {
                            ret = true;
                        }
                    }
                }
            }
            return ret;
        }

        private void Main_DragEnter(object sender, DragEventArgs e)
        {
            validData = GetFilename(out string filename, e);
            if (validData)
            {
                path = filename;
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void Main_DragDrop(object sender, DragEventArgs e)
        {
            if (validData)
            {
                textBoxFile.Text = path;
            }
        }

        private void ButtonOpenFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            textBoxFile.Text = openFileDialog1.FileName;
        }

        private void ButtonClassify_Click(object sender, EventArgs e)
        {
            Log("ML: Classifying");
        }

        private void ButtonClearLog_Click(object sender, EventArgs e)
        {
            textBoxlog.Text = "";
        }
    }
}
