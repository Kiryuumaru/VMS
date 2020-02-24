namespace VMS.Forms
{
    partial class Trainer
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
            this.buttonFish2 = new System.Windows.Forms.Button();
            this.buttonFish3 = new System.Windows.Forms.Button();
            this.buttonFish1 = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.buttonPaste = new System.Windows.Forms.Button();
            this.buttonTest = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonBuildModel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonFish2
            // 
            this.buttonFish2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.buttonFish2.Location = new System.Drawing.Point(148, 454);
            this.buttonFish2.Name = "buttonFish2";
            this.buttonFish2.Size = new System.Drawing.Size(129, 33);
            this.buttonFish2.TabIndex = 1;
            this.buttonFish2.Text = "Rabbitfish (Kitong)";
            this.buttonFish2.UseVisualStyleBackColor = true;
            this.buttonFish2.Click += new System.EventHandler(this.ButtonFish2_Click);
            // 
            // buttonFish3
            // 
            this.buttonFish3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.buttonFish3.Location = new System.Drawing.Point(283, 454);
            this.buttonFish3.Name = "buttonFish3";
            this.buttonFish3.Size = new System.Drawing.Size(129, 33);
            this.buttonFish3.TabIndex = 2;
            this.buttonFish3.Text = "Grouper (lapu-lapu)";
            this.buttonFish3.UseVisualStyleBackColor = true;
            this.buttonFish3.Click += new System.EventHandler(this.ButtonFish3_Click);
            // 
            // buttonFish1
            // 
            this.buttonFish1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.buttonFish1.Location = new System.Drawing.Point(12, 454);
            this.buttonFish1.Name = "buttonFish1";
            this.buttonFish1.Size = new System.Drawing.Size(129, 33);
            this.buttonFish1.TabIndex = 3;
            this.buttonFish1.Text = "Parrot Fish (molmol)";
            this.buttonFish1.UseVisualStyleBackColor = true;
            this.buttonFish1.Click += new System.EventHandler(this.ButtonFish1_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox.Location = new System.Drawing.Point(12, 36);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(400, 400);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 4;
            this.pictureBox.TabStop = false;
            // 
            // buttonPaste
            // 
            this.buttonPaste.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPaste.Location = new System.Drawing.Point(432, 175);
            this.buttonPaste.Name = "buttonPaste";
            this.buttonPaste.Size = new System.Drawing.Size(141, 33);
            this.buttonPaste.TabIndex = 5;
            this.buttonPaste.Text = "Paste from Clipboard";
            this.buttonPaste.UseVisualStyleBackColor = true;
            this.buttonPaste.Click += new System.EventHandler(this.ButtonPaste_Click);
            // 
            // buttonTest
            // 
            this.buttonTest.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.buttonTest.Location = new System.Drawing.Point(432, 227);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(141, 33);
            this.buttonTest.TabIndex = 6;
            this.buttonTest.Text = "Try Classify";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.ButtonTest_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.buttonClear.Location = new System.Drawing.Point(432, 279);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(141, 33);
            this.buttonClear.TabIndex = 7;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.ButtonClear_Click);
            // 
            // buttonBuildModel
            // 
            this.buttonBuildModel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.buttonBuildModel.Location = new System.Drawing.Point(432, 36);
            this.buttonBuildModel.Name = "buttonBuildModel";
            this.buttonBuildModel.Size = new System.Drawing.Size(141, 33);
            this.buttonBuildModel.TabIndex = 8;
            this.buttonBuildModel.Text = "Build Model";
            this.buttonBuildModel.UseVisualStyleBackColor = true;
            this.buttonBuildModel.Click += new System.EventHandler(this.ButtonBuildModel_Click);
            // 
            // Trainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 503);
            this.Controls.Add(this.buttonBuildModel);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonTest);
            this.Controls.Add(this.buttonPaste);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.buttonFish1);
            this.Controls.Add(this.buttonFish3);
            this.Controls.Add(this.buttonFish2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Trainer";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Trainer";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Trainer_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Trainer_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonFish2;
        private System.Windows.Forms.Button buttonFish3;
        private System.Windows.Forms.Button buttonFish1;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button buttonPaste;
        private System.Windows.Forms.Button buttonTest;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonBuildModel;
    }
}