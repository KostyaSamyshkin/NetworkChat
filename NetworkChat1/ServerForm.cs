using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace NetworkChat1
{
    public partial class ServerForm : Form
    {
        private readonly TcpListener Server;
        private readonly List<TcpClient> Clients = new List<TcpClient>();

        public ServerForm()
        {
            InitializeComponent();

            Server = new TcpListener(IPAddress.Any, 8080);
            Server.Start();

            new Thread(ServerThread).Start();
        }

        private void ServerThread()
        {
            while (true)
            {
                TcpClient client = Server.AcceptTcpClient();
                Clients.Add(client);
                new Thread( () => ClientThread(client) ).Start();
            }
        }

        private void Broadcast(string name, string message)
        {
            byte[] namebuf = Encoding.UTF8.GetBytes(name);
            byte[] namelenbuf = BitConverter.GetBytes(namebuf.Length);
            byte[] msgbuf = Encoding.UTF8.GetBytes(message);
            byte[] msglenbuf = BitConverter.GetBytes(msgbuf.Length);

            foreach (TcpClient client in Clients)
            {
                if (!client.Connected) continue;

                client.Client.Send(namelenbuf);
                client.Client.Send(namebuf);
                client.Client.Send(msglenbuf);
                client.Client.Send(msgbuf);
            }    
        }

        private void ClientThread(TcpClient client)
        {
            try
            {
                while (client.Connected)
                {
                    byte[] lenBuffer = new byte[4];
                    if (client.Client.Receive(lenBuffer) != lenBuffer.Length) continue;
                    int len = BitConverter.ToInt32(lenBuffer, 0);

                    byte[] nameBuffer = new byte[len];
                    if (client.Client.Receive(nameBuffer) != nameBuffer.Length) continue;
                    string name = Encoding.UTF8.GetString(nameBuffer);

                    if (client.Client.Receive(lenBuffer) != lenBuffer.Length) continue;
                    len = BitConverter.ToInt32(lenBuffer, 0);

                    byte[] msgBuffer = new byte[len];
                    if (client.Client.Receive(msgBuffer) != msgBuffer.Length) continue;
                    string msg = Encoding.UTF8.GetString(msgBuffer);

                    if (string.IsNullOrEmpty(msg) || string.IsNullOrWhiteSpace(msg) ) continue;

                    Broadcast(name, msg);
                }
            }
            catch { }

            Clients.Remove(client);
        }

        private void ServerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
