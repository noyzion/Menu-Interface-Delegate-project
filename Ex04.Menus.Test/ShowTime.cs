using Ex04.Menus.Interfaces;
using System;

namespace Ex04.Menus.Test
{
    public class ShowTime : IMenuItemListener
    {
        private readonly string r_Title = "Show Time";
        private readonly MenuItem r_MenuItem;

        public ShowTime(MenuItem i_PrevMenuItem)
        {
            r_MenuItem = i_PrevMenuItem.AddSubMenuItem(r_Title);
            r_MenuItem.AddItemSelectedListener(this);
        }

        void IMenuItemListener.ReportItemSelctedFromMenu()
        {
            ShowCurrentTime();
        }

        public static void ShowCurrentTime()
        {
            DateTime currentTime = DateTime.Now;
            string formattedTime = formatTime(currentTime);

            Console.WriteLine($"Current Time: {formattedTime}");
        }

        private static string formatTime(DateTime i_Time)
        {
            return i_Time.ToString("HH:mm:ss");
        }
    }
}