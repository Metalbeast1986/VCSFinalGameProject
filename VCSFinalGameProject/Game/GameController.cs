using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VCSFinalGameProject.GUI;
//using VCSFinalGameProject.Units;

namespace VCSFinalGameProject.Game
{
    class GameController
    {
        private GameScreen myGame;
        public GuiController guiController;
        public void StartGame()
        {
            //Window thisGameWindow = new Window(0, 0, 120, 30, '+');
            
            // init game
            InitGame();

            // render loop
            StartGameLoop();
        }

        public void InitGame()
        {
            // myGame = new GameScreen(30, 20);
            myGame = new GameScreen(0, 0, 120, 30, '+');

            // fill game with game data.
            /*
            Player player = new Player(10, 20, "Player");
            myGame.SetHero(player);
            */
            /*
            Random rnd = new Random();
            int enemyCount = 0;
            int enemyCountInWave = 20;
            for (int i = 0; i < enemyCountInWave; i++)
            {
                Enemy enemy_enemyCount = new Enemy(enemyCount, rnd.Next(0, 40), rnd.Next(0, 10), "enemy" + enemyCount);
                myGame.AddEnemy(enemy_enemyCount);
                enemyCount++;
            }
            */
        }


        public void StartGameLoop()
        {
            Player player = new Player(10, 20, "Player");
            myGame.SetHero(player);
            bool needToRender = true;

            Random rnd = new Random();
            int enemyCount = 0;
            int enemyCountInWave = 20;
            for (int i = 0; i < enemyCountInWave; i++)
            {
                Enemy enemy_enemyCount = new Enemy(enemyCount, rnd.Next(0, 40), rnd.Next(0, 10), "enemy" + enemyCount);
                myGame.AddEnemy(enemy_enemyCount);
                enemyCount++;
            }

            do
            {
                myGame.MoveAllEnemiesDown();       
                myGame.ClearEnemies();

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
                        case ConsoleKey.Spacebar:
                            GunFire shot = new GunFire(player.x + 1, player.y - 1, "PlayerShot");
                            myGame.ArmWeapon(shot);
                            myGame.Fire();
                            myGame.HitCheck(shot);

                            //funkcija kuri tikrina pataikyma
                            //uzblokuoti saudyma kol suvis neisnyksta
                            break;
                    }
                }

                myGame.Render();
                //Console.WriteLine(myGame.score);
                // padarom pause. (parodom ekrana).

                // if (wave <= 0)
                //     needToRender = false;
                //Console.WriteLine(myGame.score);
                // padarom pause. (parodom ekrana).

                //time tick check:
                /*
                check enemy number
                hitcheck
                check bullet time

                 */

                //Refilling game with enemies
                if (myGame.EnemyCount() < enemyCountInWave || myGame.LastEnemyPos() < 5)
                {
                    for (int i = 0; i < enemyCountInWave; i++)
                    {
                        Enemy enemy_enemyCount = new Enemy(enemyCount, rnd.Next(0, 40), rnd.Next(0, 5), "enemy" + enemyCount);
                        myGame.AddEnemy(enemy_enemyCount);
                        enemyCount++;
                    }
                }

                //collision check
                myGame.CollisionCheck();
                if (myGame.playerHealth < 0)
                {
                    GameOver();
                    needToRender = false;
                }
                System.Threading.Thread.Sleep(250);
            } while (needToRender);
        }
        public void GameOver()
        {
            Console.Clear();
            guiController = new GuiController();
            Console.WriteLine("Game over pal!");
            Console.WriteLine("Score: " + myGame.score);

            guiController.ShowGameOverMenu(myGame.score);
            //GameOverMenu
            /*
             *
             
             */

        }
    }
}
