using System;
using System.Drawing;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace NetworkChat1
{
    public partial class MainForm : Form
    {
        private readonly TcpClient Client;
        private readonly string Username;

        public MainForm(string ip, string username)
        {
            InitializeComponent();
            Username = username;

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
                byte[] lenBuffer = new byte[4];
                if (Client.Client.Receive(lenBuffer) != lenBuffer.Length) continue;
                int len = BitConverter.ToInt32(lenBuffer, 0);

                byte[] nameBuffer = new byte[len];
                if (Client.Client.Receive(nameBuffer) != nameBuffer.Length) continue;
                string name = Encoding.UTF8.GetString(nameBuffer);

                if (Client.Client.Receive(lenBuffer) != lenBuffer.Length) continue;
                len = BitConverter.ToInt32(lenBuffer, 0);

                byte[] msgBuffer = new byte[len];
                if (Client.Client.Receive(msgBuffer) != msgBuffer.Length) continue;
                string msg = Encoding.UTF8.GetString(msgBuffer);

                txtChat.Invoke( (MethodInvoker) (() =>
                {
                    txtChat.AppendText(name, GetColor(name) );
                    txtChat.AppendText(" ▸ ");
                    txtChat.AppendText(msg);
                    txtChat.AppendText("\n");
                }));
            }    
        }

        private void txtMessage_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            byte[] msgbuf = Encoding.UTF8.GetBytes(txtMessage.Text);
            byte[] namebuf = Encoding.UTF8.GetBytes(Username);

            Client.Client.Send(BitConverter.GetBytes(namebuf.Length) );
            Client.Client.Send(namebuf);
            Client.Client.Send(BitConverter.GetBytes(msgbuf.Length) );
            Client.Client.Send(msgbuf);

            txtMessage.Text = "";
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }


        private static Color GetColor(string name)
        {
            int output = 0x3ec61b00;

            foreach (char c in name.ToCharArray() )
            {
                output ^= c;
                output ^= (c ^ 137) << 8;
                output ^= (c ^ 220) << 16;
            }

            return Color.FromArgb(output);
        }
    }
}
