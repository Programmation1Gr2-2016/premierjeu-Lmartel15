using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace for_10
{
    class Program
    {
        
        static void Main(string[] args)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 1; j < 5; j++)
                {
                     
                    Console.Write("[" + i + "," + j + "]"); 
                }
                Console.WriteLine("");
            }
            Console.ReadLine();

        }
    }
}
