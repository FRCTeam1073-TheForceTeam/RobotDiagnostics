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
        public bool madeChanges = false;
        public List<Robot> robotList;
        public List<Subgroup> subgroupList;
        public List<Battery> batteryOutList;
        public List<Battery> batteryInList;
        //contsructer
        public CheckinForm()
        {
            InitializeComponent();
        }
        //hides the form, making the user think s/he has closed the window
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //checks in a battery by finding the battery that the user selected in the List
        //and removing it from the List, and telling the table to update
        private void checkinButton_Click(object sender, EventArgs e)
        {
            //do it right again here
            if (CheckinComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Battery must be selected");
            }
            else
            {
                madeChanges = true;
                Battery batt = this.createUnlinkedBattery(batteryOutList[CheckinComboBox.SelectedIndex]);
                batteryInList.Add(batt);
                batteryOutList.RemoveAt(CheckinComboBox.SelectedIndex);
                this.Close();
            }
        }
        //shows the voltage that the user has selected in the scroll bar
        private void voltageBar_Scroll(object sender, EventArgs e)
        {
            voltageLevelNum = ((this.voltageBar.Value) / 4.0);
            this.voltageLabel.Text = "" + voltageLevelNum + " V";
            if (this.voltageLevelNum <= 10) this.placeHelper.Text="Please place battery into the 'Bad' area";
            else this.placeHelper.Text="Please place battery into the 'Good' area";
        }

        private void CheckinForm_Load(object sender, EventArgs e)
        {
            while (CheckinComboBox.Items.Count != 0)
            {
                CheckinComboBox.Items.RemoveAt(0);
            }
            foreach (Battery b in batteryOutList)
            {
                CheckinComboBox.Items.Add(b);
            }
        }

        private Battery createUnlinkedBattery(Battery b)
        {
            Battery temp = new Battery();
            temp.batteryNumber = b.batteryNumber;
            temp.batteryYear = b.batteryYear;
            return temp;
        }
    }
}
