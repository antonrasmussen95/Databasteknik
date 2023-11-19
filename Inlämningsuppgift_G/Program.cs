using Inlämningsuppgift_G.Contexts;
using Inlämningsuppgift_G.Menus;
using Inlämningsuppgift_G.Repositories;
using Inlämningsuppgift_G.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Inlämningsuppgift_G
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContext<DataContext>(options => options.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Skola\Databasteknik\Inlämningsuppgift_G\Inlämningsuppgift_G\Contexts\database.mdf;Integrated Security=True;Connect Timeout=30"));

            serviceCollection.AddScoped<AddressRepository>(); 
            serviceCollection.AddScoped<CustomerRepository>();
            serviceCollection.AddScoped<CarRepository>();
            serviceCollection.AddScoped<CarModelRepository>();
            serviceCollection.AddScoped<CarTypeRepository>();

            serviceCollection.AddScoped<CustomerService>();
            serviceCollection.AddScoped<CarService>();

            serviceCollection.AddScoped<CustomerMenu>();
            serviceCollection.AddScoped<MainMenu>();
            serviceCollection.AddScoped<CarMenu>();




        
            var sp = serviceCollection.BuildServiceProvider();
            var mainMenu = sp.GetRequiredService<MainMenu>();
            await mainMenu.StartAsync();
        }
    }
}