using Inlämningsuppgift_G.Contexts;
using Inlämningsuppgift_G.Entities;
using Microsoft.EntityFrameworkCore;

namespace Inlämningsuppgift_G.Repositories;

internal class CarRepository : Repo<CarEntity>
{
    private readonly DataContext _context;
    public CarRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<CarEntity>> GetAllAsync()
    {
        return await _context.Cars
            .Include(x => x.CarModel)
            .Include(x => x.CarType)
            .ToListAsync();        
    }
}
