namespace _1073BatteryTracker
{
    partial class CheckinForm
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
            this.CheckinComboBox = new System.Windows.Forms.ComboBox();
            this.descriptor1 = new System.Windows.Forms.Label();
            this.checkinButton = new System.Windows.Forms.Button();
            this.voltageBar = new System.Windows.Forms.TrackBar();
            this.newVoltageLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.placeHelper = new System.Windows.Forms.Label();
            this.voltageLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.voltageBar)).BeginInit();
            this.SuspendLayout();
            // 
            // CheckinComboBox
            // 
            this.CheckinComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CheckinComboBox.FormattingEnabled = true;
            this.CheckinComboBox.Location = new System.Drawing.Point(12, 25);
            this.CheckinComboBox.Name = "CheckinComboBox";
            this.CheckinComboBox.Size = new System.Drawing.Size(244, 21);
            this.CheckinComboBox.TabIndex = 0;
            this.CheckinComboBox.VisibleChanged += new System.EventHandler(this.CheckinComboBox_VisibleChanged);
            // 
            // descriptor1
            // 
            this.descriptor1.AutoSize = true;
            this.descriptor1.Location = new System.Drawing.Point(9, 9);
            this.descriptor1.Name = "descriptor1";
            this.descriptor1.Size = new System.Drawing.Size(245, 13);
            this.descriptor1.TabIndex = 1;
            this.descriptor1.Text = "Select the battery you plan to check in from the list";
            // 
            // checkinButton
            // 
            this.checkinButton.Location = new System.Drawing.Point(135, 155);
            this.checkinButton.Name = "checkinButton";
            this.checkinButton.Size = new System.Drawing.Size(117, 23);
            this.checkinButton.TabIndex = 2;
            this.checkinButton.Text = "Check In";
            this.checkinButton.UseVisualStyleBackColor = true;
            this.checkinButton.Click += new System.EventHandler(this.checkinButton_Click);
            // 
            // voltageBar
            // 
            this.voltageBar.Location = new System.Drawing.Point(12, 82);
            this.voltageBar.Maximum = 60;
            this.voltageBar.Minimum = 24;
            this.voltageBar.Name = "voltageBar";
            this.voltageBar.Size = new System.Drawing.Size(240, 45);
            this.voltageBar.TabIndex = 3;
            this.voltageBar.Value = 48;
            this.voltageBar.Scroll += new System.EventHandler(this.voltageBar_Scroll);
            // 
            // newVoltageLabel
            // 
            this.newVoltageLabel.AutoSize = true;
            this.newVoltageLabel.Location = new System.Drawing.Point(13, 62);
            this.newVoltageLabel.Name = "newVoltageLabel";
            this.newVoltageLabel.Size = new System.Drawing.Size(71, 13);
            this.newVoltageLabel.TabIndex = 4;
            this.newVoltageLabel.Text = " New Voltage";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(12, 155);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(117, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // placeHelper
            // 
            this.placeHelper.AutoSize = true;
            this.placeHelper.Location = new System.Drawing.Point(51, 130);
            this.placeHelper.Name = "placeHelper";
            this.placeHelper.Size = new System.Drawing.Size(162, 13);
            this.placeHelper.TabIndex = 6;
            this.placeHelper.Text = "Place Battery in the \"Good\" area";
            // 
            // voltageLabel
            // 
            this.voltageLabel.AutoSize = true;
            this.voltageLabel.Location = new System.Drawing.Point(90, 62);
            this.voltageLabel.Name = "voltageLabel";
            this.voltageLabel.Size = new System.Drawing.Size(35, 13);
            this.voltageLabel.TabIndex = 7;
            this.voltageLabel.Text = "label4";
            // 
            // CheckinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 185);
            this.Controls.Add(this.voltageLabel);
            this.Controls.Add(this.placeHelper);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.newVoltageLabel);
            this.Controls.Add(this.voltageBar);
            this.Controls.Add(this.checkinButton);
            this.Controls.Add(this.descriptor1);
            this.Controls.Add(this.CheckinComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CheckinForm";
            this.Text = "CheckinForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CheckinForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.voltageBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CheckinComboBox;
        private System.Windows.Forms.Label descriptor1;
        private System.Windows.Forms.Button checkinButton;
        private System.Windows.Forms.TrackBar voltageBar;
        private System.Windows.Forms.Label newVoltageLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label placeHelper;
        private System.Windows.Forms.Label voltageLabel;
    }
}