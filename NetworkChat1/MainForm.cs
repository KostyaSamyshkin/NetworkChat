using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace NetworkChat1
{
    public partial class MainForm : Form
    {
        private readonly TcpClient Client;

        public MainForm(string ip)
        {
            InitializeComponent();

            try
            {
                Client = new TcpClient(ip, 8080);
                new Thread(RecvThread).Start();
            }
            catch
            {
                MessageBox.Show("Неверный IP адрес сервера!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
        }

        private void RecvThread()
        {
            while (Client.Connected)
            {
                byte[] ipBuffer = new byte[4];
                if (Client.Client.Receive(ipBuffer) != ipBuffer.Length) continue;
                string ip = new IPAddress(ipBuffer).ToString();

                byte[] lenBuffer = new byte[4];
                if (Client.Client.Receive(lenBuffer) != lenBuffer.Length) continue;
                int len = BitConverter.ToInt32(lenBuffer, 0);

                byte[] msgBuffer = new byte[len];
                if (Client.Client.Receive(msgBuffer) != msgBuffer.Length) continue;
                string msg = Encoding.UTF8.GetString(msgBuffer);

                txtChat.Invoke( (MethodInvoker) ( () =>
                {
                    txtChat.AppendText(ip, Color.FromArgb(BitConverter.ToInt32(ipBuffer, 0) ) );
                    txtChat.AppendText(" ▸ ");
                    txtChat.AppendText(msg);
                    txtChat.AppendText("\n");
                }) );
            }    
        }

        private void txtMessage_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            byte[] buf = Encoding.UTF8.GetBytes(txtMessage.Text);
            Client.Client.Send(BitConverter.GetBytes(buf.Length) );
            Client.Client.Send(buf);

            txtMessage.Text = "";
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
