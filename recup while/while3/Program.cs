using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace while3
{
    class Program
    {
        static void Main(string[] args)
        {
            int compteur = -2;

            while (compteur<10000)
            {
                compteur += 2;
                Console.WriteLine(compteur);
            }
            Console.ReadLine();
        }
    }
}
