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
        public ArrayList editList = new ArrayList();
        ArrayList arow1 = new ArrayList();
        ArrayList arow2 = new ArrayList();
        ArrayList arow3 = new ArrayList();
        ArrayList arow4 = new ArrayList();
        ArrayList arow5 = new ArrayList();
        ArrayList arow6 = new ArrayList();
        ArrayList arow7 = new ArrayList();
        ArrayList arow8 = new ArrayList();
        ArrayList arow9 = new ArrayList();
        ArrayList arow10 = new ArrayList();
        ArrayList allRows = new ArrayList();

        public MainForm()
        {
            InitializeComponent();
            this.fillArrays();
            this.updateList();
            this.setDefaultPaths();
        }

        private void fillArrays()
        {
            battList.Add(new Battery());
            battList.Add(new Battery());
            battList.Add(new Battery());
            battList.Add(new Battery());
            battList.Add(new Battery());
            battList.Add(new Battery());
            battList.Add(new Battery());
            battList.Add(new Battery());
            battList.Add(new Battery());
            battList.Add(new Battery());
            battList.Add(new Battery());
            //************************//
            /*editList.Add(this.batt1Edit);
            editList.Add(this.batt2Edit);
            editList.Add(this.batt3Edit);
            editList.Add(this.batt4Edit);
            editList.Add(this.batt5Edit);
            editList.Add(this.batt6Edit);
            editList.Add(this.batt7Edit);
            editList.Add(this.batt8Edit);
            editList.Add(this.batt9Edit);
            editList.Add(this.batt10Edit);*/
            //************************//
            allRows.Add(arow1);
            allRows.Add(arow2);
            allRows.Add(arow3);
            allRows.Add(arow4);
            allRows.Add(arow5);
            allRows.Add(arow6);
            allRows.Add(arow7);
            allRows.Add(arow8);
            allRows.Add(arow9);
            allRows.Add(arow10);
            //************************//
            arow1.Add(this.batt1Year);
            arow1.Add(this.batt1Number);
            arow1.Add(this.batt1Charge);
            arow1.Add(this.batt1Subgroup);
            arow1.Add(this.batt1CheckoutTime);
            arow1.Add(this.batt1EstCheckin);
            arow1.Add(this.batt1Robot);

            arow2.Add(this.batt2Year);
            arow2.Add(this.batt2Number);
            arow2.Add(this.batt2Charge);
            arow2.Add(this.batt2Subgroup);
            arow2.Add(this.batt2CheckoutTime);
            arow2.Add(this.batt2EstCheckin);
            arow2.Add(this.batt2Robot);

            arow3.Add(this.batt3Year);
            arow3.Add(this.batt3Number);
            arow3.Add(this.batt3Charge);
            arow3.Add(this.batt3Subgroup);
            arow3.Add(this.batt3CheckoutTime);
            arow3.Add(this.batt3EstCheckin);
            arow3.Add(this.batt3Robot);

            arow4.Add(this.batt4Year);
            arow4.Add(this.batt4Number);
            arow4.Add(this.batt4Charge);
            arow4.Add(this.batt4Subgroup);
            arow4.Add(this.batt4CheckoutTime);
            arow4.Add(this.batt4EstCheckin);
            arow4.Add(this.batt4Robot);

            arow5.Add(this.batt5Year);
            arow5.Add(this.batt5Number);
            arow5.Add(this.batt5Charge);
            arow5.Add(this.batt5Subgroup);
            arow5.Add(this.batt5CheckoutTime);
            arow5.Add(this.batt5EstCheckin);
            arow5.Add(this.batt5Robot);

            arow6.Add(this.batt6Year);
            arow6.Add(this.batt6Number);
            arow6.Add(this.batt6Charge);
            arow6.Add(this.batt6Subgroup);
            arow6.Add(this.batt6CheckoutTime);
            arow6.Add(this.batt6EstCheckin);
            arow6.Add(this.batt6Robot);

            arow7.Add(this.batt7Year);
            arow7.Add(this.batt7Number);
            arow7.Add(this.batt7Charge);
            arow7.Add(this.batt7Subgroup);
            arow7.Add(this.batt7CheckoutTime);
            arow7.Add(this.batt7EstCheckin);
            arow7.Add(this.batt7Robot);

            arow8.Add(this.batt8Year);
            arow8.Add(this.batt8Number);
            arow8.Add(this.batt8Charge);
            arow8.Add(this.batt8Subgroup);
            arow8.Add(this.batt8CheckoutTime);
            arow8.Add(this.batt8EstCheckin);
            arow8.Add(this.batt8Robot);

            arow9.Add(this.batt9Year);
            arow9.Add(this.batt9Number);
            arow9.Add(this.batt9Charge);
            arow9.Add(this.batt9Subgroup);
            arow9.Add(this.batt9CheckoutTime);
            arow9.Add(this.batt9EstCheckin);
            arow9.Add(this.batt9Robot);

            arow10.Add(this.batt10Year);
            arow10.Add(this.batt10Number);
            arow10.Add(this.batt10Charge);
            arow10.Add(this.batt10Subgroup);
            arow10.Add(this.batt10CheckoutTime);
            arow10.Add(this.batt10EstCheckin);
            arow10.Add(this.batt10Robot);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            batteryOut.Show();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            batteryIn.Show();
           
        }
        public void updateList()
        {
            for (int i = 0; i < allRows.Count; i++)
            {
                Battery batt;
                try
                {
                    batt = (Battery)battList[i];
                }
                catch (ArgumentOutOfRangeException) { return; }
                 if (!batt.isInUse())
                 {
                     for (int j = 0; j < arow1.Count; j++)
                     {
                         ArrayList theRow = (ArrayList)allRows[i];
                         Label theLabel = (Label)theRow[j];
                         theLabel.Text = null;
                     }
                 }
                 else
                 {
                     ArrayList theRow = (ArrayList)allRows[i];
                     Label year = (Label)theRow[0];
                     Label number = (Label)theRow[1];
                     Label charge = (Label)theRow[2];
                     Label subgroup = (Label)theRow[3];
                     Label timeOut = (Label)theRow[4];
                     Label estIn = (Label)theRow[5];
                     Label Robot = (Label)theRow[6];
                     //Label ActualIn = (Label)theRow[7];
                     year.Text = batt.getBatteryYear();
                     number.Text = batt.getBatteryNumber();
                     charge.Text = "" + batt.getBatteryVoltage();
                     subgroup.Text = batt.getSubgroup();
                     timeOut.Text = batt.getFormatedCheckoutTime();
                     estIn.Text = batt.getEstCheckinTime();
                     Robot.Text = batt.getRobot();
                     //ActualIn.Text = batt.getActCheckinTime();
                 }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.openFileDialog1.ShowDialog();
            
        }

        private void exitForm_Click(object sender, EventArgs e)
        {
            this.doTheSaving();
        }

        private void settBattDisp(int year, int number, float voltage)
        {
            if(year==0)

            this.batt1Year.Text = "" + year;
            this.batt1Number.Text = "" + number;
            this.batt1Charge.Text = "" + voltage;
        }

        private void editSelected_Click(object sender, EventArgs e)
        {
            int index = this.getIndexOfSelectedButton();
            if (index == -1)
                MessageBox.Show("Feature Removed");
            else
            {
                Battery batt = (Battery) battList[index];
                if (!batt.isInUse())
                    MessageBox.Show("Selected Row Contains no battery exist");
                
                    
            }
        }

        private int getIndexOfSelectedButton()
        {
            for (int i = 0; i < editList.Count; i++)
            {
                RadioButton theButton = (RadioButton)editList[i];
                if (theButton.Checked)
                {
                    return i;
                }
            }
            return -1;
        }

        private void setDefaultPaths()
        {
            appPath = Path.GetDirectoryName(Application.ExecutablePath);
            this.openFileDialog1.InitialDirectory = appPath;
            this.saveFileDialog1.InitialDirectory = appPath;
            this.saveFileDialog1.Filter = "Text File|*.txt";
            this.saveFileDialog1.Title = "Save to text file";
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            String line;
            System.IO.StreamReader file = new StreamReader(openFileDialog1.FileName);
            while (true)
            {
                line = file.ReadLine();
                if(line==null)break;
                this.parseLine(line);
            }
            file.Close();
            this.updateList();
        }

        private void parseLine(String s)
        {
            char delim = ',';
            String[] parser = s.Split(delim);
            int batteryNumbah = int.Parse(parser[0].Substring(5));
            Battery batt;
            try
            {
                batt = (Battery)this.battList[batteryNumbah];
            }
            catch (ArgumentOutOfRangeException) { return; }
            batt.isNowInUse(Boolean.Parse(parser[1].Substring(8)));
            if (!batt.isInUse()) return;
            batt.setBatteryYear(parser[2].Substring(5));
            batt.setBatteryNumber(parser[3].Substring(7));
            batt.setBatteryVoltage(float.Parse(parser[4].Substring(8)));
            batt.setSubgroup(parser[5].Substring(9));
            batt.setCheckoutTime(parser[6].Substring(15));
            batt.setEstCheckinTime(parser[7].Substring(11));
            batt.setRobot(parser[8].Substring(6));
            
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
                //this.saveFileDialog1.OpenFile();
                for (int i = 0; i < battList.Count; i++)
                {
                    batt = (Battery)battList[i];
                    String temp;
                    if (i < 10)
                    {
                        temp = "0" + i;
                    }
                    else { temp = "" + i; }
                    sb.Append("Batt=" + temp + ",isInUse=" + batt.isInUseText() + ",Year=" + batt.getBatteryYear() + ",Number=" + batt.getBatteryNumber() + ",Voltage=" + batt.getBatteryVoltage() + ",Subgroup=" + batt.getSubgroup() + ",timeCheckedOut=" + batt.getFormatedCheckoutTime() + ",EstCheckin=" + batt.getEstCheckinTime() + ",Robot=" + batt.getRobot() + "\n");
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
            for (int i = 0; i < allRows.Count; i++)
            {
                for (int j = 0; j < arow1.Count; j++)
                {
                    ArrayList theRow = (ArrayList)allRows[i];
                    Label theLabel = (Label)theRow[j];
                    theLabel.Text = null;
                }
            }
        }
    }
}
