using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ServerApp
{
    public partial class ServerForm : Form
    {
        private TcpListener server;
        private List<ClientHandler> clients = new List<ClientHandler>();
        private bool isRunning = false;
        private const int Port = 80; // Используем порт 80 как в исходном коде

        public ServerForm()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                server = new TcpListener(IPAddress.Any, Port);
                server.Start();
                isRunning = true;
                btnStart.Enabled = false;
                btnStop.Enabled = true;

                // Получаем и отображаем все локальные IP-адреса
                string ipAddresses = GetLocalIPAddresses();
                AddLog($"Сервер запущен на порту {Port}");
                AddLog($"Доступен по следующим адресам:\n{ipAddresses}");

                Thread listenThread = new Thread(ListenForClients);
                listenThread.IsBackground = true;
                listenThread.Start();
            }
            catch (Exception ex)
            {
                AddLog($"Ошибка запуска сервера: {ex.Message}");
            }
        }

        private string GetLocalIPAddresses()
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                var host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork) // Только IPv4
                    {
                        sb.AppendLine($"- {ip.ToString()}");
                    }
                }
            }
            catch (Exception ex)
            {
                sb.AppendLine($"Ошибка получения IP: {ex.Message}");
            }

            if (sb.Length == 0)
            {
                sb.AppendLine("localhost (127.0.0.1)");
            }

            return sb.ToString();
        }

        // Остальные методы остаются без изменений
        private void ListenForClients()
        {
            while (isRunning)
            {
                try
                {
                    TcpClient client = server.AcceptTcpClient();
                    ClientHandler clientHandler = new ClientHandler(client, this);
                    clients.Add(clientHandler);

                    Thread clientThread = new Thread(clientHandler.HandleClient);
                    clientThread.IsBackground = true;
                    clientThread.Start();
                }
                catch
                {
                    // Сервер остановлен
                }
            }
        }

        public void AddLog(string message)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)(() => AddLog(message)));
                return;
            }

            txtLog.AppendText($"{DateTime.Now:HH:mm:ss} - {message}\r\n");
        }

        public void UpdateClientList()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)(UpdateClientList));
                return;
            }

            lstClients.Items.Clear();
            foreach (var client in clients)
            {
                if (client.IsConnected)
                    lstClients.Items.Add(client.ClientName);
            }
        }

        public void BroadcastMessage(string message, string senderName)
        {
            AddLog($"Сообщение от {senderName}: {message}");

            // Отправляем сообщение всем подключенным клиентам
            foreach (var client in clients)
            {
                if (client.IsConnected)
                {
                    // Форматируем сообщение с указанием отправителя
                    string formattedMessage = $"{senderName}: {message}";
                    client.SendMessage(formattedMessage);
                }
            }
        }

        public void RemoveClient(ClientHandler client)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)(() => RemoveClient(client)));
                return;
            }

            clients.Remove(client);
            UpdateClientList();
            AddLog($"Клиент {client.ClientName} отключился");
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            StopServer();
        }

        private void StopServer()
        {
            isRunning = false;
            server.Stop();

            foreach (var client in clients)
            {
                client.Disconnect();
            }
            clients.Clear();

            btnStart.Enabled = true;
            btnStop.Enabled = false;
            AddLog("Сервер остановлен");
        }

        private void ServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isRunning)
            {
                StopServer();
            }
        }
    }

    public class ClientHandler
    {
        private TcpClient client;
        private NetworkStream stream;
        private ServerForm server;
        private string clientName;
        private bool isConnected = true;

        public string ClientName => clientName;
        public bool IsConnected => isConnected;

        public ClientHandler(TcpClient client, ServerForm server)
        {
            this.client = client;
            this.server = server;
            this.stream = client.GetStream();
        }

        public void HandleClient()
        {
            try
            {
                // Получаем имя клиента
                byte[] buffer = new byte[4096];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                clientName = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                server.AddLog($"Подключился новый клиент: {clientName}");
                server.UpdateClientList();

                // Принимаем сообщения от клиента
                while (isConnected)
                {
                    bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0)
                    {
                        Disconnect();
                        break;
                    }

                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    server.BroadcastMessage(message, clientName);
                }
            }
            catch
            {
                Disconnect();
            }
        }

        public void SendMessage(string message)
        {
            try
            {
                byte[] messageBytes = Encoding.UTF8.GetBytes(message);
                stream.Write(messageBytes, 0, messageBytes.Length);
            }
            catch
            {
                Disconnect();
            }
        }

        public void Disconnect()
        {
            if (isConnected)
            {
                isConnected = false;
                stream?.Close();
                client?.Close();
                server.RemoveClient(this);
            }
        }
    }
}