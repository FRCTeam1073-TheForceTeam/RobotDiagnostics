using System;
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
        private bool noConsoleConnection = false;
        private bool isEnabled = false;
        private bool consoleConnection = false;
        private bool NoConnection = false;
        private bool saveToDisk = true;
        private bool secretClose = false;
        private bool firstTime = true;
        private bool consoleFirstTime = true;
        private bool isDiagnosticCode = false;
        private bool isShifting = false;
        private bool isAnglingUp = false;
        private bool isAnglingDown = false;
        private bool isCollectingFast = false;
        private bool isCollectingSlow = false;
        private bool isCompressing = false;
        private bool isLauching = false;
        private bool isCatchModing = false;
        private bool isCollecting2Shooting = false;
        private bool isCollectingDown2 = false;
        private bool isCollectingDown = false;
        private bool isCollectingUp2 = false;
        private bool isCollectingUp = false;
        private bool isToggleCollecting = false;
        private bool isCollectingWhileHeld = false;
        private bool isPurging = false;
        private bool isLauchingBall = false;
        private bool isFowardDirectioning = false;
        private bool isTogglingDriveMode = false;
        private bool isShiftingUp = false;
        private bool isShiftingDown = false;
        private byte[] dataByte;
        private byte[] consoleByte;
        private DateTime timeStamp = new DateTime();
        private float xAxisNum = 0;
        private float yAxisNum = 0;
        private float zAxisNum = 0;
        private float totalHertz;
        private int matchNumber = 1;
        private int recv;
        private int crecv;
        private int ignoringInput = 2;
        private int parseNumber = 0;
        private int saveNumber = 0;
        private int fileSaver = 0;
        private int consoleSaveNumber = 0;
        private int connectionTimeout = 0;
        private int deleteDataSaveNumber = 0;
        private int deleteConsoleSaveNumber = 0;
        private int enoughPressure = 0;
        private int timesPer50Hz;
        private int actualHz;
        private Ping cameraPinger = new Ping();
        private PingReply reply;
        private Queue dataQueue = new Queue();
        private Queue consoleQueue = new Queue();
        private Rectangle border;
        private Rectangle point;
        private Rectangle rotation;
        private String appPath;
        private String FormatedTopRow;
        private String consoleString;
        private String formatedTopRowDiag;
        private String dataString;
        private String[] parser = new String[30];
        private StringBuilder DataSB = new StringBuilder();
        private StringBuilder ConsoleSB = new StringBuilder();
        private System.Drawing.Graphics graphics;
        private Thread dataThread;
        private Thread consoleThread;
        private Thread pinggerThread;
        
        private static IPEndPoint dataIPEndPoint = new IPEndPoint(IPAddress.Any, 1165);
        private static Socket dataSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        private EndPoint dataEndpoint = (EndPoint)(dataIPEndPoint);
        private static IPEndPoint consoleIPEndPoint = new IPEndPoint(IPAddress.Any, 6666);
        private static Socket consoleSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        private EndPoint consoleEndpoint = (EndPoint)(consoleIPEndPoint);
        
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
            FormatedTopRow = (path2+","+
            "Time Stamp,"+
            "Battery Volts,"+
            "Battery Amps,"+
            "Drive Stick X,"+
            "Drive Stick Y,"+
            "Drive Stick Z,"+
            "Front Left Speed,"+
            "Front Right Speed,"+
            "Back Left Speed,"+
            "Back Right Speed,"+
            "Angle Speed,"+
            "Left Launcher Solenoid,"+
            "Right Launcher Solenoid,"+
            "Shifter Solenoid,"+
            "Air Compressor Switch,"+
            "Ultrasonic Distance(cm),"+
            "Gyro Angle,"+
            "Transducer(PSI),"+
            "Left Talon,"+
            "Right Talon,"+
            "Packet Count,"+
            "Refresh Rate,"+
            "Match Time,"+
            "isEnabled\n");
            formatedTopRowDiag = (path2 + "," +
            "Time Stamp," +
            "Battery Volts," +
            "Battery Amps," +
            "Drive Stick X," +
            "Drive Stick Y," +
            "Drive Stick Z," +
            "Shift Button" +
            "Angle Down Button" +
            "Angle Up Button" +
            "Collect Fast Button" +
            "Collect Slow Button" +
            "Compress Button" +
            "Lauch Ball Button" +
            "Front Left Speed," +
            "Front Right Speed," +
            "Back Left Speed," +
            "Back Right Speed," +
            "Angle Speed," +
            "Left Launcher Solenoid," +
            "Right Launcher Solenoid," +
            "Shifter Solenoid," +
            "Air Compressor Switch," +
            "Ultrasonic Distance(cm)," +
            "Gyro Angle," +
            "Transducer(PSI)," +
            "Left Talon," +
            "Right Talon," +
            "Packet Count," +
            "Refresh Rate," +
            "Match Time," +
            "isEnabled\n");
            this.StartGraphics();
        }

        public void StartGraphics()
        {
            graphics = panel4.CreateGraphics();
            border = new Rectangle(0, 0, 200, 200);
            point = new Rectangle(90, 90, 10, 10);
            rotation = new Rectangle(0, 202, 100, 20);
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
                        if (ignoringInput == 1000000)
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

                        if (parser[parseNumber++].Equals("1")) isDiagnosticCode = true; else isDiagnosticCode = false;
                        //isDiagnosticCode = true;
                        if (isDiagnosticCode)
                        {   //battery system information
                            batteryVolts.Text = parser[parseNumber++];
                            batteryAmps.Text = parser[parseNumber++];
                            //driver joystick information
                            try { xAxisNum = float.Parse(parser[parseNumber++]); }
                            catch (FormatException) { xAxisNum = 0; }
                            try { yAxisNum = float.Parse(parser[parseNumber++]); }
                            catch (FormatException) { yAxisNum = 0; }
                            try { zAxisNum = float.Parse(parser[parseNumber++]); }
                            catch (FormatException) { zAxisNum = 0; }
                            if (parser[parseNumber++].Equals("1")) isShifting = true; else isShifting = false;
                            if (parser[parseNumber++].Equals("1")) isAnglingDown = true; else isAnglingDown = false;
                            if (parser[parseNumber++].Equals("1")) isAnglingUp = true; else isAnglingUp = false;
                            if (parser[parseNumber++].Equals("1")) isCollectingFast = true; else isCollectingFast = false;
                            if (parser[parseNumber++].Equals("1")) isCollectingSlow = true; else isCollectingSlow = false;
                            if (parser[parseNumber++].Equals("1")) isCompressing = true; else isCompressing = false;
                            if (parser[parseNumber++].Equals("1")) isLauching = true; else isLauching = false;

                            //drive train and elevator
                            leftFrontSpeed.Text = parser[parseNumber++];
                            rightFrontSpeed.Text = parser[parseNumber++];
                            leftBackSpeed.Text = parser[parseNumber++];
                            rightBackSpeed.Text = parser[parseNumber++];
                            collectorInputSpeed.Text = parser[parseNumber++];
                            //everything else
                            launcherSolenoid1.Text = parser[parseNumber++];
                            launcherSolenoid2.Text = parser[parseNumber++];
                            shifterStatus.Text = parser[parseNumber++];
                            pressureValue.Text = parser[parseNumber++];
                            try { enoughPressure = int.Parse(pressureValue.Text); }
                            catch (FormatException) { }
                            ultrasonic.Text = parser[parseNumber++];
                            gyroAngle.Text = parser[parseNumber++];
                            transducerPSI.Text = parser[parseNumber++];
                            leftTalon.Text = parser[parseNumber++];
                            rightTalon.Text = parser[parseNumber++];
                            packetCounter.Text = parser[parseNumber++];
                            timesPer50Hz = (int.Parse(parser[parseNumber++]));
                            actualHz = 50 / timesPer50Hz;
                            DataTimer.Interval = 1000/actualHz;
                            matchTime.Text = parser[parseNumber++];
                            isReallyEnabled.Text = parser[parseNumber];
                            if (isReallyEnabled.Text.Equals("1")) isEnabled = true; else isEnabled = false;
                        }
                        else
                        {
                            batteryVolts.Text = parser[parseNumber++];
                            batteryAmps.Text = parser[parseNumber++];

                            try { xAxisNum = float.Parse(parser[parseNumber++]); }
                            catch (FormatException) { xAxisNum = 0; }
                            try { yAxisNum = float.Parse(parser[parseNumber++]); }
                            catch (FormatException) { yAxisNum = 0; }
                            try { zAxisNum = float.Parse(parser[parseNumber++]); }
                            catch (FormatException) { zAxisNum = 0; }
                            parseNumber++;
                            parseNumber++;
                            leftFrontSpeed.Text = parser[parseNumber++];
                            rightFrontSpeed.Text = parser[parseNumber++];
                            leftBackSpeed.Text = parser[parseNumber++];
                            rightBackSpeed.Text = parser[parseNumber++];
                            collectorInputSpeed.Text = parser[parseNumber++];

                            launcherSolenoid1.Text = parser[parseNumber++];
                            launcherSolenoid2.Text = parser[parseNumber++];
                            shifterStatus.Text = parser[parseNumber++];
                            pressureValue.Text = parser[parseNumber++];
                            try { enoughPressure = int.Parse(pressureValue.Text); }
                            catch (FormatException) { }
                            ultrasonic.Text = parser[parseNumber++];
                            gyroAngle.Text = parser[parseNumber++];
                            transducerPSI.Text = parser[parseNumber++];
                            leftTalon.Text = parser[parseNumber++];
                            rightTalon.Text = parser[parseNumber++];
                            packetCounter.Text = parser[parseNumber++];
                            float number = float.Parse(parser[parseNumber++]);
                            float moreNumber = number * 1000;
                            int converted = (int)moreNumber;
                            DataTimer.Interval = converted;
                            matchTime.Text = parser[parseNumber++];
                            isReallyEnabled.Text = parser[parseNumber];
                            if (isReallyEnabled.Text.Equals("1")) isEnabled = true;
                            if (isReallyEnabled.Text.Equals("0")) isEnabled = false;
                        }
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
                                        if (isDiagnosticCode) DataSB.Append(formatedTopRowDiag);
                                        else DataSB.Append(FormatedTopRow);
                                        firstTime = false;
                                    }
                                    else
                                    {
                                        while (File.Exists(appPath + "\\" + "tmp" + saveNumber + ".csv")) saveNumber++;
                                        if (isDiagnosticCode) DataSB.Append(formatedTopRowDiag);
                                        else DataSB.Append(FormatedTopRow);
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
            this.DataTimer.Stop();
            this.ConsoleTimer.Stop();
        }

        private void ListenTimer_Tick(object sender, EventArgs e)
        {
            connectionTimeout++;
            
                this.displayData();
                if (connectionTimeout >= 1000 / DataTimer.Interval) //connection timout is 1s
                {
                    timeStamp = DateTime.Now;
                    String error = String.Format("{0:HH-mm-ss}", timeStamp);
                    if(!NoConnection) disconnectionMessages.AppendText("Data Connection lost at " + error + "\n");
                    NoConnection = true;
                }
                this.UpdateUI();
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
            if (isDiagnosticCode) { totalHertz = actualHz; }
            else { totalHertz = 1000 / this.DataTimer.Interval; }
            label87.Text = "" + totalHertz + "Hz";
            if (NoConnection)
            {
                label87.Text = "0Hz";
                label87.ForeColor = Color.Red;
            }
            else
            {
                if (totalHertz>=20) label87.ForeColor = Color.Green;
                if (totalHertz<20&&totalHertz>=10) label87.ForeColor = Color.Yellow;
                if (totalHertz<10&&totalHertz>=5) label87.ForeColor = Color.Orange;
                if (totalHertz<5&&totalHertz>=2) label87.ForeColor = Color.OrangeRed;
            }
            if (enoughPressure == 1) label2.Text = "Sufficent";
            if (enoughPressure == 0) label2.Text = "Insufficent";
            //draw the circle with the joystick in it and the z axis
            float zProcessed = zAxisNum * 100;
            float yProcessed = yAxisNum * 90;
            float xProcessed = xAxisNum * 90;
            int z = (int)zProcessed;
            int y = (int)yProcessed;
            int x = (int)xProcessed;
            
            z = z + 100;
            x = x + 96;
            y = y + 96;
            graphics.Clear(panel4.BackColor);
            rotation.Width = z;
            point.X = x;
            point.Y = y;
            graphics.DrawRectangle(Pens.Black, border);
            graphics.FillEllipse(Brushes.Black, point);
            graphics.FillRectangle(Brushes.Black, rotation);
            //update the buttons
            if (isDiagnosticCode)
            {
                if (isShifting)
                    this.shiftButton.BackColor = Color.Green;
                else
                    this.shiftButton.BackColor = Color.Red;

                if (isAnglingDown)
                    this.AngleDownButton.BackColor = Color.Green;
                else
                    this.AngleDownButton.BackColor = Color.Red;

                if (isAnglingUp)
                    this.AngleUpButton.BackColor = Color.Green;
                else
                    this.AngleUpButton.BackColor = Color.Red;

                if (isCollectingFast)
                    this.CollectFasterButton.BackColor = Color.Green;
                else
                    this.CollectFasterButton.BackColor = Color.Red;

                if (isCollectingSlow)
                    this.CollectSlowerButton.BackColor = Color.Green;
                else
                    this.CollectSlowerButton.BackColor = Color.Red;

                if (isCompressing)
                    this.CompressButton.BackColor = Color.Green;
                else
                    this.CompressButton.BackColor = Color.Red;

                if (isLauching)
                    this.lauchBallButton.BackColor = Color.Green;
                else
                    this.lauchBallButton.BackColor = Color.Red;
            }
            else
            {
                this.label18.Visible = false;
                this.label17.Visible = false;
                this.label21.Visible = false;
                this.CollectSlowerButton.Visible = false;
                this.lauchBallButton.Visible = false;
                this.CompressButton.Visible = false;
                this.label26.Visible = false;
                this.label27.Visible = false;
                this.label28.Visible = false;
                this.label10.Text = "Foward Direction";
                this.label11.Text = "Toggle Field";
                this.label16.Text = "Shift Down";
                this.label13.Text = "Shift Up";
                this.label22.Text = "2";
                this.label23.Text = "3";
                this.label24.Text = "10";
                this.label25.Text = "9";
                if (isFowardDirectioning)
                    this.shiftButton.BackColor = Color.Green;
                else
                    this.shiftButton.BackColor = Color.Red;

                if (isTogglingDriveMode)
                    this.AngleUpButton.BackColor = Color.Green;
                else
                    this.AngleUpButton.BackColor = Color.Red;

                if (isShiftingUp)
                    this.AngleDownButton.BackColor = Color.Green;
                else
                    this.AngleDownButton.BackColor = Color.Red;

                if (isShiftingDown)
                    this.CollectFasterButton.BackColor = Color.Green;
                else
                    this.CollectFasterButton.BackColor = Color.Red;
            }
            if (isDiagnosticCode) diagOrComp.Text = "diag"; else diagOrComp.Text = "comp";

            if (diagOrComp.Text.Equals("comp"))
                this.panel28.Visible = true;
            else
                this.panel28.Visible = false;

            if (isCatchModing)
                this.catchModeButton.BackColor = Color.Green;
            else
                this.catchModeButton.BackColor = Color.Red;

            if (isCollecting2Shooting)
                this.CollectorToShootButton.BackColor = Color.Green;
            else
                this.CollectorToShootButton.BackColor = Color.Red;

            if (isCollectingDown2)
                this.CollectorDown2Button.BackColor = Color.Green;
            else
                this.CollectorDown2Button.BackColor = Color.Red;

            if (isCollectingDown)
                this.OPCollectorDownButton.BackColor = Color.Green;
            else
                this.OPCollectorDownButton.BackColor = Color.Red;

            if (isCollectingUp2)
                this.CollectorUp2Button.BackColor = Color.Green;
            else
                this.CollectorUp2Button.BackColor = Color.Red;

            if (isCollectingUp)
                this.OPCollectorUpButton.BackColor = Color.Green;
            else
                this.OPCollectorUpButton.BackColor = Color.Red;

            if (isToggleCollecting)
                this.toggleCollectorButton.BackColor = Color.Green;
            else
                this.toggleCollectorButton.BackColor = Color.Red;

            if (isCollectingWhileHeld)
                this.whileHeldCollectorButton.BackColor = Color.Green;
            else
                this.whileHeldCollectorButton.BackColor = Color.Red;

            if (isPurging)
                this.OPPurgeButton.BackColor = Color.Green;
            else
                this.OPPurgeButton.BackColor = Color.Red;

            if (isLauchingBall)
                this.OPLauchBallButton.BackColor = Color.Green;
            else
                this.OPLauchBallButton.BackColor = Color.Red;
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
            netConsoleDisplay.Clear();
            batteryVolts.Text = null;
            batteryAmps.Text = null;
            
            leftFrontSpeed.Text = null;
            rightFrontSpeed.Text = null;
            leftBackSpeed.Text = null;
            rightBackSpeed.Text = null;
            collectorInputSpeed.Text = null;
            launcherSolenoid1.Text = null;
            launcherSolenoid2.Text = null;
            shifterStatus.Text = null;
            pressureValue.Text = null;
            ultrasonic.Text = null;
            gyroAngle.Text = null;
            leftTalon.Text = null;
            rightTalon.Text = null;
            packetCounter.Text = null;
            //refresh rate
            matchTime.Text = null;
            transducerPSI.Text = null;
            isReallyEnabled.Text = null;
            NoConnection = false;
            noConsoleConnection = false;
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
