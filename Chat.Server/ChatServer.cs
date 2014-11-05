using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chat.Server
{
    public class ChatServer
    {
        public delegate void ClientConnectedHandle(Socket socket);

        public event ClientConnectedHandle ClientConnected;

        private readonly TcpListener _listener;
        private Thread _listenerThread;

        public ChatServer()
        {
            var portToListenFromConfiguration = ConfigurationSettings.AppSettings.Get("ServerListener_Port");
            _listener = new TcpListener(int.Parse(portToListenFromConfiguration));
            _listenerThread = new Thread(Start);
            _listenerThread.Start(_listener);
        }

        private void Start(object o)
        {
            Listen(o as TcpListener);
        }

        private void Listen(TcpListener listener)
        {
            listener.Start();
            var clientSocket = listener.AcceptSocket();
            OnClientConnected(clientSocket);
        }

        private void OnClientConnected(Socket clientSocket)
        {
            if (ClientConnected != null)
                ClientConnected(clientSocket);
        }
    }
}