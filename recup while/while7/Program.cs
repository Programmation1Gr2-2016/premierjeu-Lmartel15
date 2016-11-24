using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace while7
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int compteur = 1;
            int compteur0 = 0;
            int compteur1 = 0;

            while (compteur <= 100)
            {
                
                int nombre = rnd.Next(0,2);
                Console.WriteLine(nombre);
                compteur++;
                if (nombre==0)
                {
                    compteur0++;
                }

               else
                {
                    compteur1++;
                }
            }
            

            Console.ReadLine();
        }
    }
}
