using Inlämningsuppgift_G.Entities;
using Microsoft.EntityFrameworkCore;

namespace Inlämningsuppgift_G.Contexts;

internal class DataContext : DbContext

{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<CustomerEntity> Customers { get; set; }
    public DbSet<AddressEntity> Adresses { get; set; }
    public DbSet<CarEntity> Cars { get; set; }
    public DbSet<CarTypeEntity> CarTypes { get; set; }
    public DbSet<CarModelEntity> CarModels { get; set; }

}
