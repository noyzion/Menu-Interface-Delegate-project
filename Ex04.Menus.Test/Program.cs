using Ex04.Menus.Test;
class Program
{
   public static void Main()
    {
        Ex04.Menus.Interfaces.MainMenu interfaceMenu = InterfacesMenuTest.BuildInterfaceMenu();

        interfaceMenu.Show();
        Ex04.Menus.Events.MainMenu eventsMenu = EventsMenuTest.BuildEventsMenu();

        eventsMenu.Show();
    }
}
