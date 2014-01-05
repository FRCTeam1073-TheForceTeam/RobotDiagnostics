namespace DataCollection2014
{
    partial class Form1
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.General = new System.Windows.Forms.TabPage();
            this.Status = new System.Windows.Forms.TabPage();
            this.More_Stuff = new System.Windows.Forms.TabPage();
            this.Listen = new System.Windows.Forms.Button();
            this.Pause = new System.Windows.Forms.Button();
            this.Stop = new System.Windows.Forms.Button();
            this.SavetoDisk = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.General);
            this.tabControl1.Controls.Add(this.Status);
            this.tabControl1.Controls.Add(this.More_Stuff);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(543, 259);
            this.tabControl1.TabIndex = 0;
            // 
            // General
            // 
            this.General.Location = new System.Drawing.Point(4, 22);
            this.General.Name = "General";
            this.General.Padding = new System.Windows.Forms.Padding(3);
            this.General.Size = new System.Drawing.Size(535, 233);
            this.General.TabIndex = 0;
            this.General.Text = "General";
            this.General.UseVisualStyleBackColor = true;
            this.General.Click += new System.EventHandler(this.General_Click);
            // 
            // Status
            // 
            this.Status.Location = new System.Drawing.Point(4, 22);
            this.Status.Name = "Status";
            this.Status.Padding = new System.Windows.Forms.Padding(3);
            this.Status.Size = new System.Drawing.Size(535, 233);
            this.Status.TabIndex = 1;
            this.Status.Text = "Status";
            this.Status.UseVisualStyleBackColor = true;
            // 
            // More_Stuff
            // 
            this.More_Stuff.Location = new System.Drawing.Point(4, 22);
            this.More_Stuff.Name = "More_Stuff";
            this.More_Stuff.Size = new System.Drawing.Size(535, 233);
            this.More_Stuff.TabIndex = 2;
            this.More_Stuff.Text = "More_Stuff";
            this.More_Stuff.UseVisualStyleBackColor = true;
            // 
            // Listen
            // 
            this.Listen.Location = new System.Drawing.Point(12, 277);
            this.Listen.Name = "Listen";
            this.Listen.Size = new System.Drawing.Size(43, 23);
            this.Listen.TabIndex = 1;
            this.Listen.Text = "Listen";
            this.Listen.UseVisualStyleBackColor = true;
            // 
            // Pause
            // 
            this.Pause.Location = new System.Drawing.Point(61, 277);
            this.Pause.Name = "Pause";
            this.Pause.Size = new System.Drawing.Size(45, 23);
            this.Pause.TabIndex = 2;
            this.Pause.Text = "Pause";
            this.Pause.UseVisualStyleBackColor = true;
            // 
            // Stop
            // 
            this.Stop.Location = new System.Drawing.Point(112, 277);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(37, 23);
            this.Stop.TabIndex = 3;
            this.Stop.Text = "Stop";
            this.Stop.UseVisualStyleBackColor = true;
            // 
            // SavetoDisk
            // 
            this.SavetoDisk.Location = new System.Drawing.Point(155, 277);
            this.SavetoDisk.Name = "SavetoDisk";
            this.SavetoDisk.Size = new System.Drawing.Size(77, 23);
            this.SavetoDisk.TabIndex = 4;
            this.SavetoDisk.Text = "Save to Disk";
            this.SavetoDisk.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 302);
            this.Controls.Add(this.SavetoDisk);
            this.Controls.Add(this.Stop);
            this.Controls.Add(this.Pause);
            this.Controls.Add(this.Listen);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "DataListener2014";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage General;
        private System.Windows.Forms.TabPage Status;
        private System.Windows.Forms.TabPage More_Stuff;
        private System.Windows.Forms.Button Listen;
        private System.Windows.Forms.Button Pause;
        private System.Windows.Forms.Button Stop;
        private System.Windows.Forms.Button SavetoDisk;
    }
}

