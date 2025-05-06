using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Girrafe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Movie movie1 = new Movie("шрек", "Твоя мадь", "рандом");

            Console.WriteLine(movie1.Rating);
            Console.ReadLine();
        }

    }
}
