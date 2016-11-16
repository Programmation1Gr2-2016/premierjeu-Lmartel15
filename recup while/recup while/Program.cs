using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recup_while
{
    class Program
    {
        static void Main(string[] args)
        {
            int compteur = 0;

            while (compteur<100)
            {
                Console.WriteLine("JE MAITRISE LES BOUCLES!");
                ++compteur;
            }

            Console.ReadLine();

        }
    }
}
