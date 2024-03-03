using Microsoft.EntityFrameworkCore;
using MVM.SmartParking.Company.API.Data.Interfaces;
using MVM.SmartParking.Company.API.Models;

namespace MVM.SmartParking.Company.API.Data;

public class DataContext : DbContext, IUnityOfWork
{
    public DataContext(DbContextOptions<DataContext> opt) : base(opt)
    {
        
    }

    public DbSet<Models.Company> Companies { get; set; }
    public DbSet<Adress> Adresses { get; set; }
    public DbSet<Contact> Contacts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    public async Task<bool> Commit()
    {
        return await SaveChangesAsync() > 0;
    }
}