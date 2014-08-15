using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _1073BatteryTracker
{

    //TODO make checker for dublicate batteries
    //TODO add file saving and loading abilities

    public partial class CheckoutForm : Form
    {
        private double voltageLevelNum;

        public CheckoutForm()
        {
            InitializeComponent();
            checkoutTime.Format = DateTimePickerFormat.Custom;
            checkoutTime.CustomFormat = "MM/dd/yy  hh:mm tt";
            checkoutTime.ShowUpDown = true;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            voltageLevelNum=((this.batteryLevelHelper.Value)/4.0);
            this.voltageLevel.Text = "" + voltageLevelNum + " V";
            if (this.voltageLevelNum <= 10) this.chargeHelper.Visible = true;
            else this.chargeHelper.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm form1 = (MainForm) Application.OpenForms["MainForm"];
            Battery batt = this.getNextUnusedBattery(form1);
            if (!this.everythingIsFilledOut())
            {
                MessageBox.Show("Please fill out all fields before clicking checkout");
                return;
            }
            if (batt == null)
            {
                MessageBox.Show("Maximum number of batteries have been checked out");
                return;
            }
            if (this.isDuplicate(form1))
            {
                MessageBox.Show("Duplicate battery detected, please recheck your settings");
                return;
            }
            batt.setBatteryYear(this.yearComboBox.Text);
            batt.setBatteryNumber(this.batteryNumberBox.Text);
            DateTime dt = DateTime.Now;
            batt.setCheckoutTime(String.Format("{0:MM/dd/yy hh:mm tt}", dt));
            batt.setEstCheckinTime(checkoutTime.Text);
            batt.setSubgroup(subgroupBox.Text);
            batt.setRobot(robotBox.Text);
            batt.isNowInUse(true);
            batt.setBatteryVoltage((float)this.voltageLevelNum);
            form1.updateList();
            this.Hide();
        }

        private void CheckoutForm_VisibleChanged(object sender, EventArgs e)
        {
           voltageLevelNum=((this.batteryLevelHelper.Value)/4.0);
           this.voltageLevel.Text = "" + voltageLevelNum;
           if (this.voltageLevelNum <= 10) this.chargeHelper.Visible = true;
           else this.chargeHelper.Visible = false;
           this.robotBox.Text = null;
           this.batteryNumberBox.Text = null;
           this.yearComboBox.Text = null;
           this.subgroupBox.Text = null;
        }

        private Battery getNextUnusedBattery(MainForm form1)
        {
            int i = 0;
            
            while (true) {
                Battery batt = (Battery)form1.battList[i];
                if (!batt.isInUse()) break;
                i++;
                if (i==10) return null;
            }
            return (Battery) form1.battList[i];
        }

        private void CheckoutForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private bool everythingIsFilledOut()
        {
            if (yearComboBox.Text == "" || batteryNumberBox.Text == "" || robotBox.Text == "" || subgroupBox.Text == "")
                return false;
            return true;
        }

        private bool isDuplicate(MainForm form1)
        {
            for (int i = 0; i < form1.battList.Count; )
            {
                Battery Batt = (Battery)form1.battList[i];
                String newBattNumber = this.batteryNumberBox.Text;
                String newYearNumber = this.yearComboBox.Text;
                if (newBattNumber.Equals(Batt.getBatteryNumber()) && newYearNumber.Equals(Batt.getBatteryYear())) return true;
                else
                    return false;
            }
            return false;
        }
    }
}
