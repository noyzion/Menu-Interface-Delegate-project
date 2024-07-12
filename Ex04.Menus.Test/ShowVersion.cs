using Ex04.Menus.Interfaces;
using System;

namespace Ex04.Menus.Test
{
    public class ShowVersion : IMenuItemListener
    {
        private readonly string r_Title = "Show Version";
        private readonly MenuItem r_MenuItem;

        public ShowVersion(MenuItem i_PrevMenuItem)
        {
            r_MenuItem = i_PrevMenuItem.AddSubMenuItem(r_Title);
            r_MenuItem.AddItemSelectedListener(this);
        }

        void IMenuItemListener.ReportItemSelctedFromMenu()
        {
            ShowTheVersion();
        }

        public static void ShowTheVersion()
        {
            int major = 24;
            int minor = 2;
            int build = 4;
            int revision = 9504;
            string formattedVersion = formatVersion(major, minor, build, revision);

            Console.WriteLine($"Version: {formattedVersion}");
        }

        private static string formatVersion(int i_Major, int i_Minor,
                                            int i_Build, int i_Revision)
        {
            return $"{i_Major}.{i_Minor}.{i_Build}.{i_Revision}";
        }
    }
}

