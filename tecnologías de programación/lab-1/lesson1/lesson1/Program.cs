//using System;

//namespace HelloApp
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("Введите первое число: ");
//            int num1 = Convert.ToInt32(Console.ReadLine());
//            Console.WriteLine("Введите второе число: ");
//            int num2 = Convert.ToInt32(Console.ReadLine());

//            if (num1 > num2)
//            {
//                Console.WriteLine("Первое число больше второго");
//            }
//            else if (num1 < num2)
//            {
//                Console.WriteLine("Первое число меньше второго");
//            }
//            else
//            {
//                Console.WriteLine("Оба числа равны");
//            }
//            Console.ReadKey();
//        }
//    }
//}

//namespace lesson1
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("Введите число:");
//            double value = Convert.ToDouble(Console.ReadLine());

//            if (5<value && value < 10)
//                Console.WriteLine("Число больше 5 и меньше 10");
//            else
//                Console.WriteLine("Неизвестное число");
//        }
//    }
//}

//namespace lesson1Task3
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("Введите число:");
//            double value = Convert.ToDouble(Console.ReadLine());

//            if (5 == value || value == 10)
//                Console.WriteLine("Число либо равно 5 либо равно 10");
//            else
//                Console.WriteLine("Неизвестное число");
//        }
//    }
//}

//namespace lesson1Task4
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("В банке в зависимости от суммы вклада начисляемый процент по вкладу может отличаться. ");
//            Console.WriteLine("Напишите сумму вклада(в т.р.): ");
//            double importe = Convert.ToDouble(Console.ReadLine());

//            if (importe < 100.0)
//                importe *= (1.0+0.05);
//            else if (importe>=100 && importe<=200)
//                importe *= (1.0 + 0.07);
//            else
//                importe *= (1.0 + 0.10);
//            importe += 15;

//            Console.WriteLine($"Cумма вклада с начисленными процентами: {importe}т.р.");
//        }
//    }
//}

//namespace lesson1Task6
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("В банке в зависимости от суммы вклада начисляемый процент по вкладу может отличаться. ");
//            Console.WriteLine("Напишите сумму вклада(в т.р.): ");
//            decimal importe = Convert.ToDecimal(Console.ReadLine());

//            Console.WriteLine("Напишите количество месяцев:");
//            decimal meses = Convert.ToDecimal(Console.ReadLine());

//            int i = 0;
//            while(i<meses)
//            {
//                importe *= (1.0m + 7.0m / 100.0m/12m);
//                i++;
//            }

//            Console.WriteLine($"Cумма вклада с начисленными процентами: {importe}т.р.");
//        }
//    }
//}

namespace lesson1Task6
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Введите перевое число: ");
                double a = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Введите второе число: ");
                double b = Convert.ToDouble(Console.ReadLine());

                if (a < 0 || a > 10 || b < 0 || b > 10)
                    Console.WriteLine("Числа больше 10 или менльше 0");
                else
                {
                    Console.WriteLine($"Результат умножения: {a * b}");
                    break;
                }
            }
        }
    }
}
