//федосеев 26 вариант

class NameSpace
{
    class Program
    {
        static double f1(double x)
        {
            static double sh(double x)
            {
                return (Math.Exp(x) - Math.Exp(-x)) / 2;
            }
            try
            {
                return (sh(1 / x));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"возникла ошибка {ex} при x = {x}");
            }
            return double.NaN;
        }
        static double f2(double x)
        {
            try
            {
                return (Math.Exp(Math.Pow(100, 1 / x)));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"возникла ошибка {ex} при x = {x}");
            }
            return double.NaN;
        }
        static double f3(double x)
        {
            static double arsh(double x)
            {
                return (Math.Log(x + Math.Sqrt(x * x + 1)));
            }
            try
            {
                return Math.Pow(1.05, arsh(Math.Abs(x + Math.Sin(x))));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"возникла ошибка {ex} при x = {x}");
            }
            return double.NaN;
        }
        static double f4(double x)
        {
            //static double func(double x)
            //{
            //}
            try
            {
                double sum = 0;
                for (int i = 0; i < 1e6; i++)
                {
                    sum = (sum + 1 / (x + Math.Sqrt(i)));
                }
                return sum;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"возникла ошибка {ex} при x = {x}");
            }
            return double.NaN;
        }
        static void Main(string[] args)
        {
            int[,] arr = new int[2, 1000];
            int x = 0;
            double sum = 0;
            while (x < 1000)
            {   
                double f = f1(x) + f2(x) + f3(x) + f4(x);
                arr[0, x] = x;
                arr[1, x] = x;
                sum += f;
                x++;
                if (double.IsInfinity(f) || double.IsNaN(f))
                {
                    Console.WriteLine($"x = {x}, f(x) = беск. или 1/беск.");
                }
                else
                {
                    Console.WriteLine($"x = {x}, f(x) = {f:F2}");
                }
            }
        }
    }
}