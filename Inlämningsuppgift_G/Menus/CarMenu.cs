using Inlämningsuppgift_G.Models;
using Inlämningsuppgift_G.Services;
using System.Diagnostics;

namespace Inlämningsuppgift_G.Menus;

internal class CarMenu
{
    private readonly CarService _carService;

    public CarMenu(CarService carService)
    {
        _carService = carService;
    }

    public async Task ManageCars()
    {
        Console.Clear();
        Console.WriteLine("Manage Cars");
        Console.WriteLine("1. View All Cars");
        Console.WriteLine("2. Add Car");
        Console.Write("Choose one option: ");
        var option = Console.ReadLine();

        switch (option)
        {
            case "1":
                await ListAllAsync();
                break;

            case "2":
                await CreateAsync();
                break;
        }
    }

    public async Task ListAllAsync()
    {
        try
        {

            var cars = await _carService.GetAllAsync();
            foreach (var car in cars)
            {
                Console.Clear();
                Console.WriteLine($"{car.CarName} {car.CarModel.Model} ({car.CarType.Type}) {car.CarPrice}");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Press down button to go through cars");

                Console.ReadKey();
            }
        } 
        catch (Exception ex) { Debug.WriteLine(ex.Message); }

        
    }

    public async Task CreateAsync()
    {
        var form = new CarRegistrationForm();

        Console.Clear();
        Console.Write("Car Name: ");
        form.CarName = Console.ReadLine()!;

        Console.Write("Car Model: ");
        form.CarModel = Console.ReadLine()!;

        Console.Write("Car Type: ");
        form.CarType = Console.ReadLine()!;

        Console.Write("Car Price: ");
        form.CarPrice = decimal.Parse(Console.ReadLine()!);

        var result = await _carService.CreateCarAsync(form);
        if (result)
            Console.WriteLine("Car was created successfully.");
        else
            Console.WriteLine("Unable to create Car");
    }
}
