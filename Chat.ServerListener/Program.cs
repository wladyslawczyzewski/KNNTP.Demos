using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat.Server;

namespace Chat.ServerListener
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ChatServer server = new ChatServer();
            server.ClientConnected += server_ClientConnected;
            while (true)
            {
            }
        }

        private static void server_ClientConnected(System.Net.Sockets.Socket socket)
        {
            StringBuilder commandBuilder = new StringBuilder();
            byte[] buf = new byte[100];
            while (socket.Receive(buf) != 0)
            {
                commandBuilder.Append(ASCIIEncoding.ASCII.GetString(buf));
            }

            Console.WriteLine(commandBuilder.ToString());
        }
    }
}