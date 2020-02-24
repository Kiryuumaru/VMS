namespace VMS.Forms
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.buttonClassify = new System.Windows.Forms.Button();
            this.buttonOpenFile = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxFile = new System.Windows.Forms.TextBox();
            this.buttonTrain = new System.Windows.Forms.Button();
            this.textBoxlog = new System.Windows.Forms.TextBox();
            this.buttonClearLog = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "MP4 Files|*.mp4";
            // 
            // buttonClassify
            // 
            this.buttonClassify.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClassify.Location = new System.Drawing.Point(479, 318);
            this.buttonClassify.Name = "buttonClassify";
            this.buttonClassify.Size = new System.Drawing.Size(108, 33);
            this.buttonClassify.TabIndex = 8;
            this.buttonClassify.Text = "Start Process";
            this.buttonClassify.UseVisualStyleBackColor = true;
            this.buttonClassify.Click += new System.EventHandler(this.ButtonClassify_Click);
            // 
            // buttonOpenFile
            // 
            this.buttonOpenFile.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOpenFile.Location = new System.Drawing.Point(390, 318);
            this.buttonOpenFile.Name = "buttonOpenFile";
            this.buttonOpenFile.Size = new System.Drawing.Size(83, 33);
            this.buttonOpenFile.TabIndex = 7;
            this.buttonOpenFile.Text = "Open File";
            this.buttonOpenFile.UseVisualStyleBackColor = true;
            this.buttonOpenFile.Click += new System.EventHandler(this.ButtonOpenFile_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(184, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(295, 37);
            this.label2.TabIndex = 5;
            this.label2.Text = "Classifying and Sizing";
            // 
            // textBoxFile
            // 
            this.textBoxFile.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFile.Location = new System.Drawing.Point(16, 323);
            this.textBoxFile.Multiline = true;
            this.textBoxFile.Name = "textBoxFile";
            this.textBoxFile.Size = new System.Drawing.Size(368, 26);
            this.textBoxFile.TabIndex = 9;
            // 
            // buttonTrain
            // 
            this.buttonTrain.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTrain.Location = new System.Drawing.Point(593, 318);
            this.buttonTrain.Name = "buttonTrain";
            this.buttonTrain.Size = new System.Drawing.Size(78, 33);
            this.buttonTrain.TabIndex = 10;
            this.buttonTrain.Text = "Train";
            this.buttonTrain.UseVisualStyleBackColor = true;
            this.buttonTrain.Click += new System.EventHandler(this.ButtonTrain_Click);
            // 
            // textBoxlog
            // 
            this.textBoxlog.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxlog.Location = new System.Drawing.Point(16, 49);
            this.textBoxlog.Multiline = true;
            this.textBoxlog.Name = "textBoxlog";
            this.textBoxlog.ReadOnly = true;
            this.textBoxlog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxlog.Size = new System.Drawing.Size(655, 260);
            this.textBoxlog.TabIndex = 11;
            // 
            // buttonClearLog
            // 
            this.buttonClearLog.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClearLog.Location = new System.Drawing.Point(593, 16);
            this.buttonClearLog.Name = "buttonClearLog";
            this.buttonClearLog.Size = new System.Drawing.Size(78, 33);
            this.buttonClearLog.TabIndex = 12;
            this.buttonClearLog.Text = "Clear Log";
            this.buttonClearLog.UseVisualStyleBackColor = true;
            this.buttonClearLog.Click += new System.EventHandler(this.ButtonClearLog_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 361);
            this.Controls.Add(this.buttonClearLog);
            this.Controls.Add(this.textBoxlog);
            this.Controls.Add(this.buttonTrain);
            this.Controls.Add(this.buttonClassify);
            this.Controls.Add(this.buttonOpenFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxFile);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Isda Best";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Main_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Main_DragEnter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button buttonClassify;
        private System.Windows.Forms.Button buttonOpenFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxFile;
        private System.Windows.Forms.Button buttonTrain;
        private System.Windows.Forms.TextBox textBoxlog;
        private System.Windows.Forms.Button buttonClearLog;
    }
}