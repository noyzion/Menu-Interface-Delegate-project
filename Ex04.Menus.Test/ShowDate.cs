using Ex04.Menus.Interfaces;
using System;

namespace Ex04.Menus.Test
{
    public class ShowDate : IMenuItemListener
    {
        private readonly string r_Title = "Show Date";
        private readonly MenuItem r_MenuItem;

        public ShowDate(MenuItem i_PrevMenuItem)
        {
            r_MenuItem = i_PrevMenuItem.AddSubMenuItem(r_Title);
            r_MenuItem.AddItemSelectedListener(this);
        }

        void IMenuItemListener.ReportItemSelctedFromMenu()
        {
            ShowCurrentDate();
        }

        public static void ShowCurrentDate()
        {
            DateTime currentTime = DateTime.Now;
            string formattedDate = formatDate(currentTime);

            Console.WriteLine($"Current Date: {formattedDate}");
        }

        private static string formatDate(DateTime i_Date)
        {
            return i_Date.ToString("dd.MM.yyyy");
        }
    }
}

