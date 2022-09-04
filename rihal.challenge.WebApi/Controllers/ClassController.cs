using MediatR;
using Microsoft.AspNetCore.Mvc;
using rihal.challenge.Application.Features.Classes.Commands.CreateClass;
using rihal.challenge.Application.Features.Classes.Commands.DeleteClass;
using rihal.challenge.Application.Features.Classes.Commands.UpdateClass;
using rihal.challenge.Application.Features.Classes.Queries.GetAllClasses;
using rihal.challenge.Application.Features.Classes.Queries.GetByIdClass;
using rihal.challenge.Application.Features.Students.Commands.DeleteStudent;
using rihal.challenge.Application.Models.DTOs.ClassDtos;
using rihal.challenge.Application.Models.Results;
using rihal.challenge.Application.Models.Sorting;
using rihal.challenge.Domain.Entities;
using System.Threading.Tasks;

namespace PaymentPlatform.Domain.Entities.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : Controller
    {
        private readonly IMediator _mediator;

        public ClassController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ListResult<GetAllClassesDto>> Get(string searchkey,
            int pageIndex = 0, int pageSize = 100, ClassesSortingColumn orderBy = ClassesSortingColumn.Id, OrderDirection direction = OrderDirection.ASC)
        {
            return await _mediator.Send(new GetAllClassesQuery
            {
                SearchKey = searchkey,
                Sorting = new SortingModel<ClassesSortingColumn>
                {
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    OrderBy = orderBy,
                    OrderByDirection = direction
                }
            });
        }

        [HttpGet("{Id}")]
        public async Task<Class> GetClassById(int Id)
        {
            return await _mediator.Send(new GetByIdClassQuery { Id = Id });
        }

        [HttpPost]
        public async Task<Class> CreateClass(CreateClassDto model)
        {
            return await _mediator.Send(new CreateClassCommand { Model = model });
        }

        [HttpPut]
        public async Task<bool> Put(UpdateClassDto model)
        {
            return await _mediator.Send(new UpdateClassCommand { Model = model });
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _mediator.Send(new DeleteClassCommand
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








