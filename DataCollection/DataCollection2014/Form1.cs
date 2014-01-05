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

namespace DataCollection2014
{
    public partial class Form1 : Form
    {
        public DateTime timeStamp = new DateTime();
        public int matchNumber = 1;
        public StringBuilder robotData = new StringBuilder();
        public String data;
        public StringBuilder netConsole = new StringBuilder();
        public String console;
        public byte[] dataByte;
        public byte[] consoleByte;
        public static IPEndPoint dataEndPoint = new IPEndPoint(IPAddress.Any, 1165);
        public static Socket dataSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        public EndPoint dataEndpoint = (EndPoint)(dataEndPoint);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
