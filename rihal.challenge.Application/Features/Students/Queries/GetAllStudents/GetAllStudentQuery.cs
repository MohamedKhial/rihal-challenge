using MediatR;
using rihal.challenge.Application.Models.DTOs.StudentDtos;
using rihal.challenge.Application.Models.Results;
using rihal.challenge.Application.Models.Sorting;

namespace rihal.challenge.Application.Features.Students.Queries.GetAllStudents
{
    public class GetAllStudentQuery : IRequest<ListResult<GetAllStudentDto>>
    {
        public string SearchKey { get; set; }
        public SortingModel<StudentsSortingColumn> Sorting { get; set; }

    }

    public enum StudentsSortingColumn
    {
        Id,
       Name
    }
}



