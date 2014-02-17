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

namespace DataCollection2014
{
    public partial class Form1 : Form
    {
        public DateTime timeStamp = new DateTime();
        public int matchNumber = 1;
        public StringBuilder DataSB = new StringBuilder();
        public String dataString;
        public StringBuilder ConsoleSB = new StringBuilder();
        public String consoleString;
        public byte[] dataByte;
        public byte[] consoleByte;
        public static IPEndPoint dataIPEndPoint = new IPEndPoint(IPAddress.Any, 1165);
        public static Socket dataSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        public EndPoint dataEndpoint = (EndPoint)(dataIPEndPoint);
        public static IPEndPoint consoleIPEndPoint = new IPEndPoint(IPAddress.Any, 6666);
        public static Socket consoleSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        public EndPoint consoleEndpoint = (EndPoint)(consoleIPEndPoint);
        public int recv;
        public int crecv;
        public Queue dataQueue = new Queue();
        public Queue consoleQueue = new Queue();
        public int joystickX = new int();
        public int joystickY = new int();
        public Thread dataThread;
        public Thread consoleThread;
        public volatile bool NoConnection = false;
        public volatile bool stopIt = false;
        public String[] parser= new String[30];
        public StringBuilder failSafe = new StringBuilder();
        public volatile bool saveToDisk = true;
        public string appPath;
        public volatile bool secretClose = false;
        public int ignoringInput = 2;
        public int parseNumber = 0;
        public StringBuilder netFailSafe = new StringBuilder();
        public String FormatedTopRow;
        public volatile bool firstTime = true;
        public Form1()
        {
            this.MaximizeBox = false;
            InitializeComponent();
            dataSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            consoleSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            consoleSocket.Bind(consoleIPEndPoint);
            dataSocket.Bind(dataIPEndPoint);
            ListenTimer.Enabled = true;
            ListenTimer.Interval = 100;
            ListenTimer.Stop();
            appPath = Path.GetDirectoryName(Application.ExecutablePath);
            StartListenerThreads();
            ListenTimer.Start();
            fileSaveTimer.Enabled = true;
            fileSaveTimer.Start();
            timeStamp = DateTime.Now;
            String path2 = String.Format("{0:yyyy-MMM-d_HH-mm-ss}", timeStamp);
            FormatedTopRow = (path2 + "," + "Battery Volts,"+"Battery Amps,"+"Drive Stick X,"+
            "Drive Stick Y,"+"Drive Stick Z,"+"Operator Stick X,"+"Operator Stick Y,"+"Throttle,"+
            "Front Left Speed,"+"Front Left Out Volts,"+"Front Left Current,"+"Front Left Position,"+
            "Front Left In Volts,"+"Front Left Temp(C),"+"Front Left Faults,"+"Front Right Speed,"+
            "Front Right Out Volts,"+"Front Right Current,"+"Front Right Position,"+"Front Right In Volts,"+
            "Front Right Temp(C),"+"Front Right Faults,"+"Back Left Speed,"+"Back Left Out Volts,"+
            "Back Left Current,"+"Back Left Position,"+"Back Left Out Volts,"+"Back Left Temp(C),"+
            "Back Left Faults,"+"Back Right Speed,"+"Back Right Out Volts,"+"Back Right Current,"+
            "Back Right Position,"+"Back Right In Volts,"+"Back Right Temp(C),"+"Back Right Faults,"+
            "Angle Speed,"+"Angle Out Volts,"+"Angle Current,"+"Angle In Volts,"+"Angle Temp,"+
            "Angle Foward Limit,"+"Angle Reverse Limit,"+"Angle Faults,"+"Left Launcher Solenoid,"+
            "Right Launcher Solenoid,"+"Shifter Solenoid,"+"Air Compressor Switch,"+"Ultrasonic Distance(cm),"+
            "Gyro Angle,"+"Elevation Volts,"+"Low Transducer(PSI),"+"High Transducer(PSI),"+"Left Talon,"+
            "Right Talon,"+"Packet Count,"+"Uptime(s),"+"Downtime(s),"+"% CPU,"+"Match Time,\n");
            DataSB.Append(FormatedTopRow);
            this.WindowState = FormWindowState.Minimized;
        }

        public void StartListenerThreads()
        {
            dataThread = new Thread(new ThreadStart(listen4Data));
            consoleThread = new Thread(new ThreadStart(listen4Netconsole));
            dataThread.IsBackground = true;
            consoleThread.IsBackground = true;
            dataThread.Start();
            consoleThread.Start();
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
                consoleQueue.Enqueue(consoleString + "\n");
            }
        }

        public void displayData()
        {
            timeStamp= DateTime.Now;
            String error = String.Format("{0:HH-mm-ss}", timeStamp);

            if (dataQueue.Count > 0)
            {
                String s2 = (String)dataQueue.Dequeue();
                if (s2 == null)
                {
                    disconnectionMessages.AppendText("Packet Error at " + error + "\n");
                    panel1.BackColor = Color.OrangeRed;
                }
                if (s2 != null)
                {
                    try
                    {
                        char delim = ',';
                        String parsed = s2.Substring(35, s2.Length - 35);
                        timeStamp = DateTime.Now;
                        String path2 = String.Format("{0:yyyy-MMM-d_HH-mm-ss}", timeStamp);
                        DataSB.Append(path2 + ",");
                        DataSB.Append(parsed);
                        if (saveToDisk)
                        {
                            if (firstTime)
                            {
                                failSafe.Append(FormatedTopRow);
                                firstTime = false;
                            }
                            failSafe.Append(path2 + ",");
                            failSafe.Append(parsed);
                        }
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
                        ultrasonic.Text = parser[parseNumber++];
                        gyroAngle.Text = parser[parseNumber++];
                        elevationBox.Text = parser[parseNumber++];
                        transducer1.Text = parser[parseNumber++];
                        transducer2.Text = parser[parseNumber++];
                        leftVictor.Text = parser[parseNumber++];
                        rightVictor.Text = parser[parseNumber++];
                        packetCounter.Text = parser[parseNumber++];
                        loadTime.Text = parser[parseNumber++];
                        downTime.Text = parser[parseNumber++];
                        percentCPU.Text = parser[parseNumber++];
                        matchTime.Text = parser[parseNumber++];
                        panel1.BackColor = Color.Green;
                    }
                    catch (System.IndexOutOfRangeException e){
                    }
                    parseNumber = 0;
                }
            }
            if (consoleQueue.Count > 0)
            {
                String s3 = (String)consoleQueue.Dequeue();
                if (s3 == null)
                {
                    disconnectionMessages.AppendText("Packet Error at " + error + "\n");
                }
                if (s3 != null)
                {
                    NoConnection = false;
                    String newNetConsole = s3.Substring(0, s3.Length - 2);
                    if (!s3.Equals("\n"))
                    {
                        if (saveToDisk)
                        {
                            netFailSafe.Append(s3);
                        }
                        if (ignoringInput % 2 == 0)
                        {
                            netConsoleDisplay.AppendText(newNetConsole);
                            ConsoleSB.Append(s3);
                        }
                        else
                        {}
                        if (ignoringInput == 1000)
                        {
                            ignoringInput = 2;
                        }
                    }
                }
            }

            if ((dataQueue.Count == 0)&&NoConnection==false)
            {
                ConsoleSB.Append("Connection lost at " + error + "\n");
                netFailSafe.Append("Connection lost at " + error + "\n");
                disconnectionMessages.AppendText("Connection lost at " + error + "\n");
                panel1.BackColor = Color.Red;
                NoConnection = true;
                if(stopIt)ListenTimer.Stop();
            }
            dataQueue.Clear();
            consoleQueue.Clear();
        }

        private void Pause_Click(object sender, EventArgs e)
        {
            if (dataThread!=null)dataThread.Suspend();
            if (consoleThread!=null)consoleThread.Suspend();
            ListenTimer.Stop();
        }

        private void fastSpeed_CheckedChanged(object sender, EventArgs e)
        {
            ListenTimer.Interval = 75;
        }

        private void ListenTimer_Tick(object sender, EventArgs e)
        {
            displayData();
        }

        private void Listen_Click(object sender, EventArgs e)
        {
            StartListenerThreads();
            ListenTimer.Start();
            ConsoleTimer.Start();
            fileSaveTimer.Enabled = true;
            fileSaveTimer.Start();
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            timeStamp = DateTime.Now;
            String path2 = String.Format("{0:yyyy-MMM-d_HH-mm-ss}", timeStamp);
            File.WriteAllText(appPath + "\\"+ path2 + "_Match" + matchNumber + ".rtf", ConsoleSB.ToString());
            File.WriteAllText(appPath + "\\" + path2 + "_Match" + matchNumber + "DATA" + ".csv", DataSB.ToString());
            File.Delete(appPath + "\\" + "tmp" + ".csv");
            File.Delete(appPath + "\\" + "tmp" + ".rtf");
            matchNumber++;
            firstTime = true;
            if(dataThread!=null)dataThread.Suspend();
            if(consoleThread!=null)consoleThread.Suspend();
            ListenTimer.Stop();
            dataQueue.Clear();
            consoleQueue.Clear();
            fileSaveTimer.Stop();
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
            transducer1.Text = null;
            leftVictor.Text = null;
            rightVictor.Text = null;
            packetCounter.Text = null;
            loadTime.Text = null;
            downTime.Text = null;
            percentCPU.Text = null;
            matchTime.Text = null;
            transducer2.Text = null;
        }

        private void ultraSpeed_CheckedChanged(object sender, EventArgs e)
        {
            ListenTimer.Interval = 50;
        }

        private void mediumSpeed_CheckedChanged(object sender, EventArgs e)
        {
            ListenTimer.Interval = 100;
        }

        private void slowSpeed_CheckedChanged(object sender, EventArgs e)
        {
            ListenTimer.Interval = 200;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            stopIt = false;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            stopIt = true;
        }

        private void fileSaveTimer_Tick(object sender, EventArgs e)
        {
            if (saveToDisk)
            {
                try
                {
                    File.AppendAllText(appPath + "\\" + "tmp" + ".csv", failSafe.ToString());
                    File.AppendAllText(appPath + "\\" + "tmp" + ".rtf", netFailSafe.ToString());
                    failSafe.Clear();
                    netFailSafe.Clear();
                }
                catch (IOException)
                { }//MessageBox.Show("ERROR: Please insert the USB drive back in!!!1!");}
            }
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
        }

        private void Form1_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (!secretClose)
            {
                MessageBox.Show("There is no closing of the Application");
                e.Cancel = true;
                this.Show();
            }
            //this.WindowState = FormWindowState.Minimized;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            secretClose = true;
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            ignoringInput++;
        }
    }
}
