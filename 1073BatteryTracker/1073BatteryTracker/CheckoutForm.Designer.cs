namespace _1073BatteryTracker
{
    partial class CheckoutForm
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
            this.checkoutBatteryLabel = new System.Windows.Forms.Label();
            this.yearLabel = new System.Windows.Forms.Label();
            this.numberLabel = new System.Windows.Forms.Label();
            this.batteryLevelHelper = new System.Windows.Forms.TrackBar();
            this.voltageLabel = new System.Windows.Forms.Label();
            this.estCheckinLabel = new System.Windows.Forms.Label();
            this.yearComboBox = new System.Windows.Forms.ComboBox();
            this.batteryNumberBox = new System.Windows.Forms.ComboBox();
            this.checkoutButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.subgroupLabel = new System.Windows.Forms.Label();
            this.subgroupBox = new System.Windows.Forms.ComboBox();
            this.sixVolts = new System.Windows.Forms.Label();
            this.fifteenVolts = new System.Windows.Forms.Label();
            this.chargeHelper = new System.Windows.Forms.Label();
            this.voltageLevel = new System.Windows.Forms.Label();
            this.checkoutTime = new System.Windows.Forms.DateTimePicker();
            this.robotLabel = new System.Windows.Forms.Label();
            this.robotBox = new System.Windows.Forms.ComboBox();
            this.batteryComboBox = new System.Windows.Forms.ComboBox();
            this.subgroupComboBox = new System.Windows.Forms.ComboBox();
            this.robotComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.batteryLevelHelper)).BeginInit();
            this.SuspendLayout();
            // 
            // checkoutBatteryLabel
            // 
            this.checkoutBatteryLabel.AutoSize = true;
            this.checkoutBatteryLabel.Location = new System.Drawing.Point(12, 9);
            this.checkoutBatteryLabel.Name = "checkoutBatteryLabel";
            this.checkoutBatteryLabel.Size = new System.Drawing.Size(98, 13);
            this.checkoutBatteryLabel.TabIndex = 0;
            this.checkoutBatteryLabel.Text = "Checkout a Battery";
            // 
            // yearLabel
            // 
            this.yearLabel.AutoSize = true;
            this.yearLabel.Location = new System.Drawing.Point(12, 35);
            this.yearLabel.Name = "yearLabel";
            this.yearLabel.Size = new System.Drawing.Size(29, 13);
            this.yearLabel.TabIndex = 1;
            this.yearLabel.Text = "Year";
            // 
            // numberLabel
            // 
            this.numberLabel.AutoSize = true;
            this.numberLabel.Location = new System.Drawing.Point(12, 75);
            this.numberLabel.Name = "numberLabel";
            this.numberLabel.Size = new System.Drawing.Size(44, 13);
            this.numberLabel.TabIndex = 2;
            this.numberLabel.Text = "Number";
            // 
            // batteryLevelHelper
            // 
            this.batteryLevelHelper.Location = new System.Drawing.Point(28, 143);
            this.batteryLevelHelper.Maximum = 60;
            this.batteryLevelHelper.Minimum = 24;
            this.batteryLevelHelper.Name = "batteryLevelHelper";
            this.batteryLevelHelper.Size = new System.Drawing.Size(142, 45);
            this.batteryLevelHelper.TabIndex = 3;
            this.batteryLevelHelper.Value = 48;
            this.batteryLevelHelper.Scroll += new System.EventHandler(this.batteryLevelHelper_Scroll);
            // 
            // voltageLabel
            // 
            this.voltageLabel.AutoSize = true;
            this.voltageLabel.Location = new System.Drawing.Point(12, 115);
            this.voltageLabel.Name = "voltageLabel";
            this.voltageLabel.Size = new System.Drawing.Size(43, 13);
            this.voltageLabel.TabIndex = 4;
            this.voltageLabel.Text = "Voltage";
            // 
            // estCheckinLabel
            // 
            this.estCheckinLabel.AutoSize = true;
            this.estCheckinLabel.Location = new System.Drawing.Point(9, 311);
            this.estCheckinLabel.Name = "estCheckinLabel";
            this.estCheckinLabel.Size = new System.Drawing.Size(137, 13);
            this.estCheckinLabel.TabIndex = 7;
            this.estCheckinLabel.Text = "Estimated Time to Check In";
            // 
            // yearComboBox
            // 
            this.yearComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yearComboBox.FormattingEnabled = true;
            this.yearComboBox.Items.AddRange(new object[] {
            "2004",
            "2005",
            "2006",
            "2007",
            "2008",
            "2009",
            "2010",
            "2011",
            "2012",
            "2013",
            "2014",
            "2015",
            "2016"});
            this.yearComboBox.Location = new System.Drawing.Point(15, 51);
            this.yearComboBox.Name = "yearComboBox";
            this.yearComboBox.Size = new System.Drawing.Size(121, 21);
            this.yearComboBox.TabIndex = 8;
            // 
            // batteryNumberBox
            // 
            this.batteryNumberBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.batteryNumberBox.FormattingEnabled = true;
            this.batteryNumberBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.batteryNumberBox.Location = new System.Drawing.Point(15, 91);
            this.batteryNumberBox.Name = "batteryNumberBox";
            this.batteryNumberBox.Size = new System.Drawing.Size(121, 21);
            this.batteryNumberBox.TabIndex = 9;
            // 
            // checkoutButton
            // 
            this.checkoutButton.Location = new System.Drawing.Point(131, 353);
            this.checkoutButton.Name = "checkoutButton";
            this.checkoutButton.Size = new System.Drawing.Size(75, 23);
            this.checkoutButton.TabIndex = 11;
            this.checkoutButton.Text = "Checkout";
            this.checkoutButton.UseVisualStyleBackColor = true;
            this.checkoutButton.Click += new System.EventHandler(this.checkoutButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(12, 353);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 12;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // subgroupLabel
            // 
            this.subgroupLabel.AutoSize = true;
            this.subgroupLabel.Location = new System.Drawing.Point(12, 208);
            this.subgroupLabel.Name = "subgroupLabel";
            this.subgroupLabel.Size = new System.Drawing.Size(53, 13);
            this.subgroupLabel.TabIndex = 13;
            this.subgroupLabel.Text = "Subgroup";
            // 
            // subgroupBox
            // 
            this.subgroupBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.subgroupBox.FormattingEnabled = true;
            this.subgroupBox.Items.AddRange(new object[] {
            "Software",
            "Strategy",
            "Buisness",
            "Mechanical",
            "BACS",
            "Electrical"});
            this.subgroupBox.Location = new System.Drawing.Point(12, 224);
            this.subgroupBox.Name = "subgroupBox";
            this.subgroupBox.Size = new System.Drawing.Size(84, 21);
            this.subgroupBox.TabIndex = 14;
            // 
            // sixVolts
            // 
            this.sixVolts.AutoSize = true;
            this.sixVolts.Location = new System.Drawing.Point(9, 143);
            this.sixVolts.Name = "sixVolts";
            this.sixVolts.Size = new System.Drawing.Size(13, 13);
            this.sixVolts.TabIndex = 15;
            this.sixVolts.Text = "6";
            // 
            // fifteenVolts
            // 
            this.fifteenVolts.AutoSize = true;
            this.fifteenVolts.Location = new System.Drawing.Point(176, 143);
            this.fifteenVolts.Name = "fifteenVolts";
            this.fifteenVolts.Size = new System.Drawing.Size(19, 13);
            this.fifteenVolts.TabIndex = 16;
            this.fifteenVolts.Text = "15";
            // 
            // chargeHelper
            // 
            this.chargeHelper.AutoSize = true;
            this.chargeHelper.ForeColor = System.Drawing.Color.Red;
            this.chargeHelper.Location = new System.Drawing.Point(12, 188);
            this.chargeHelper.Name = "chargeHelper";
            this.chargeHelper.Size = new System.Drawing.Size(190, 13);
            this.chargeHelper.TabIndex = 18;
            this.chargeHelper.Text = "Battery is too weak. Place in \'bad\' area";
            this.chargeHelper.Visible = false;
            // 
            // voltageLevel
            // 
            this.voltageLevel.AutoSize = true;
            this.voltageLevel.Location = new System.Drawing.Point(61, 115);
            this.voltageLevel.Name = "voltageLevel";
            this.voltageLevel.Size = new System.Drawing.Size(0, 13);
            this.voltageLevel.TabIndex = 19;
            // 
            // checkoutTime
            // 
            this.checkoutTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.checkoutTime.Location = new System.Drawing.Point(12, 327);
            this.checkoutTime.Name = "checkoutTime";
            this.checkoutTime.Size = new System.Drawing.Size(200, 20);
            this.checkoutTime.TabIndex = 10;
            // 
            // robotLabel
            // 
            this.robotLabel.AutoSize = true;
            this.robotLabel.Location = new System.Drawing.Point(12, 259);
            this.robotLabel.Name = "robotLabel";
            this.robotLabel.Size = new System.Drawing.Size(36, 13);
            this.robotLabel.TabIndex = 20;
            this.robotLabel.Text = "Robot";
            // 
            // robotBox
            // 
            this.robotBox.FormattingEnabled = true;
            this.robotBox.Items.AddRange(new object[] {
            "Libra",
            "Ursa",
            "Altas",
            "Mobile Base",
            "Other"});
            this.robotBox.Location = new System.Drawing.Point(12, 276);
            this.robotBox.Name = "robotBox";
            this.robotBox.Size = new System.Drawing.Size(84, 21);
            this.robotBox.TabIndex = 21;
            // 
            // batteryComboBox
            // 
            this.batteryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.batteryComboBox.FormattingEnabled = true;
            this.batteryComboBox.Items.AddRange(new object[] {
            "2004",
            "2005",
            "2006",
            "2007",
            "2008",
            "2009",
            "2010",
            "2011",
            "2012",
            "2013",
            "2014",
            "2015",
            "2016"});
            this.batteryComboBox.Location = new System.Drawing.Point(90, 24);
            this.batteryComboBox.Name = "batteryComboBox";
            this.batteryComboBox.Size = new System.Drawing.Size(105, 21);
            this.batteryComboBox.TabIndex = 22;
            // 
            // subgroupComboBox
            // 
            this.subgroupComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.subgroupComboBox.FormattingEnabled = true;
            this.subgroupComboBox.Items.AddRange(new object[] {
            "2004",
            "2005",
            "2006",
            "2007",
            "2008",
            "2009",
            "2010",
            "2011",
            "2012",
            "2013",
            "2014",
            "2015",
            "2016"});
            this.subgroupComboBox.Location = new System.Drawing.Point(102, 224);
            this.subgroupComboBox.Name = "subgroupComboBox";
            this.subgroupComboBox.Size = new System.Drawing.Size(84, 21);
            this.subgroupComboBox.TabIndex = 23;
            // 
            // robotComboBox
            // 
            this.robotComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.robotComboBox.FormattingEnabled = true;
            this.robotComboBox.Items.AddRange(new object[] {
            "2004",
            "2005",
            "2006",
            "2007",
            "2008",
            "2009",
            "2010",
            "2011",
            "2012",
            "2013",
            "2014",
            "2015",
            "2016"});
            this.robotComboBox.Location = new System.Drawing.Point(102, 276);
            this.robotComboBox.Name = "robotComboBox";
            this.robotComboBox.Size = new System.Drawing.Size(84, 21);
            this.robotComboBox.TabIndex = 24;
            // 
            // CheckoutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(218, 388);
            this.Controls.Add(this.robotComboBox);
            this.Controls.Add(this.subgroupComboBox);
            this.Controls.Add(this.batteryComboBox);
            this.Controls.Add(this.robotBox);
            this.Controls.Add(this.robotLabel);
            this.Controls.Add(this.voltageLevel);
            this.Controls.Add(this.chargeHelper);
            this.Controls.Add(this.fifteenVolts);
            this.Controls.Add(this.sixVolts);
            this.Controls.Add(this.subgroupBox);
            this.Controls.Add(this.subgroupLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.checkoutButton);
            this.Controls.Add(this.checkoutTime);
            this.Controls.Add(this.batteryNumberBox);
            this.Controls.Add(this.yearComboBox);
            this.Controls.Add(this.estCheckinLabel);
            this.Controls.Add(this.voltageLabel);
            this.Controls.Add(this.batteryLevelHelper);
            this.Controls.Add(this.numberLabel);
            this.Controls.Add(this.yearLabel);
            this.Controls.Add(this.checkoutBatteryLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CheckoutForm";
            this.Text = "CheckoutForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CheckoutForm_FormClosing);
            this.Load += new System.EventHandler(this.CheckoutForm_Load);
            this.VisibleChanged += new System.EventHandler(this.CheckoutForm_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.batteryLevelHelper)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label checkoutBatteryLabel;
        private System.Windows.Forms.Label yearLabel;
        private System.Windows.Forms.Label numberLabel;
        private System.Windows.Forms.TrackBar batteryLevelHelper;
        private System.Windows.Forms.Label voltageLabel;
        private System.Windows.Forms.Label estCheckinLabel;
        private System.Windows.Forms.ComboBox yearComboBox;
        private System.Windows.Forms.ComboBox batteryNumberBox;
        private System.Windows.Forms.Button checkoutButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label subgroupLabel;
        private System.Windows.Forms.ComboBox subgroupBox;
        private System.Windows.Forms.Label sixVolts;
        private System.Windows.Forms.Label fifteenVolts;
        private System.Windows.Forms.Label chargeHelper;
        private System.Windows.Forms.Label voltageLevel;
        private System.Windows.Forms.DateTimePicker checkoutTime;
        private System.Windows.Forms.Label robotLabel;
        private System.Windows.Forms.ComboBox robotBox;
        private System.Windows.Forms.ComboBox batteryComboBox;
        private System.Windows.Forms.ComboBox subgroupComboBox;
        private System.Windows.Forms.ComboBox robotComboBox;
    }
}