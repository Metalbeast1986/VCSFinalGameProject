using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VCSFinalGameProject.Game
{
    class GameScreen
    {
        public int _width;
        public int _height;
        private Frame _border;

        private Player _player;
        private GunFire _gunfire;
        private List<Enemy> _enemies = new List<Enemy>();
        public int score = 0;
        public int playerHealth = 10;
        public bool isPaused = false;
        //internal int enemyWaveCount;

        public GameScreen(int x, int y, int width, int height, char borderChar)
        {
            _width = width;
            _height = height;
            _border = new Frame(x, y, width, height, borderChar);
        }

        public void SetHero(Player player)
        {
            this._player = player;
        }

        public void ArmWeapon(GunFire gunfire)
        {
            this._gunfire = gunfire;  
        }


        public void MoveHeroLeft()
        {
            if (_player.x > 0)
            {
                _player.MoveLeft();
            }
        }

        public void MoveHeroRight()
        {
            if (_player.x < _width-1)
            {
                _player.MoveRight();
            }
        }

        public void Fire()
        {
            bool bulletFlying = true;
            do
            {
                if (_gunfire.y > 1)
                {
                    _gunfire.Gunshot();
                }
                else
                    bulletFlying = false;

            } while (bulletFlying);
        }
       
        public void AddEnemy(Enemy enemy)
        {
            _enemies.Add(enemy);
        }

        public void MoveAllEnemiesDown()
        {
            foreach (Enemy enemy in _enemies)
            {
                enemy.MoveDown();
            }
        }
        
        public void ClearEnemies()
        {
            // trinam enemius uzkritusius uz ekrano
            foreach (Enemy enemy in _enemies.Reverse<Enemy>())
            {
                if (enemy.y > 25)
                {
                    _enemies.Remove(enemy);
                }
            }
        }

        public void HitCheck(GunFire gunshot)
        {
            // trinam enemius uzkritusius uz ekrano
            
            foreach (Enemy enemy in _enemies.Reverse<Enemy>())
            {
                //if (enemy.y == gunshot.y && enemy.x == gunshot.x)
                /*
                if (enemy.x == gunshot.x || enemy.x-1 == gunshot.x || enemy.x+1 == gunshot.x)
                {
                    _enemies.Remove(enemy);
                    score++;
                }
                */
                if (enemy.x+1 == gunshot.x)
                {
                    _enemies.Remove(enemy);
                    gunshot.y = enemy.y;
                    Console.SetCursorPosition(enemy.x, enemy.y);
                    Console.Write("###");

                    score++;
                }
            }
            //Console.WriteLine(gunshot.y);
        }
        

        public Enemy GetEnemyById(int id)
        {
            foreach (Enemy enemy in _enemies)
            {
                if (enemy.GetId() == id)
                {
                    return enemy;
                }
            }

            return null;
        }

        
        public void Pause()
        {
            isPaused = true;
            Console.WriteLine("Game Paused");
            Console.WriteLine("score: " + score);
        }
        
        public void Render()
        {
            //
            _player.Render();
            foreach (Enemy enemy in _enemies)
            {
                //enemy.PrintInfo();
                enemy.Render();
            }

            Console.SetCursorPosition(70, 3);
            Console.WriteLine("Score: " + score);
            Console.SetCursorPosition(80, 4);
            Console.WriteLine("Player Health: "+ playerHealth);
            
            for (int i=0; i<=playerHealth; i++)
            {
                Console.SetCursorPosition(70+ i, 5);
                Console.Write("I");
            }
            Console.SetCursorPosition(70, 6);

            //draw frame
            for ( int i=0; i<_height; i++)
            {
                Console.SetCursorPosition(_width, i);
                Console.Write("[");
                Console.SetCursorPosition(0, i);
                Console.Write("]");
            }    
           
        }
        public void ShowGameTime(int gameTime)
        {
            Console.SetCursorPosition(70, 7);
            Console.WriteLine("Time: "+ gameTime);
        }
        public int EnemyCount()
        {
            return _enemies.Count();
        }
        public int LastEnemyPos()
        {
            return _enemies[_enemies.Count() - 1].y;
        }

        public void CollisionCheck()
        {
            foreach (Enemy enemy in _enemies.Reverse<Enemy>())
            {
                //if (enemy.y == gunshot.y && enemy.x == gunshot.x)
                if ((enemy.x == _player.x || enemy.x - 1 == _player.x || enemy.x + 1 == _player.x) && enemy.y == _player.y)
                {
                    _enemies.Remove(enemy);
                    Console.SetCursorPosition(_player.x, _player.y);
                    Console.Write("*#*");
                    score--;
                    playerHealth--;

                }
            }
        }


    }
}

