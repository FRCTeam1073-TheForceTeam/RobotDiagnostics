using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace ConsoleSender
{
    class Program
    {
        static void Main(string[] args)
        {
            string robotSim1 = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA1,13.58,1.11,0.22,0.33,0.24,1,1,1,1,1,1,1,1.11,1.11,1.11,1.11,1.11,1,1,2,0,250,1.11,110,1.11,1.11,500,5,67,1";
            string robotSim2 = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA1,13.25,1.11,-0.22,-0.33,-0.24,0,0,0,0,0,0,0,1.11,1.11,1.11,1.11,1.11,0,0,1,1,250,1.11,110,1.11,1.11,500,5,67,1";
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1165);
            UdpClient client = new UdpClient();
            client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            client.Connect(ipep);
            string consoleSim;
            IPEndPoint console = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 6666);
            UdpClient Cclient = new UdpClient();
            Cclient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            Cclient.Connect(console);
            int count = 0;
            int sendingSim1 = 2;
            while (true)
            {
                if (sendingSim1 % 2 == 0)
                {
                    client.Send(Encoding.ASCII.GetBytes(robotSim1), robotSim1.Length);
                    System.Threading.Thread.Sleep(7);
                }
                else
                {
                    client.Send(Encoding.ASCII.GetBytes(robotSim2), robotSim2.Length);
                    System.Threading.Thread.Sleep(7);
                }
                //Console.WriteLine(input);
                consoleSim = "This is a test string "+count+++"\n";
                Cclient.Send(Encoding.ASCII.GetBytes(consoleSim), consoleSim.Length);
                //Console.WriteLine(input);
                if (count == int.MaxValue) count = 0;
                if (sendingSim1 == int.MaxValue) sendingSim1 = 2;
                sendingSim1++;
                System.Threading.Thread.Sleep(10);
            }
        }
    }
}