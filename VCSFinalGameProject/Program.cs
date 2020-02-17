using System;
using VCSFinalGameProject.Game;
using VCSFinalGameProject.GUI;

namespace VCSFinalGameProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //good
            /*
            Console.CursorVisible = false;
            GuiController guiController = new GuiController();

            guiController.ShowMenu();

            Console.ReadKey();
            */

            GameScreen myGame = new GameScreen(30, 20);

            // fill game with game data.
            myGame.SetHero(new Player(5, 5, "HERO"));
            bool needToRender = true;

            do
            {
                // isvalom ekrana
                Console.Clear();

                while (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressedChar = Console.ReadKey(true);
                    int hashCode = pressedChar.Key.GetHashCode();

                    switch (pressedChar.Key)
                    {
                        case ConsoleKey.Escape:
                            needToRender = false;
                            break;
                        case ConsoleKey.RightArrow:
                            myGame.MoveHeroRight();
                            break;
                        case ConsoleKey.LeftArrow:
                            myGame.MoveHeroLeft();
                            break;
                    }
                }

                myGame.Render();

                // padarom pause. (parodom ekrana).
                System.Threading.Thread.Sleep(250);
            } while (needToRender);
        }
    }
}
