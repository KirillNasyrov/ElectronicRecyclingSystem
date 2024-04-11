using ElectronicRecyclingSystem.Database.Models;
using ElectronicRecyclingSystem.Domain.Models;

namespace ElectronicRecyclingSystem.Infrastructure.Repositories.Users;

public static class UserMapping
{
    public static User MapToModel(
        this UserDto dto)
    {
        return new User
        (
            dto.Id,
            dto.Email,
            dto.Password,
            dto.Name,
            dto.Surname,
            (UserRole)dto.RoleId
        );
    }
    
    public static UserDto MapToDto(
        this User model)
    {
        return new UserDto
        {
            Id = model.Id,
            Email = model.Email,
            Password = model.Password,
            Name = model.Name,
            Surname = model.Surname,
            RoleId = (short)model.Role
        };
    }
}