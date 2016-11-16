using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace for_6
{
    class Program
    {
        static void Main(string[] args)
        {

            double solde = 0;            
            double montantdepose = 0.01;

            for (int i = 1; i <= 10; i++)
            {
                solde = solde + montantdepose;
                montantdepose *= 2;
                Console.Write("Jour: " + i); Console.WriteLine("   solde: "+solde);

            }
            Console.WriteLine("");
            Console.WriteLine("voici le soldefinal : "+solde);
            Console.ReadLine();

        }
    }
}
