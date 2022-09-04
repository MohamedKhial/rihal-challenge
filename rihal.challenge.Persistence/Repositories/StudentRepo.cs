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
    public class StudentRepo :BaseRepo<Student,int>, IStudentRepo
    {
        public StudentRepo(rihalchallengeDbContext dbContext) : base(dbContext)
        {
        }
    }
}
