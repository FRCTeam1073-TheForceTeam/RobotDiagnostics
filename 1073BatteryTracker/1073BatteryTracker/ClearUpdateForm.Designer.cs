namespace _1073BatteryTracker
{
    partial class PleaseWait
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
            this.loadingMessage = new System.Windows.Forms.Label();
            this.loadingProgressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // loadingMessage
            // 
            this.loadingMessage.AutoSize = true;
            this.loadingMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadingMessage.Location = new System.Drawing.Point(12, 5);
            this.loadingMessage.Name = "loadingMessage";
            this.loadingMessage.Size = new System.Drawing.Size(97, 20);
            this.loadingMessage.TabIndex = 0;
            this.loadingMessage.Text = "Sample Text";
            // 
            // loadingProgressBar
            // 
            this.loadingProgressBar.Location = new System.Drawing.Point(12, 28);
            this.loadingProgressBar.Name = "loadingProgressBar";
            this.loadingProgressBar.Size = new System.Drawing.Size(230, 23);
            this.loadingProgressBar.TabIndex = 1;
            // 
            // PleaseWait
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 57);
            this.Controls.Add(this.loadingProgressBar);
            this.Controls.Add(this.loadingMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PleaseWait";
            this.Text = "Loading...";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PleaseWait_FormClosing);
            this.Load += new System.EventHandler(this.PleaseWait_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label loadingMessage;
        private System.Windows.Forms.ProgressBar loadingProgressBar;
    }
}