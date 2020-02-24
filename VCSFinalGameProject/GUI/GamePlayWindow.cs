using System;
using System.Collections.Generic;
using System.Text;

namespace VCSFinalGameProject.GUI
{
    sealed class GamePlayWindow : Window
    {
      
        private Button _score;
        private TextBlock _titleTextBlock;
        public List<Button> buttonList = new List<Button>();

        public GamePlayWindow() : base(0, 0, 120, 30, '+')
        {
            _titleTextBlock = new TextBlock(10, 5, 100, new List<String> { "Final Project", "Vardas Pavardaitis kuryba!", "Made in Vilnius Coding School!" });
            _score = new Button(80, 13, 18, 5, "Score: ");
            buttonList.Add(_score);
        }


        public override void Render()
        {
            base.Render();

            _titleTextBlock.Render();

            _score.Render();       
            Console.SetCursorPosition(0, 0);
        }
    }
}
