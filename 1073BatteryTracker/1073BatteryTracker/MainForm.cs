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
    {
        private String appPath;
        private CheckoutForm batteryOut = new CheckoutForm();
        private CheckinForm batteryIn = new CheckinForm();
        public ArrayList battList = new ArrayList();
        private TableLayoutPanel tableLayoutPanel1;
        private int nameDiff = 0;
        public MainForm()
        {
            InitializeComponent();
            this.makeTheTable();
            this.setDefaultPaths();
        }
            
        private void button1_Click(object sender, EventArgs e)
        {
            batteryOut.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            batteryIn.Show();
        }

        public void add(Battery batt)
        {
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableLayoutPanel1.RowCount += 1;
            tableLayoutPanel1.Controls.Add(new Label { Name = "name" + nameDiff++, Text = batt.getYear() });
            tableLayoutPanel1.Controls.Add(new Label { Name = "name" + nameDiff++, Text = batt.getNumber() });
            tableLayoutPanel1.Controls.Add(new Label { Name = "name" + nameDiff++, Text = ""+batt.getVoltage() });
            tableLayoutPanel1.Controls.Add(new Label { Name = "name" + nameDiff++, Text = batt.getSubgroup() });
            tableLayoutPanel1.Controls.Add(new Label { Name = "name" + nameDiff++, Text = batt.getFormatedCheckoutTime() });
            tableLayoutPanel1.Controls.Add(new Label { Name = "name" + nameDiff++, Text = batt.getEstCheckinTime() });
            tableLayoutPanel1.Controls.Add(new Label { Name = "name" + nameDiff++, Text = batt.getRobot() });
        }

        public void remove(int index)
        {
            tableLayoutPanel1.Controls.RemoveAt(index);
            tableLayoutPanel1.Controls.RemoveAt(index);
            tableLayoutPanel1.Controls.RemoveAt(index);
            tableLayoutPanel1.Controls.RemoveAt(index);
            tableLayoutPanel1.Controls.RemoveAt(index);
            tableLayoutPanel1.Controls.RemoveAt(index);
            tableLayoutPanel1.Controls.RemoveAt(index);
            tableLayoutPanel1.RowStyles.RemoveAt(index);
            tableLayoutPanel1.RowCount--;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.openFileDialog1.ShowDialog();
            
        }

        private void exitForm_Click(object sender, EventArgs e)
        {
            this.doTheSaving();
        }

        private void setDefaultPaths()
        {
            appPath = Path.GetDirectoryName(Application.ExecutablePath);
            this.openFileDialog1.InitialDirectory = appPath;
            this.saveFileDialog1.InitialDirectory = appPath;
            this.saveFileDialog1.Filter = "Text File|*.txt";
            this.saveFileDialog1.Title = "Save to le text file XD";
        }

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
            batt.isNowInUse(Boolean.Parse(parser[1].Substring(8)));
            if (!batt.isInUse()) return;
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

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.doTheSaving();
            this.clearList();
        }

        private void doTheSaving()
        {
            StringBuilder sb = new StringBuilder();
            Battery batt;
            this.saveFileDialog1.ShowDialog();
            if (this.saveFileDialog1.FileName != "")
            {
                for (int i = 0; i < battList.Count; i++)
                {
                    batt = (Battery) battList[i];
                    String temp;
                    if (i < 10)
                    {
                        temp = "0" + i;
                    }
                    else { temp = "" + i; }
                    sb.Append("Batt=" + temp + ",isInUse=" + batt.isInUseText() + ",Year=" + batt.getYear() + ",Number=" + batt.getNumber() + ",Voltage=" + batt.getVoltage() + ",Subgroup=" + batt.getSubgroup() + ",timeCheckedOut=" + batt.getFormatedCheckoutTime() + ",EstCheckin=" + batt.getEstCheckinTime() + ",Robot=" + batt.getRobot() + "\n");
                }
                try
                {
                    File.WriteAllText(saveFileDialog1.FileName, sb.ToString());
                }
                catch (IOException)
                {
                    MessageBox.Show("Unable to save file, please try again");
                }
            }
        }

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
            this.Controls.Add(tableLayoutPanel1);
        }

        private void clearTheList_Click(object sender, EventArgs e)
        {
            this.clearList();
        }
    }
}
