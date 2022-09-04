using MediatR;
using Microsoft.AspNetCore.Mvc;
using rihal.challenge.Application.Features.Countries.Commands.CreateCountry;
using rihal.challenge.Application.Features.Countries.Commands.DeleteCountry;
using rihal.challenge.Application.Features.Countries.Commands.UpdateCountry;
using rihal.challenge.Application.Features.Countries.Queries.GetAllCounteries;
using rihal.challenge.Application.Features.Countries.Queries.GetByIdCountry;
using rihal.challenge.Application.Models.DTOs.CountryDtos;
using rihal.challenge.Application.Models.Results;
using rihal.challenge.Application.Models.Sorting;
using rihal.challenge.Domain.Entities;
using System.Threading.Tasks;

namespace PaymentPlatform.Domain.Entities.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : Controller
    {
        private readonly IMediator _mediator;

        public CountryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ListResult<GetAllCountryDto>> Get(string searchkey,
            int pageIndex = 0, int pageSize = 100, CountriesSortingColumn orderBy = CountriesSortingColumn.Id, OrderDirection direction = OrderDirection.ASC)
        {
            return await _mediator.Send(new GetAllCounteryQuery
            {
                SearchKey = searchkey,
                Sorting = new SortingModel<CountriesSortingColumn>
                {
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    OrderBy = orderBy,
                    OrderByDirection = direction
                }
            });
        }

        [HttpGet("{Id}")]
        public async Task<Country> GetCountryById(int Id)
        {
            return await _mediator.Send(new GetByIdCountryQuery { Id = Id });
        }

        [HttpPost]
        public async Task<Country> CreateCountry(CreateCountryDto model)
        {
            return await _mediator.Send(new CreateCountryCommand { Model = model });
        }

        [HttpPut]
        public async Task<bool> Put(UpdateCountryDto model)
        {
            return await _mediator.Send(new UpdateCountryCommand { Model = model });
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _mediator.Send(new DeleteCountryCommand
            {
                Id = id
            });
        }

       


       


        [HttpPut("DeleteCountry/{id}")]
        public async Task<bool> DeleteTaxType(int id)
        {
            return await _mediator.Send(new DeleteCountryCommand { Id = id });
        }


     

    }

}








