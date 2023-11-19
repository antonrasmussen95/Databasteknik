using Inlämningsuppgift_G.Contexts;
using Inlämningsuppgift_G.Entities;

namespace Inlämningsuppgift_G.Repositories;

internal class CarModelRepository : Repo<CarModelEntity>
{
    public CarModelRepository(DataContext context) : base(context)
    {
    }
}
