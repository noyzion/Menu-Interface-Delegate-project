using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex04.Menus.Interfaces
{
    public class MenuItem
    {
        private const char k_FinishOption = '0';
        private readonly string r_Title;
        private readonly MenuItem r_PrevMenuItem;
        private readonly List<MenuItem> r_SubMenuItems = new List<MenuItem>();
        private readonly List<IMenuItemListener> r_ItemListeners = new List<IMenuItemListener>();

        public MenuItem(string i_Title, MenuItem i_PrevMenuItem)
        {
            r_Title = i_Title;
            r_PrevMenuItem = i_PrevMenuItem;
        }

        public int CountSubs
        {
            get
            {
                return r_SubMenuItems.Count;
            }
        }

        public MenuItem PrevMenuItem
        {
            get
            {
                return r_PrevMenuItem;
            }
        }

        public char FinishOption
        {
            get
            {
                return k_FinishOption;
            }
        }

        public MenuItem GetSubMenuByIndex(int i_SubMenuIndex)
        {
            return r_SubMenuItems[i_SubMenuIndex];
        }

        public MenuItem AddSubMenuItem(string i_Title)
        {
            MenuItem subItem = new MenuItem(i_Title, this);

            r_SubMenuItems.Add(subItem);

            return subItem;
        }

        public void AddItemSelectedListener(IMenuItemListener i_Listener)
        {
            r_ItemListeners.Add(i_Listener);
        }

        public void NotifyItemListeners()
        {
            foreach (IMenuItemListener listener in r_ItemListeners)
            {
                listener.ReportItemSelctedFromMenu();
            }
        }

        public void Selected()
        {
            Console.Clear();
            NotifyItemListeners();
            Console.WriteLine("Please press Enter to continue.");
            Console.ReadLine();
        }

        private void printMenu(string i_FinishWord)
        {
            Console.WriteLine(@"~~~ {0} ~~~
============================", r_Title);
            for (int i = 0; i < r_SubMenuItems.Count; i++)
            {
                Console.WriteLine($"({i + 1}) {r_SubMenuItems[i].r_Title}");
            }

            Console.WriteLine(@"({0}) {1}
============================", k_FinishOption, i_FinishWord);
            Console.WriteLine("Please choose an option between 1 - {0}, or {1} to {2}",
                   r_SubMenuItems.Count(), k_FinishOption, i_FinishWord);
        }

        public void Show(string i_FinishWord)
        {
            Console.Clear();
            if (r_SubMenuItems.Count != 0)
            {
                printMenu(i_FinishWord);
            }
        }
    }
}