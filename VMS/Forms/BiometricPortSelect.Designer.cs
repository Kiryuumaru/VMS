namespace VMS.Forms
{
    partial class BiometricPortSelect
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
            this.buttonAdd = new System.Windows.Forms.Button();
            this.comboBoxPort = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonAdd.FlatAppearance.BorderColor = System.Drawing.Color.Goldenrod;
            this.buttonAdd.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonAdd.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
            this.buttonAdd.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdd.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdd.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.buttonAdd.Location = new System.Drawing.Point(17, 62);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(8);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(290, 30);
            this.buttonAdd.TabIndex = 12;
            this.buttonAdd.Text = "SELECT";
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // comboBoxPort
            // 
            this.comboBoxPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPort.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxPort.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.comboBoxPort.FormattingEnabled = true;
            this.comboBoxPort.Items.AddRange(new object[] {
            "Select Port"});
            this.comboBoxPort.Location = new System.Drawing.Point(17, 17);
            this.comboBoxPort.Margin = new System.Windows.Forms.Padding(8);
            this.comboBoxPort.Name = "comboBoxPort";
            this.comboBoxPort.Size = new System.Drawing.Size(291, 29);
            this.comboBoxPort.TabIndex = 18;
            // 
            // BiometricPortSelect
            // 
            this.AcceptButton = this.buttonAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 114);
            this.Controls.Add(this.comboBoxPort);
            this.Controls.Add(this.buttonAdd);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BiometricPortSelect";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Biometric Port";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.ComboBox comboBoxPort;
    }
}