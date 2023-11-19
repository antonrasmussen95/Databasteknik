using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Inlämningsuppgift_G.Contexts;

internal class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        var optionBuilder = new DbContextOptionsBuilder<DataContext>();
        optionBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Skola\Databasteknik\Inlämningsuppgift_G\Inlämningsuppgift_G\Contexts\database.mdf;Integrated Security=True;Connect Timeout=30"); 

        return new DataContext(optionBuilder.Options);
    }
}
