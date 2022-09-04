using rihal.challenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rihal.challenge.Application.Contracts.Persistence
{
    public interface IClassRepo : IAsyncRepo<Class, int>
    {
    }
}
