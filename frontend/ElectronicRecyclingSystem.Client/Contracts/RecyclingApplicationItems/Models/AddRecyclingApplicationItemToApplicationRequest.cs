using ElectronicRecyclingSystem.Client.Contracts.Common.ElectronicDevices;

namespace ElectronicRecyclingSystem.Client.Contracts.RecyclingApplicationItems.Models;

public record AddRecyclingApplicationItemToApplicationRequest(
    string Name,
    ElectronicDeviceCategoryViewModel Category,
    int Quantity)
{
    public string Name { get; set; } = Name;
    public ElectronicDeviceCategoryViewModel Category { get; set; } = Category;
    public int Quantity { get; set; } = Quantity;
}