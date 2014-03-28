﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections;
using System.IO;
using System.Net.NetworkInformation;

namespace DataCollection2014
{
    public partial class Form1 : Form
    {
        private DateTime timeStamp = new DateTime();
        private int matchNumber = 1;
        private StringBuilder DataSB = new StringBuilder();
        private String dataString;
        private StringBuilder ConsoleSB = new StringBuilder();
        private String consoleString;
        private byte[] dataByte;
        private byte[] consoleByte;
        private static IPEndPoint dataIPEndPoint = new IPEndPoint(IPAddress.Any, 1165);
        private static Socket dataSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        private EndPoint dataEndpoint = (EndPoint)(dataIPEndPoint);
        private static IPEndPoint consoleIPEndPoint = new IPEndPoint(IPAddress.Any, 6666);
        private static Socket consoleSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        private EndPoint consoleEndpoint = (EndPoint)(consoleIPEndPoint);
        private int recv;
        private int crecv;
        private Queue dataQueue = new Queue();
        private Queue consoleQueue = new Queue();
        private int joystickX = new int();
        private int joystickY = new int();
        private Thread dataThread;
        private Thread consoleThread;
        private Thread pinggerThread;
        private volatile bool NoConnection = false;
        private String[] parser= new String[30];
        //private StringBuilder failSafe = new StringBuilder();
        private volatile bool saveToDisk = true;
        private string appPath;
        private volatile bool secretClose = false;
        private int ignoringInput = 2;
        private int parseNumber = 0;
        //private StringBuilder netFailSafe = new StringBuilder();
        private String FormatedTopRow;
        private volatile bool firstTime = true;
        private int saveNumber = 0;
        private int fileSaver = 0;
        private volatile bool consoleFirstTime = true;
        private int consoleSaveNumber = 0;
        private volatile bool noConsoleConnection = false;
        private volatile bool isEnabled = false;
        private volatile bool consoleConnection = false;
        private Ping cameraPinger = new Ping();
        private volatile bool cameraExists = false;
        private float totalHertz;
        private PingReply reply;
        private int connectionTimeout = 0;
        private int deleteDataSaveNumber = 0;
        private int deleteConsoleSaveNumber = 0;
        private int enoughPressure = 0;
        public Form1()
        {
            this.MaximizeBox = false;
            InitializeComponent();
            dataSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            consoleSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            consoleSocket.Bind(consoleIPEndPoint);
            dataSocket.Bind(dataIPEndPoint);
            DataTimer.Enabled = true;
            DataTimer.Interval = 100;
            DataTimer.Stop();
            appPath = Path.GetDirectoryName(Application.ExecutablePath);
            StartListenerThreads();
            DataTimer.Start();
            timeStamp = DateTime.Now;
            String path2 = String.Format("{0:yyyy-MMM-d_HH-mm-ss}", timeStamp);
            FormatedTopRow = (path2 + "," + "Time Stamp," + "Battery Volts,"+"Battery Amps,"+"Drive Stick X,"+
            "Drive Stick Y,"+"Drive Stick Z,"+"Operator Stick X,"+"Operator Stick Y,"+"Front Left Speed,"+
            "Front Left Out Volts,"+"Front Left Current,"+"Front Left Position,"+"Front Left In Volts,"+
            "Front Left Temp(C),"+"Front Left Faults,"+"Front Right Speed,"+"Front Right Out Volts,"+
            "Front Right Current,"+"Front Right Position,"+"Front Right In Volts,"+
            "Front Right Temp(C),"+"Front Right Faults,"+"Back Left Speed,"+"Back Left Out Volts,"+
            "Back Left Current,"+"Back Left Position,"+"Back Left In Volts,"+"Back Left Temp(C),"+
            "Back Left Faults,"+"Back Right Speed,"+"Back Right Out Volts,"+"Back Right Current,"+
            "Back Right Position,"+"Back Right In Volts,"+"Back Right Temp(C),"+"Back Right Faults,"+
            "Angle Speed,"+"Angle Out Volts,"+"Angle Current,"+"Angle In Volts,"+"Angle Temp,"+
            "Angle Foward Limit,"+"Angle Reverse Limit,"+"Angle Faults,"+"Left Launcher Solenoid,"+
            "Right Launcher Solenoid,"+"Shifter Solenoid,"+"Air Compressor Switch,"+"Ultrasonic Distance(cm),"+
            "Gyro Angle,"+"Elevation Volts,"+"High Transducer(PSI),"+"Left Talon,"+
            "Right Talon,"+"Packet Count,"+"Refresh Rate,"+"Match Time," + "isEnabled\n");
            //DataSB.Append(FormatedTopRow);
            //this.WindowState = FormWindowState.Minimized;
        }

        public void StartListenerThreads()
        {
            dataThread = new Thread(new ThreadStart(listen4Data));
            consoleThread = new Thread(new ThreadStart(listen4Netconsole));
            pinggerThread = new Thread(new ThreadStart(pingDatCamera));
            dataThread.IsBackground = true;
            consoleThread.IsBackground = true;
            pinggerThread.IsBackground = true;
            dataThread.Start();
            consoleThread.Start();
            pinggerThread.Start();
        }

        public void pingDatCamera()
        {
            while (true)
            {
                try
                {
                    try
                    {reply = cameraPinger.Send(IPAddress.Parse("10.10.73.11"), 10);}
                    catch (InvalidOperationException) { }
                    try
                    {
                        if (reply.Status == IPStatus.Success)
                        {
                            cameraStats.BackColor = Color.Green;
                        }
                        else
                        {
                            cameraStats.BackColor = Color.Red;
                        }
                    }
                    catch (NullReferenceException) { }
                }
                catch (PingException)
                {
                    timeStamp = DateTime.Now;
                    String exactSeconds = String.Format("{0:HH-mm-ss.f}", timeStamp);
                    disconnectionMessages.AppendText("Ping Exeption at " + exactSeconds + "\n");
                }
                System.Threading.Thread.Sleep(500);
            }
        }
        public void listen4Data()
        {

            dataByte = new byte[1024];
            while (true)
            {
                recv = dataSocket.ReceiveFrom(dataByte, ref dataEndpoint);
                dataString = Encoding.ASCII.GetString(dataByte, 0, recv);
                dataQueue.Enqueue(dataString);
            }
        }

        public void listen4Netconsole()
        {
            consoleByte = new byte[1024];
            while (true)
            {
                crecv = consoleSocket.ReceiveFrom(consoleByte, ref consoleEndpoint);
                consoleString = Encoding.ASCII.GetString(consoleByte, 0, crecv);
                consoleQueue.Enqueue(consoleString);
            }
        }
        public void displayConsoledata()
        {
            if (consoleQueue.Count == 0&&noConsoleConnection==false)
            {
                
                timeStamp = DateTime.Now;
                String error = String.Format("{0:HH-mm-ss}", timeStamp);
                //ConsoleSB.Append("Console Connection lost at " + error + "\n");
                //disconnectionMessages.AppendText("Console connection lost at " + error + "\n");
                noConsoleConnection = true;
            }
            if (consoleQueue.Count > 0)
            {
                String s3 = (String)consoleQueue.Dequeue();
                if (s3 == null)
                {
                    timeStamp = DateTime.Now;
                    String error = String.Format("{0:HH-mm-ss}", timeStamp);
                    ConsoleSB.Append("Console packet error at " + error + "\n");
                    disconnectionMessages.AppendText("Console packet Error at " + error + "\n");
                }
                if (s3 != null)
                {
                    consoleConnection = true;
                    noConsoleConnection = false;
                    String newNetConsole = s3.Substring(0, s3.Length - 2);//arguement out of range acception
                    if (!s3.Equals("\n"))
                    {
                        if (saveToDisk)
                        {
                            fileSaver++;
                            ConsoleSB.Append(s3);
                            if (fileSaver == 10)
                            {
                                try
                                {
                                    if (consoleFirstTime)
                                    {
                                        if(File.Exists("P:\\here.txt"))
                                        {
                                            while (File.Exists("P:\\" + "tmp" + consoleSaveNumber + ".rtf")) consoleSaveNumber++;
                                            consoleFirstTime = false;
                                        }
                                        else
                                        {
                                        while (File.Exists(appPath + "\\" + "tmp" + consoleSaveNumber + ".rtf")) consoleSaveNumber++;
                                        consoleFirstTime = false;
                                        }
                                    }
                                    if (File.Exists("P:\\here.txt"))
                                    {
                                        File.AppendAllText("P:\\" + "tmp" + consoleSaveNumber + ".rtf", ConsoleSB.ToString());
                                        ConsoleSB.Clear();
                                    }
                                    else
                                    {
                                        File.AppendAllText(appPath + "\\" + "tmp" + consoleSaveNumber + ".rtf", ConsoleSB.ToString());
                                        ConsoleSB.Clear();
                                    }
                                }
                                catch (IOException) { }
                                fileSaver = 0;
                            }
                        }
                        if (ignoringInput % 2 == 0)
                        {
                            netConsoleDisplay.AppendText(s3);
                        }
                        else
                        { }
                        if (ignoringInput == 1000)
                        {
                            ignoringInput = 2;
                        }
                    }
                }
            }
            consoleQueue.Clear();
           
        }
        public void displayData()
        {
            timeStamp= DateTime.Now;
            String error = String.Format("{0:HH-mm-ss}", timeStamp);

            if (dataQueue.Count > 0)
            {
                String s2 = (String)dataQueue.Dequeue();
                connectionTimeout = 0;
                if (s2 == null)
                {
                    disconnectionMessages.AppendText("Packet Error at " + error + "\n");
                }
                else
                {
                    try
                    {
                        char delim = ',';
                        String parsed = s2.Substring(35, s2.Length - 35);
                        timeStamp = DateTime.Now;
                        String path2 = String.Format("{0:yyyy-MMM-d_HH-mm-ss}", timeStamp);
                        String exactSeconds = String.Format("{0:HH-mm-ss.f}", timeStamp);
                        //DataSB.Append(path2 + ",");
                        //DataSB.Append(parsed);
                        
                        parser = parsed.Split(delim);
                        batteryVolts.Text = parser[parseNumber++];
                        batteryAmps.Text = parser[parseNumber++];
                        xAxis.Text = parser[parseNumber++];
                        yAxis.Text = parser[parseNumber++];
                        zAxis.Text = parser[parseNumber++];
                        operatorX.Text = parser[parseNumber++];
                        operatorY.Text = parser[parseNumber++];

                        leftFrontSpeed.Text = parser[parseNumber++];
                        leftFrontVolts.Text = parser[parseNumber++];
                        leftFrontAmps.Text = parser[parseNumber++];
                        leftFrontEncoder.Text = parser[parseNumber++];
                        leftFrontInVolts.Text = parser[parseNumber++];
                        leftFrontTemp.Text = parser[parseNumber++];
                        leftFrontError.Text = parser[parseNumber++];

                        rightFrontSpeed.Text = parser[parseNumber++];
                        rightFrontVolts.Text = parser[parseNumber++];
                        rightFrontAmps.Text = parser[parseNumber++];
                        rightFrontEncoder.Text = parser[parseNumber++];
                        rightFrontInVolts.Text = parser[parseNumber++];
                        rightFrontTemp.Text = parser[parseNumber++];
                        rightFrontError.Text = parser[parseNumber++];

                        leftBackSpeed.Text = parser[parseNumber++];
                        leftBackVolts.Text = parser[parseNumber++];
                        leftBackAmps.Text = parser[parseNumber++];
                        leftBackEncoder.Text = parser[parseNumber++];
                        leftBackInVolts.Text = parser[parseNumber++];
                        leftBackTemp.Text = parser[parseNumber++];
                        leftBackError.Text = parser[parseNumber++];

                        rightBackSpeed.Text = parser[parseNumber++];
                        rightBackVolts.Text = parser[parseNumber++];
                        rightBackAmps.Text = parser[parseNumber++];
                        rightBackEncoder.Text = parser[parseNumber++];
                        rightBackInVolts.Text = parser[parseNumber++];
                        rightBackTemp.Text = parser[parseNumber++];
                        rightBackError.Text = parser[parseNumber++];
                        
                        collectorInputSpeed.Text = parser[parseNumber++];
                        collecterOutputVoltage.Text = parser[parseNumber++];
                        collectorOutputCurrent.Text = parser[parseNumber++];
                        collectorInputVoltage.Text = parser[parseNumber++];
                        collectorTemp.Text = parser[parseNumber++];
                        collectorFrontLimit.Text = parser[parseNumber++];
                        collectorReverseLimit.Text = parser[parseNumber++];
                        collectorFaults.Text = parser[parseNumber++];
                        
                        launcherSolenoid1.Text = parser[parseNumber++];
                        launcherSolenoid2.Text = parser[parseNumber++];
                        shifterStatus.Text = parser[parseNumber++];
                        pressureValue.Text = parser[parseNumber++];
                        try { enoughPressure = int.Parse(pressureValue.Text); }
                        catch(FormatException){}
                        ultrasonic.Text = parser[parseNumber++];
                        gyroAngle.Text = parser[parseNumber++];
                        elevationBox.Text = parser[parseNumber++];
                        transducer2.Text = parser[parseNumber++];
                        leftVictor.Text = parser[parseNumber++];
                        rightVictor.Text = parser[parseNumber++];
                        packetCounter.Text = parser[parseNumber++];
                        float number = float.Parse(parser[parseNumber++]);
                        float moreNumber = number * 1000;
                        int converted = (int)moreNumber;
                        DataTimer.Interval = converted;
                        matchTime.Text = parser[parseNumber++];
                        isReallyEnabled.Text = parser[parseNumber];
                        if(isReallyEnabled.Text.Equals ("1"))isEnabled=true;
                        if(isReallyEnabled.Text.Equals("0")) isEnabled = false;
                        if (!saveToDisk)
                        {}
                        else
                        {
                            if (isEnabled)
                            {
                                if (firstTime)
                                {
                                    if (File.Exists("P:\\here.txt"))
                                    {
                                        while (File.Exists("P:\\" + "tmp" + saveNumber + ".csv")) saveNumber++;
                                        DataSB.Append(FormatedTopRow);
                                        firstTime = false;
                                    }
                                    else
                                    {
                                        while (File.Exists(appPath + "\\" + "tmp" + saveNumber + ".csv")) saveNumber++;
                                        DataSB.Append(FormatedTopRow);
                                        firstTime = false;
                                    }
                                }
                                DataSB.Append(path2 + ",");
                                DataSB.Append(exactSeconds + ",");
                                DataSB.Append(parsed);
                                try
                                {
                                    if (File.Exists("P:\\here.txt")){File.AppendAllText("P:\\" + "tmp" + saveNumber + ".csv", DataSB.ToString() + "\n");}
                                    else{File.AppendAllText(appPath + "\\" + "tmp" + saveNumber + ".csv", DataSB.ToString() + "\n");}
                                }
                                catch (IOException) { }
                            }
                            else
                            {
                                if (radioButton3.Checked) { }
                                else
                                {
                                    if (firstTime)
                                    {
                                        if (File.Exists("P:\\here.txt"))
                                        {
                                            while (File.Exists("P:\\" + "tmp" + saveNumber + ".csv")) saveNumber++;
                                            DataSB.Append(FormatedTopRow);
                                            firstTime = false;
                                        }
                                        else
                                        {
                                            while (File.Exists(appPath + "\\" + "tmp" + saveNumber + ".csv")) saveNumber++;
                                            DataSB.Append(FormatedTopRow);
                                            firstTime = false;
                                        }
                                    }
                                    DataSB.Append(path2 + ",");
                                    DataSB.Append(exactSeconds + ",");
                                    DataSB.Append(parsed);
                                    try
                                    {
                                        if (File.Exists("P:\\here.txt")){File.AppendAllText("P:\\" + "tmp" + saveNumber + ".csv", DataSB.ToString() + "\n");}
                                        else{File.AppendAllText(appPath + "\\" + "tmp" + saveNumber + ".csv", DataSB.ToString() + "\n");}
                                    }
                                    catch (IOException) { }
                                }
                            }
                        }
                        DataSB.Clear();
                        NoConnection = false;
                    }
                    catch (System.IndexOutOfRangeException){
                    }
                    parseNumber = 0;
                }
            }
            dataQueue.Clear();
        }

        private void Pause_Click(object sender, EventArgs e)
        {
            if (dataThread!=null)dataThread.Suspend();
            if (consoleThread!=null)consoleThread.Suspend();
            if (pinggerThread != null) pinggerThread.Abort();
            DataTimer.Stop();
            ConsoleTimer.Stop();
        }

        private void ListenTimer_Tick(object sender, EventArgs e)
        {
            connectionTimeout++;
            
                displayData();
                if (connectionTimeout >= 1000 / DataTimer.Interval) //connection timout is 1s
                {
                    timeStamp = DateTime.Now;
                    String error = String.Format("{0:HH-mm-ss}", timeStamp);
                    disconnectionMessages.AppendText("Data Connection lost at " + error + "\n");
                    NoConnection = true;
                }
                UpdateUI();
        }
        private void UpdateUI()
        {
            if (isEnabled && !NoConnection)
            {
                label37.Text = "Enabled";
                label37.BackColor = Color.Green;
            }
            if (!isEnabled || NoConnection)
            {
                label37.Text = "Disabled";
                label37.BackColor = Color.Red;
            }
            if (NoConnection && !consoleConnection) panel1.BackColor = Color.Red;
            else
            {
                if (NoConnection || !consoleConnection) panel1.BackColor = Color.Orange;
                if (!NoConnection && consoleConnection) panel1.BackColor = Color.Green;
            }
            if (launcherSolenoid1.Text.Equals("1")) launcher1.Text = "on";
            if (launcherSolenoid2.Text.Equals("1")) launcher2.Text = "on";
            if (launcherSolenoid1.Text.Equals("0")) launcher1.Text = "off";
            if (launcherSolenoid2.Text.Equals("0")) launcher2.Text = "off";
            if (shifterStatus.Text.Equals("0")) shiftah.Text = "off";
            if (shifterStatus.Text.Equals("1")) shiftah.Text = "low";
            if (shifterStatus.Text.Equals("2")) shiftah.Text = "high";
            totalHertz = 1000/DataTimer.Interval;
            label87.Text = "" + totalHertz + "Hz";
            if (NoConnection)
            {
                label87.Text = "0Hz";
                label87.ForeColor = Color.Red;
            }
            else
            {
                if (totalHertz>=20) label87.ForeColor = Color.Green;
                if (totalHertz<20&&totalHertz>=13) label87.ForeColor = Color.YellowGreen;
                if (totalHertz<13&&totalHertz>=10) label87.ForeColor = Color.Yellow;
                if (totalHertz<10&&totalHertz>=5) label87.ForeColor = Color.Orange;
                if (totalHertz<5&&totalHertz>=2) label87.ForeColor = Color.OrangeRed;
            }
            if (enoughPressure == 1) label2.Text = "Sufficent";
            if (enoughPressure == 0) label2.Text = "Insufficent";
        }

        private void Listen_Click(object sender, EventArgs e)
        {
            StartListenerThreads();
            DataTimer.Start();
            ConsoleTimer.Start();
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            timeStamp = DateTime.Now;
            String path2 = String.Format("{0:yyyy-MMM-d_HH-mm-ss}", timeStamp);
            if (File.Exists("P:\\here.txt"))
            {
                if (File.Exists("P:\\" + "tmp" + saveNumber + ".csv")) File.Move("P:\\" + "tmp" + saveNumber + ".csv", "P:\\" + path2 + "_Match" + matchNumber + "DATA" + ".csv");
                if (File.Exists("P:\\" + "tmp" + saveNumber + ".rtf")) File.Move("P:\\" + "tmp" + consoleSaveNumber + ".rtf", "P:\\" + path2 + "_Match" + matchNumber + "DATA" + ".rtf");
            }
            else
            {
                if (File.Exists(appPath + "\\" + "tmp" + saveNumber + ".csv")) File.Move(appPath + "\\" + "tmp" + saveNumber + ".csv", appPath + "\\" + path2 + "_Match" + matchNumber + "DATA" + ".csv");
                if (File.Exists(appPath + "\\" + "tmp" + saveNumber + ".rtf")) File.Move(appPath + "\\" + "tmp" + consoleSaveNumber + ".rtf", appPath + "\\" + path2 + "_Match" + matchNumber + "DATA" + ".rtf");
            }
            //File.WriteAllText(appPath + "\\"+ path2 + "_Match" + matchNumber + ".rtf", ConsoleSB.ToString());
            //File.WriteAllText(appPath + "\\" + path2 + "_Match" + matchNumber + "DATA" + ".csv", DataSB.ToString());
            //File.Delete(appPath + "\\" + "tmp" +saveNumber+ ".csv");
            //File.Delete(appPath + "\\" + "tmp" + ".rtf");
            matchNumber++;
            firstTime = true;
            consoleFirstTime = true;
            if(dataThread!=null)dataThread.Suspend();
            if(consoleThread!=null)consoleThread.Suspend();
            if (pinggerThread != null) pinggerThread.Abort();
            DataTimer.Stop();
            dataQueue.Clear();
            consoleQueue.Clear();
            ConsoleTimer.Stop();
            netConsoleDisplay.Text = "Listening Stopped\n";
            batteryVolts.Text = null;
            batteryAmps.Text = null;
            xAxis.Text = null;
            yAxis.Text = null;
            zAxis.Text = null;
            operatorX.Text = null;
            operatorY.Text = null;
            leftFrontSpeed.Text = null;
            leftFrontVolts.Text = null;
            leftFrontAmps.Text = null;
            leftFrontEncoder.Text = null;
            leftFrontInVolts.Text = null;
            leftFrontTemp.Text = null;
            leftFrontError.Text = null;
            rightFrontSpeed.Text = null;
            rightFrontVolts.Text = null;
            rightFrontAmps.Text = null;
            rightFrontEncoder.Text = null;
            rightFrontInVolts.Text = null;
            rightFrontTemp.Text = null;
            rightFrontError.Text = null;
            leftBackSpeed.Text = null;
            leftBackVolts.Text = null;
            leftBackAmps.Text = null;
            leftBackEncoder.Text = null;
            leftBackInVolts.Text = null;
            leftBackTemp.Text = null;
            leftBackError.Text = null;
            rightBackSpeed.Text = null;
            rightBackVolts.Text = null;
            rightBackAmps.Text = null;
            rightBackEncoder.Text = null;
            rightBackInVolts.Text = null;
            rightBackTemp.Text = null;
            rightBackError.Text = null;
            collectorInputSpeed.Text = null;
            collecterOutputVoltage.Text = null;
            collectorOutputCurrent.Text = null;
            collectorInputVoltage.Text = null;
            collectorTemp.Text = null;
            collectorFrontLimit.Text = null;
            collectorReverseLimit.Text = null;
            collectorFaults.Text = null;
            launcherSolenoid1.Text = null;
            launcherSolenoid2.Text = null;
            shifterStatus.Text = null;
            pressureValue.Text = null;
            ultrasonic.Text = null;
            gyroAngle.Text = null;
            elevationBox.Text = null;
            leftVictor.Text = null;
            rightVictor.Text = null;
            packetCounter.Text = null;
            //refresh rate
            matchTime.Text = null;
            transducer2.Text = null;
            isReallyEnabled.Text = null;
        }

       
        private void clearConsole_Click(object sender, EventArgs e)
        {
            netConsoleDisplay.Clear();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            saveToDisk = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            saveToDisk = false;
            deleteConsoleSaveNumber = consoleSaveNumber;
            deleteDataSaveNumber = saveNumber;
            if (File.Exists("P:\\here.txt"))
            {
                while(File.Exists("P:\\" + "tmp" + deleteDataSaveNumber + ".csv"))
                {
                    File.Delete("P:\\" + "tmp" + deleteDataSaveNumber + ".csv");
                    deleteDataSaveNumber++;
                }
                while(File.Exists("P:\\" + "tmp" + deleteConsoleSaveNumber + ".rtf"))
                {
                    File.Delete("P:\\" + "tmp" + deleteConsoleSaveNumber + ".csv");
                    deleteConsoleSaveNumber++;
                }
            }
            else
            {
                while (File.Exists(appPath + "\\" + "tmp" + deleteDataSaveNumber + ".csv"))
                {
                    File.Delete(appPath + "\\" + "tmp" + deleteDataSaveNumber + ".csv");
                    deleteDataSaveNumber++;
                }
                while (File.Exists(appPath + "\\" + "tmp" + consoleSaveNumber + ".rtf"))
                {
                    File.Delete(appPath + "\\" + "tmp" + consoleSaveNumber + ".rtf");
                    deleteConsoleSaveNumber++;
                }
            }
        }

        private void Form1_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (!secretClose)
            {
                if (e.CloseReason == CloseReason.WindowsShutDown)
                {
                    timeStamp = DateTime.Now;
                    String exactSeconds = String.Format("{0:HH-mm-ss.f}", timeStamp);
                    String path2 = String.Format("{0:yyyy-MMM-d_HH-mm-ss}", timeStamp);
                    if (File.Exists("P:\\here.txt"))
                    {
                        if (File.Exists("P:\\" + "tmp" + saveNumber + ".csv"))
                        {
                            File.AppendAllText("P:\\" + "tmp" + saveNumber + ".csv", exactSeconds + "," + "Form Closed due to Windows shutdown!");
                            File.Move("P:\\" + "tmp" + saveNumber + ".csv", "P:\\" + path2 + "_Match" + matchNumber + "DATA" + ".csv");
                        }
                        if (File.Exists("P:\\" + "tmp" + saveNumber + ".rtf"))
                        {
                            File.AppendAllText("P:\\" + "tmp" + saveNumber + ".rtf", "Form Closed due to Windows shutdown!");
                            File.Move("P:\\" + "tmp" + consoleSaveNumber + ".rtf", "P:\\" + path2 + "_Match" + matchNumber + "DATA" + ".rtf");
                        }
                    }
                    else
                    {
                        if (File.Exists(appPath + "\\" + "tmp" + saveNumber + ".csv"))
                        {
                            File.AppendAllText(appPath + "\\" + "tmp" + saveNumber + ".csv", exactSeconds + "," + "Form Closed due to windows shutdown!");
                            File.Move(appPath + "\\" + "tmp" + saveNumber + ".csv", appPath + "\\" + path2 + "_Match" + matchNumber + "DATA" + ".csv");
                        }
                        if (File.Exists(appPath + "\\" + "tmp" + saveNumber + ".rtf"))
                        {
                            File.AppendAllText(appPath + "\\" + "tmp" + saveNumber + ".rtf", "Form Closed due to windows shutdown!");
                            File.Move(appPath + "\\" + "tmp" + consoleSaveNumber + ".rtf", appPath + "\\" + path2 + "_Match" + matchNumber + "DATA" + ".rtf");
                        }
                    }
                }
                else
                {
                    // MessageBox.Show("There is no closing of the Application");
                    switch (MessageBox.Show(this, "Are you sure you want to close? (It will be logged!)", "Wait a second...", MessageBoxButtons.YesNo))
                    {
                        case DialogResult.No:
                            e.Cancel = true;
                            break;
                        default:
                            timeStamp = DateTime.Now;
                            String exactSeconds = String.Format("{0:HH-mm-ss.f}", timeStamp);
                            String path2 = String.Format("{0:yyyy-MMM-d_HH-mm-ss}", timeStamp);
                            if (File.Exists("P:\\here.txt"))
                            {
                                if (File.Exists("P:\\" + "tmp" + saveNumber + ".csv"))
                                {
                                    File.AppendAllText("P:\\" + "tmp" + saveNumber + ".csv", exactSeconds + "," + "Form Closed!");
                                    File.Move("P:\\" + "tmp" + saveNumber + ".csv", "P:\\" + path2 + "_Match" + matchNumber + "DATA" + ".csv");
                                }
                                if (File.Exists("P:\\" + "tmp" + saveNumber + ".rtf"))
                                {
                                    File.AppendAllText("P:\\" + "tmp" + saveNumber + ".rtf", "Form Closed!");
                                    File.Move("P:\\" + "tmp" + consoleSaveNumber + ".rtf", "P:\\" + path2 + "_Match" + matchNumber + "DATA" + ".rtf");
                                }
                            }
                            else
                            {
                                if (File.Exists(appPath + "\\" + "tmp" + saveNumber + ".csv"))
                                {
                                    File.AppendAllText(appPath + "\\" + "tmp" + saveNumber + ".csv", exactSeconds + "," + "Form Closed!");
                                    File.Move(appPath + "\\" + "tmp" + saveNumber + ".csv", appPath + "\\" + path2 + "_Match" + matchNumber + "DATA" + ".csv");
                                }
                                if (File.Exists(appPath + "\\" + "tmp" + saveNumber + ".rtf"))
                                {
                                    File.AppendAllText(appPath + "\\" + "tmp" + saveNumber + ".rtf", "Form Closed!");
                                    File.Move(appPath + "\\" + "tmp" + consoleSaveNumber + ".rtf", appPath + "\\" + path2 + "_Match" + matchNumber + "DATA" + ".rtf");
                                }
                            }
                            this.Dispose();
                            break;
                    }
                }
            }
            //this.WindowState = FormWindowState.Minimized;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            ignoringInput++;
        }

        private void ConsoleTimer_Tick(object sender, EventArgs e)
        {
            displayConsoledata();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            disconnectionMessages.Clear();
        }

       

        private void label4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("LOL not anymore!!!1");
        }
    }
}
