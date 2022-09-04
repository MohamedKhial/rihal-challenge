using rihal.challenge.Application.Contracts.Persistence;
using rihal.challenge.Domain.Entities;
using rihal.challenge.Persistence.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rihal.challenge.Persistence.Repositories
{
    public class CountryRepo : BaseRepo<Country, int>, ICountryRepo
    {
        public CountryRepo(rihalchallengeDbContext dbContext) : base(dbContext)
        {
        }
    }
}
