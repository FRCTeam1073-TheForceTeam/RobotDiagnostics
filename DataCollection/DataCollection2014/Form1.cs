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
        public static IPEndPoint consoleIPEndPoint = new IPEndPoint(IPAddress.Any, 1166);
        public static Socket consoleSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        public EndPoint consoleEndpoint = (EndPoint)(dataIPEndPoint);
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
        public Form1()
        {
            InitializeComponent();
            consoleSocket.Bind(consoleIPEndPoint);
            dataSocket.Bind(dataIPEndPoint);
            ListenTimer.Enabled = true;
            ListenTimer.Interval = 100;
            ListenTimer.Stop();
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
                dataQueue.Enqueue(dataString + "\n");
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
                    DisconnectionMessages.AppendText("Packet Error at " + error + "\n");
                    panel1.BackColor = Color.OrangeRed;
                }
                if (s2 != null)
                {
                    NoConnection = false;
                    /*textBox2.Text = s2.Substring(0, 7);
                    textBox7.Text = s2.Substring(8, 1);
                    textBox6.Text = s2.Substring(10, 6);
                    textBox4.Text = s2.Substring(17, 6);
                    textBox5.Text = s2.Substring(24, 6);
                    textBox3.Text = s2.Substring(31, 6);*/
                    panel1.BackColor = Color.Green;
                }
            }

            if (consoleQueue.Count > 0)
            {
                String s3 = (String)consoleQueue.Dequeue();
                if (s3 == null)
                {
                    DisconnectionMessages.AppendText("Packet Error at " + error + "\n");
                }
                if (s3 != null)
                {
                    NoConnection = false;
                    NetConsoleDisplay.AppendText(s3);
                }
            }

            if ((dataQueue.Count == 0 && consoleQueue.Count == 0)&&NoConnection==false)
            {
                ConsoleSB.Append("Connection lost at " + error);
                DisconnectionMessages.AppendText("Connection lost at " + error + "\n");
                panel1.BackColor = Color.Red;
                NoConnection = true;
                if(stopIt)ListenTimer.Stop();
            }
            dataQueue.Clear();
            consoleQueue.Clear();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = new Rectangle(0, 0, 100, 100);
            Rectangle thing = new Rectangle(45, 45, 10, 10);
            Pen lol = new Pen(Color.Black);
            e.Graphics.DrawEllipse(lol, rect);
            e.Graphics.FillRectangle(Brushes.Black, thing);
        }

        private void Pause_Click(object sender, EventArgs e)
        {
            if (dataThread!=null)dataThread.Suspend();
            if (consoleThread!=null)consoleThread.Suspend();
            ListenTimer.Stop();
        }

        private void fastSpeed_CheckedChanged(object sender, EventArgs e)
        {
            ListenTimer.Interval = 25;
        }

        private void ListenTimer_Tick(object sender, EventArgs e)
        {
            displayData();
        }

        private void Listen_Click(object sender, EventArgs e)
        {
            StartListenerThreads();
            ListenTimer.Start();
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            if(dataThread!=null)dataThread.Suspend();
            if(consoleThread!=null)consoleThread.Suspend();
            ListenTimer.Stop();
            dataQueue.Clear();
            consoleQueue.Clear();
            NetConsoleDisplay.Text = "Listening Stopped\n";
        }

        private void ultraSpeed_CheckedChanged(object sender, EventArgs e)
        {
            ListenTimer.Interval = 10;
        }

        private void mediumSpeed_CheckedChanged(object sender, EventArgs e)
        {
            ListenTimer.Interval = 100;
        }

        private void slowSpeed_CheckedChanged(object sender, EventArgs e)
        {
            ListenTimer.Interval = 250;
        }

        private void SavetoDisk_Click(object sender, EventArgs e)
        {
            timeStamp = DateTime.Now;
            String path2 = String.Format("{0:yyyy-MMM-d_HH-mm-ss}", timeStamp);
            File.WriteAllText("C:\\" + path2 + "_Match" + matchNumber + ".rtf", ConsoleSB.ToString());
            File.WriteAllText("C:\\" + path2 + "_Match" + matchNumber + "DATA" + ".csv", DataSB.ToString());
            matchNumber++;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            stopIt = false;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            stopIt = true;
        }
    }
}
