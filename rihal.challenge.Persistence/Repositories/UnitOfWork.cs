using rihal.challenge.Application.Contracts.Persistence;
using rihal.challenge.Persistence.DbContexts;
using System.Threading.Tasks;

namespace rihal.challenge.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly rihalchallengeDbContext _dbContext;

        public UnitOfWork(rihalchallengeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
