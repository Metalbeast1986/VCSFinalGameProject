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
            
            Console.CursorVisible = false;
            GuiController guiController = new GuiController();

            guiController.ShowMenu();

            Console.ReadKey();
            

            // moving with keys
            /*
            GameScreen myGame = new GameScreen(30, 20);
            // fill game with game data.
            Player player = new Player(10, 20, "HERO");
            myGame.SetHero(player);

            Random rnd = new Random();
            int enemyCount = 0;
            for (int i = 0; i < 20; i++)
            {
                Enemy enemy_enemyCount = new Enemy(enemyCount, rnd.Next(0, 40), rnd.Next(0, 5), "enemy" + enemyCount);
                myGame.AddEnemy(enemy_enemyCount);
                enemyCount++;
            }
            //myGame.ArmWeapon(new GunFire(player.x+1, player.y - 1, "PlayerShot"));
            bool needToRender = true;

            do
            {
                // isvalom ekrana
                Console.Clear();
                myGame.MoveAllEnemiesDown();
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
                        case ConsoleKey.Spacebar:
                            myGame.ArmWeapon(new GunFire(player.x + 1, player.y - 1, "PlayerShot"));
                            myGame.Fire();
                            break;

                    }
                }

                myGame.Render();

                // padarom pause. (parodom ekrana).
                System.Threading.Thread.Sleep(250);
            } while (needToRender);
            */
            // moving with keys end
        }
    }
}
