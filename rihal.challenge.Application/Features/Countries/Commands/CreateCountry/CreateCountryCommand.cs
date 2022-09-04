using MediatR;
using rihal.challenge.Application.Models.DTOs.CountryDtos;
using rihal.challenge.Application.Models.DTOs.StudentDtos;
using rihal.challenge.Domain.Entities;

namespace rihal.challenge.Application.Features.Countries.Commands.CreateCountry
{
    public class CreateCountryCommand : IRequest<Country>
    {
        public CreateCountryDto Model { get; set; }
    }
}