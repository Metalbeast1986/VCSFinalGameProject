using System;
using VCSFinalGameProject.Game;
using VCSFinalGameProject.GUI;

namespace VCSFinalGameProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            GuiController guiController = new GuiController();

            guiController.ShowMenu();

            Console.ReadKey();        
        }
    }
}
