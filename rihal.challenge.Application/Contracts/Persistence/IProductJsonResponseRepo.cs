﻿using rihal.challenge.Domain.Entities;

namespace rihal.challenge.Application.Contracts.Persistence
{
    public interface IProductJsonResponseRepo : IAsyncRepo<ProductJosnResponse, string>
    {
    }
}
