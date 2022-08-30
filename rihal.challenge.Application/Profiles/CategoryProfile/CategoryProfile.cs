using AutoMapper;
using rihal.challenge.Application.Models.DTOs.Category;
using rihal.challenge.Domain.Entities;

namespace rihal.challenge.Application.Profiles.CategoryProfile
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, DisplayCategoryDTO>().ReverseMap();

        }
    }
}
