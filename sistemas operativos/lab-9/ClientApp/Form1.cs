using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Globalization;

namespace ClientApp
{
    public partial class Form1 : Form
    {
        private TcpClient client;
        private NetworkStream stream;
        private Thread receiveThread;
        private bool isConnected = false;

        public Form1()
        {
            InitializeComponent();
            txtMessage.KeyDown += TxtMessage_KeyDown;
        }

        private void TxtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(txtMessage.Text))
            {
                btnSend_Click(sender, e);
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (isConnected) return;

            try
            {
                client = new TcpClient();
                client.Connect(txtServerIP.Text, 80);
                stream = client.GetStream();

                // Отправляем ID серверу
                byte[] idBytes = Encoding.UTF8.GetBytes(txtClientID.Text);
                stream.Write(idBytes, 0, idBytes.Length);

                isConnected = true;
                btnConnect.Enabled = false;
                txtServerIP.Enabled = false;
                txtClientID.Enabled = false;

                // Запускаем поток для получения сообщений
                receiveThread = new Thread(ReceiveMessages);
                receiveThread.IsBackground = true;
                receiveThread.Start();

                AddMessageToChat("Подключено к серверу");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения: {ex.Message}");
            }
        }

        private void ReceiveMessages()
        {
            byte[] buffer = new byte[4096];
            while (isConnected)
            {
                try
                {
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead > 0)
                    {
                        string receivedMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                        // Проверяем, не наше ли это сообщение (чтобы избежать дублирования)
                        if (!receivedMessage.StartsWith(txtClientID.Text + ":"))
                        {
                            Invoke((MethodInvoker)(() => AddMessageToChat(receivedMessage)));
                        }
                    }
                }
                catch
                {
                    if (isConnected)
                    {
                        Invoke((MethodInvoker)(() => AddMessageToChat("Соединение с сервером потеряно")));
                        Disconnect();
                    }
                    break;
                }
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            SendMessage(txtMessage.Text);
            txtMessage.Clear();
        }

        private void btnSendSystemInfo_Click(object sender, EventArgs e)
        {
            string fullSystemInfo = GetFullSystemInfo();
            SendMessage(fullSystemInfo);
        }

        private string GetFullSystemInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("=== Полная системная информация ===");
            sb.AppendLine(GetSystemInfo());
            sb.AppendLine(GetDiskInfo());
            sb.AppendLine(GetNetworkInfo());
            sb.AppendLine(GetProcessInfo());
            sb.AppendLine(GetHardwareInfo());
            sb.AppendLine(GetTimeInfo());
            sb.AppendLine(GetKeyboardInfo());
            return sb.ToString();
        }

        private void SendMessage(string message)
        {
            if (!isConnected || string.IsNullOrEmpty(message)) return;

            try
            {
                // Мгновенно отображаем свое сообщение в чате
                AddMessageToChat($"Я: {message}");

                // Отправляем сообщение на сервер
                byte[] messageBytes = Encoding.UTF8.GetBytes(message);
                stream.Write(messageBytes, 0, messageBytes.Length);
            }
            catch (Exception ex)
            {
                AddMessageToChat($"Ошибка отправки сообщения: {ex.Message}");
                Disconnect();
            }
        }

        private void AddMessageToChat(string message)
        {
            txtChat.AppendText($"{DateTime.Now:HH:mm:ss} - {message}\r\n");
            txtChat.ScrollToCaret(); // Автоматическая прокрутка к новому сообщению
        }

        // Все методы получения системной информации
        static string GetSystemInfo()
        {
            var sb = new StringBuilder();
            sb.AppendLine("=== Системная информация ===");
            sb.AppendLine($"ОС: {Environment.OSVersion}");
            sb.AppendLine($"Версия ОС: {Environment.OSVersion.VersionString}");
            sb.AppendLine($"Имя ПК: {Environment.MachineName}");
            sb.AppendLine($"Имя пользователя: {Environment.UserName}");
            sb.AppendLine($"Домен: {Environment.UserDomainName}");
            sb.AppendLine($"Количество процессоров: {Environment.ProcessorCount}");
            sb.AppendLine($"Системная папка: {Environment.SystemDirectory}");
            sb.AppendLine($"Время работы системы: {TimeSpan.FromMilliseconds(Environment.TickCount)}");
            sb.AppendLine($"64-битная система: {Environment.Is64BitOperatingSystem}");
            sb.AppendLine($"Текущая культура: {CultureInfo.CurrentCulture.Name}");
            return sb.ToString();
        }

        static string GetDiskInfo()
        {
            var sb = new StringBuilder();
            sb.AppendLine("=== Информация о дисках ===");
            foreach (var drive in DriveInfo.GetDrives().Where(d => d.IsReady))
            {
                sb.AppendLine($"{drive.Name} ({drive.DriveType})");
                sb.AppendLine($"  Файловая система: {drive.DriveFormat}");
                sb.AppendLine($"  Всего: {drive.TotalSize / (1024 * 1024 * 1024)} GB");
                sb.AppendLine($"  Свободно: {drive.TotalFreeSpace / (1024 * 1024 * 1024)} GB");
            }
            return sb.ToString();
        }

        static string GetNetworkInfo()
        {
            var sb = new StringBuilder();
            sb.AppendLine("=== Сетевая информация ===");
            foreach (var ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.OperationalStatus != OperationalStatus.Up) continue;

                sb.AppendLine($"{ni.Name} ({ni.NetworkInterfaceType})");
                foreach (var ip in ni.GetIPProperties().UnicastAddresses)
                {
                    if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                    {
                        sb.AppendLine($"  IP: {ip.Address}");
                    }
                }
            }
            return sb.ToString();
        }

        static string GetProcessInfo()
        {
            var sb = new StringBuilder();
            sb.AppendLine("=== Топ-10 процессов по памяти ===");
            foreach (var p in Process.GetProcesses()
                .OrderByDescending(p => p.WorkingSet64)
                .Take(10))
            {
                try
                {
                    sb.AppendLine($"{p.ProcessName} (ID: {p.Id})");
                    sb.AppendLine($"  Запущен: {p.StartTime}");
                    sb.AppendLine($"  Память: {p.WorkingSet64 / 1024 / 1024} MB");
                }
                catch { }
            }
            return sb.ToString();
        }

        static string GetHardwareInfo()
        {
            var sb = new StringBuilder();
            sb.AppendLine("=== Аппаратная информация ===");
            try
            {
                using (var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor"))
                {
                    foreach (var item in searcher.Get())
                    {
                        sb.AppendLine($"Процессор: {item["Name"]}");
                        sb.AppendLine($"  Ядер: {item["NumberOfCores"]}");
                    }
                }

                using (var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMemory"))
                {
                    long total = 0;
                    foreach (var item in searcher.Get())
                    {
                        total += Convert.ToInt64(item["Capacity"]) / 1024 / 1024;
                    }
                    sb.AppendLine($"Всего памяти: {total} MB");
                }
            }
            catch (Exception ex)
            {
                sb.AppendLine($"Ошибка получения данных: {ex.Message}");
            }
            return sb.ToString();
        }

        static string GetTimeInfo()
        {
            var sb = new StringBuilder();
            sb.AppendLine("=== Временная информация ===");
            sb.AppendLine($"Текущее время: {DateTime.Now}");
            sb.AppendLine($"Часовой пояс: {TimeZoneInfo.Local.DisplayName}");
            sb.AppendLine($"UTC время: {DateTime.UtcNow}");
            sb.AppendLine($"Локальное время: {DateTime.Now.ToLocalTime()}");
            sb.AppendLine($"Дата: {DateTime.Now.ToShortDateString()}");
            sb.AppendLine($"Время: {DateTime.Now.ToShortTimeString()}");
            return sb.ToString();
        }

        static string GetKeyboardInfo()
        {
            var sb = new StringBuilder();
            sb.AppendLine("=== Информация о клавиатуре ===");
            try
            {
                sb.AppendLine($"Текущая раскладка: {InputLanguage.CurrentInputLanguage.Culture.EnglishName}");
                sb.AppendLine($"Код языка: {InputLanguage.CurrentInputLanguage.Culture.Name}");
                sb.AppendLine($"Доступные раскладки:");

                foreach (InputLanguage lang in InputLanguage.InstalledInputLanguages)
                {
                    sb.AppendLine($"- {lang.Culture.EnglishName} ({lang.Culture.Name})");
                }
            }
            catch (Exception ex)
            {
                sb.AppendLine($"Ошибка получения информации о клавиатуре: {ex.Message}");
            }
            return sb.ToString();
        }

        private void Disconnect()
        {
            if (isConnected)
            {
                isConnected = false;
                stream?.Close();
                client?.Close();
                Invoke((MethodInvoker)(() => {
                    btnConnect.Enabled = true;
                    txtServerIP.Enabled = true;
                    txtClientID.Enabled = true;
                }));
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Disconnect();
            receiveThread?.Abort();
        }
    }
}