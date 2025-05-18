using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CreateFile();
            FileInfo();
            DeleteFile();
        }
        static void CreateFile(string path = "C:\\Users\\que mienten\\Documents\\waste\\drives.log", string newPath = "C:\\Users\\que mienten\\Documents\\waste\\drives.txt")
        {
            File.Create(path).Close();
            File.Copy(path, newPath, overwrite: true);
            File.Move(path, newPath);
            File.Move(path, newPath);
        }

        static public void FileInfo(string path = "C:\\Users\\que mienten\\Documents\\waste\\drives.log")
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("Файл не найден.");
                return;
            }

            FileInfo fileInfo = new FileInfo(path);

            Console.WriteLine("Имя файла: " + fileInfo.Name);
            Console.WriteLine("Полный путь: " + fileInfo.FullName);
            Console.WriteLine("Расширение: " + fileInfo.Extension);
            Console.WriteLine("Размер: " + fileInfo.Length + " байт");
            Console.WriteLine("Создан: " + fileInfo.CreationTime);
            Console.WriteLine("Изменён: " + fileInfo.LastWriteTime);
            Console.WriteLine("Последний доступ: " + fileInfo.LastAccessTime);
            Console.WriteLine("Атрибуты: " + fileInfo.Attributes);
            Console.WriteLine("Только для чтения: " + fileInfo.IsReadOnly);
            Console.WriteLine("Родительская директория: " + fileInfo.DirectoryName);
            Console.WriteLine("Время создания UTC: " + fileInfo.CreationTimeUtc);
            Console.WriteLine("Изменён UTC: " + fileInfo.LastWriteTimeUtc);
            Console.WriteLine("Доступ UTC: " + fileInfo.LastAccessTimeUtc);
        }

        static public void DeleteFile(string path = "C:\\Users\\que mienten\\Documents\\waste\\drives.log", string newPath = "C:\\Users\\que mienten\\Documents\\waste\\drives.txt")
        {
            File.Delete(path);
            File.Delete(newPath);
        }
    }
}