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
            this.addButton.Location = new System.Drawing.Point(12, 144);
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
            this.removeButton.Location = new System.Drawing.Point(12, 202);
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
            this.applyAndCloseButton.Location = new System.Drawing.Point(12, 231);
            this.applyAndCloseButton.Name = "applyAndCloseButton";
            this.applyAndCloseButton.Size = new System.Drawing.Size(205, 23);
            this.applyAndCloseButton.TabIndex = 8;
            this.applyAndCloseButton.Text = "apply changes and close";
            this.applyAndCloseButton.UseVisualStyleBackColor = true;
            this.applyAndCloseButton.Visible = false;
            this.applyAndCloseButton.Click += new System.EventHandler(this.applyAndCloseButton_Click);
            // 
            // modifyButton
            // 
            this.modifyButton.Enabled = false;
            this.modifyButton.Location = new System.Drawing.Point(12, 173);
            this.modifyButton.Name = "modifyButton";
            this.modifyButton.Size = new System.Drawing.Size(205, 23);
            this.modifyButton.TabIndex = 6;
            this.modifyButton.Text = "modify";
            this.modifyButton.UseVisualStyleBackColor = true;
            this.modifyButton.Click += new System.EventHandler(this.modifyButton_Click);
            // 
            // EditWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 260);
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
    }
}