using System.Threading;
using System.Threading.Tasks;
using ElectronicRecyclingSystem.Database;
using ElectronicRecyclingSystem.Domain.Models;
using ElectronicRecyclingSystem.Domain.Repositories;

namespace ElectronicRecyclingSystem.Infrastructure.Repositories.Users;

public class UserRepository : IUserRepository 
{
    private readonly ApplicationDbContext _applicationDbContext;

    public UserRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<User> Get(long userId, CancellationToken cancellationToken)
    {
        var dto = await _applicationDbContext.UserDtos
            .FindAsync([userId], cancellationToken: cancellationToken);

        return dto!.MapToModel();
    }
}