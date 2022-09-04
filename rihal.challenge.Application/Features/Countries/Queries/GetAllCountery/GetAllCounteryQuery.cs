using MediatR;
using rihal.challenge.Application.Models.DTOs.CountryDtos;
using rihal.challenge.Application.Models.Results;
using rihal.challenge.Application.Models.Sorting;

namespace rihal.challenge.Application.Features.Countries.Queries.GetAllCounteries
{
    public class GetAllCounteryQuery : IRequest<ListResult<GetAllCountryDto>>
    {
        public string SearchKey { get; set; }
        public SortingModel<CountriesSortingColumn> Sorting { get; set; }

    }

    public enum CountriesSortingColumn
    {
        Id,
       Name
    }
}



