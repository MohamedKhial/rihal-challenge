using AutoMapper;
using MediatR;
using rihal.challenge.Application.Features.Students.Queries.GetAllStudents;
using rihal.challenge.Application.Contracts.Persistence;
using rihal.challenge.Application.Models.DTOs.StudentDtos;
using rihal.challenge.Application.Models.Results;
using rihal.challenge.Application.Models.Sorting;
using rihal.challenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using rihal.challenge.Application.Models.DTOs.CountryDtos;

namespace rihal.challenge.Application.Features.Countries.Queries.GetAllCounteries
{
    public class GetAllCounteryQueryHandler : IRequestHandler<GetAllCounteryQuery, ListResult<GetAllCountryDto>>
    {
        private readonly ICountryRepo _countryRepo;
        private readonly IMapper _mapper;

        public GetAllCounteryQueryHandler(ICountryRepo countryRepo, IMapper mapper)
        {
            _countryRepo = countryRepo;
            _mapper = mapper;
        }
        public async Task<ListResult<GetAllCountryDto>> Handle(GetAllCounteryQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Country, bool>> searchExpression = x => request.SearchKey == null ||
                x.Name.Contains(request.SearchKey)
                || x.Name.Contains(request.SearchKey);

            Expression<Func<Country, object>> orderByExpression = x => request.Sorting.OrderBy == CountriesSortingColumn.Name ? x.Id :
                request.Sorting.OrderBy == CountriesSortingColumn.Name? x.Name :
                x.Id;
            IEnumerable<Country> items;
            if (request.Sorting.OrderByDirection == OrderDirection.ASC)
            {
                items = await _countryRepo.ListOrderedAsync(orderByExpression, searchExpression, request.Sorting.PageIndex, request.Sorting.PageSize);
            }
            else
            {
                items = await _countryRepo.ListDescendingOrderedAsync(orderByExpression, searchExpression, request.Sorting.PageIndex, request.Sorting.PageSize);
            }

            ListResult<GetAllCountryDto> result = new ListResult<GetAllCountryDto>
            {
                Items = _mapper.Map<IEnumerable<GetAllCountryDto>>(items),
                TotalCount = await _countryRepo.GetTotalCount(searchExpression)
            };
            return result;
        }
    }
}



