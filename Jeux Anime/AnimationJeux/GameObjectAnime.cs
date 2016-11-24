using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME_2
{
    class GameObjectAnime
    {
        public Texture2D sprite;
        public Vector2 vitesse;
        public Vector2 direction;
        public Rectangle position;
        public Rectangle spriteAfficher; //Le rectangle affiché à l'écran




        public enum etats { attenteDroite, attenteGauche, runDroite, runGauche };
        public etats objetState;


        //Compteur qui changera le sprite affiché
        private int cpt = 0;

        //GESTION DES TABLEAUX DE SPRITES (chaque sprite est un rectangle dans le tableau)

        int runState = 0; //État de départ
        int nbEtatRun = 8; //Combien il y a de rectangles pour l’état “courrir”

        public Rectangle[] tabRunDroite = {
            new Rectangle(12, 20, 70, 105),
            new Rectangle(112, 25, 70, 105),
            new Rectangle(222, 23, 70, 105),
            new Rectangle(330, 20, 70, 105),
            new Rectangle(436, 21, 70, 105),
            new Rectangle(539, 19, 75, 105),
            new Rectangle(652, 21, 75, 105),
            new Rectangle(762, 22, 70, 105) };

        public Rectangle[] tabRunGauche = {
            new Rectangle(776, 133, 70, 105),
            new Rectangle(669, 128, 70, 105),
            new Rectangle(561, 131, 70, 105),
            new Rectangle(451, 131, 70, 105),
            new Rectangle(346, 131, 70, 105),
            new Rectangle(237, 128, 75, 105),
            new Rectangle(127, 130, 75, 105),
            new Rectangle(20, 131, 70, 105) };

        int waitState = 0;
        public Rectangle[] tabAttenteDroite =
        {
            new Rectangle(11, 248, 70, 105)
        };


        public Rectangle[] tabAttenteGauche =
        {
            new Rectangle(18, 362, 70, 105)
        };

        public virtual void Update(GameTime gameTime)
        {
            if (objetState == etats.attenteDroite)
            {
                spriteAfficher = tabAttenteDroite[waitState];
            }
            if (objetState == etats.attenteGauche)
            {
                spriteAfficher = tabAttenteGauche[waitState];
            }
            if (objetState == etats.runDroite)
            {
                spriteAfficher = tabRunDroite[runState];
            }
            if (objetState == etats.runGauche)
            {
                spriteAfficher = tabRunGauche[runState];
            }

            //Compteur permettant de gérer le changement d'images
            cpt++;
            if (cpt == 8) //Vitesse défilement
            {
                //Gestion de la course
                runState++;
                if (runState == nbEtatRun)
                {
                    runState = 0;
                }
                cpt = 0;
            }
        }


    }
}



