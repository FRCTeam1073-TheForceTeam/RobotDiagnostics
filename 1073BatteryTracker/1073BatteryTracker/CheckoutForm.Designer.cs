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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.batteryLevelHelper = new System.Windows.Forms.TrackBar();
            this.voltageLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.yearComboBox = new System.Windows.Forms.ComboBox();
            this.batteryNumberBox = new System.Windows.Forms.ComboBox();
            this.checkoutButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.subgroupBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.chargeHelper = new System.Windows.Forms.Label();
            this.voltageLevel = new System.Windows.Forms.Label();
            this.checkoutTime = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.robotBox = new System.Windows.Forms.ComboBox();
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Year";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Number";
            // 
            // batteryLevelHelper
            // 
            this.batteryLevelHelper.Location = new System.Drawing.Point(28, 143);
            this.batteryLevelHelper.Maximum = 60;
            this.batteryLevelHelper.Minimum = 24;
            this.batteryLevelHelper.Name = "batteryLevelHelper";
            this.batteryLevelHelper.Size = new System.Drawing.Size(142, 42);
            this.batteryLevelHelper.TabIndex = 3;
            this.batteryLevelHelper.Value = 48;
            this.batteryLevelHelper.Scroll += new System.EventHandler(this.trackBar1_Scroll);
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 311);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(137, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Estimated Time to Check In";
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
            this.checkoutButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(12, 353);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 12;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Subgroup";
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
            this.subgroupBox.Size = new System.Drawing.Size(121, 21);
            this.subgroupBox.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "6";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(176, 143);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(19, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "15";
            // 
            // chargeHelper
            // 
            this.chargeHelper.AutoSize = true;
            this.chargeHelper.ForeColor = System.Drawing.Color.Red;
            this.chargeHelper.Location = new System.Drawing.Point(12, 188);
            this.chargeHelper.Name = "chargeHelper";
            this.chargeHelper.Size = new System.Drawing.Size(185, 13);
            this.chargeHelper.TabIndex = 18;
            this.chargeHelper.Text = "Battery is too weak. Place on Charger";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 259);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Robot";
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
            this.robotBox.Size = new System.Drawing.Size(121, 21);
            this.robotBox.TabIndex = 21;
            // 
            // CheckoutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(218, 388);
            this.Controls.Add(this.robotBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.voltageLevel);
            this.Controls.Add(this.chargeHelper);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.subgroupBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.checkoutButton);
            this.Controls.Add(this.checkoutTime);
            this.Controls.Add(this.batteryNumberBox);
            this.Controls.Add(this.yearComboBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.voltageLabel);
            this.Controls.Add(this.batteryLevelHelper);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkoutBatteryLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CheckoutForm";
            this.Text = "CheckoutForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CheckoutForm_FormClosing);
            this.VisibleChanged += new System.EventHandler(this.CheckoutForm_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.batteryLevelHelper)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label checkoutBatteryLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar batteryLevelHelper;
        private System.Windows.Forms.Label voltageLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox yearComboBox;
        private System.Windows.Forms.ComboBox batteryNumberBox;
        private System.Windows.Forms.Button checkoutButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox subgroupBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label chargeHelper;
        private System.Windows.Forms.Label voltageLevel;
        private System.Windows.Forms.DateTimePicker checkoutTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox robotBox;
    }
}