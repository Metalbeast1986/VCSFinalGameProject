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
        public MenuWindow menuWindow;
        public GameWindow gameWindow;
        public GamePlayWindow gamePlayWindow;
        private CreditWindow creditWindow;
        public GameOverMenu gameOverMenu;
        bool needToRender = true;
        bool creditWindowRender = true;
        bool needToRenderGameOverMenu = false;
        int index = 0;
        ConsoleKey key;

        public GuiController()
        {
            menuWindow = new MenuWindow();
            gamePlayWindow = new GamePlayWindow();
            creditWindow = new CreditWindow();
            gameOverMenu = new GameOverMenu();
        }
        public void ShowMenu()
        {
            //gameWindow.Render();
            if (needToRender)
            {
                menuWindow.Render();

                //call out Select function to display all possible buttons
                Select(menuWindow.buttonList);
            }

        }
        void Active(int index, List<Button> buttonList)
        {
            menuWindow.buttonList[index].SetActive();

            for (int i = 0; i < buttonList.Count; i++)
            {
                if (i != index)
                {
                    //deactivate all other buttons
                    menuWindow.buttonList[i].SetInActive();
                }
            }

            menuWindow.Render();
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
                gameWindow = new GameWindow();
                gameWindow.Render();
                GameController myGame = new GameController();
                myGame.StartGame();
                needToRender = false;
                //gamePlayWindow.Render();
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
        public void ShowGameOverMenu(bool WinLose, int score)
        {
            needToRenderGameOverMenu = true;
            if (needToRenderGameOverMenu)
            {
                gameOverMenu.SetWinner(WinLose);
                gameOverMenu.SetScore(score);
                gameOverMenu.Render();
                key = Console.ReadKey(true).Key;
                do
                {
                    key = Console.ReadKey(true).Key;
                    switch (key)
                    {
                        case ConsoleKey.R:
                            {
                                Console.Clear();
                                GameController myGame = new GameController();
                                myGame.StartGame();
                                needToRender = false;
                                break;
                            }

                        case ConsoleKey.M:
                            {
                                ShowMenu();
                                needToRender = true;
                                needToRenderGameOverMenu = false;
                                break;
                            }
                        case ConsoleKey.Q:
                            {
                                System.Environment.Exit(0);
                                break;
                            }
                    }

                } while (needToRender);
            }

        }
    }
}

