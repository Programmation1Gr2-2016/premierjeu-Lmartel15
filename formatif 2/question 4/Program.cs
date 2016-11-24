using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace question_4
{
    class Program
    {
        static void Main(string[] args)
        {




            int compteurfemme = 0;
            int compteurhomme = 0;
            string sexe = "";
            Console.WriteLine("quel sexe ?");
            sexe = Console.ReadLine();

           

            
                switch (sexe)
                {
                    case "F":
                        ++compteurfemme;
                        Console.WriteLine("femme");
                        break;

                    case "M":
                        ++compteurhomme;
                        Console.WriteLine("homme");
                        break;

                    case "f":
                        ++compteurfemme;
                        Console.WriteLine("femme");
                        break;

                             case "m":
                        ++compteurhomme;
                        Console.WriteLine("homme");
                        break;

                    default:
                        Console.WriteLine("FIN");
                        break;

                }
            

            Console.ReadLine();

        }
    }
}
