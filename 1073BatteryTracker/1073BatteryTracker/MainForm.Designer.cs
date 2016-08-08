namespace _1073BatteryTracker
{
    partial class MainForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.clearTheList = new System.Windows.Forms.Button();
            this.checkOut = new System.Windows.Forms.Button();
            this.checkIn = new System.Windows.Forms.Button();
            this.load = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.modifyCatagoriesButton = new System.Windows.Forms.Button();
            this.editEntryButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Year";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Number";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(107, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Charge Status (V)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(214, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Subgroup";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(303, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Time checked out";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "txt";
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.RestoreDirectory = true;
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "txt";
            this.saveFileDialog1.RestoreDirectory = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(574, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Robot";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(438, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Est Checkin time";
            // 
            // clearTheList
            // 
            this.clearTheList.Location = new System.Drawing.Point(12, 386);
            this.clearTheList.Name = "clearTheList";
            this.clearTheList.Size = new System.Drawing.Size(59, 23);
            this.clearTheList.TabIndex = 31;
            this.clearTheList.Text = "Clear List";
            this.clearTheList.UseVisualStyleBackColor = true;
            this.clearTheList.Click += new System.EventHandler(this.clearTheList_Click);
            // 
            // checkOut
            // 
            this.checkOut.Location = new System.Drawing.Point(144, 386);
            this.checkOut.Name = "checkOut";
            this.checkOut.Size = new System.Drawing.Size(99, 23);
            this.checkOut.TabIndex = 1;
            this.checkOut.Text = "Checkout Battery";
            this.checkOut.UseVisualStyleBackColor = true;
            this.checkOut.Click += new System.EventHandler(this.checkOut_Click);
            // 
            // checkIn
            // 
            this.checkIn.Location = new System.Drawing.Point(357, 386);
            this.checkIn.Name = "checkIn";
            this.checkIn.Size = new System.Drawing.Size(92, 23);
            this.checkIn.TabIndex = 3;
            this.checkIn.Text = "Checkin Battery";
            this.checkIn.UseVisualStyleBackColor = true;
            this.checkIn.Click += new System.EventHandler(this.checkIn_Click);
            // 
            // load
            // 
            this.load.Location = new System.Drawing.Point(455, 386);
            this.load.Name = "load";
            this.load.Size = new System.Drawing.Size(88, 23);
            this.load.TabIndex = 6;
            this.load.Text = "Load From File";
            this.load.UseVisualStyleBackColor = true;
            this.load.Click += new System.EventHandler(this.load_Click_1);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(549, 386);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(74, 23);
            this.save.TabIndex = 2;
            this.save.Text = "Save to File";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // modifyCatagoriesButton
            // 
            this.modifyCatagoriesButton.Location = new System.Drawing.Point(249, 386);
            this.modifyCatagoriesButton.Name = "modifyCatagoriesButton";
            this.modifyCatagoriesButton.Size = new System.Drawing.Size(102, 23);
            this.modifyCatagoriesButton.TabIndex = 32;
            this.modifyCatagoriesButton.Text = "Modify Catagories";
            this.modifyCatagoriesButton.UseVisualStyleBackColor = true;
            this.modifyCatagoriesButton.Click += new System.EventHandler(this.modifyCatagoriesButton_Click);
            // 
            // editEntryButton
            // 
            this.editEntryButton.Location = new System.Drawing.Point(77, 386);
            this.editEntryButton.Name = "editEntryButton";
            this.editEntryButton.Size = new System.Drawing.Size(61, 23);
            this.editEntryButton.TabIndex = 33;
            this.editEntryButton.Text = "Edit entry";
            this.editEntryButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 421);
            this.Controls.Add(this.editEntryButton);
            this.Controls.Add(this.modifyCatagoriesButton);
            this.Controls.Add(this.clearTheList);
            this.Controls.Add(this.checkOut);
            this.Controls.Add(this.checkIn);
            this.Controls.Add(this.load);
            this.Controls.Add(this.save);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "1073BatteryTracker";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button clearTheList;
        private System.Windows.Forms.Button checkOut;
        private System.Windows.Forms.Button checkIn;
        private System.Windows.Forms.Button load;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button modifyCatagoriesButton;
        private System.Windows.Forms.Button editEntryButton;
    }
}

