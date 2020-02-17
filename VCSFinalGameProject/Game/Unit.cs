using System;
using System.Collections.Generic;
using System.Text;

namespace VCSFinalGameProject.Game
{
    abstract class Unit
    {
        protected int x { get; set; }
        protected int y { get; set; }
        protected string name;

        public Unit(int x, int y, string name)
        {
            this.x = x;
            this.y = y;
            this.name = name;
        }
        public void PrintInfo()
        {
            Console.WriteLine($" {name} is at {x}x{y}");
        }
        public abstract void Render();
    }
}
