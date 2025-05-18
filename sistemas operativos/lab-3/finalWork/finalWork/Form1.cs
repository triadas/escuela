using System.Diagnostics;
using System.IO.Packaging;
using System.Net.Http.Headers;
using System.Windows.Forms;

namespace finalWork
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            CreateFile();
        }

        private void showInfo_Click(object sender, EventArgs e)
        {
            FileInfo();
            DeleteFile();
        }

        void CreateFile(string path = "C:\\Users\\que mienten\\Documents\\waste\\drives.log", string newPath = "C:\\Users\\que mienten\\Documents\\waste\\drives.txt")
        {
            pathValue.Text = "C:\\Users\\que mienten\\Documents\\waste\\drives.log";
            File.Create(path).Close();
            File.Copy(path, newPath, overwrite: true);
            //File.Move(path, newPath);
            //File.Move(path, newPath);
        }

        public void FileInfo(string path = "C:\\Users\\que mienten\\Documents\\waste\\drives.log")
        {
            infoValue.Clear();

            if (!File.Exists(path))
            {
                MessageBox.Show("Файл не найден.");
                infoValue.Text = "Файл не найден.";
                return;
            }

            FileInfo fileInfo = new FileInfo(path);

            infoValue.Multiline = true;
            infoValue.Text = "Имя файла: " + fileInfo.Name +
                             "Полный путь: " + fileInfo.FullName + "\n" +
                             "Расширение: " + fileInfo.Extension + "\n" +
                             "Размер: " + fileInfo.Length + " байт" + "\n" +
                             "Создан: " + fileInfo.CreationTime + "\n" +
                             "Изменён: " + fileInfo.LastWriteTime + "\n" +
                             "Последний доступ: " + fileInfo.LastAccessTime + "\n" +
                             "Атрибуты: " + fileInfo.Attributes + "\n" +
                             "Только для чтения: " + fileInfo.IsReadOnly + "\n" +
                             "Родительская директория: " + fileInfo.DirectoryName + "\n" +
                             "Время создания UTC: " + fileInfo.CreationTimeUtc + "\n" +
                             "Изменён UTC: " + fileInfo.LastWriteTimeUtc + "\n" +
                             "Доступ UTC: " + fileInfo.LastAccessTimeUtc;
        }

        public void DeleteFile(string path = "C:\\Users\\que mienten\\Documents\\waste\\drives.log", string newPath = "C:\\Users\\que mienten\\Documents\\waste\\drives.txt")
        {
            File.Delete(path);
            File.Delete(newPath);
        }



    }
}
