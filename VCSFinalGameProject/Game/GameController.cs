/*
using System;
using System.Collections.Generic;
using System.Text;

namespace VCSFinalGameProject.Game
{
    class GameController
    {
        public void StartGame()
        {
            Console.WriteLine("Hello World!");
            GameScreen myGame = new GameScreen(30, 20);
            myGame.SetHero(new Player(5, 5, "Player"));

            // create
            Random rnd = new Random();
            int enemyCount = 0;
            for (int i = 0; i < 10; i++)
            {
                myGame.AddEnemy(new Enemy(enemyCount, rnd.Next(0, 10), rnd.Next(0, 10), "enemy" + enemyCount));
                enemyCount++;
            }

            // print

            myGame.Render();

            // move
            myGame.MoveHeroLeft();
            myGame.MoveAllEnemiesDown();


            // print
            Enemy secondEnemy = myGame.GetEnemyById(1);
            if (secondEnemy != null)
            {
                secondEnemy.MoveDown();
            }
            myGame.Render();

            Console.ReadKey();
        }

    }
}
*/
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using VCSFinalGameProject.Units;

namespace VCSFinalGameProject.Game
{
    class GameController
    {

        private GameScreen myGame;

        public void StartGame()
        {

            // init game
            InitGame();

            // render loop
            StartGameLoop();
        }

        private void InitGame()
        {
            myGame = new GameScreen(30, 20);

            // fill game with game data.
            myGame.SetHero(new Player(5, 5, "HERO"));
            Random rnd = new Random();
            int enemyCount = 0;
            for (int i = 0; i < 10; i++)
            {
                myGame.AddEnemy(new Enemy(enemyCount, rnd.Next(0, 10), rnd.Next(0, 10), "enemy" + enemyCount));
                enemyCount++;
            }
        }


        private void StartGameLoop()
        {
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
