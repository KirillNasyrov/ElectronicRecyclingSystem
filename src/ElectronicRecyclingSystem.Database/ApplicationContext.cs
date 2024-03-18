using ElectronicRecyclingSystem.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace ElectronicRecyclingSystem.Database;

public class ApplicationContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<DeliveryApplicationDto>? DeliveryApplicationDtos { get; set; }
}