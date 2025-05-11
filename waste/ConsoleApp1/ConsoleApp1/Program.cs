             using System;
using System.Collections.Generic;
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
            float x = 5f;
            Console.WriteLine(x);

            Coffee coffee1 = new Coffee();
            coffee1.name = "myName";
            coffee1.author = "im";
            coffee1.weigth = 50;

            Console.WriteLine($"{coffee1.name} {coffee1.author} {coffee1.weigth}");
        }
    }
}
