namespace Inlämningsuppgift_G.Menus;

internal class MainMenu
{
    private readonly CustomerMenu _customerMenu;
    private readonly CarMenu _carMenu;

    public MainMenu(CustomerMenu customerMenu, CarMenu carMenu)
    {
        _customerMenu = customerMenu;
        _carMenu = carMenu;
    }

    public async Task StartAsync()
    {
        do
        {
            Console.Clear();
            Console.WriteLine("MAIN MENU");
            Console.WriteLine("---------");
            Console.WriteLine("1. Manage Customers");
            Console.WriteLine("2. Manage Cars");
            Console.Write("Choose one option: ");

            var option = Console.ReadLine();   

            switch (option)
            {
                case "1":
                    await _customerMenu.ManageCustomers();
                    break;

                case "2":
                    await _carMenu.ManageCars();
                    break;
            }
        }
        while (true);
    }

   
}
