using rihal.challenge.Domain.Entities;

namespace rihal.challenge.Application.Contracts.Persistence
{
    public interface IProductCategoryLinkEntityRepo : IAsyncRepo<category_link, int>
    {
    }
}
