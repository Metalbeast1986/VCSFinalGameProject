using System;
using System.Collections.Generic;
using System.Text;

namespace VCSFinalGameProject.Game
{
    class GunFire : Unit
    {   
        public GunFire(int x, int y, string name) : base(x, y, name)
        {
        }
        
        public void Gunshot()
        {
            y--;
            Render();
            /*
            while (y >= 0)
            {
                Render();
                y--;
            }
            */

            //if yshot == enemy.y && xshot == enemy.x enemy dies and dissapears
            //klausimai :
            //kaip paimt enemy.y kad iskaityti pataikyma?

            //kaip panaikinti enemius kurie jau uzkrito uz ekrano?
            /*
            jei prieso y > uz ekrano height
            pasalinti
            remove();
             */


            //kaip paleisti cikla kad enemiai nuolat kristu?
            // kaip padaryti kad saudytu pavieniais | suviais o ne lazeriu?

            for (int i = 0; i < 20; i++)
            {
                //prasuku visu enemiu cikla ir tikrinu ar sutampa lazerio ir enemiu koordinates
                //if (y == enemy_enemyCount.y )
                Hit();
            }
        }
        public void Hit()
        {
            // nukalamas priesas ir gaunami taskai         
        }
        public override void Render()
        {
            Console.SetCursorPosition(x, y);
            Console.Write("|");
        }

    }
}
