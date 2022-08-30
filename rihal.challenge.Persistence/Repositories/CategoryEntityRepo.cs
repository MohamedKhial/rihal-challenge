using rihal.challenge.Application.Contracts.Persistence;
using rihal.challenge.Domain.Entities;
using rihal.challenge.Persistence.DbContexts;

namespace rihal.challenge.Persistence.Repositories
{
    public class CategoryEntityRepo : BaseRepo<Category, int>, ICategoryEntityRepo
    {
        public CategoryEntityRepo(rihalchallengeDbContext rihalchallengeDbContext) : base(rihalchallengeDbContext)
        {
        }
    }
}
