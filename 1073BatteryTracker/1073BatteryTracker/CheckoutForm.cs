using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _1073BatteryTracker
{
    public partial class CheckoutForm : Form
    {   //instance variables
        public bool madeChanges = false;
        private double voltageLevelNum;
        public List<Robot> robotList;
        public List<Subgroup> subgroupList;
        public List<Battery> batteryOutList;
        public List<Battery> batteryInList;
        public CheckoutForm()
        {
            InitializeComponent();
        }
        //apply the new voltage number when moving the scrollbar
        private void batteryLevelHelper_Scroll(object sender, EventArgs e)
        {
            voltageLevelNum=((this.batteryLevelHelper.Value)/4.0);
            this.voltageLevel.Text = "" + voltageLevelNum + " V";
            if (this.voltageLevelNum <= 10) this.chargeHelper.Visible = true;
            else this.chargeHelper.Visible = false;
        }
        //"closes" the form
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //
        private void checkoutButton_Click(object sender, EventArgs e)
        {
            //create method to make sure everything is set
            if (this.everythingIsFilledOut())
            {
                madeChanges = true;
                Battery batt = this.createUnlinkedBattery(batteryInList[batteryComboBox.SelectedIndex]);
                batteryOutList.Add(batt);
                batteryInList.RemoveAt(batteryComboBox.SelectedIndex);
                this.Close();
            }
            else
            {
                MessageBox.Show("Not everything is filled out");
            }
        }
        //makes sure that the user had filled out every form option
        private bool everythingIsFilledOut()
        {
            if (robotComboBox.SelectedIndex != -1 && subgroupComboBox.SelectedIndex !=-1 && batteryComboBox.SelectedIndex != -1) return true;
            else return false;
        }
        //also sets the format for the checkoutTime dateTime object
        private void CheckoutForm_Load(object sender, EventArgs e)
        {
            checkoutTime.Format = DateTimePickerFormat.Custom;
            checkoutTime.CustomFormat = "MM/dd/yy  hh:mm tt";
            checkoutTime.ShowUpDown = true;
            //empty combo boxes
            while (batteryComboBox.Items.Count != 0) batteryComboBox.Items.RemoveAt(0);
            while (robotComboBox.Items.Count != 0) robotComboBox.Items.RemoveAt(0);
            while (subgroupComboBox.Items.Count != 0) subgroupComboBox.Items.RemoveAt(0);
            //parse lists into combo boxes
            foreach (Battery b in batteryInList) batteryComboBox.Items.Add(b);
            foreach (Robot r in robotList) robotComboBox.Items.Add(r);
            foreach (Subgroup s in subgroupList) subgroupComboBox.Items.Add(s);
            batteryLevelHelper_Scroll(null, null);
        }
        //
        private Battery createUnlinkedBattery(Battery b)
        {
            Battery temp = new Battery();
            temp.batteryNumber = b.batteryNumber;
            temp.batteryVoltage = ((float)this.voltageLevelNum);
            temp.batteryYear = b.batteryYear;
            DateTime dt = DateTime.Now;
            temp.checkoutTime = String.Format("{0:MM/dd/yy hh:mm tt}", dt);
            temp.estCheckinTime = checkoutTime.Text;
            temp.robot = robotList[robotComboBox.SelectedIndex].ToString();
            temp.subgroup = subgroupList[subgroupComboBox.SelectedIndex].ToString();
            return temp;
        }
    }
}
