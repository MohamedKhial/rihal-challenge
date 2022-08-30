using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rihal.challenge.Application.Features.MegentoCategory.Commands.UpdateArabicCategoryMagentoMemory;
using rihal.challenge.Application.Features.MegentoCategory.Commands.UpdateEnglishCategoryMagentoMemory;
using rihal.challenge.Application.Features.MegentoCategory.Queries.GetArabicCategory;
using rihal.challenge.Application.Features.MegentoCategory.Queries.GetEnglishCategory;
using rihal.challenge.Application.Models.DTOs.Category;
using System.Threading.Tasks;

namespace rihal.challenge.WebApi.Controllers
{
    [Route("")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("api/[controller]/UpdateEnglishCategory")]
        public async Task<bool> UpdateEnglishCategory()
        {
            return await _mediator.Send(new UpdateEnglishCategoryCommand());
        }
        [HttpGet("rest/english/V1/crocoit/categories")]
        public async Task<DisplayCategoryDTO> GetEnglishCategory(int rootCategoryId, int depth)
        {
            return await _mediator.Send(new GetEnglishCategoryQuery());
        }

        [HttpPost("api/[controller]/UpdateArabicCategory")]
        public async Task<bool> UpdateArabicCategory()
        {
            return await _mediator.Send(new UpdateArabicCategoryCommand());
        }

        [HttpGet("rest/arabic/V1/crocoit/categories")]
        public async Task<DisplayCategoryDTO> GetArabicCategory(int rootCategoryId, int depth)
        {
            return await _mediator.Send(new GetArabicCategoryQuery());
        }


    }
}
