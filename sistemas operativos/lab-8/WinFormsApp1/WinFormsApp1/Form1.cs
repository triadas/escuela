using System;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.Win32;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadRegistryKeys();
        }

        private void LoadRegistryKeys()
        {
            treeViewRegistry.Nodes.Clear();

            // Добавим основные корневые ветки
            AddRegistryRootKey(Registry.CurrentUser, "HKEY_CURRENT_USER");
            AddRegistryRootKey(Registry.LocalMachine, "HKEY_LOCAL_MACHINE");
        }

        private void AddRegistryRootKey(RegistryKey rootKey, string rootName)
        {
            TreeNode rootNode = new TreeNode(rootName) { Tag = rootKey.Name };
            treeViewRegistry.Nodes.Add(rootNode);
            LoadSubKeys(rootKey, rootNode);
        }

        private void LoadSubKeys(RegistryKey parentKey, TreeNode parentNode)
        {
            try
            {
                foreach (string subKeyName in parentKey.GetSubKeyNames())
                {
                    TreeNode subNode = new TreeNode(subKeyName);
                    parentNode.Nodes.Add(subNode);

                    using (RegistryKey subKey = parentKey.OpenSubKey(subKeyName))
                    {
                        if (subKey != null)
                        {
                            if (HasSubKeys(subKey))
                            {
                                // Добавим узел-заглушку для возможности разворачивания
                                subNode.Nodes.Add(new TreeNode("..."));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogChange($"Ошибка загрузки под ключей {parentNode.FullPath}: {ex.Message}");
            }
        }

        private bool HasSubKeys(RegistryKey key)
        {
            try
            {
                return key.GetSubKeyNames().Length > 0;
            }
            catch
            {
                return false;
            }
        }

        private void treeViewRegistry_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode node = e.Node;
            if (node.Nodes.Count == 1 && node.Nodes[0].Text == "...")
            {
                node.Nodes.Clear();
                string path = GetFullRegistryPath(node);
                using (RegistryKey key = OpenRegistryKeyByPath(path))
                {
                    if (key != null)
                    {
                        LoadSubKeys(key, node);
                    }
                }
            }
        }

        private void treeViewRegistry_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string path = GetFullRegistryPath(e.Node);
            using (RegistryKey key = OpenRegistryKeyByPath(path))
            {
                if (key != null)
                {
                    // По умолчанию читаем значение по умолчанию (null)
                    var value = key.GetValue(null);
                    textBoxValue.Text = value != null ? value.ToString() : string.Empty;
                }
                else
                {
                    textBoxValue.Text = string.Empty;
                }
            }
        }

        private string GetFullRegistryPath(TreeNode node)
        {
            string path = node.Text;
            TreeNode current = node.Parent;
            while (current != null)
            {
                path = current.Text + "\\" + path;
                current = current.Parent;
            }
            return path;
        }

        private RegistryKey OpenRegistryKeyByPath(string fullPath)
        {
            // Определить корневой ключ
            if (fullPath.StartsWith("HKEY_CURRENT_USER"))
            {
                string subPath = fullPath.Substring("HKEY_CURRENT_USER".Length);
                return Registry.CurrentUser.OpenSubKey(subPath, true);
            }
            else if (fullPath.StartsWith("HKEY_LOCAL_MACHINE"))
            {
                string subPath = fullPath.Substring("HKEY_LOCAL_MACHINE".Length);
                return Registry.LocalMachine.OpenSubKey(subPath, true);
            }
            else
            {
                LogChange($"Корневой ключ {fullPath} не поддерживается.");
                return null;
            }
        }

        private void buttonWrite_Click(object sender, EventArgs e)
        {
            if (treeViewRegistry.SelectedNode == null)
            {
                MessageBox.Show("Выберите ключ реестра для записи значения.");
                return;
            }

            string path = GetFullRegistryPath(treeViewRegistry.SelectedNode);

            try
            {
                using (RegistryKey key = OpenOrCreateRegistryKeyByPath(path))
                {
                    if (key != null)
                    {
                        key.SetValue(null, textBoxValue.Text); // Запись значения по умолчанию (null)
                        LogChange($"Записано значение в {path}: {textBoxValue.Text}");
                    }
                    else
                    {
                        MessageBox.Show("Не удалось открыть ключ для записи.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка записи в реестр: " + ex.Message);
            }
        }

        private RegistryKey OpenOrCreateRegistryKeyByPath(string fullPath)
        {
            if (fullPath.StartsWith("HKEY_CURRENT_USER"))
            {
                string subPath = fullPath.Substring("HKEY_CURRENT_USER".Length);
                return Registry.CurrentUser.CreateSubKey(subPath);
            }
            else if (fullPath.StartsWith("HKEY_LOCAL_MACHINE"))
            {
                string subPath = fullPath.Substring("HKEY_LOCAL_MACHINE".Length);
                return Registry.LocalMachine.CreateSubKey(subPath);
            }
            else
            {
                LogChange($"Корневой ключ {fullPath} не поддерживается.");
                return null;
            }
        }

        private void buttonBackup_Click(object sender, EventArgs e)
        {
            try
            {
                string backupFile = "backup.reg";
                ProcessStartInfo psi = new ProcessStartInfo("reg", $"export HKEY_CURRENT_USER {backupFile} /y")
                {
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                };
                using (Process proc = Process.Start(psi))
                {
                    proc.WaitForExit();
                    if (proc.ExitCode == 0)
                    {
                        LogChange($"Резервная копия создана: {backupFile}");
                    }
                    else
                    {
                        string error = proc.StandardError.ReadToEnd();
                        LogChange($"Ошибка создания бэкапа: {error}");
                        MessageBox.Show("Ошибка создания бэкапа: " + error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка создания резервной копии: " + ex.Message);
            }
        }

        private void buttonRestore_Click(object sender, EventArgs e)
        {
            try
            {
                string backupFile = "backup.reg";
                ProcessStartInfo psi = new ProcessStartInfo("reg", $"import {backupFile}")
                {
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                };
                using (Process proc = Process.Start(psi))
                {
                    proc.WaitForExit();
                    if (proc.ExitCode == 0)
                    {
                        LogChange("Реестр восстановлен из резервной копии.");
                        MessageBox.Show("Реестр успешно восстановлен.");
                    }
                    else
                    {
                        string error = proc.StandardError.ReadToEnd();
                        LogChange($"Ошибка восстановления: {error}");
                        MessageBox.Show("Ошибка восстановления: " + error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка восстановления резервной копии: " + ex.Message);
            }
        }

        private void LogChange(string message)
        {
            listBoxLog.Items.Add($"{DateTime.Now}: {message}");
            listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
        }
    }
}

