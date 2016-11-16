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
            int x = 0;
            int y = 2;

            while (compteur <= 100)
            {
                
                int nombre = rnd.Next(x,y);
                Console.WriteLine(nombre);
                compteur++;
               

            }
            

            Console.ReadLine();
        }
    }
}
