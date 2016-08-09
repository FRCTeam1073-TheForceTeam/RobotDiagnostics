namespace _1073BatteryTracker
{
    partial class EditWindow
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
            this.label1 = new System.Windows.Forms.Label();
            this.selectCatagoryComboBox = new System.Windows.Forms.ComboBox();
            this.fieldEntry1 = new System.Windows.Forms.TextBox();
            this.selectItemComboBox = new System.Windows.Forms.ComboBox();
            this.addButton = new System.Windows.Forms.Button();
            this.field1 = new System.Windows.Forms.Label();
            this.removeButton = new System.Windows.Forms.Button();
            this.field2 = new System.Windows.Forms.Label();
            this.fieldEntry2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.applyAndCloseButton = new System.Windows.Forms.Button();
            this.modifyButton = new System.Windows.Forms.Button();
            this.field3 = new System.Windows.Forms.Label();
            this.fieldEntry3 = new System.Windows.Forms.TextBox();
            this.field4 = new System.Windows.Forms.Label();
            this.fieldEntry4 = new System.Windows.Forms.TextBox();
            this.field5 = new System.Windows.Forms.Label();
            this.fieldEntry5 = new System.Windows.Forms.TextBox();
            this.field6 = new System.Windows.Forms.Label();
            this.field7 = new System.Windows.Forms.Label();
            this.subgroupComboBox = new System.Windows.Forms.ComboBox();
            this.robotComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "select catagory to modify";
            // 
            // selectCatagoryComboBox
            // 
            this.selectCatagoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectCatagoryComboBox.FormattingEnabled = true;
            this.selectCatagoryComboBox.Location = new System.Drawing.Point(12, 25);
            this.selectCatagoryComboBox.Name = "selectCatagoryComboBox";
            this.selectCatagoryComboBox.Size = new System.Drawing.Size(205, 21);
            this.selectCatagoryComboBox.TabIndex = 1;
            this.selectCatagoryComboBox.SelectedIndexChanged += new System.EventHandler(this.selectCatagoryComboBox_SelectedIndexChanged);
            // 
            // fieldEntry1
            // 
            this.fieldEntry1.Location = new System.Drawing.Point(68, 92);
            this.fieldEntry1.Name = "fieldEntry1";
            this.fieldEntry1.ReadOnly = true;
            this.fieldEntry1.Size = new System.Drawing.Size(149, 20);
            this.fieldEntry1.TabIndex = 3;
            // 
            // selectItemComboBox
            // 
            this.selectItemComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectItemComboBox.FormattingEnabled = true;
            this.selectItemComboBox.Location = new System.Drawing.Point(12, 65);
            this.selectItemComboBox.Name = "selectItemComboBox";
            this.selectItemComboBox.Size = new System.Drawing.Size(205, 21);
            this.selectItemComboBox.TabIndex = 2;
            this.selectItemComboBox.SelectedIndexChanged += new System.EventHandler(this.selectItemComboBox_SelectedIndexChanged);
            // 
            // addButton
            // 
            this.addButton.Enabled = false;
            this.addButton.Location = new System.Drawing.Point(12, 275);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(205, 23);
            this.addButton.TabIndex = 5;
            this.addButton.Text = "add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // field1
            // 
            this.field1.AutoSize = true;
            this.field1.Location = new System.Drawing.Point(9, 95);
            this.field1.Name = "field1";
            this.field1.Size = new System.Drawing.Size(33, 13);
            this.field1.TabIndex = 5;
            this.field1.Text = "value";
            // 
            // removeButton
            // 
            this.removeButton.Enabled = false;
            this.removeButton.Location = new System.Drawing.Point(12, 333);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(205, 23);
            this.removeButton.TabIndex = 7;
            this.removeButton.Text = "remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // field2
            // 
            this.field2.AutoSize = true;
            this.field2.Location = new System.Drawing.Point(9, 121);
            this.field2.Name = "field2";
            this.field2.Size = new System.Drawing.Size(33, 13);
            this.field2.TabIndex = 8;
            this.field2.Text = "value";
            // 
            // fieldEntry2
            // 
            this.fieldEntry2.Location = new System.Drawing.Point(68, 118);
            this.fieldEntry2.Name = "fieldEntry2";
            this.fieldEntry2.ReadOnly = true;
            this.fieldEntry2.Size = new System.Drawing.Size(149, 20);
            this.fieldEntry2.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "select item from selected catagory";
            // 
            // applyAndCloseButton
            // 
            this.applyAndCloseButton.Enabled = false;
            this.applyAndCloseButton.Location = new System.Drawing.Point(12, 362);
            this.applyAndCloseButton.Name = "applyAndCloseButton";
            this.applyAndCloseButton.Size = new System.Drawing.Size(205, 23);
            this.applyAndCloseButton.TabIndex = 8;
            this.applyAndCloseButton.Text = "null";
            this.applyAndCloseButton.UseVisualStyleBackColor = true;
            this.applyAndCloseButton.Visible = false;
            this.applyAndCloseButton.Click += new System.EventHandler(this.applyAndCloseButton_Click);
            // 
            // modifyButton
            // 
            this.modifyButton.Enabled = false;
            this.modifyButton.Location = new System.Drawing.Point(12, 304);
            this.modifyButton.Name = "modifyButton";
            this.modifyButton.Size = new System.Drawing.Size(205, 23);
            this.modifyButton.TabIndex = 6;
            this.modifyButton.Text = "modify";
            this.modifyButton.UseVisualStyleBackColor = true;
            this.modifyButton.Click += new System.EventHandler(this.modifyButton_Click);
            // 
            // field3
            // 
            this.field3.AutoSize = true;
            this.field3.Location = new System.Drawing.Point(9, 147);
            this.field3.Name = "field3";
            this.field3.Size = new System.Drawing.Size(42, 13);
            this.field3.TabIndex = 11;
            this.field3.Text = "voltage";
            // 
            // fieldEntry3
            // 
            this.fieldEntry3.Location = new System.Drawing.Point(68, 144);
            this.fieldEntry3.Name = "fieldEntry3";
            this.fieldEntry3.ReadOnly = true;
            this.fieldEntry3.Size = new System.Drawing.Size(149, 20);
            this.fieldEntry3.TabIndex = 10;
            // 
            // field4
            // 
            this.field4.AutoSize = true;
            this.field4.Location = new System.Drawing.Point(9, 173);
            this.field4.Name = "field4";
            this.field4.Size = new System.Drawing.Size(54, 13);
            this.field4.TabIndex = 13;
            this.field4.Text = "checkOut";
            // 
            // fieldEntry4
            // 
            this.fieldEntry4.Location = new System.Drawing.Point(68, 170);
            this.fieldEntry4.Name = "fieldEntry4";
            this.fieldEntry4.ReadOnly = true;
            this.fieldEntry4.Size = new System.Drawing.Size(149, 20);
            this.fieldEntry4.TabIndex = 12;
            // 
            // field5
            // 
            this.field5.AutoSize = true;
            this.field5.Location = new System.Drawing.Point(9, 199);
            this.field5.Name = "field5";
            this.field5.Size = new System.Drawing.Size(46, 13);
            this.field5.TabIndex = 15;
            this.field5.Text = "checkIn";
            // 
            // fieldEntry5
            // 
            this.fieldEntry5.Location = new System.Drawing.Point(68, 196);
            this.fieldEntry5.Name = "fieldEntry5";
            this.fieldEntry5.ReadOnly = true;
            this.fieldEntry5.Size = new System.Drawing.Size(149, 20);
            this.fieldEntry5.TabIndex = 14;
            // 
            // field6
            // 
            this.field6.AutoSize = true;
            this.field6.Location = new System.Drawing.Point(9, 225);
            this.field6.Name = "field6";
            this.field6.Size = new System.Drawing.Size(51, 13);
            this.field6.TabIndex = 17;
            this.field6.Text = "subgroup";
            // 
            // field7
            // 
            this.field7.AutoSize = true;
            this.field7.Location = new System.Drawing.Point(9, 251);
            this.field7.Name = "field7";
            this.field7.Size = new System.Drawing.Size(31, 13);
            this.field7.TabIndex = 19;
            this.field7.Text = "robot";
            // 
            // subgroupComboBox
            // 
            this.subgroupComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.subgroupComboBox.FormattingEnabled = true;
            this.subgroupComboBox.Location = new System.Drawing.Point(68, 222);
            this.subgroupComboBox.Name = "subgroupComboBox";
            this.subgroupComboBox.Size = new System.Drawing.Size(149, 21);
            this.subgroupComboBox.TabIndex = 20;
            // 
            // robotComboBox
            // 
            this.robotComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.robotComboBox.FormattingEnabled = true;
            this.robotComboBox.Location = new System.Drawing.Point(68, 248);
            this.robotComboBox.Name = "robotComboBox";
            this.robotComboBox.Size = new System.Drawing.Size(149, 21);
            this.robotComboBox.TabIndex = 21;
            // 
            // EditWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 394);
            this.Controls.Add(this.robotComboBox);
            this.Controls.Add(this.subgroupComboBox);
            this.Controls.Add(this.field7);
            this.Controls.Add(this.field6);
            this.Controls.Add(this.field5);
            this.Controls.Add(this.fieldEntry5);
            this.Controls.Add(this.field4);
            this.Controls.Add(this.fieldEntry4);
            this.Controls.Add(this.field3);
            this.Controls.Add(this.fieldEntry3);
            this.Controls.Add(this.modifyButton);
            this.Controls.Add(this.applyAndCloseButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.field2);
            this.Controls.Add(this.fieldEntry2);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.field1);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.selectItemComboBox);
            this.Controls.Add(this.fieldEntry1);
            this.Controls.Add(this.selectCatagoryComboBox);
            this.Controls.Add(this.label1);
            this.Name = "EditWindow";
            this.Text = "EditWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditWindow_FormClosing);
            this.Load += new System.EventHandler(this.EditWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox selectCatagoryComboBox;
        public System.Windows.Forms.TextBox fieldEntry1;
        public System.Windows.Forms.ComboBox selectItemComboBox;
        public System.Windows.Forms.Button addButton;
        public System.Windows.Forms.Label field1;
        public System.Windows.Forms.Button removeButton;
        public System.Windows.Forms.Label field2;
        public System.Windows.Forms.TextBox fieldEntry2;
        public System.Windows.Forms.Button applyAndCloseButton;
        public System.Windows.Forms.Button modifyButton;
        public System.Windows.Forms.Label field3;
        public System.Windows.Forms.TextBox fieldEntry3;
        public System.Windows.Forms.Label field4;
        public System.Windows.Forms.TextBox fieldEntry4;
        public System.Windows.Forms.Label field5;
        public System.Windows.Forms.TextBox fieldEntry5;
        public System.Windows.Forms.Label field6;
        public System.Windows.Forms.Label field7;
        public System.Windows.Forms.ComboBox subgroupComboBox;
        public System.Windows.Forms.ComboBox robotComboBox;
    }
}