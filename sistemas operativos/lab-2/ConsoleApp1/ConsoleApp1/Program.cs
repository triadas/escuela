using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                WriteDataInFile();
                Thread.Sleep(5000); // задержка 5 секунд
            }
        }

        static public void WriteDataInFile()
        {
            string path = "C:\\Users\\que mienten\\Documents\\waste\\drives.log";

            using (StreamWriter sr = new StreamWriter(path)) 
            {
                sr.WriteLine("=== " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " ===");
                DriveInfo[] drives = DriveInfo.GetDrives();

                foreach (DriveInfo drive in drives)
                {
                    if (drive.IsReady)
                    {
                        sr.WriteLine("Name: " + drive.Name);
                        sr.WriteLine("Format: " + drive.DriveFormat);
                        sr.WriteLine("Type: " + drive.DriveType);
                        sr.WriteLine("Total Size (GB): " + (drive.TotalSize / (1024 * 1024 * 1024)));
                        sr.WriteLine("Free Space (GB): " + (drive.TotalFreeSpace / (1024 * 1024 * 1024)));
                        sr.WriteLine();
                    }
                }
            }
        }
    }

}

//DriveInfo[] drives = DriveInfo.GetDrives();
//foreach (DriveInfo drive in drives)
//    if (drive.IsReady)
//    {
//        Console.WriteLine(drive.Name);
//        Console.WriteLine(drive.DriveFormat);
//        Console.WriteLine(drive.DriveType);
//        Console.WriteLine(drive.TotalSize);
//        Console.WriteLine(drive.TotalFreeSpace / (1024 * 1024 * 1024));
//    }