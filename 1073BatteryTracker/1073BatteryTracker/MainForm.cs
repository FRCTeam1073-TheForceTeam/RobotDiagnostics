using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Windows;

namespace _1073BatteryTracker
{
    public partial class MainForm : Form
    {   //all the private and public instance variables that are needed
        private String appPath;
        private CheckoutForm batteryOut = new CheckoutForm();
        private CheckinForm batteryIn = new CheckinForm();
        public List<Battery> battList = new List<Battery>();
        private TableLayoutPanel tableLayoutPanel1;
        private int nameDiff = 0;
        //constructer that also adds the table and sets the default paths
        //on the file loader and saver to be the application path
        public MainForm()
        {
            InitializeComponent();
            this.makeTheTable();
            this.setDefaultPaths();
        }
        //opens the checkout battery window
        private void checkOut_Click(object sender, EventArgs e)
        {
            batteryOut.Show();
        }
        //opens the checkin battery window
        private void checkIn_Click(object sender, EventArgs e)
        {
            batteryIn.Show();
        }
        //adds a battery to the table by increasing the row count, adding
        //a row, and populating it
        public void add(Battery batt)
        {
            tableLayoutPanel1.RowCount++;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableLayoutPanel1.Controls.Add(new Label { Name = "name" + nameDiff++, Text = batt.getYear() });
            tableLayoutPanel1.Controls.Add(new Label { Name = "name" + nameDiff++, Text = batt.getNumber() });
            tableLayoutPanel1.Controls.Add(new Label { Name = "name" + nameDiff++, Text = ""+batt.getVoltage() });
            tableLayoutPanel1.Controls.Add(new Label { Name = "name" + nameDiff++, Text = batt.getSubgroup() });
            tableLayoutPanel1.Controls.Add(new Label { Name = "name" + nameDiff++, Text = batt.getFormatedCheckoutTime() });
            tableLayoutPanel1.Controls.Add(new Label { Name = "name" + nameDiff++, Text = batt.getEstCheckinTime() });
            tableLayoutPanel1.Controls.Add(new Label { Name = "name" + nameDiff++, Text = batt.getRobot() });
        }
        //removes a battery from the table by removing the controlls,
        //removing the row, and decrementing the row count, in that order
        public void remove(int index)
        {
            try
            {
            tableLayoutPanel1.Controls.RemoveAt(index);
            tableLayoutPanel1.Controls.RemoveAt(index);
            tableLayoutPanel1.Controls.RemoveAt(index);
            tableLayoutPanel1.Controls.RemoveAt(index);
            tableLayoutPanel1.Controls.RemoveAt(index);
            tableLayoutPanel1.Controls.RemoveAt(index);
            tableLayoutPanel1.Controls.RemoveAt(index);
            }
            catch (ArgumentOutOfRangeException) { }
            tableLayoutPanel1.RowStyles.RemoveAt(index);
            tableLayoutPanel1.RowCount--;
        }
        //clears the entire table and List of batteries
        private void clearList()
        {
            int index = this.battList.Count - 1;
            while (index != -1)
            {
                this.battList.RemoveAt(index);
                this.remove(index);
                index--;
            }
        }
        //clears the entire table
        private void clearList4Update()
        {
            int index = this.tableLayoutPanel1.RowCount - 1;
            while (index != -1)
            {
                this.remove(index);
                index--;
            }
        }
        //called after the battlist is changed. this makes the
        //changes reflected in the table
        public void updateList()
        {
            this.clearList4Update();
            for (int i = 0; i < battList.Count; i++)
            {
                Battery batt = this.battList[i];
                this.add(batt);
            }
        }
        //opens the open file dialog
        private void load_Click_1(object sender, EventArgs e)
        {
            this.openFileDialog1.ShowDialog();
        }
        //opens the save file dialog
        private void save_Click(object sender, EventArgs e)
        {
            this.doTheSaving();
        }
        //sets the default paths of the file save and open to the exe path
        private void setDefaultPaths()
        {
            appPath = Path.GetDirectoryName(Application.ExecutablePath);
            this.openFileDialog1.InitialDirectory = appPath;
            this.saveFileDialog1.InitialDirectory = appPath;
            this.saveFileDialog1.Filter = "Text File|*.txt";
            this.saveFileDialog1.Title = "Save to le text file XD";
        }
        //reads each line in the file to be parsed. parsed in the below method
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            this.clearList();
            String line;
            System.IO.StreamReader file = new StreamReader(openFileDialog1.FileName);
            while (true)
            {
                line = file.ReadLine();
                if(line==null)break;
                this.parseLine(line);
            }
            file.Close();
        }
        //takes each line from the above method, and splits it into a string array
        //each array index has part of a battery parameter in it, they are used
        //to make the battery
        private void parseLine(String s)
        {
            char delim = ',';
            String[] parser = s.Split(delim);
            int batteryNumbah;
            try
            {
                batteryNumbah = int.Parse(parser[0].Substring(5));
            }
            catch (FormatException) { MessageBox.Show("Loading Failed");
            return;
            }
            Battery batt = new Battery();
            batt.setYear(parser[2].Substring(5));
            batt.setNumber(parser[3].Substring(7));
            batt.setVoltage(float.Parse(parser[4].Substring(8)));
            batt.setSubgroup(parser[5].Substring(9));
            batt.setCheckoutTime(parser[6].Substring(15));
            batt.setEstCheckinTime(parser[7].Substring(11));
            batt.setRobot(parser[8].Substring(6));
            this.battList.Insert(batteryNumbah, batt);
            this.add(batt);
        }
        //button that saves AND clears the form
        private void saveAndClear_Click_1(object sender, EventArgs e)
        {
            this.doTheSaving();
            this.clearList();
        }
        //saves the file by writing each battery parameter to a line of a text file
        private void doTheSaving()
        {
            StringBuilder sb = new StringBuilder();
            Battery batt;
            this.saveFileDialog1.ShowDialog();
            if (this.saveFileDialog1.FileName != "")
            {
                for (int i = 0; i < battList.Count; i++)
                {
                    batt = battList[i];
                    String temp;
                    if (i < 10)
                    {
                        temp = "0" + i;
                    }
                    else { temp = "" + i; }
                    sb.Append("Batt=" + temp + ",isInUse=" + ",Year=" + batt.getYear() + ",Number=" + batt.getNumber() + ",Voltage=" + batt.getVoltage() + ",Subgroup=" + batt.getSubgroup() + ",timeCheckedOut=" + batt.getFormatedCheckoutTime() + ",EstCheckin=" + batt.getEstCheckinTime() + ",Robot=" + batt.getRobot() + "\n");
                }
                try
                {
                    File.WriteAllText(saveFileDialog1.FileName, sb.ToString());
                }
                catch (IOException)
                {
                    MessageBox.Show("File unable so save, please retry again");
                }
            }
        }
        //makes the table in the main form
        private void makeTheTable()
        {
            tableLayoutPanel1 = new TableLayoutPanel
            {
                AutoScroll = true,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
                ColumnCount = 7,
                Location = new System.Drawing.Point(5, 25),
                RowCount = 1,
                TabIndex = 7,
                Height = 300,
                Width = 650,
                GrowStyle = TableLayoutPanelGrowStyle.AddRows,
            };
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this.Controls.Add(tableLayoutPanel1);
        }
        //button that clears the list
        private void clearTheList_Click(object sender, EventArgs e)
        {
            this.clearList();
        }
    }
}
