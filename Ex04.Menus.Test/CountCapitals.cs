using Ex04.Menus.Interfaces;
using System;

namespace Ex04.Menus.Test
{
    public class CountCapitals : IMenuItemListener
    {
        private readonly string r_Title = "Count Capitals";
        private readonly MenuItem r_MenuItem;

        public CountCapitals(MenuItem i_PrevMenuItem)
        {
            r_MenuItem = i_PrevMenuItem.AddSubMenuItem(r_Title);
            r_MenuItem.AddItemSelectedListener(this);
        }

        void IMenuItemListener.ReportItemSelctedFromMenu()
        {
            CountCapitalLetters();
        }

        public static void CountCapitalLetters()
        {
            Console.WriteLine("Please enter your sentence: ");
            string userInput = Console.ReadLine();
            int upperCaseCount = CountUppercaseLetters(userInput);

            Console.WriteLine($"There are {upperCaseCount} capitals in your sentence.");
        }

        public static int CountUppercaseLetters(string i_Sentence)
        {
            int upperCaseCount = 0;

            foreach (char character in i_Sentence)
            {
                if (char.IsUpper(character))
                {
                    upperCaseCount++;
                }
            }

            return upperCaseCount;
        }
    }
}