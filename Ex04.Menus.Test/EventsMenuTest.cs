using System;
using Ex04.Menus.Events;

namespace Ex04.Menus.Test
{
    public class EventsMenuTest
    {
        public static MainMenu BuildEventsMenu()
        {
            MainMenu delegateMenu = new MainMenu("Delegate Main Menu");
            MenuItem dateTimeSubMenu = delegateMenu.AddSubMenuItem("Show Date/Time");
            MenuItem versionCapitalSubMenu = delegateMenu.AddSubMenuItem("Version And Capital");
            MenuItem showDateSubDateTimeMenu = dateTimeSubMenu.AddSubMenuItem("Show Date");

            showDateSubDateTimeMenu.Selected += menuItemShowDate_Selected;
            MenuItem showTimeSubDateTimeMenu = dateTimeSubMenu.AddSubMenuItem("Show Time");

            showTimeSubDateTimeMenu.Selected += menuItemShowTime_Selected;
            MenuItem countCapitalsSubVersionCapitalMenu = versionCapitalSubMenu.AddSubMenuItem("Count Capitals");

            countCapitalsSubVersionCapitalMenu.Selected += menuItemCountCapitals_Selected;
            MenuItem showVersionSubVersionCapitalMenu = versionCapitalSubMenu.AddSubMenuItem("Show Version");

            showVersionSubVersionCapitalMenu.Selected += menuItemShowVersion_Selected;

            return delegateMenu;
        }

        private static void menuItemCountCapitals_Selected()
        {
            CountCapitals.CountCapitalLetters();
        }

        private static void menuItemShowVersion_Selected()
        {
            ShowVersion.ShowTheVersion();
        }

        private static void menuItemShowDate_Selected()
        {
            ShowDate.ShowCurrentDate();
        }

        private static void menuItemShowTime_Selected()
        {
            ShowTime.ShowCurrentTime();
        }
    }
}

