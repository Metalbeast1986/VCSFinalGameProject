using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VCSFinalGameProject.Game
{
    class GunFire : Unit
    {
        private List<Enemy> _enemies = new List<Enemy>();
        public GunFire(int x, int y, string name) : base(x, y, name)
        {
        }
        
        public void Gunshot()
        {

            y--;
            Render();
           
        }
        
        public override void Render()
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine("|");
        }
      
    }
}
