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
            //omg so wrong again
            /*MainForm form1 = (MainForm)Application.OpenForms["MainForm"];
            Battery selectedBatt = (Battery) this.CheckinComboBox.SelectedItem;
            if (selectedBatt == null)
            {
                MessageBox.Show("Please have battery be selected");
                return;
            }
            String selected = selectedBatt.ToString();
            for (int i = 0; i < form1.batteryOutList.Count; i++)
            {
                Battery batt = form1.batteryOutList[i];
                String printed = batt.ToString();
                if (printed.Equals(selected))
                {
                    form1.batteryOutList.RemoveAt(i);
                    
                }
            }
            form1.updateList();
            this.Hide();*/
            //do it right again here
            madeChanges = true;
            Battery batt = this.createUnlinkedBattery(batteryOutList[CheckinComboBox.SelectedIndex]);
            batteryInList.Add(batt);
            batteryOutList.RemoveAt(CheckinComboBox.SelectedIndex);
            this.Close();
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
            for (int i = 0; i < form1.batteryOutList.Count; i++)
            {
                Battery batt = form1.batteryOutList[i];
                this.CheckinComboBox.Items.Add(batt);
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
