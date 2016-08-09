using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _1073BatteryTracker
{
    public partial class EditWindow : Form
    {
        public bool applyChanges = false;
        public List<Robot> robotList;
        public List<Subgroup> subgroupList;
        public List<Battery> batteryOutList;
        public List<Battery> batteryInList;
        public EditWindow()
        {
            InitializeComponent();
        }

        private void EditWindow_Load(object sender, EventArgs e)
        {
            //disable everything
            selectItemComboBox.Enabled = false;
            field1.Visible = false;
            field2.Visible = false;
            field3.Visible = false;
            field4.Visible = false;
            field5.Visible = false;
            field6.Visible = false;
            field7.Visible = false;
            fieldEntry1.Visible = false;
            fieldEntry1.Enabled = false;
            fieldEntry1.ReadOnly = true;
            fieldEntry2.Visible = false;
            fieldEntry2.Enabled = false;
            fieldEntry2.ReadOnly = true;
            fieldEntry3.Visible = false;
            fieldEntry3.Enabled = false;
            fieldEntry4.Visible = false;
            fieldEntry4.Enabled = false;
            fieldEntry5.Visible = false;
            fieldEntry5.Enabled = false;
            subgroupComboBox.Visible = false;
            robotComboBox.Visible = false;
            addButton.Enabled = false;
            modifyButton.Enabled = false;
            removeButton.Enabled = false;
            //and null their text
            selectItemComboBox.SelectedIndex = -1;
            fieldEntry1.Text = "";
            fieldEntry2.Text = "";
            fieldEntry3.Text = "";
            fieldEntry4.Text = "";
            fieldEntry5.Text = "";
            while (subgroupComboBox.Items.Count != 0) subgroupComboBox.Items.RemoveAt(0);
            while (robotComboBox.Items.Count != 0) robotComboBox.Items.RemoveAt(0);
            foreach (Robot r in robotList) robotComboBox.Items.Add(r);
            foreach (Subgroup s in subgroupList) subgroupComboBox.Items.Add(s);
            subgroupComboBox.SelectedIndex = -1;
            robotComboBox.SelectedIndex = -1;
        }

        private void EditWindow_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void applyAndCloseButton_Click(object sender, EventArgs e)
        {
            applyChanges = true;
            this.Close();
        }

        private void selectCatagoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectCatagoryComboBox.SelectedIndex == -1)
            {

            }
            else
            {
                EditWindow_Load(null, null);
                //enable select item
                selectItemComboBox.Enabled = true;
                //fill select combo box
                while (selectItemComboBox.Items.Count != 0)
                {
                    selectItemComboBox.Items.RemoveAt(0);
                }
                //"BatteryInList"
                if (selectCatagoryComboBox.Text.Equals("BatteryInList"))
                {
                    foreach (Battery b in batteryInList)
                    {
                        selectItemComboBox.Items.Add(b);
                    }
                    field1.Visible = true;
                    fieldEntry1.Visible = true;
                    field2.Visible = true;
                    fieldEntry2.Visible = true;
                }
                //"RobotList"
                else if (selectCatagoryComboBox.Text.Equals("RobotList"))
                {
                    foreach (Robot r in robotList)
                    {
                        selectItemComboBox.Items.Add(r);
                    }
                    field1.Visible = true;
                    fieldEntry1.Visible = true;
                    field2.Visible = false;
                    fieldEntry2.Visible = false;
                }
                //"SubgroupList"
                else if (selectCatagoryComboBox.Text.Equals("SubgroupList"))
                {
                    foreach (Subgroup s in subgroupList)
                    {
                        selectItemComboBox.Items.Add(s);
                    }
                    field1.Visible = true;
                    fieldEntry1.Visible = true;
                    field2.Visible = false;
                    fieldEntry2.Visible = false;
                }
                //"BatteryOutList"
                else if (selectCatagoryComboBox.Text.Equals("BatteryOutList"))
                {
                    foreach (Battery b in batteryOutList)
                    {
                        selectItemComboBox.Items.Add(b);
                    }
                    field1.Visible = true;
                    field2.Visible = true;
                    field3.Visible = true;
                    field4.Visible = true;
                    field5.Visible = true;
                    field6.Visible = true;
                    field7.Visible = true;
                    fieldEntry1.Visible = true;
                    fieldEntry2.Visible = true;
                    fieldEntry3.Visible = true;
                    fieldEntry4.Visible = true;
                    fieldEntry5.Visible = true;
                    subgroupComboBox.Visible = true;
                    robotComboBox.Visible = true;
                }
                else
                {

                }
                if (!selectCatagoryComboBox.Text.Equals("BatteryOutList")) selectItemComboBox.Items.Add("create...");
            }
        }

        private void selectItemComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectItemComboBox.SelectedIndex == -1)
            {

            }
            else
            {
                //enable values and buttons
                if (selectItemComboBox.Text.Equals("create..."))
                {
                    if (fieldEntry1.Visible)
                    {
                        fieldEntry1.ReadOnly = false;
                        fieldEntry1.Enabled = true;
                    }
                    if (fieldEntry1.Visible)
                    {
                        fieldEntry2.ReadOnly = false;
                        fieldEntry2.Enabled = true;
                    }
                    addButton.Enabled = true;
                    modifyButton.Enabled = false;
                    removeButton.Enabled = false;

                    if (selectCatagoryComboBox.Text.Equals("BatteryInList"))
                    {
                        field1.Text = "year";
                        field2.Text = "number";
                        fieldEntry1.Text = "";
                        fieldEntry2.Text = "";
                    }
                    else if (selectCatagoryComboBox.Text.Equals("RobotList"))
                    {
                        field1.Text = "robot";
                        fieldEntry1.Text = "";
                    }
                    else if (selectCatagoryComboBox.Text.Equals("SubgroupList"))
                    {
                        field1.Text = "subgroup";
                        fieldEntry1.Text = "";
                    }
                    else if (selectCatagoryComboBox.Text.Equals("BatteryOutList"))
                    {
                        field1.Text = "year";
                        field2.Text = "number";
                        fieldEntry1.Text = "";
                        fieldEntry2.Text = "";
                    }
                    else
                    {

                    }
                }
                else
                {
                    if (fieldEntry1.Visible)
                    {
                        fieldEntry1.ReadOnly = false;
                        fieldEntry1.Enabled = true;
                    }
                    if (fieldEntry1.Visible)
                    {
                        fieldEntry2.ReadOnly = false;
                        fieldEntry2.Enabled = true;
                    }
                    addButton.Enabled = false;
                    modifyButton.Enabled = true;
                    removeButton.Enabled = true;

                    if (selectCatagoryComboBox.Text.Equals("BatteryInList"))
                    {
                        field1.Text = "year";
                        fieldEntry1.Text = batteryInList[selectItemComboBox.SelectedIndex].batteryYear;
                        field2.Text = "number";
                        fieldEntry2.Text = batteryInList[selectItemComboBox.SelectedIndex].batteryNumber;
                    }
                    else if (selectCatagoryComboBox.Text.Equals("RobotList"))
                    {
                        field1.Text = "robot";
                        fieldEntry1.Text = robotList[selectItemComboBox.SelectedIndex].robotName;
                    }
                    else if (selectCatagoryComboBox.Text.Equals("SubgroupList"))
                    {
                        field1.Text = "subgroup";
                        fieldEntry1.Text = subgroupList[selectItemComboBox.SelectedIndex].groupName;
                    }
                    else if (selectCatagoryComboBox.Text.Equals("BatteryOutList"))
                    {
                        field1.Text = "year";
                        field2.Text = "number";
                        fieldEntry1.Enabled = true;
                        fieldEntry2.Enabled = true;
                        fieldEntry3.Enabled = true;
                        fieldEntry4.Enabled = true;
                        fieldEntry5.Enabled = true;
                        robotComboBox.Enabled = true;
                        subgroupComboBox.Enabled = true;
                        fieldEntry3.ReadOnly = false;
                        fieldEntry4.ReadOnly = false;
                        fieldEntry5.ReadOnly = false;
                        fieldEntry1.Text = batteryOutList[selectItemComboBox.SelectedIndex].batteryYear;
                        fieldEntry2.Text = batteryOutList[selectItemComboBox.SelectedIndex].batteryNumber;
                        fieldEntry3.Text = "" + batteryOutList[selectItemComboBox.SelectedIndex].batteryVoltage;
                        fieldEntry4.Text = batteryOutList[selectItemComboBox.SelectedIndex].checkoutTime;
                        fieldEntry5.Text = batteryOutList[selectItemComboBox.SelectedIndex].estCheckinTime;
                        robotComboBox.SelectedIndex = getRobotListIndex(batteryOutList[selectItemComboBox.SelectedIndex].robot);
                        subgroupComboBox.SelectedIndex = getsubgroupListIndex(batteryOutList[selectItemComboBox.SelectedIndex].subgroup);
                    }
                    else
                    {

                    }
                }
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (selectCatagoryComboBox.Text.Equals("BatteryInList"))
            {
                Battery b = new Battery();
                b.batteryYear = fieldEntry1.Text;
                b.batteryNumber = fieldEntry2.Text;
                batteryInList.Add(b);
            }
            else if (selectCatagoryComboBox.Text.Equals("RobotList"))
            {
                Robot r = new Robot();
                r.robotName = fieldEntry1.Text;
                robotList.Add(r);
            }
            else if (selectCatagoryComboBox.Text.Equals("SubgroupList"))
            {
                Subgroup s = new Subgroup();
                s.groupName = fieldEntry1.Text;
                subgroupList.Add(s);
            }
            else
            {

            }
            selectCatagoryComboBox.SelectedIndex = -1;
            EditWindow_Load(null, null);
        }

        private void modifyButton_Click(object sender, EventArgs e)
        {
            if (selectCatagoryComboBox.Text.Equals("BatteryInList"))
            {
                batteryInList[selectItemComboBox.SelectedIndex].batteryYear = fieldEntry1.Text;
                batteryInList[selectItemComboBox.SelectedIndex].batteryNumber = fieldEntry2.Text;
            }
            else if (selectCatagoryComboBox.Text.Equals("RobotList"))
            {
                robotList[selectItemComboBox.SelectedIndex].robotName = fieldEntry1.Text;
            }
            else if (selectCatagoryComboBox.Text.Equals("SubgroupList"))
            {
                subgroupList[selectItemComboBox.SelectedIndex].groupName = fieldEntry1.Text;
            }
            else if (selectCatagoryComboBox.Text.Equals("BatteryOutList"))
            {
                batteryOutList[selectItemComboBox.SelectedIndex].batteryYear = fieldEntry1.Text;
                batteryOutList[selectItemComboBox.SelectedIndex].batteryNumber = fieldEntry2.Text;
                batteryOutList[selectItemComboBox.SelectedIndex].batteryVoltage = float.Parse(fieldEntry3.Text);
                batteryOutList[selectItemComboBox.SelectedIndex].checkoutTime = fieldEntry4.Text;
                batteryOutList[selectItemComboBox.SelectedIndex].estCheckinTime = fieldEntry5.Text;
                batteryOutList[selectItemComboBox.SelectedIndex].robot = robotComboBox.Text;
                batteryOutList[selectItemComboBox.SelectedIndex].subgroup = subgroupComboBox.Text;
            }
            else
            {

            }
            selectCatagoryComboBox.SelectedIndex = -1;
            EditWindow_Load(null, null);
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (selectCatagoryComboBox.Text.Equals("BatteryInList"))
            {
                batteryInList.RemoveAt(selectItemComboBox.SelectedIndex);
            }
            else if (selectCatagoryComboBox.Text.Equals("RobotList"))
            {
                robotList.RemoveAt(selectItemComboBox.SelectedIndex);
            }
            else if (selectCatagoryComboBox.Text.Equals("SubgroupList"))
            {
                subgroupList.RemoveAt(selectItemComboBox.SelectedIndex);
            }
            else if (selectCatagoryComboBox.Text.Equals("BatteryOutList"))
            {
                batteryOutList.RemoveAt(selectItemComboBox.SelectedIndex);
            }
            else
            {

            }
            selectCatagoryComboBox.SelectedIndex = -1;
            EditWindow_Load(null, null);
        }

        private int getRobotListIndex(string searchTitle)
        {
            for (int i = 0; i < robotList.Count; i++)
            {
                if (robotList[i].robotName.Equals(searchTitle))
                {
                    return i;
                }
            }
            return -1;
        }

        private int getsubgroupListIndex(string searchTitle)
        {
            for (int i = 0; i < subgroupList.Count; i++)
            {
                if (subgroupList[i].groupName.Equals(searchTitle))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
