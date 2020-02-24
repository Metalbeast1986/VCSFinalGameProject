using System;
using System.Collections.Generic;
using System.Text;

namespace VCSFinalGameProject.GUI
{
    class GameOverMenu : Window
    {
        private MenuLabel _replayGameText;
        private MenuLabel _menuText;
        private MenuLabel _quitText;
        private TextBlock _titleTextBlock;
        public List<MenuLabel> LabelList = new List<MenuLabel>();

        public GameOverMenu() : base(0, 0, 120, 30, '%')
        {
            _titleTextBlock = new TextBlock(10, 5, 100, new List<String> { $"The Winner is " });

            _replayGameText = new MenuLabel(20, 13, 18, 5, "R - Replay Game");
            _menuText = new MenuLabel(50, 13, 18, 5, "M - Menu");
            _quitText = new MenuLabel(80, 13, 18, 5, "Q - Quit");

            LabelList.Add(_replayGameText);
            LabelList.Add(_menuText);
            LabelList.Add(_quitText);

        }
        
        public void SetWinner(int score)
        {
            _titleTextBlock.SetLine(0, $"Score: {score} !");
        }
        

        public override void Render()
        {
            base.Render();

            _titleTextBlock.Render();

            _replayGameText.Render();
            _menuText.Render();
            _quitText.Render();

            Console.SetCursorPosition(0, 0);
        }

    }
}
