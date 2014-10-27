using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
namespace ConsoleReciever
{
    class Program
    {
        static void Main(string[] args)
        {
            String s;
            byte[] data;
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 1165);
            UdpClient client = new UdpClient(ipep);
            client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

            String c;
            byte[] cdata;
            IPEndPoint cipep = new IPEndPoint(IPAddress.Any, 1166);
            UdpClient Cclient = new UdpClient(cipep);
            Cclient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            while (true)
          {
              data = client.Receive(ref ipep);
              s = Encoding.ASCII.GetString(data);
              Console.WriteLine(s.Substring(35,75));//only what we need to see
              
              //don't need the console stuff right now...
              //cdata = Cclient.Receive(ref cipep);
              //c = Encoding.ASCII.GetString(cdata);
              //Console.ReadLine(); //this will pause the console
              //Console.WriteLine(c); //we dont want to do this quite yet
            }
        }
    }
}
