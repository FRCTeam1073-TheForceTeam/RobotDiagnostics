using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _1073BatteryTracker
{
    public partial class CheckoutForm : Form
    {   //private instance variables
        private double voltageLevelNum;
        public List<Robot> robotList = new List<Robot>();
        public List<Subgroup> subgroupList = new List<Subgroup>();
        public List<Battery> batteryOutList = new List<Battery>();
        public List<Battery> batteryInList = new List<Battery>();
        //constructer. also sets the format for the checkoutTime dateTime object
        public CheckoutForm()
        {
            InitializeComponent();
            checkoutTime.Format = DateTimePickerFormat.Custom;
            checkoutTime.CustomFormat = "MM/dd/yy  hh:mm tt";
            checkoutTime.ShowUpDown = true;
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
            this.Hide();
        }
        //makes a battery based on the settings and then adds it to the List, and
        //tells the table to update
        private void checkoutButton_Click(object sender, EventArgs e)
        {
            MainForm form1 = (MainForm) Application.OpenForms["MainForm"];
            Battery batt = new Battery();
            if (!this.everythingIsFilledOut())
            {
                MessageBox.Show("All settings be completed before proceding checkout");
                return;
            }
            if (this.isDuplicate(form1))
            {
                MessageBox.Show("Duplicate battery detected, please recheck your settings");
                return;
            }
            batt.setYear(this.yearComboBox.Text);
            batt.setNumber(this.batteryNumberBox.Text);
            DateTime dt = DateTime.Now;
            batt.setCheckoutTime(String.Format("{0:MM/dd/yy hh:mm tt}", dt));
            batt.setEstCheckinTime(checkoutTime.Text);
            batt.setSubgroup(subgroupBox.Text);
            batt.setRobot(robotBox.Text);
            batt.setVoltage((float)this.voltageLevelNum);
            form1.batteryOutList.Add(batt);
            form1.updateList();
            this.Hide();
        }
        //clears everything in the text boxes for the next use
        private void CheckoutForm_VisibleChanged(object sender, EventArgs e)
        {
            this.batteryLevelHelper_Scroll(null, null);
           this.robotBox.Text = null;
           this.batteryNumberBox.Text = null;
           this.yearComboBox.Text = null;
           this.subgroupBox.Text = null;
        }
        //cancels the close and hides the form
        private void CheckoutForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
        //makes sure that the user had filled out every form option
        private bool everythingIsFilledOut()
        {
            if (yearComboBox.Text == "" || batteryNumberBox.Text == "" || robotBox.Text == "" || subgroupBox.Text == "")
                return false;
            return true;
        }
        //checks for duplicate batteries from the List
        private bool isDuplicate(MainForm form1)
        {
            for (int i = 0; i < form1.batteryOutList.Count; i++)
            {
                Battery Batt = form1.batteryOutList[i];
                String newBattNumber = this.batteryNumberBox.Text;
                String newYearNumber = this.yearComboBox.Text;
                if (newBattNumber.Equals(Batt.getNumber()) && newYearNumber.Equals(Batt.getYear())) return true;
            }
            return false;
        }

        private void CheckoutForm_Load(object sender, EventArgs e)
        {
            //parse lists into combo boxes
        }
    }
}
