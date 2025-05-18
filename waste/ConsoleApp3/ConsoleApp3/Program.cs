using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string @str = "";
            double[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9};

            for(int i = 0; i<arr.Length; i++)
            {
                @str += arr[i].ToString() + " "; 
            }
            Console.WriteLine(@str);
        }
    }
}
