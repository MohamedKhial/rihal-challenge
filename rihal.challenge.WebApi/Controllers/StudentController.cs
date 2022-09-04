using MediatR;
using Microsoft.AspNetCore.Mvc;
using rihal.challenge.Application.Features.Students.Commands.CreateStudent;
using rihal.challenge.Application.Features.Students.Commands.DeleteStudent;
using rihal.challenge.Application.Features.Students.Commands.UpdateStudent;
using rihal.challenge.Application.Features.Students.Queries.GetAllStudents;
using rihal.challenge.Application.Features.Students.Queries.GetByIdStudent;
using rihal.challenge.Application.Models.DTOs.StudentDtos;
using rihal.challenge.Application.Models.Results;
using rihal.challenge.Application.Models.Sorting;
using rihal.challenge.Domain.Entities;
using System.Threading.Tasks;

namespace PaymentPlatform.Domain.Entities.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly IMediator _mediator;

        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ListResult<GetAllStudentDto>> Get(string searchkey,
            int pageIndex = 0, int pageSize = 100, StudentsSortingColumn orderBy = StudentsSortingColumn.Id, OrderDirection direction = OrderDirection.ASC)
        {
            return await _mediator.Send(new GetAllStudentQuery
            {
                SearchKey = searchkey,
                Sorting = new SortingModel<StudentsSortingColumn>
                {
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    OrderBy = orderBy,
                    OrderByDirection = direction
                }
            });
        }

        [HttpGet("{Id}")]
        public async Task<Student> GetStudentById(int Id)
        {
            return await _mediator.Send(new GetByIdStudentQuery { Id = Id });
        }

        [HttpPost]
        public async Task<Student> CreateStudent(CreateStudentDto model)
        {
            return await _mediator.Send(new CreateStudentCommand { Model = model });
        }

        [HttpPut]
        public async Task<bool> Put(UpdateStudentDto model)
        {
            return await _mediator.Send(new UpdateStudentCommand { Model = model });
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _mediator.Send(new DeleteStudentCommand
            {
                Id = id
            });
        }

       


       


        [HttpPut("DeleteStudent/{id}")]
        public async Task<bool> DeleteTaxType(int id)
        {
            return await _mediator.Send(new DeleteStudentCommand { Id = id });
        }


     

    }

}








