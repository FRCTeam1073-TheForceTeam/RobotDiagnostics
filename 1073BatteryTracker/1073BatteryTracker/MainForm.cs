using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Windows;
using System.Net;
using System.Web;
using System.Diagnostics;
using Microsoft.Win32;
using System.Xml;

namespace _1073BatteryTracker
{
    public partial class MainForm : Form
    {   //all the private and public instance variables that are needed
        private String appPath = Path.GetDirectoryName(Application.ExecutablePath);
        private String battOutListXml;
        private String battInListXml;
        private String robotListXml;
        private String subgroupListXml;
        private XmlTextReader XmlReader;
        private XmlTextWriter XmlWriter;
        private CheckoutForm batteryOut = new CheckoutForm();
        private CheckinForm batteryIn = new CheckinForm();
        private TableLayoutPanel tableLayoutPanel1;
        private int nameDiff = 0;
        private PleaseWait loadingForm = new PleaseWait();
        private List<Robot> robotList = new List<Robot>();
        private List<Subgroup> subgroupList = new List<Subgroup>();
        public List<Battery> batteryOutList = new List<Battery>();
        private List<Battery> batteryInList = new List<Battery>();
        private EditWindow ew = new EditWindow();
        //constructer that also adds the table and sets the default paths
        //on the file loader and saver to be the application path
        public MainForm()
        {
            InitializeComponent();

        }
        //opens the checkout battery window
        private void checkOut_Click(object sender, EventArgs e)
        {
            batteryOut.ShowDialog();
        }
        //opens the checkin battery window
        private void checkIn_Click(object sender, EventArgs e)
        {
            batteryIn.ShowDialog();
        }
        //adds a battery to the table by increasing the row count, adding
        //a row, and populating it
        public void add(Battery batt)
        {
            tableLayoutPanel1.RowCount++;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableLayoutPanel1.Controls.Add(new Label { Name = "name" + nameDiff++, Text = batt.getYear() });
            tableLayoutPanel1.Controls.Add(new Label { Name = "name" + nameDiff++, Text = batt.getNumber() });
            tableLayoutPanel1.Controls.Add(new Label { Name = "name" + nameDiff++, Text = "" + batt.getVoltage() });
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
            //messagebox letting them know about it clearing
            this.showTheMessage(2);
            int index = this.batteryOutList.Count - 1;
            while (index != -1)
            {
                this.batteryOutList.RemoveAt(index);
                this.remove(index);
                index--;
            }
            loadingForm.Hide();
            this.Show();
        }
        //clears the entire table
        private void clearList4Update()
        {
            //messagebox about the list updating
            this.showTheMessage(1);
            int index = this.tableLayoutPanel1.RowCount - 1;
            while (index != -1)
            {
                this.remove(index);
                index--;
            }
            loadingForm.Hide();
            this.Show();
        }
        //called after the battlist is changed. this makes the
        //changes reflected in the table
        public void updateList()
        {
            this.clearList4Update();
            for (int i = 0; i < batteryOutList.Count; i++)
            {
                Battery batt = this.batteryOutList[i];
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
            this.openFileDialog1.InitialDirectory = appPath;
            this.saveFileDialog1.InitialDirectory = appPath;
            this.saveFileDialog1.Filter = "Text File|*.txt";
            this.saveFileDialog1.Title = "Save to le file XD";
            battInListXml = appPath + "\\battInList.xml";
            battOutListXml = appPath + "\\battOutList.xml";
            robotListXml = appPath + "\\robotList.xml";
            subgroupListXml = appPath + "\\subgroupList.xml";
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
                if (line == null) break;
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
            catch (FormatException)
            {
                MessageBox.Show("Loading Failed");
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
            this.batteryOutList.Insert(batteryNumbah, batt);
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
                for (int i = 0; i < batteryOutList.Count; i++)
                {
                    batt = batteryOutList[i];
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

        private void showTheMessage(int condition)
        {
            loadingForm.setLocation(this.Location.X + 200, this.Location.Y + 200);
            loadingForm.setText(condition);
            this.Hide();
            loadingForm.Show();
            Application.DoEvents();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.makeTheTable();
            this.setDefaultPaths();
            //run it once so the location is updated
            this.showTheMessage(1);
            loadingForm.Hide();
        }

        private void modifyCatagoriesButton_Click(object sender, EventArgs e)
        {
            ew.ShowDialog();
        }

        private void readBattOutList()
        {
            batteryOutList = new List<Battery>();
            XmlReader = new XmlTextReader(battOutListXml);
            Battery b = new Battery();
            XmlReader.Read();
            XmlReader.Read();
            XmlReader.Read();
            XmlReader.Read();
            XmlReader.Read();
            XmlReader.Read();
            while (XmlReader.Read())
            {
                if (XmlReader.Name.Equals("Battery"))
                {
                    while (XmlReader.Read())
                    {
                        if (XmlReader.IsStartElement())
                        {
                            switch (XmlReader.Name)
                            {
                                //parse everything into it
                                case "year":
                                    b.batteryYear = XmlReader.ReadString();
                                    break;
                                case "number":
                                    b.batteryNumber = XmlReader.ReadString();
                                    break;
                                case "voltage":
                                    b.batteryVoltage = float.Parse(XmlReader.ReadString());
                                    break;
                                case "checkoutTime":
                                    b.checkoutTime = XmlReader.ReadString();
                                    break;
                                case "checkinTime":
                                    b.estCheckinTime = XmlReader.ReadString();
                                    break;
                                case "subgroup":
                                    b.subgroup = XmlReader.ReadString();
                                    break;
                                case "robot":
                                    b.robot = XmlReader.ReadString();
                                    break;
                            }
                        }
                        batteryOutList.Add(b);
                    }
                }
            }
            XmlReader.Close();
            //reset ui prolly
        }

        private void readBattInList()
        {
            batteryInList = new List<Battery>();
            XmlReader = new XmlTextReader(battInListXml);
            Battery b = new Battery();
            XmlReader.Read();
            XmlReader.Read();
            XmlReader.Read();
            XmlReader.Read();
            XmlReader.Read();
            XmlReader.Read();
            while (XmlReader.Read())
            {
                if (XmlReader.Name.Equals("Battery"))
                {
                    while (XmlReader.Read())
                    {
                        if (XmlReader.IsStartElement())
                        {
                            switch (XmlReader.Name)
                            {
                                //parse everything into it
                                case "year":
                                    b.batteryYear = XmlReader.ReadString();
                                    break;
                                case "number":
                                    b.batteryNumber = XmlReader.ReadString();
                                    break;
                            }
                        }
                        batteryInList.Add(b);
                    }
                }
            }
            XmlReader.Close();
            //reset ui prolly
        }

        private void readRobotList()
        {
            robotList = new List<Robot>();
            XmlReader = new XmlTextReader(robotListXml);
            Robot r = new Robot();
            XmlReader.Read();
            XmlReader.Read();
            XmlReader.Read();
            XmlReader.Read();
            XmlReader.Read();
            XmlReader.Read();
            while (XmlReader.Read())
            {
                if (XmlReader.Name.Equals("Robot"))
                {
                    while (XmlReader.Read())
                    {
                        if (XmlReader.IsStartElement())
                        {
                            switch (XmlReader.Name)
                            {
                                //parse everything into it
                                case "robotName":
                                    r.robotName = XmlReader.ReadString();
                                    break;
                            }
                        }
                        robotList.Add(r);
                    }
                }
            }
            XmlReader.Close();
            //reset ui prolly
        }

        private void readCatagoryList()
        {
            subgroupList = new List<Subgroup>();
            XmlReader = new XmlTextReader(subgroupListXml);
            Subgroup s = new Subgroup();
            XmlReader.Read();
            XmlReader.Read();
            XmlReader.Read();
            XmlReader.Read();
            XmlReader.Read();
            XmlReader.Read();
            while (XmlReader.Read())
            {
                if (XmlReader.Name.Equals("subgroup"))
                {
                    while (XmlReader.Read())
                    {
                        if (XmlReader.IsStartElement())
                        {
                            switch (XmlReader.Name)
                            {
                                //parse everything into it
                                case "groupName":
                                    s.groupName = XmlReader.ReadString();
                                    break;
                            }
                        }
                        subgroupList.Add(s);
                    }
                }
            }
            XmlReader.Close();
            //reset ui prolly
        }

        private void writeBattOutList()
        {
            if (File.Exists(battOutListXml)) File.Delete(battOutListXml);
            XmlWriter = new XmlTextWriter(battOutListXml, Encoding.UTF8);
            XmlWriter.Formatting = Formatting.Indented;
            XmlWriter.WriteStartDocument();
            XmlWriter.WriteStartElement(Path.GetFileName(battOutListXml));
            XmlWriter.WriteStartElement("batteriesOut");
            foreach (Battery b in batteryOutList)
            {
                XmlWriter.WriteStartElement("battery");
                XmlWriter.WriteElementString("year", b.batteryYear);
                XmlWriter.WriteElementString("number", b.batteryNumber);
                XmlWriter.WriteElementString("voltage", "" + b.batteryVoltage);
                XmlWriter.WriteElementString("checkoutTime", b.checkoutTime);
                XmlWriter.WriteElementString("checkinTime", b.estCheckinTime);
                XmlWriter.WriteElementString("subgroup", b.subgroup);
                XmlWriter.WriteElementString("robot", b.robot);
                XmlWriter.WriteEndElement();
            }
            XmlWriter.WriteEndElement();
            XmlWriter.WriteEndElement();
            XmlWriter.Close();
        }

        private void writeBattInList()
        {
            if (File.Exists(battInListXml)) File.Delete(battInListXml);
            XmlWriter = new XmlTextWriter(battInListXml, Encoding.UTF8);
            XmlWriter.Formatting = Formatting.Indented;
            XmlWriter.WriteStartDocument();
            XmlWriter.WriteStartElement(Path.GetFileName(battInListXml));
            XmlWriter.WriteStartElement("batteriesIn");
            foreach (Battery b in batteryInList)
            {
                XmlWriter.WriteStartElement("battery");
                XmlWriter.WriteElementString("year", b.batteryYear);
                XmlWriter.WriteElementString("number", b.batteryNumber);
                XmlWriter.WriteEndElement();
            }
            XmlWriter.WriteEndElement();
            XmlWriter.WriteEndElement();
            XmlWriter.Close();
        }

        private void writeRobotList()
        {
            if (File.Exists(robotListXml)) File.Delete(robotListXml);
            XmlWriter = new XmlTextWriter(robotListXml, Encoding.UTF8);
            XmlWriter.Formatting = Formatting.Indented;
            XmlWriter.WriteStartDocument();
            XmlWriter.WriteStartElement(Path.GetFileName(robotListXml));
            XmlWriter.WriteStartElement("robots");
            foreach (Robot r in robotList)
            {
                XmlWriter.WriteStartElement("robot");
                XmlWriter.WriteElementString("robotName", r.robotName);
                XmlWriter.WriteEndElement();
            }
            XmlWriter.WriteEndElement();
            XmlWriter.WriteEndElement();
            XmlWriter.Close();
        }

        private void writeCatagoryList()
        {
            if (File.Exists(subgroupListXml)) File.Delete(subgroupListXml);
            XmlWriter = new XmlTextWriter(subgroupListXml, Encoding.UTF8);
            XmlWriter.Formatting = Formatting.Indented;
            XmlWriter.WriteStartDocument();
            XmlWriter.WriteStartElement(Path.GetFileName(subgroupListXml));
            XmlWriter.WriteStartElement("subgroups");
            foreach (Subgroup s in subgroupList)
            {
                XmlWriter.WriteStartElement("subgroup");
                XmlWriter.WriteElementString("groupName", s.groupName);
                XmlWriter.WriteEndElement();
            }
            XmlWriter.WriteEndElement();
            XmlWriter.WriteEndElement();
            XmlWriter.Close();
        }
    }
}
