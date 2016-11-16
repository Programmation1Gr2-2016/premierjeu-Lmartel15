using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace while6
{
    class Program
    {
        static void Main(string[] args)
        {
            int compteur = 0;

            DateTime debut = DateTime.Now;

            while (compteur <= 100000)
            {
                         
                compteur++;
            }
            DateTime fin = DateTime.Now;
            double differencesEnSec = (fin - debut).TotalSeconds;
            Console.WriteLine(differencesEnSec);

            Console.ReadLine();

        }
    }
}
