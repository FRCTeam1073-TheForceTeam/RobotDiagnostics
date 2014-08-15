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
            this.label1 = new System.Windows.Forms.Label();
            this.CheckinButton = new System.Windows.Forms.Button();
            this.voltageBar = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
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
            this.CheckinComboBox.Location = new System.Drawing.Point(12, 38);
            this.CheckinComboBox.Name = "CheckinComboBox";
            this.CheckinComboBox.Size = new System.Drawing.Size(244, 21);
            this.CheckinComboBox.TabIndex = 0;
            this.CheckinComboBox.VisibleChanged += new System.EventHandler(this.CheckinComboBox_VisibleChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select the Battery you plan to checkin from the list";
            // 
            // CheckinButton
            // 
            this.CheckinButton.Location = new System.Drawing.Point(12, 159);
            this.CheckinButton.Name = "CheckinButton";
            this.CheckinButton.Size = new System.Drawing.Size(120, 23);
            this.CheckinButton.TabIndex = 2;
            this.CheckinButton.Text = "Check In";
            this.CheckinButton.UseVisualStyleBackColor = true;
            this.CheckinButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // voltageBar
            // 
            this.voltageBar.Location = new System.Drawing.Point(16, 82);
            this.voltageBar.Maximum = 60;
            this.voltageBar.Minimum = 24;
            this.voltageBar.Name = "voltageBar";
            this.voltageBar.Size = new System.Drawing.Size(240, 42);
            this.voltageBar.TabIndex = 3;
            this.voltageBar.Value = 48;
            this.voltageBar.Scroll += new System.EventHandler(this.voltageBar_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = " New Voltage";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(138, 159);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(117, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // placeHelper
            // 
            this.placeHelper.AutoSize = true;
            this.placeHelper.Location = new System.Drawing.Point(16, 131);
            this.placeHelper.Name = "placeHelper";
            this.placeHelper.Size = new System.Drawing.Size(162, 13);
            this.placeHelper.TabIndex = 6;
            this.placeHelper.Text = "Place Battery in the \"Good\" area";
            // 
            // voltageLabel
            // 
            this.voltageLabel.AutoSize = true;
            this.voltageLabel.Location = new System.Drawing.Point(90, 66);
            this.voltageLabel.Name = "voltageLabel";
            this.voltageLabel.Size = new System.Drawing.Size(35, 13);
            this.voltageLabel.TabIndex = 7;
            this.voltageLabel.Text = "label4";
            // 
            // CheckinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 207);
            this.Controls.Add(this.voltageLabel);
            this.Controls.Add(this.placeHelper);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.voltageBar);
            this.Controls.Add(this.CheckinButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CheckinComboBox);
            this.Name = "CheckinForm";
            this.Text = "CheckinForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CheckinForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.voltageBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CheckinComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CheckinButton;
        private System.Windows.Forms.TrackBar voltageBar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label placeHelper;
        private System.Windows.Forms.Label voltageLabel;
    }
}