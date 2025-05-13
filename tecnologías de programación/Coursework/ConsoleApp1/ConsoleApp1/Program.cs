using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    static public class Program
    {
        static void Main(string[] args)
        {
            double[] arr = GetData();

            if (arr == null || arr.Length == 0)
            {
                Console.WriteLine("Ошибка: массив данных пуст.\n");
                return;
            }

            //GetArrs(arr, out var arr1, out var arr2);
            double[,,] OutputArr = GetOutputArr(arr);
            int numArr = OutputArr.GetLength(0);
            int rows = OutputArr.GetLength(1);
            int cols = OutputArr.GetLength(2);

            for (int i = 0; i < numArr; i++)
            {
                Console.WriteLine("Массив " + (i + 1));
                for (int j = 0; j < rows; j++)
                {
                    for (int k = 0; k < cols; k++)
                    {
                        Console.Write(OutputArr[i, j, k] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }

        }

        //static public void ShowArr(double[,] arr)
        //{
        //    if (arr == null)
        //    {
        //        Console.WriteLine("Массив пуст (null). Невозможно отобразить.\n");
        //        return;
        //    }

        //    int rows = arr.GetLength(0);
        //    int cols = arr.GetLength(1);

        //    for (int i = 0; i < rows; i++)
        //    {
        //        for (int j = 0; j < cols; j++)
        //        {
        //            Console.Write(arr[i, j] + "\t");
        //        }
        //        Console.WriteLine();
        //    }
        //}


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

        static public double[,,] GetOutputArr(double[] arr)
        {
            int G, N, M;
            while (true)
            {
                try
                {
                    Console.Write("Введите кол-во строк выходных массивов: ");
                    N = Convert.ToInt32(Console.ReadLine());
                    if (N > 0)
                        break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            while (true)
            {
                try
                {
                    Console.Write("Введите кол-во столбцов выходных массивов: ");
                    M = Convert.ToInt32(Console.ReadLine());
                    if (M > 0)
                        break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            Console.Write("Введите метод заполнения выходных массивов (по строкам, по столбцам или змейкой): \n");
            string method = Console.ReadLine().ToLower();

            G = arr.Length / (M * N) + 1;
            double[,,] outputArr = new double[G, N, M];

            int k = 0;

            void FillSnake(double[,,] target, int arrNum)
            {

                for (int i = 0; i < N; i++)
                {
                    if (i % 2 == 0)
                    {
                        for (int j = 0; j < M && k < arr.Length; j++)
                            target[arrNum, i, j] = arr[k++];
                    }
                    else
                    {
                        for (int j = M - 1; j >= 0 && k < arr.Length; j--)
                            target[arrNum, i, j] = arr[k++];
                    }
                }
            }

            void FillRows(double[,,] target, int arrNum)
            {
                for (int i = 0; i < N; i++)
                    for (int j = 0; j < M && k < arr.Length; j++)
                        target[arrNum, i, j] = arr[k++];
            }

            void FillCols(double[,,] target, int arrNum)
            {
                for (int j = 0; j < M; j++)
                    for (int i = 0; i < N && k < arr.Length; i++)
                        target[arrNum, i, j] = arr[k++];
            }

            if (method == "змейка" || method == "змейкой" || method == "snake" || method == "s")
                for (int i = 0; i < G; i++)
                    FillSnake(outputArr, i);

            else if (method == "по строкам" || method == "строка" || method == "по строке" || method == "строкой" || method == "по строке" || method == "стр")
                for (int i = 0; i < G; i++)
                    FillRows(outputArr, i);

            else if (method == "по столбцам" || method == "столбец" || method == "по столбцу" || method == "столбцом" || method == "по столбцу" || method == "стл")
                for (int i = 0; i < G; i++)
                    FillCols(outputArr, i);

            else
            {
                Console.WriteLine("Недопустимый метод заполнения.");
                outputArr = null;
                return outputArr;
            }
            return outputArr;
        }


    }
}
