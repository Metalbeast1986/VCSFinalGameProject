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
