using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace while4
{
    class Program
    {
        static void Main(string[] args)
        {
            int compteur1 = 1;
            int compteur2 = 20;

            while (compteur1 <= 10)
            {
                while (compteur2 >=2)
                {
                    Console.WriteLine(compteur2);                   
                    compteur2--;
                }
                compteur1++;
                compteur2 = 20;
            }

            Console.ReadLine();

        }
    }
}
