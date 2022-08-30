using rihal.challenge.Domain.Entities;

namespace rihal.challenge.Application.Contracts.Persistence
{
    public interface ICategoryEntityRepo : IAsyncRepo<Category, int>
    {
    }
}
