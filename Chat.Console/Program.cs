using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            TcpClient client = new TcpClient();
            client.Connect("localhost", 65534);
            NetworkStream networkStream = client.GetStream();
            byte[] buffer = ASCIIEncoding.ASCII.GetBytes("Hello");
            networkStream.Write(buffer, 0, buffer.Length);
            networkStream.Close();

            System.Console.ReadKey();
        }
    }
}