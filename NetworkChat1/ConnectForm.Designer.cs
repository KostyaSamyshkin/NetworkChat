
namespace NetworkChat1
{
    partial class ConnectForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rbnServer = new System.Windows.Forms.RadioButton();
            this.rbnClient = new System.Windows.Forms.RadioButton();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // rbnServer
            // 
            this.rbnServer.AutoSize = true;
            this.rbnServer.Location = new System.Drawing.Point(12, 12);
            this.rbnServer.Name = "rbnServer";
            this.rbnServer.Size = new System.Drawing.Size(62, 17);
            this.rbnServer.TabIndex = 0;
            this.rbnServer.Text = "Сервер";
            this.rbnServer.UseVisualStyleBackColor = true;
            this.rbnServer.CheckedChanged += new System.EventHandler(this.rbnServer_CheckedChanged);
            // 
            // rbnClient
            // 
            this.rbnClient.AutoSize = true;
            this.rbnClient.Checked = true;
            this.rbnClient.Location = new System.Drawing.Point(12, 35);
            this.rbnClient.Name = "rbnClient";
            this.rbnClient.Size = new System.Drawing.Size(61, 17);
            this.rbnClient.TabIndex = 1;
            this.rbnClient.TabStop = true;
            this.rbnClient.Text = "Клиент";
            this.rbnClient.UseVisualStyleBackColor = true;
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(12, 58);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(166, 20);
            this.txtIP.TabIndex = 2;
            this.txtIP.Text = "IP адрес сервера";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 110);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(166, 23);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Запустить";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(12, 84);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(166, 20);
            this.txtUsername.TabIndex = 3;
            this.txtUsername.Text = "Имя пользователя";
            // 
            // ConnectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(190, 141);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.rbnClient);
            this.Controls.Add(this.rbnServer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ConnectForm";
            this.ShowIcon = false;
            this.Text = "Подключение";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbnServer;
        private System.Windows.Forms.RadioButton rbnClient;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtUsername;
    }
}