using MediatR;
using rihal.challenge.Application.Models.DTOs.ClassDtos;
using rihal.challenge.Application.Models.Results;
using rihal.challenge.Application.Models.Sorting;

namespace rihal.challenge.Application.Features.Classes.Queries.GetAllClasses
{
    public class GetAllClassesQuery : IRequest<ListResult<GetAllClassesDto>>
    {
        public string SearchKey { get; set; }
        public SortingModel<ClassesSortingColumn> Sorting { get; set; }

    }

    public enum ClassesSortingColumn
    {
        Id,
       Name
    }
}



