using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MVM.SmartParking.Company.API.Data.Interfaces;
using MVM.SmartParking.Company.API.Models;

namespace MVM.SmartParking.Company.API.Data;

public class DataContext : DbContext, IUnityOfWork
{
    public DataContext(DbContextOptions<DataContext> opt) : base(opt)
    {
    }
    
    public DataContext(){}

    public DbSet<Models.Company> Companies { get; set; }
    public DbSet<Adress> Adresses { get; set; }
    public DbSet<Contact> Contacts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
    }

    public async Task<bool> Commit()
    {
        return await SaveChangesAsync() > 0;
    }
}
public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        var conectString = "Server=localhost;Port=3307;Database=smart-parking;Uid=root;Pwd=8837;";

        optionsBuilder.UseMySql(conectString, ServerVersion.AutoDetect(conectString));

        return new DataContext(optionsBuilder.Options);
    }
}
