using System.Threading;
using System.Threading.Tasks;
using ElectronicRecyclingSystem.Domain.Models;

namespace ElectronicRecyclingSystem.Domain.Repositories;

public interface IUserRepository
{
    public Task<User> Get(
        long userId,
        CancellationToken cancellationToken);
}