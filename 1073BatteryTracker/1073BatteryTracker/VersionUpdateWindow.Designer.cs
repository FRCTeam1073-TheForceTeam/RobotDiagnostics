namespace _1073BatteryTracker
{
    partial class VersionUpdateWindow
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
            this.NewVersionAvailableTextBox = new System.Windows.Forms.Label();
            this.newVersionInfoRTB = new System.Windows.Forms.RichTextBox();
            this.updateNowText = new System.Windows.Forms.Label();
            this.CancelButton = new System.Windows.Forms.Button();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NewVersionAvailableTextBox
            // 
            this.NewVersionAvailableTextBox.AutoSize = true;
            this.NewVersionAvailableTextBox.Location = new System.Drawing.Point(12, 9);
            this.NewVersionAvailableTextBox.Name = "NewVersionAvailableTextBox";
            this.NewVersionAvailableTextBox.Size = new System.Drawing.Size(135, 13);
            this.NewVersionAvailableTextBox.TabIndex = 0;
            this.NewVersionAvailableTextBox.Text = "A new version is available: ";
            // 
            // newVersionInfoRTB
            // 
            this.newVersionInfoRTB.Location = new System.Drawing.Point(9, 25);
            this.newVersionInfoRTB.Name = "newVersionInfoRTB";
            this.newVersionInfoRTB.ReadOnly = true;
            this.newVersionInfoRTB.Size = new System.Drawing.Size(263, 153);
            this.newVersionInfoRTB.TabIndex = 1;
            this.newVersionInfoRTB.Text = "";
            // 
            // updateNowText
            // 
            this.updateNowText.AutoSize = true;
            this.updateNowText.Location = new System.Drawing.Point(58, 181);
            this.updateNowText.Name = "updateNowText";
            this.updateNowText.Size = new System.Drawing.Size(156, 13);
            this.updateNowText.TabIndex = 2;
            this.updateNowText.Text = "Would you like to update Now?";
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(9, 198);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 3;
            this.CancelButton.Text = "No.";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // UpdateButton
            // 
            this.UpdateButton.Location = new System.Drawing.Point(197, 198);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(75, 23);
            this.UpdateButton.TabIndex = 4;
            this.UpdateButton.Text = "Yeah.";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // VersionUpdateWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 229);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.updateNowText);
            this.Controls.Add(this.newVersionInfoRTB);
            this.Controls.Add(this.NewVersionAvailableTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "VersionUpdateWindow";
            this.Text = "VersionUpdateWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label updateNowText;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button UpdateButton;
        public System.Windows.Forms.Label NewVersionAvailableTextBox;
        public System.Windows.Forms.RichTextBox newVersionInfoRTB;
    }
}