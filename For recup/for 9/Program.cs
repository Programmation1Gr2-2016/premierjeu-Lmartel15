using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace for_9
{
    class Program
    {
        static void Main(string[] args)
        {

            for (int i = 1; i <= 12; i++)
            {
                for (int j = 10; j >= 0; j -= 2)
                {
                    Console.Write(j+" ");
                }
                Console.WriteLine("");

            }
            Console.ReadLine();
        }
    }
}
