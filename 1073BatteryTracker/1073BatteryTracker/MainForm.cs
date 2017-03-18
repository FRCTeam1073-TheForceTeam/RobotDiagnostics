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
        private string version = "2.2";
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
        private EditWindow editWindow = new EditWindow();
        private WebClient client = new WebClient();
        private VersionUpdateWindow updateWindow = new VersionUpdateWindow();
        private bool forceClose = false;
        /*
         * TODO:
         * comment code
        */
        //constructer that also adds the table and sets the default paths
        //on the file loader and saver to be the application path
        public MainForm()
        {
            InitializeComponent();
        }
        //checks for updates using dropBox
        private void checkForUpdates()
        {
            //download version.txt
            try
            {
                //"http://willster419.atwebpages.com/Applications/"
                if (File.Exists(appPath + "\\version.txt")) File.Delete(appPath + "\\version.txt");
                client.DownloadFile("http://willster419.atwebpages.com/Applications/1073BatteryTracker/version.txt", appPath + "\\version.txt");
                string newVersion = File.ReadAllText(appPath + "\\version.txt");
                if (newVersion.Equals(version))
                {
                    //up to date
                }
                else
                {
                    //download updateNotes.txt
                    if (File.Exists(appPath + "\\updateNotes.txt")) File.Delete(appPath + "\\updateNotes.txt");
                    client.DownloadFile("http://willster419.atwebpages.com/Applications/1073BatteryTracker/updateNotes.txt", appPath + "\\updateNotes.txt");
                    //prompt user
                    updateWindow.newVersionInfoRTB.Text = File.ReadAllText(appPath + "\\updateNotes.txt");
                    updateWindow.NewVersionAvailableTextBox.Text = "An update is available: " + newVersion;
                    updateWindow.ShowDialog();
                    if (updateWindow.update)
                    {
                        //download new version
                        client.DownloadFile("http://willster419.atwebpages.com/Applications/1073BatteryTracker/1073BatteryTracker.exe", appPath + "\\1073BatteryTracker V_" + newVersion + ".exe");
                        //open new one
                        System.Diagnostics.Process.Start(appPath + "\\1073BatteryTracker V_" + newVersion + ".exe");
                        //close this one
                        forceClose = true;
                        updateWindow.Close();
                        loadingForm.Close();
                        this.Close();
                        return;
                    }
                    else
                    {
                        forceClose = true;
                        updateWindow.Close();
                        loadingForm.Close();
                        this.Close();
                        return;
                    }
                }
            }
            catch (WebException)
            {
                MessageBox.Show("unable to check for updates. Eithor you are offline or the update service is down.");
                return;
            }
        }
        //opens the checkout battery window
        private void checkOut_Click(object sender, EventArgs e)
        {
            batteryOut = new CheckoutForm();
            batteryOut.batteryInList = batteryInList;
            batteryOut.batteryOutList = batteryOutList;
            batteryOut.robotList = robotList;
            batteryOut.subgroupList = subgroupList;
            batteryOut.ShowDialog();
            if (batteryOut.madeChanges)
            {
                this.updateUI();
                this.saveToDisk();
            }
        }
        //opens the checkin battery window
        private void checkIn_Click(object sender, EventArgs e)
        {
            batteryIn = new CheckinForm();
            batteryIn.batteryInList = batteryInList;
            batteryIn.batteryOutList = batteryOutList;
            batteryIn.robotList = robotList;
            batteryIn.subgroupList = subgroupList;
            batteryIn.ShowDialog();
            if (batteryIn.madeChanges)
            {
                this.updateUI();
                this.saveToDisk();
            }
        }
        //adds a battery to the table by increasing the row count, adding a row, and populating it
        public void add(Battery batt)
        {
            tableLayoutPanel1.RowCount++;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tableLayoutPanel1.Controls.Add(new Label { Name = "name" + nameDiff++, Text = batt.batteryYear });
            tableLayoutPanel1.Controls.Add(new Label { Name = "name" + nameDiff++, Text = batt.batteryNumber });
            tableLayoutPanel1.Controls.Add(new Label { Name = "name" + nameDiff++, Text = "" + batt.batteryVoltage });
            tableLayoutPanel1.Controls.Add(new Label { Name = "name" + nameDiff++, Text = batt.subgroup });
            tableLayoutPanel1.Controls.Add(new Label { Name = "name" + nameDiff++, Text = batt.checkoutTime });
            tableLayoutPanel1.Controls.Add(new Label { Name = "name" + nameDiff++, Text = batt.estCheckinTime });
            tableLayoutPanel1.Controls.Add(new Label { Name = "name" + nameDiff++, Text = batt.robot });
        }
        //removes a battery from the table by removing the controlls, removing the row, and decrementing the row count, in that order
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
        //opens the open file dialog
        private void load_Click_1(object sender, EventArgs e)
        {
            this.showTheMessage(1);
            this.readCatagoryList();
            this.readRobotList();
            this.readBattInList();
            this.readBattOutList();
            this.updateUI();
            loadingForm.Hide();
        }
        //opens the save file dialog
        private void save_Click(object sender, EventArgs e)
        {
            //this.doTheSaving();
            this.saveToDisk();
        }
        //sets the default paths of the file save and open to the exe path
        private void setDefaultPaths()
        {
            battInListXml = appPath + "\\battInList.xml";
            battOutListXml = appPath + "\\battOutList.xml";
            robotListXml = appPath + "\\robotList.xml";
            subgroupListXml = appPath + "\\subgroupList.xml";
        }
        //make this
        private void updateUI()
        {
            this.clearList4Update();
            foreach (Battery b in batteryOutList)
            {
                this.add(b);
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
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this.Controls.Add(tableLayoutPanel1);
        }
        //button that resets the entire database
        private void clearTheList_Click(object sender, EventArgs e)
        {
            //messagebox to confirm
            DialogResult result = MessageBox.Show("This will clear ALL database entries, including robot and subgroup lists!!!\ncontinue?", "are you sure?", MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                //clears UI
                this.clearList4Update();

                //clears databases from memory
                batteryInList = new List<Battery>();
                batteryOutList = new List<Battery>();
                robotList = new List<Robot>();
                subgroupList = new List<Subgroup>();

                //delets xml files
                if (File.Exists(battInListXml)) File.Delete(battInListXml);
                if (File.Exists(battOutListXml)) File.Delete(battOutListXml);
                if (File.Exists(robotListXml)) File.Delete(robotListXml);
                if (File.Exists(subgroupListXml)) File.Delete(subgroupListXml);
                //reloads xml files
                this.readBattInList();
                this.readBattOutList();
                this.readCatagoryList();
                this.readRobotList();
                //updates UI
                this.updateUI();
            }
            else
            {

            }
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
            this.setDefaultPaths();
            //run it once so the location is updated
            this.showTheMessage(1);
            this.checkForUpdates();
            if (forceClose)
            {
                loadingForm.Close();
                this.Close();
            }
            else
            {
                this.readCatagoryList();
                this.readRobotList();
                this.readBattInList();
                this.readBattOutList();
                this.makeTheTable();
                this.updateUI();
                loadingForm.Hide();
            }
        }

        private void modifyCatagoriesButton_Click(object sender, EventArgs e)
        {
            editWindow = new EditWindow();
            //setup refrence links
            editWindow.batteryInList = batteryInList;
            editWindow.batteryOutList = batteryOutList;
            editWindow.robotList = robotList;
            editWindow.subgroupList = subgroupList;
            //setup editWindow for modifying 3 regular catagories
            while (editWindow.selectCatagoryComboBox.Items.Count != 0)
            {
                editWindow.selectCatagoryComboBox.Items.RemoveAt(0);
            }
            editWindow.selectCatagoryComboBox.Items.Add("BatteryInList");//index 0
            editWindow.selectCatagoryComboBox.Items.Add("RobotList");//index 1
            editWindow.selectCatagoryComboBox.Items.Add("SubgroupList");//index 2
            editWindow.ShowDialog();
            this.updateUI();
            this.saveToDisk();
        }

        private void readBattOutList()
        {
            if (!File.Exists(battOutListXml)) this.writeBattOutList();
            batteryOutList = new List<Battery>();
            XmlReader = new XmlTextReader(battOutListXml);
            Battery b = new Battery();
            XmlReader.MoveToContent();
            while (XmlReader.Read())
            {
                if (XmlReader.Name.Equals("battery"))
                {
                    b = new Battery();
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
                        else
                        {
                            if (XmlReader.Name.Equals("battery"))
                            {
                                batteryOutList.Add(b);
                                b = new Battery();
                            }
                            else
                            {

                            }
                        }
                    }
                }
            }
            XmlReader.Close();
            //reset ui prolly
        }

        private void readBattInList()
        {
            if (!File.Exists(battInListXml)) this.writeBattInList();
            batteryInList = new List<Battery>();
            XmlReader = new XmlTextReader(battInListXml);
            Battery b = new Battery();
            XmlReader.MoveToContent();
            while (XmlReader.Read())
            {
                if (XmlReader.Name.Equals("battery"))
                {
                    b = new Battery();
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
                        else
                        {
                            if (XmlReader.Name.Equals("battery"))
                            {
                                batteryInList.Add(b);
                                b = new Battery();
                            }
                            else
                            {

                            }
                        }
                    }
                }
                else { }
            }
            XmlReader.Close();
            //reset ui prolly
        }

        private void readRobotList()
        {
            if (!File.Exists(robotListXml)) this.writeRobotList();
            robotList = new List<Robot>();
            XmlReader = new XmlTextReader(robotListXml);
            XmlReader.MoveToContent();
            while (XmlReader.Read())
            {
                if (XmlReader.Name.Equals("robot"))
                {
                    while (XmlReader.Read())
                    {
                        if (XmlReader.IsStartElement())
                        {
                            switch (XmlReader.Name)
                            {
                                //parse everything into it
                                case "robotName":
                                    robotList.Add(new Robot(XmlReader.ReadString()));
                                    break;
                            }
                        }
                    }
                }
            }
            XmlReader.Close();
            //reset ui prolly
        }

        private void readCatagoryList()
        {
            if (!File.Exists(subgroupListXml)) this.writeCatagoryList();
            subgroupList = new List<Subgroup>();
            XmlReader = new XmlTextReader(subgroupListXml);
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
                                    subgroupList.Add(new Subgroup(XmlReader.ReadString()));
                                    break;
                            }
                        }
                        
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

        private void editEntryButton_Click(object sender, EventArgs e)
        {
            //setup editWindow for checkOutList pre-selected
            editWindow = new EditWindow();
            //setup refrence links
            editWindow.batteryInList = batteryInList;
            editWindow.batteryOutList = batteryOutList;
            editWindow.robotList = robotList;
            editWindow.subgroupList = subgroupList;
            //setup editWindow for modifying 3 regular catagories
            while (editWindow.selectCatagoryComboBox.Items.Count != 0)
            {
                editWindow.selectCatagoryComboBox.Items.RemoveAt(0);
            }
            editWindow.selectCatagoryComboBox.Items.Add("BatteryOutList");//index 0
            editWindow.ShowDialog();
            this.updateUI();
            this.saveToDisk();
        }

        private void saveToDisk()
        {
            this.writeBattInList();
            this.writeBattOutList();
            this.writeCatagoryList();
            this.writeRobotList();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (forceClose)
            {
                
            }
            else
            {
                this.saveToDisk();
            }
        }
    }
}
