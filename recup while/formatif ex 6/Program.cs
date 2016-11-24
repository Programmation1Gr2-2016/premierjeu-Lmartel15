using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace formatif_ex_6
{
    class Program
    {
        static void Main(string[] args)
        {
            int compteurhomme = 0;
            int compteurfemme = 0;
            int montanttotal = 0;
            int age = 0;
            string nom = "";
            string prenom = "";
            int montant = 0;
            string sexe = "";

            while (nom != "quitter")
            {
                Console.WriteLine("quel est votre prenom ?");
                prenom = string.Copy(Console.ReadLine());                

                Console.WriteLine("quel est votre nom");
                nom = string.Copy(Console.ReadLine());

                Console.WriteLine("quel est votre age");
                age = int.Parse(Console.ReadLine());


                Console.WriteLine("quel est votre sexe");
                sexe = Console.ReadLine();
                switch (sexe)
                {
                    case "M":
                        sexe = "homme";
                        
                    break;

                    case "F":
                        sexe = "femme";
                        
                        break;                       
                }


                Console.WriteLine("Quel est le montant paye ?");
                montant = int.Parse(Console.ReadLine());

                if (sexe == "homme"&& age > 30)
                {
                    compteurhomme++;
                }

                if (sexe == "femme" && age > 25)
                {
                    compteurfemme++;
                }

                if (montant > 0)
                {
                    montanttotal += montant;
                }
                
                
            }
            Console.WriteLine("nombre d'hommes qui ont plus de 30 ans: "+compteurhomme);
            Console.WriteLine("nombre de femmes qui ont plus de 25 ans: "+compteurfemme);
            Console.WriteLine(montanttotal);
            Console.ReadLine();

        }
    }
}
