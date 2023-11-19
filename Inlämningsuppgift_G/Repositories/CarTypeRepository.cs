using Inlämningsuppgift_G.Contexts;
using Inlämningsuppgift_G.Entities;

namespace Inlämningsuppgift_G.Repositories;

internal class CarTypeRepository : Repo<CarTypeEntity>
{
    public CarTypeRepository(DataContext context) : base(context)
    {
    }
}
