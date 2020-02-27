using System;
using System.Collections.Generic;
using System.Text;

namespace VCSFinalGameProject.GUI
{
    sealed class GameWindow : Window
    {
        public GameWindow() : base(0, 0, 120, 30, '+')
        {

        }


        public override void Render()
        {
            base.Render();
            
            Console.SetCursorPosition(0, 0);
        }
    }

}
