using Inlämningsuppgift_G.Contexts;
using Inlämningsuppgift_G.Entities;

namespace Inlämningsuppgift_G.Repositories;

internal class AddressRepository : Repo<AddressEntity>
{
    public AddressRepository(DataContext context) : base(context)
    {
    }
}
