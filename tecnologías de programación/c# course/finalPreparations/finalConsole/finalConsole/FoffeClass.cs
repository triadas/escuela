using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finalConsole
{
    internal class FoffeClass
    {
        public string author;
        public string name;
        private int weigth;
        public static int countCoffe = 0;

        public FoffeClass(string Anauthor, string aName, int aWeigth)
        {
            author = Anauthor;
            name = aName;
            Weigth = aWeigth;
            countCoffe++;
        }

        public string WeigthGreater50()
        {
            if (Weigth > 50)
            {
                return "weigth is greater than 50";
            }
            else
            {
                return "weigth isn't greater than 50";
            }
        }

        public int Weigth
        {
            get { return weigth; }
            set
            {
                int N = 1000;
                int[] arr = new int[N];
                for(int i = 0; i<N; i++)
                {
                    arr[i] = i;
                }

                if (arr.Contains(value))
                {
                    weigth = value;
                }
                else
                {
                    weigth = 50;
                }
            }
        }

        public int GetCountCoffee()
        {
            return countCoffe;
        }
    }

}
