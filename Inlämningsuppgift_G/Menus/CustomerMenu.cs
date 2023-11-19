using Inlämningsuppgift_G.Entities;
using Inlämningsuppgift_G.Models;
using Inlämningsuppgift_G.Services;
using System.Diagnostics;

namespace Inlämningsuppgift_G.Menus;

internal class CustomerMenu
{
    private readonly CustomerService _customerService;

    public CustomerMenu(CustomerService customerService)
    {
        _customerService = customerService;
    }

    public async Task ManageCustomers()
    {
        Console.Clear();
        Console.WriteLine("Manage Customers");
        Console.WriteLine("1. Add Customer");
        Console.WriteLine("2. View All Customers");
        Console.WriteLine("3. View Specific Customer");
        Console.WriteLine("4. Update Customer");
        Console.WriteLine("5. Delete Customer");
        Console.Write("Choose one option: ");
        var option = Console.ReadLine();

        switch (option)
        {
            case "1":
                await CreateAsync();
                break;

            case "2":
                await ListAllAsync();
                break;

            case "3":
                await ListSpecificAsync();
                break;

            case "4":
                await UpdateAsync();
                break;

            case "5":
                await DeleteAsync();
                break;
           
        }
    }


    public async Task CreateAsync()
    {
        var form = new CustomerRegistrationForm();

        Console.Clear();
        Console.Write("First Name: ");
        form.FirstName = Console.ReadLine()!;

        Console.Write("Last Name: ");
        form.LastName = Console.ReadLine()!;

        Console.Write("Email: ");
        form.Email = Console.ReadLine()!;

        Console.Write("Street Name: ");
        form.StreetName = Console.ReadLine()!;

        Console.Write("Postal Code: ");
        form.PostalCode = Console.ReadLine()!;

        Console.Write("City: ");
        form.City = Console.ReadLine()!;

        var result = await _customerService.CreateCustomerAsync(form);
        if (result)
            Console.WriteLine("Customer was created successfully.");
        else
            Console.WriteLine("Unable to create customer");
    }


    public async Task ListAllAsync()
    {


        var customers = await _customerService.GetAllAsync();
        foreach (var customer in customers)
        {
            Console.WriteLine("");
            Console.WriteLine($"{customer.FirstName} {customer.LastName} <{customer.Email}>");
            Console.WriteLine($"{customer.Address.StreetName}, {customer.Address.PostalCode}, {customer.Address.City}");
            Console.WriteLine("---------------------------------");

        }

        Console.ReadKey();
    }

    public async Task ListSpecificAsync()
    {
        try
        {
            Console.WriteLine("");
            Console.WriteLine("VIEW SPECIFIC CUSTOMER");
            Console.WriteLine("----------------------");
            Console.Write("Type in email: ");

            var email = Console.ReadLine()!.Trim().ToLower();
            var customer = await _customerService.ListSpecificAsync(new CustomerEntity { Email = email });


            if (customer != null)
            {
                Console.WriteLine("");
                Console.WriteLine($"{customer.FirstName} {customer.LastName} <{customer.Email}>");
                ;

            }
            else
            {
                Console.WriteLine($"Could not find a customer with email: {email}");
            }

            Console.ReadKey();
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }

    }
    public async Task UpdateAsync()
    {
        try
        {
            Console.WriteLine("");
            Console.Write("Type in email to update customer: ");
            var email = Console.ReadLine()!.ToLower().Trim();

            var customer = await _customerService.ListSpecificAsync(new CustomerEntity { Email = email });

            if (customer == null)
            {
                Console.WriteLine("No customer with this email.");
                Console.ReadKey();
            }
            else
            {

                var form = new CustomerRegistrationForm();
                Console.WriteLine("-------------------------");
                Console.WriteLine("Update your customer");
                Console.WriteLine("");

                Console.Write("First Name: ");
                form.FirstName = Console.ReadLine()!;

                Console.Write("First Last: ");
                form.LastName = Console.ReadLine()!;

                Console.Write("Email: ");
                form.Email = Console.ReadLine()!;

                Console.Write("Street Name: ");
                form.StreetName = Console.ReadLine()!;

                Console.Write("Postal Code: ");
                form.PostalCode = Console.ReadLine()!;

                Console.Write("City: ");
                form.City = Console.ReadLine()!;

                var result = await _customerService.UpdateCustomerAsync(form, email!);

                Console.ReadLine();
            }




        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }


    }

    public async Task<bool> DeleteAsync()
    {
        Console.WriteLine("-----------------------");
        Console.WriteLine("Delete Customer");
        Console.WriteLine("");
        Console.Write("Type in email to delete customer: ");
        var email = Console.ReadLine()!.ToLower().Trim();

        var result = await _customerService.DeleteAsync(email);

        if (result)
        {
            Console.WriteLine("Customer deleted.");
        }

        else
        {
            Console.WriteLine("Could not delete Customer"); 
        }

        Console.ReadKey();

        return result;
    }


    


}