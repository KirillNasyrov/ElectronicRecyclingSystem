using ElectronicRecyclingSystem.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace ElectronicRecyclingSystem.Database;

public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
{
    public required DbSet<RecyclingApplicationDto> RecyclingApplicationDtos { get; init; }
    public required DbSet<RecyclingApplicationItemDto> RecyclingApplicationItemsDtos { get; init; }
    public required DbSet<ElectronicDeviceDto> ElectronicDeviceDtos { get; init; }
    
    public required DbSet<RecyclingApplicationStatusDto> RecyclingApplicationStatusDtos { get; set; }
    public required DbSet<ElectronicDevicesCategoryDto> ElectronicDevicesCategoryDtos { get; set; }
}