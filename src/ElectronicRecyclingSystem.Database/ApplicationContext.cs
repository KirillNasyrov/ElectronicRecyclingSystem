using ElectronicRecyclingSystem.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace ElectronicRecyclingSystem.Database;

public class ApplicationContext(DbContextOptions options) : DbContext(options)
{
    public required DbSet<DeliveryApplicationDto> DeliveryApplicationDtos { get; init; }
}