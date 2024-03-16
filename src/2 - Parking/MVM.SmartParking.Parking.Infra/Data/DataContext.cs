using Microsoft.EntityFrameworkCore;
using MVM.SmartParking.Parking.Domain.Entities;

namespace MVM.SmartParking.Parking.Infra.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> opt) : base(opt)
    {
        
    }
    
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<Company> Companies { get; set; }
}