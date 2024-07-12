using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class InterfacesMenuTest
    {
        public static MainMenu BuildInterfaceMenu()
        {
            MainMenu interfaceMenu = new MainMenu("Interface Main Menu");
            MenuItem dateTimeSubMenu = interfaceMenu.AddSubMenuItem("Show Date/Time");
            MenuItem versionCapitalSubMenu = interfaceMenu.AddSubMenuItem("Version And Capital");
            ShowDate showDate = new ShowDate(dateTimeSubMenu);
            ShowTime showTime = new ShowTime(dateTimeSubMenu);
            CountCapitals countCapitals = new CountCapitals(versionCapitalSubMenu);
            ShowVersion showVersion = new ShowVersion(versionCapitalSubMenu);

            return interfaceMenu;
        }
    }
}
