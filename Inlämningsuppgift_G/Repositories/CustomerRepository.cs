using Inlämningsuppgift_G.Contexts;
using Inlämningsuppgift_G.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Inlämningsuppgift_G.Repositories;

internal class CustomerRepository : Repo<CustomerEntity>
{
    private readonly DataContext _context;
    public CustomerRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<CustomerEntity>> GetAllAsync()
    {
        return await _context.Customers.Include(x => x.Address).ToListAsync(); 
    }

   
}
