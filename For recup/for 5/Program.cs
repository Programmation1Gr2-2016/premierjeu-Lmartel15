using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace for_5
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(i);
            }

            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(i * i);
            }

            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(i * i * i);
            }
            Console.ReadLine();

        }
    }
}
