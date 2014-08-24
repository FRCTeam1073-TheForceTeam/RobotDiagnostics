using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

namespace _1073BatteryTracker
{
    public partial class CheckinForm : Form
    {   //private instance variables
        private double voltageLevelNum;
        private bool isFirstTime = true;
        //contsructer
        public CheckinForm()
        {
            InitializeComponent();
        }
        //hides the form, making the user think s/he has closed the window
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        //checks in a battery by finding the battery that the user selected in the List
        //and removing it from the List, and telling the table to update
        private void checkinButton_Click(object sender, EventArgs e)
        {
            MainForm form1 = (MainForm)Application.OpenForms["MainForm"];
            Battery selectedBatt = (Battery) this.CheckinComboBox.SelectedItem;
            if (selectedBatt == null)
            {
                MessageBox.Show("Please have battery be selected");
                return;
            }
            String selected = selectedBatt.ToString();
            for (int i = 0; i < form1.battList.Count; i++)
            {
                Battery batt = form1.battList[i];
                String printed = batt.ToString();
                if (printed.Equals(selected))
                {
                    form1.battList.RemoveAt(i);
                    
                }
            }
            form1.updateList();
            this.Hide();
        }
        //adds the batteries to the drop down menu of batteries to select to check in
        private void CheckinComboBox_VisibleChanged(object sender, EventArgs e)
        {
            if (isFirstTime)
            {
                isFirstTime = false;
                return;
            }
            this.voltageBar_Scroll(null, null);
            this.CheckinComboBox.Items.Clear();
            this.CheckinComboBox.Text = null;
            MainForm form1 = (MainForm)Application.OpenForms["MainForm"];
            for (int i = 0; i < form1.battList.Count; i++)
            {
                Battery batt = form1.battList[i];
                this.CheckinComboBox.Items.Add(batt);
            }
        }
        //stops the form from closing, just hides it instead
        private void CheckinForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
        //shows the voltage that the user has selected in the scroll bar
        private void voltageBar_Scroll(object sender, EventArgs e)
        {
            voltageLevelNum = ((this.voltageBar.Value) / 4.0);
            this.voltageLabel.Text = "" + voltageLevelNum + " V";
            if (this.voltageLevelNum <= 10) this.placeHelper.Text="Please place battery into the 'Bad' area";
            else this.placeHelper.Text="Please place battery into the 'Good' area";
        }
    }
}
