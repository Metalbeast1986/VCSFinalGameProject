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
            // init game
            InitGame();

            // render loop
            StartGameLoop();
        }

        public void InitGame()
        {
            // myGame = new GameScreen(30, 20);
            myGame = new GameScreen(0, 0, 60, 30, '+');
        }


        public void StartGameLoop()
        {
            Player player = new Player(10, 20, "Player");
            myGame.SetHero(player);
           
            bool needToRender = true;
            bool WinLose = false;

            Random rnd = new Random();
            int enemyCount = 0;
            int enemyCountInWave = 20;
            int gameTime = 250;
            for (int i = 0; i < enemyCountInWave; i++)
            {
                Enemy enemy_enemyCount = new Enemy(enemyCount, rnd.Next(1, 59), rnd.Next(0, 10), "enemy" + enemyCount);
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

                            break;
                    }
                }
                
                myGame.Render();

                //Refilling game with enemies
                if (myGame.EnemyCount() < enemyCountInWave || myGame.LastEnemyPos() > 5)
                {
                    for (int i = 0; i < enemyCountInWave; i++)
                    {
                        Enemy enemy_enemyCount = new Enemy(enemyCount, rnd.Next(0, 59), rnd.Next(0, 5), "enemy" + enemyCount);
                        myGame.AddEnemy(enemy_enemyCount);
                        enemyCount++;
                    }
                }

                //collision check
                myGame.CollisionCheck();
                myGame.ShowGameTime(gameTime);
                gameTime--;

              
                if (myGame.playerHealth <= 0 || gameTime <= 0)
                {
                    if (myGame.playerHealth <= 0 && gameTime > 0)
                        WinLose = false;
                    else if (gameTime <= 0 && myGame.playerHealth > 0)
                        WinLose = true;
                        GameOver(WinLose);

                    needToRender = false;
                }

                System.Threading.Thread.Sleep(250);
            } while (needToRender);
        }
        public void GameOver(bool WinLose)
        {
            Console.Clear();

            guiController = new GuiController();
            guiController.ShowGameOverMenu(WinLose, myGame.score);
           
        }
        
    }
}
