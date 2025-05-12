using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] arr = GetData();

            if (arr == null || arr.Length == 0)
            {
                Console.WriteLine("Ошибка: массив данных пуст.\n");
                return;
            }

            GetArrs(arr, out var arr1, out var arr2);

            Console.WriteLine("arr1: ");
            ShowArr(arr1);
            Console.WriteLine("arr2: ");
            ShowArr(arr2);
        }

        static public void ShowArr(double[,] arr)
        {
            if (arr == null)
            {
                Console.WriteLine("Массив пуст (null). Невозможно отобразить.\n");
                return;
            }

            int rows = arr.GetLength(0);
            int cols = arr.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(arr[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }


        static public double[] GetData(string path = "C:\\Users\\que mienten\\Documents\\GitHub\\escuela\\waste\\vector.txt")
        {
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    double[] arr = sr.ReadLine()
                                     .Replace('.', ',')
                                     .Split(' ')
                                     .Select(s => Convert.ToDouble(s))
                                     .ToArray();
                    return arr;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        static public void GetArrs(double[] arr, out double[,] Arr1, out double[,] Arr2)
        {
            int N, M;
            while (true)
            {
                Console.Write("Введите кол-во строк выходных массивов: ");
                N = Convert.ToInt32(Console.ReadLine());
                if (N > 0)
                    break;
            }
            while (true)
            {
                Console.Write("Введите кол-во столбцов выходных массивов: ");
                M = Convert.ToInt32(Console.ReadLine());
                if (M > 0)
                    break;
            }

            Console.Write("Введите метод заполнения выходных массивов (по строкам, по столбцам или змейкой): \n");
            string method = Console.ReadLine().ToLower();

            double[,] arr1 = new double[N, M];
            double[,] arr2 = new double[N, M];

            int k = 0;

            void FillSnake(double[,] target)
            {
                for (int i = 0; i < N; i++)
                {
                    if (i % 2 == 0)
                    {
                        for (int j = 0; j < M && k < arr.Length; j++)
                            target[i, j] = arr[k++];
                    }
                    else
                    {
                        for (int j = M - 1; j >= 0 && k < arr.Length; j--)
                            target[i, j] = arr[k++];
                    }
                }
            }

            void FillRows(double[,] target)
            {
                for (int i = 0; i < N; i++)
                    for (int j = 0; j < M && k < arr.Length; j++)
                        target[i, j] = arr[k++];
            }

            void FillCols(double[,] target)
            {
                for (int j = 0; j < M; j++)
                    for (int i = 0; i < N && k < arr.Length; i++)
                        target[i, j] = arr[k++];
            }

            if (method == "змейка" || method == "змейкой" || method == "snake")
            {
                FillSnake(arr1);
                FillSnake(arr2);
            }
            else if (method == "по строкам" || method == "строка" || method == "по строке" || method == "строкой")
            {
                FillRows(arr1);
                FillRows(arr2);
            }
            else if (method == "по столбцам" || method == "столбец" || method == "по столбцу" || method == "столбцом")
            {
                FillCols(arr1);
                FillCols(arr2);
            }
            else
            {
                Console.WriteLine("Недопустимый метод заполнения.");
                Arr1 = null;
                Arr2 = null;
                return;
            }

            Arr1 = arr1;
            Arr2 = arr2;
        }


    }
}
