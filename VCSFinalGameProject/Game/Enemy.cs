using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCSFinalGameProject.Game
{
    class Enemy:Unit
    {
        private int _id;
        public Enemy(int id, int x, int y, string name) : base( x,  y,  name)
        {
            this._id = id;  
        }

        public void MoveDown()
        {
            y++;
        }
        public int GetId()
        {
            return _id;
        }
        public override void Render()
        {
            Console.SetCursorPosition(x, y);
            //Console.WriteLine("render enemy");
        }
    }
}
