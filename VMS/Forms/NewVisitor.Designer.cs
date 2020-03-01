namespace VMS.Forms
{
    partial class NewVisitor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewVisitor));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.imageBoxFrameGrabber = new Emgu.CV.UI.ImageBox();
            this.labelIndicator = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonScanBioRight = new System.Windows.Forms.Button();
            this.labelFingerRight = new System.Windows.Forms.Label();
            this.labelFingerLeft = new System.Windows.Forms.Label();
            this.buttonScanBioLeft = new System.Windows.Forms.Button();
            this.comboBoxDestination = new System.Windows.Forms.ComboBox();
            this.comboBoxGender = new System.Windows.Forms.ComboBox();
            this.textboxContactNumber = new VMS.Controls.WaterMarkTextBox();
            this.textboxName = new VMS.Controls.WaterMarkTextBox();
            this.buttonCapture = new System.Windows.Forms.Button();
            this.buttonRegister = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxFrameGrabber)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
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
            // imageBoxFrameGrabber
            // 
            this.imageBoxFrameGrabber.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.imageBoxFrameGrabber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBoxFrameGrabber.Location = new System.Drawing.Point(0, 35);
            this.imageBoxFrameGrabber.Name = "imageBoxFrameGrabber";
            this.imageBoxFrameGrabber.Size = new System.Drawing.Size(420, 340);
            this.imageBoxFrameGrabber.TabIndex = 12;
            this.imageBoxFrameGrabber.TabStop = false;
            // 
            // labelIndicator
            // 
            this.labelIndicator.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelIndicator.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIndicator.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.labelIndicator.Location = new System.Drawing.Point(0, 0);
            this.labelIndicator.Name = "labelIndicator";
            this.labelIndicator.Size = new System.Drawing.Size(420, 35);
            this.labelIndicator.TabIndex = 13;
            this.labelIndicator.Text = "Face straight to the camera";
            this.labelIndicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(319, 35);
            this.label2.TabIndex = 14;
            this.label2.Text = "Please fill the necessary information";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.imageBoxFrameGrabber);
            this.panel1.Controls.Add(this.labelIndicator);
            this.panel1.Location = new System.Drawing.Point(25, 159);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(420, 375);
            this.panel1.TabIndex = 16;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.Controls.Add(this.buttonScanBioRight);
            this.panel2.Controls.Add(this.labelFingerRight);
            this.panel2.Controls.Add(this.labelFingerLeft);
            this.panel2.Controls.Add(this.buttonScanBioLeft);
            this.panel2.Controls.Add(this.comboBoxDestination);
            this.panel2.Controls.Add(this.comboBoxGender);
            this.panel2.Controls.Add(this.textboxContactNumber);
            this.panel2.Controls.Add(this.textboxName);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(451, 159);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(319, 375);
            this.panel2.TabIndex = 17;
            // 
            // buttonScanBioRight
            // 
            this.buttonScanBioRight.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonScanBioRight.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonScanBioRight.FlatAppearance.BorderColor = System.Drawing.Color.Goldenrod;
            this.buttonScanBioRight.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonScanBioRight.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
            this.buttonScanBioRight.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.buttonScanBioRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonScanBioRight.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonScanBioRight.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.buttonScanBioRight.Location = new System.Drawing.Point(167, 337);
            this.buttonScanBioRight.Margin = new System.Windows.Forms.Padding(8);
            this.buttonScanBioRight.Name = "buttonScanBioRight";
            this.buttonScanBioRight.Size = new System.Drawing.Size(144, 30);
            this.buttonScanBioRight.TabIndex = 25;
            this.buttonScanBioRight.Text = "SCAN RIGHT";
            this.buttonScanBioRight.UseVisualStyleBackColor = false;
            this.buttonScanBioRight.Click += new System.EventHandler(this.ButtonScanBioRight_Click);
            // 
            // labelFingerRight
            // 
            this.labelFingerRight.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFingerRight.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.labelFingerRight.Location = new System.Drawing.Point(163, 170);
            this.labelFingerRight.Name = "labelFingerRight";
            this.labelFingerRight.Size = new System.Drawing.Size(148, 159);
            this.labelFingerRight.TabIndex = 24;
            this.labelFingerRight.Text = "Right fingerprint not scanned";
            this.labelFingerRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelFingerLeft
            // 
            this.labelFingerLeft.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFingerLeft.ForeColor = System.Drawing.Color.DarkGray;
            this.labelFingerLeft.Location = new System.Drawing.Point(8, 170);
            this.labelFingerLeft.Name = "labelFingerLeft";
            this.labelFingerLeft.Size = new System.Drawing.Size(148, 159);
            this.labelFingerLeft.TabIndex = 23;
            this.labelFingerLeft.Text = "Left fingerprint not scanned";
            this.labelFingerLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonScanBioLeft
            // 
            this.buttonScanBioLeft.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonScanBioLeft.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonScanBioLeft.FlatAppearance.BorderColor = System.Drawing.Color.Goldenrod;
            this.buttonScanBioLeft.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonScanBioLeft.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
            this.buttonScanBioLeft.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.buttonScanBioLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonScanBioLeft.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonScanBioLeft.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.buttonScanBioLeft.Location = new System.Drawing.Point(8, 337);
            this.buttonScanBioLeft.Margin = new System.Windows.Forms.Padding(8);
            this.buttonScanBioLeft.Name = "buttonScanBioLeft";
            this.buttonScanBioLeft.Size = new System.Drawing.Size(148, 30);
            this.buttonScanBioLeft.TabIndex = 22;
            this.buttonScanBioLeft.Text = "SCAN LEFT";
            this.buttonScanBioLeft.UseVisualStyleBackColor = false;
            this.buttonScanBioLeft.Click += new System.EventHandler(this.ButtonScanBioLeft_Click);
            // 
            // comboBoxDestination
            // 
            this.comboBoxDestination.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDestination.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxDestination.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.comboBoxDestination.FormattingEnabled = true;
            this.comboBoxDestination.Items.AddRange(new object[] {
            "Destination"});
            this.comboBoxDestination.Location = new System.Drawing.Point(8, 133);
            this.comboBoxDestination.Margin = new System.Windows.Forms.Padding(8);
            this.comboBoxDestination.Name = "comboBoxDestination";
            this.comboBoxDestination.Size = new System.Drawing.Size(303, 29);
            this.comboBoxDestination.TabIndex = 17;
            // 
            // comboBoxGender
            // 
            this.comboBoxGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGender.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxGender.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.comboBoxGender.FormattingEnabled = true;
            this.comboBoxGender.Items.AddRange(new object[] {
            "Gender",
            "Male",
            "Female"});
            this.comboBoxGender.Location = new System.Drawing.Point(229, 88);
            this.comboBoxGender.Margin = new System.Windows.Forms.Padding(8);
            this.comboBoxGender.Name = "comboBoxGender";
            this.comboBoxGender.Size = new System.Drawing.Size(82, 29);
            this.comboBoxGender.TabIndex = 16;
            // 
            // textboxContactNumber
            // 
            this.textboxContactNumber.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.textboxContactNumber.Location = new System.Drawing.Point(8, 88);
            this.textboxContactNumber.Margin = new System.Windows.Forms.Padding(8);
            this.textboxContactNumber.Name = "textboxContactNumber";
            this.textboxContactNumber.Size = new System.Drawing.Size(210, 29);
            this.textboxContactNumber.TabIndex = 2;
            this.textboxContactNumber.WaterMarkColor = System.Drawing.Color.Gray;
            this.textboxContactNumber.WaterMarkText = "Contact number";
            // 
            // textboxName
            // 
            this.textboxName.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.textboxName.Location = new System.Drawing.Point(8, 43);
            this.textboxName.Margin = new System.Windows.Forms.Padding(8);
            this.textboxName.Name = "textboxName";
            this.textboxName.Size = new System.Drawing.Size(303, 29);
            this.textboxName.TabIndex = 1;
            this.textboxName.WaterMarkColor = System.Drawing.Color.Gray;
            this.textboxName.WaterMarkText = "Name";
            // 
            // buttonCapture
            // 
            this.buttonCapture.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonCapture.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonCapture.FlatAppearance.BorderColor = System.Drawing.Color.Goldenrod;
            this.buttonCapture.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonCapture.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
            this.buttonCapture.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.buttonCapture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCapture.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCapture.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.buttonCapture.Location = new System.Drawing.Point(246, 545);
            this.buttonCapture.Margin = new System.Windows.Forms.Padding(8);
            this.buttonCapture.Name = "buttonCapture";
            this.buttonCapture.Size = new System.Drawing.Size(199, 30);
            this.buttonCapture.TabIndex = 18;
            this.buttonCapture.Text = "TAKE PICTURE";
            this.buttonCapture.UseVisualStyleBackColor = false;
            this.buttonCapture.Click += new System.EventHandler(this.ButtonCapture_Click);
            // 
            // buttonRegister
            // 
            this.buttonRegister.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonRegister.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonRegister.FlatAppearance.BorderColor = System.Drawing.Color.Goldenrod;
            this.buttonRegister.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonRegister.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
            this.buttonRegister.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.buttonRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRegister.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRegister.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.buttonRegister.Location = new System.Drawing.Point(641, 545);
            this.buttonRegister.Margin = new System.Windows.Forms.Padding(8);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(129, 30);
            this.buttonRegister.TabIndex = 21;
            this.buttonRegister.Text = "REGISTER";
            this.buttonRegister.UseVisualStyleBackColor = false;
            this.buttonRegister.Click += new System.EventHandler(this.ButtonRegister_Click);
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
            this.buttonBack.Location = new System.Drawing.Point(25, 108);
            this.buttonBack.Margin = new System.Windows.Forms.Padding(8);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(129, 30);
            this.buttonBack.TabIndex = 22;
            this.buttonBack.Text = "BACK";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.ButtonBack_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonReset.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonReset.FlatAppearance.BorderColor = System.Drawing.Color.Goldenrod;
            this.buttonReset.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonReset.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
            this.buttonReset.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.buttonReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReset.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReset.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.buttonReset.Location = new System.Drawing.Point(25, 545);
            this.buttonReset.Margin = new System.Windows.Forms.Padding(8);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(205, 30);
            this.buttonReset.TabIndex = 23;
            this.buttonReset.Text = "RESET";
            this.buttonReset.UseVisualStyleBackColor = false;
            this.buttonReset.Click += new System.EventHandler(this.ButtonReset_Click);
            // 
            // NewVisitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.ControlBox = false;
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonRegister);
            this.Controls.Add(this.buttonCapture);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "NewVisitor";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Isda Best";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxFrameGrabber)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private Emgu.CV.UI.ImageBox imageBoxFrameGrabber;
        private System.Windows.Forms.Label labelIndicator;
        private System.Windows.Forms.Label label2;
        private Controls.WaterMarkTextBox textboxName;
        private Controls.WaterMarkTextBox textboxContactNumber;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox comboBoxGender;
        private System.Windows.Forms.ComboBox comboBoxDestination;
        private System.Windows.Forms.Button buttonCapture;
        private System.Windows.Forms.Button buttonRegister;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonScanBioLeft;
        private System.Windows.Forms.Label labelFingerRight;
        private System.Windows.Forms.Label labelFingerLeft;
        private System.Windows.Forms.Button buttonScanBioRight;
    }
}