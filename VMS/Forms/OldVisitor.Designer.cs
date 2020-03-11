namespace VMS.Forms
{
    partial class OldVisitor
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OldVisitor));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.imageBoxFrameGrabber = new Emgu.CV.UI.ImageBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboBoxDestination = new System.Windows.Forms.ComboBox();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.labelGreetings = new System.Windows.Forms.Label();
            this.panelOverride = new System.Windows.Forms.Panel();
            this.labelOverride = new System.Windows.Forms.Label();
            this.buttonOverride = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonBack = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxFrameGrabber)).BeginInit();
            this.panel2.SuspendLayout();
            this.panelOverride.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 97);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.imageBoxFrameGrabber);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(26, 159);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(420, 375);
            this.panel1.TabIndex = 17;
            // 
            // imageBoxFrameGrabber
            // 
            this.imageBoxFrameGrabber.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.imageBoxFrameGrabber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBoxFrameGrabber.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imageBoxFrameGrabber.Location = new System.Drawing.Point(0, 35);
            this.imageBoxFrameGrabber.Name = "imageBoxFrameGrabber";
            this.imageBoxFrameGrabber.Size = new System.Drawing.Size(420, 340);
            this.imageBoxFrameGrabber.TabIndex = 12;
            this.imageBoxFrameGrabber.TabStop = false;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(420, 35);
            this.label1.TabIndex = 13;
            this.label1.Text = "Face straight to the camera";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.Controls.Add(this.labelGreetings);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panelOverride);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(452, 194);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(319, 340);
            this.panel2.TabIndex = 18;
            // 
            // comboBoxDestination
            // 
            this.comboBoxDestination.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDestination.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxDestination.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.comboBoxDestination.FormattingEnabled = true;
            this.comboBoxDestination.Items.AddRange(new object[] {
            "Destination"});
            this.comboBoxDestination.Location = new System.Drawing.Point(8, 11);
            this.comboBoxDestination.Margin = new System.Windows.Forms.Padding(8);
            this.comboBoxDestination.Name = "comboBoxDestination";
            this.comboBoxDestination.Size = new System.Drawing.Size(303, 29);
            this.comboBoxDestination.TabIndex = 17;
            // 
            // buttonLogin
            // 
            this.buttonLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonLogin.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonLogin.FlatAppearance.BorderColor = System.Drawing.Color.Goldenrod;
            this.buttonLogin.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonLogin.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
            this.buttonLogin.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.buttonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogin.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogin.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.buttonLogin.Location = new System.Drawing.Point(182, 56);
            this.buttonLogin.Margin = new System.Windows.Forms.Padding(8);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(129, 30);
            this.buttonLogin.TabIndex = 22;
            this.buttonLogin.Text = "LOGIN";
            this.buttonLogin.UseVisualStyleBackColor = false;
            this.buttonLogin.Click += new System.EventHandler(this.ButtonLogin_Click);
            // 
            // labelGreetings
            // 
            this.labelGreetings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelGreetings.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGreetings.ForeColor = System.Drawing.Color.MidnightBlue;
            this.labelGreetings.Location = new System.Drawing.Point(0, 147);
            this.labelGreetings.Name = "labelGreetings";
            this.labelGreetings.Size = new System.Drawing.Size(319, 99);
            this.labelGreetings.TabIndex = 18;
            this.labelGreetings.Text = "Welcome";
            this.labelGreetings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelOverride
            // 
            this.panelOverride.AutoSize = true;
            this.panelOverride.Controls.Add(this.labelOverride);
            this.panelOverride.Controls.Add(this.buttonOverride);
            this.panelOverride.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelOverride.Location = new System.Drawing.Point(0, 77);
            this.panelOverride.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.panelOverride.Name = "panelOverride";
            this.panelOverride.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.panelOverride.Size = new System.Drawing.Size(319, 70);
            this.panelOverride.TabIndex = 23;
            this.panelOverride.Visible = false;
            // 
            // labelOverride
            // 
            this.labelOverride.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelOverride.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOverride.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelOverride.Location = new System.Drawing.Point(0, 10);
            this.labelOverride.Name = "labelOverride";
            this.labelOverride.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelOverride.Size = new System.Drawing.Size(319, 30);
            this.labelOverride.TabIndex = 15;
            this.labelOverride.Text = "New user detected: name";
            this.labelOverride.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonOverride
            // 
            this.buttonOverride.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonOverride.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonOverride.FlatAppearance.BorderColor = System.Drawing.Color.Goldenrod;
            this.buttonOverride.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonOverride.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
            this.buttonOverride.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.buttonOverride.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOverride.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOverride.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.buttonOverride.Location = new System.Drawing.Point(0, 40);
            this.buttonOverride.Margin = new System.Windows.Forms.Padding(8);
            this.buttonOverride.Name = "buttonOverride";
            this.buttonOverride.Size = new System.Drawing.Size(319, 30);
            this.buttonOverride.TabIndex = 23;
            this.buttonOverride.Text = "OVERRIDE USER";
            this.buttonOverride.UseVisualStyleBackColor = false;
            this.buttonOverride.Click += new System.EventHandler(this.ButtonOverride_Click);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(319, 77);
            this.label2.TabIndex = 14;
            this.label2.Text = "If the facial recognition did not\r\nrecognized you, please use your\r\nbiometric to " +
    "log in.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonBack
            // 
            this.buttonBack.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonBack.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonBack.FlatAppearance.BorderColor = System.Drawing.Color.Goldenrod;
            this.buttonBack.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonBack.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
            this.buttonBack.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBack.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBack.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.buttonBack.Location = new System.Drawing.Point(26, 108);
            this.buttonBack.Margin = new System.Windows.Forms.Padding(8);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(129, 30);
            this.buttonBack.TabIndex = 23;
            this.buttonBack.Text = "BACK";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.ButtonBack_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.comboBoxDestination);
            this.panel3.Controls.Add(this.buttonLogin);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 246);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(319, 94);
            this.panel3.TabIndex = 24;
            // 
            // OldVisitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.ControlBox = false;
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "OldVisitor";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Isda Best";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxFrameGrabber)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelOverride.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private Emgu.CV.UI.ImageBox imageBoxFrameGrabber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox comboBoxDestination;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelGreetings;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Panel panelOverride;
        private System.Windows.Forms.Label labelOverride;
        private System.Windows.Forms.Button buttonOverride;
        private System.Windows.Forms.Panel panel3;
    }
}