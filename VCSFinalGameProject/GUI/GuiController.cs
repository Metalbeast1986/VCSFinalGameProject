using VCSFinalGameProject.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCSFinalGameProject.GUI
{
    class GuiController
    {
        public GameWindow gameWindow;
        private CreditWindow creditWindow;
        bool needToRender = true;
        bool creditWindowRender = true;
        int index = 0;
        ConsoleKey key;

        public GuiController()
        {
            gameWindow = new GameWindow();
            creditWindow = new CreditWindow();

        }
        public void ShowMenu()
        {
            if (needToRender)
            {
                gameWindow.Render();

                //call out Select function to display all possible buttons
                Select(gameWindow.buttonList);
            }

        }
        void Active(int index, List<Button> buttonList)
        {

            gameWindow.buttonList[index].SetActive();

            for (int i = 0; i < buttonList.Count; i++)
            {
                if (i != index)
                {
                    //deactivate all other buttons
                    gameWindow.buttonList[i].SetInActive();
                }
            }

            gameWindow.Render();
            if (key == ConsoleKey.Enter)
            {
                checkIndexValue(index);
            }

        }
        void Select(List<Button> buttonList)
        {
            creditWindowRender = true;

            do
            {
                key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        {
                            index--;
                            if (index < 0)
                            {
                                index = buttonList.Count - 1;

                            }
                            break;
                        }
                    case ConsoleKey.RightArrow:
                        {
                            index++;
                            if (index >= buttonList.Count)
                            {
                                index = 0;
                            }
                            break;
                        }
                }

                Active(index, buttonList);
            } while (needToRender);

        }
        public void checkIndexValue(int index)
        {

            if (index == 0)
            {
                //start game
                Console.Clear();

                GameController myGame = new GameController();
                myGame.StartGame();
                needToRender = false;
            }
            else if (index == 1)
            {
                if (creditWindowRender)
                {
                    creditWindow.Render();
                }
                if (key == ConsoleKey.Enter || key == ConsoleKey.Escape)
                {
                    creditWindowRender = !creditWindowRender;
                }
            }
            else
            {
                //how to exit application
                System.Environment.Exit(0);
            }

        }
    }
}

