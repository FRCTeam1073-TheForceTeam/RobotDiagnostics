using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

namespace _1073BatteryTracker
{
    public partial class CheckinForm : Form
    {
        private double voltageLevelNum;
        private bool isFirstTime = true;

        public CheckinForm()
        {
            InitializeComponent();
        }
        //cancel button
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        //checkin button
        private void button1_Click(object sender, EventArgs e)
        {
            MainForm form1 = (MainForm)Application.OpenForms["MainForm"];
            Battery selectedBatt = (Battery) this.CheckinComboBox.SelectedItem;
            if (selectedBatt == null)
            {
                MessageBox.Show("Please have battery be selected");
                return;
            }
            selectedBatt.isNowInUse(false);
            String selected = selectedBatt.ToString();
            for (int i = 0; i < form1.battList.Count; i++)
            {
                Battery batt = (Battery)form1.battList[i];
                String printed = batt.ToString();
                if (printed.Equals(selected))
                {
                    form1.battList.RemoveAt(i);
                    form1.remove(i);
                }
            }
            this.Hide();
        }

        private void CheckinComboBox_VisibleChanged(object sender, EventArgs e)
        {
            if (isFirstTime)
            {
                isFirstTime = false;
                return;
            }
            voltageLevelNum = ((this.voltageBar.Value) / 4.0);
            this.voltageLabel.Text = "" + voltageLevelNum + " V";
            if (this.voltageLevelNum <= 10) this.placeHelper.Text = "Please place battery into the 'Bad' area";
            else this.placeHelper.Text = "Please place battery into the 'Good' area";
            this.CheckinComboBox.Items.Clear();
            this.CheckinComboBox.Text = null;
            MainForm form1 = (MainForm)Application.OpenForms["MainForm"];
            for (int i = 0; i < form1.battList.Count; i++)
            {
                Battery batt = (Battery)form1.battList[i];
                if (batt.isInUse()) this.CheckinComboBox.Items.Add(batt);
            }
        }

        private void CheckinForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void voltageBar_Scroll(object sender, EventArgs e)
        {
            voltageLevelNum = ((this.voltageBar.Value) / 4.0);
            this.voltageLabel.Text = "" + voltageLevelNum + " V";
            if (this.voltageLevelNum <= 10) this.placeHelper.Text="Please place battery into the 'Bad' area";
            else this.placeHelper.Text="Please place battery into the 'Good' area";
        }
    }
}
