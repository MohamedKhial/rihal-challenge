using System.Threading.Tasks;

namespace rihal.challenge.Application.Contracts.Persistence
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}
