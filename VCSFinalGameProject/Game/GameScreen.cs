using System;
using System.Collections.Generic;
using System.Text;

namespace VCSFinalGameProject.Game
{
    class GameScreen
    {
        private int _width;
        private int _height;

        private Player _player;
        private List<Enemy> _enemies = new List<Enemy>();

        public GameScreen(int width, int height)
        {
            _width = width;
            _height = height;
        }

        public void SetHero(Player player)
        {
            this._player = player;
        }


        public void MoveHeroLeft()
        {
            _player.MoveLeft();
        }

        public void MoveHeroRight()
        {
            _player.MoveRight();
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

        public void Render()
        {
            _player.Render();
            foreach (Enemy enemy in _enemies)
            {
                enemy.PrintInfo();
            }
        }
    }
}

