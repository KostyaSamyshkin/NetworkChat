﻿using System;
using System.Net;
using System.Windows.Forms;

namespace NetworkChat1
{
    public partial class ConnectForm : Form
    {
        public ConnectForm()
        {
            InitializeComponent();
        }

        private void rbnServer_CheckedChanged(object sender, EventArgs e)
        {
            txtIP.Visible = !rbnServer.Checked;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (rbnServer.Checked)
            {
                new ServerForm().Show();
            }
            else
            {
                if (!IPAddress.TryParse(txtIP.Text, out _) )
                {
                    MessageBox.Show(this, "Неверный IP адрес сервера!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                new MainForm(txtIP.Text).Show();
            }

            this.Hide();
        }
    }
}
