using System;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu
    {
        private const string k_ExitMainMenu = "Exit";
        private const string k_BackFromSubMenu = "Back";
        private const int k_UserChoseFinishBlock = (int)eFinish.Finish;
        private readonly MenuItem r_MenuItem;
        private MenuItem m_CurrentMenuItem;

        private enum eFinish
        {
            Finish = -1
        }

        public MainMenu(string i_Title)
        {
            r_MenuItem = new MenuItem(i_Title, null);
            m_CurrentMenuItem = r_MenuItem;
        }

        public MenuItem AddSubMenuItem(string i_Title)
        {
            return r_MenuItem.AddSubMenuItem(i_Title);
        }

        public void Show()
        {
            bool ifUserChoseFinish = false;
            string finishOptionText = updateFinishOptionText();

            while (!ifUserChoseFinish)
            {
                displayCurrentMenu(finishOptionText);
                int userChoice = getMenuChoiceFromUser();

                if (userChoice == k_UserChoseFinishBlock)
                {
                    ifUserChoseFinish = handleUserFinish();
                    finishOptionText = updateFinishOptionText();
                }
                else
                {
                    navigateToSubMenu(userChoice);
                    finishOptionText = updateFinishOptionText();
                }
            }
        }

        private void displayCurrentMenu(string i_FinishOptionText)
        {
            m_CurrentMenuItem.Show(i_FinishOptionText);
        }

        private bool handleUserFinish()
        {
            bool isUserFinish = true;

            if (m_CurrentMenuItem.PrevMenuItem != null)
            {
                isUserFinish = false;
                m_CurrentMenuItem = m_CurrentMenuItem.PrevMenuItem;
            }

            return isUserFinish;
        }

        private string updateFinishOptionText()
        {
            return (m_CurrentMenuItem.PrevMenuItem == null ? k_ExitMainMenu : k_BackFromSubMenu);
        }

        private void navigateToSubMenu(int i_UserChoice)
        {
            m_CurrentMenuItem = m_CurrentMenuItem.GetSubMenuByIndex(i_UserChoice - 1);

            if (m_CurrentMenuItem.CountSubs == 0)
            {
                m_CurrentMenuItem.Selected();
                m_CurrentMenuItem = m_CurrentMenuItem.PrevMenuItem;
            }
        }

        private int getMenuChoiceFromUser()
        {
            int userChoiceInt = 0;
            bool validInput = false;

            while (!validInput)
            {
                try
                {
                    string userChoiceStr = Console.ReadLine();
                    validUserChoice(userChoiceStr, out userChoiceInt);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }

            return userChoiceInt;
        }

        private bool validUserChoice(string i_UserChoice, out int o_UserChoiceInt)
        {
            bool validInput = int.TryParse(i_UserChoice, out o_UserChoiceInt);

            if (i_UserChoice == (r_MenuItem.FinishOption).ToString())
            {
                validInput = true;
                o_UserChoiceInt = k_UserChoseFinishBlock;
            }
            else if (!validInput)
            {
                throw new FormatException("Invalid input, You should enter a number");
            }
            else if (o_UserChoiceInt < 1 || o_UserChoiceInt > r_MenuItem.CountSubs)
            {
                throw new ArgumentException(String.Format("Invalid input, excepted a" +
                                            " number between (1,{0}) or {1}", r_MenuItem.CountSubs,
                                            r_MenuItem.FinishOption));
            }

            return validInput;
        }
    }
}