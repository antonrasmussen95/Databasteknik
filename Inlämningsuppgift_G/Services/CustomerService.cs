using Inlämningsuppgift_G.Entities;
using Inlämningsuppgift_G.Models;
using Inlämningsuppgift_G.Repositories;
using System.Diagnostics;

namespace Inlämningsuppgift_G.Services;

internal class CustomerService
{
    private readonly AddressRepository _addressRepository;
    private readonly CustomerRepository _customerRepository;

    public CustomerService(AddressRepository addressRepository, CustomerRepository customerRepository)
    {
        _addressRepository = addressRepository;
        _customerRepository = customerRepository;
    }

    public async Task<bool> CreateCustomerAsync(CustomerRegistrationForm form)
    {

        if (!await _customerRepository.ExistsAsync(x => x.Email == form.Email))
        {

            AddressEntity addressEntity = await _addressRepository.GetAsync(x => x.StreetName == form.StreetName && x.PostalCode == form.PostalCode);
            addressEntity ??= await _addressRepository.CreateAsync(new AddressEntity { StreetName = form.StreetName, PostalCode = form.PostalCode, City = form.City });


            CustomerEntity customerEntity = await _customerRepository.CreateAsync(new CustomerEntity { FirstName = form.FirstName, LastName = form.LastName, Email = form.Email, AddressId = addressEntity.Id });
            if (customerEntity != null)
                return true;

        }

        return false;

    }

    public async Task<IEnumerable<CustomerEntity>> GetAllAsync()
    {
        var customers = await _customerRepository.GetAllAsync();
        return customers;
    }

    public async Task<CustomerEntity> ListSpecificAsync(CustomerEntity email)
    {
        try
        {
            if (await _customerRepository.ExistsAsync(x => x.Email == email.Email))
            {
                return await _customerRepository.GetSpecificAsync(x => x.Email == email.Email);
            }
            return null!;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public async Task<bool> UpdateCustomerAsync(CustomerRegistrationForm form, string email )
    {
        
        {
            var existingcustomer = await _customerRepository.GetAsync(x => x.Email == email);
            

            if (existingcustomer == null || existingcustomer.Address == null)
            return false;          

            existingcustomer.FirstName = form.FirstName;
            existingcustomer.LastName = form.LastName;
            existingcustomer.Email = form.Email;
            existingcustomer.Address.StreetName = form.StreetName; 
            existingcustomer.Address.PostalCode = form.PostalCode;
            existingcustomer.Address.City = form.City;

            var updatedCustomer = await _customerRepository.UpdateAsync(existingcustomer);

            return updatedCustomer != null;
        }
        
        

      

    }

    public async Task<bool> DeleteAsync(string email)
    {
        var result = await _customerRepository.DeleteAsync(x => x.Email == email);
        return result;
    }
}
