﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _1073BatteryTracker
{
    public partial class PleaseWait : Form
    {
        private bool showProgress;
        private string message;
        public PleaseWait()
        {
            InitializeComponent();
        }

        public PleaseWait(string waitText, bool showProgressBar = false)
        {
            InitializeComponent();
            message = waitText;
            showProgress = showProgressBar;
        }

        public void setProgress(int progress)
        {
            loadingProgressBar.Value = progress;
        }

        public void setText(string message)
        {
            loadingMessage.Text = message;
        }

        private void PleaseWait_Load(object sender, EventArgs e)
        {

        }

        private void PleaseWait_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
        public void setText(int i)
        {
            //1=updating, 2=clearing
            if (i == 1) this.loadingMessage.Text = "Please wait, updating the list...";
            else this.loadingMessage.Text = "Please wait, clearing the list...";
            
        }
        //A simple method to hide the form
        public void goAway() { this.Hide(); }
        //sets the location of the top-left corner of the form
        public void setLocation(int x, int y)
        {
            Point p = new Point(x,y);
            this.Location = p;
        }
    }
}
