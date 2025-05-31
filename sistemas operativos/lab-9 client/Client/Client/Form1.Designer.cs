namespace Client
{
    partial class ClientForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtIP = new TextBox();
            label2 = new Label();
            textBox1 = new TextBox();
            btnConnect = new Button();
            btnDisconnect = new Button();
            txtChat = new RichTextBox();
            txtMessage = new TextBox();
            btnSend = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(158, 42);
            label1.Name = "label1";
            label1.Size = new Size(23, 15);
            label1.TabIndex = 0;
            label1.Text = "IP :";
            // 
            // txtIP
            // 
            txtIP.Location = new Point(187, 39);
            txtIP.Name = "txtIP";
            txtIP.Size = new Size(100, 23);
            txtIP.TabIndex = 1;
            txtIP.Text = "127.0.0.1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(140, 76);
            label2.Name = "label2";
            label2.Size = new Size(41, 15);
            label2.TabIndex = 2;
            label2.Text = "Порт :";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(187, 73);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 3;
            textBox1.Text = "5000";
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(186, 110);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(101, 23);
            btnConnect.TabIndex = 4;
            btnConnect.Text = "Подключиться";
            btnConnect.UseVisualStyleBackColor = true;
            // 
            // btnDisconnect
            // 
            btnDisconnect.Location = new Point(186, 139);
            btnDisconnect.Name = "btnDisconnect";
            btnDisconnect.Size = new Size(101, 23);
            btnDisconnect.TabIndex = 5;
            btnDisconnect.Text = "Отключиться";
            btnDisconnect.UseVisualStyleBackColor = true;
            // 
            // txtChat
            // 
            txtChat.Location = new Point(316, 39);
            txtChat.Name = "txtChat";
            txtChat.ReadOnly = true;
            txtChat.Size = new Size(169, 123);
            txtChat.TabIndex = 6;
            txtChat.Text = "";
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(140, 168);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(345, 23);
            txtMessage.TabIndex = 7;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(257, 197);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(101, 23);
            btnSend.TabIndex = 8;
            btnSend.Text = "Отправить";
            btnSend.UseVisualStyleBackColor = true;
            // 
            // ClientForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSend);
            Controls.Add(txtMessage);
            Controls.Add(txtChat);
            Controls.Add(btnDisconnect);
            Controls.Add(btnConnect);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(txtIP);
            Controls.Add(label1);
            Name = "ClientForm";
            Text = "ClientForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtIP;
        private Label label2;
        private TextBox textBox1;
        private Button btnConnect;
        private Button btnDisconnect;
        private RichTextBox txtChat;
        private TextBox txtMessage;
        private Button btnSend;
    }
}
