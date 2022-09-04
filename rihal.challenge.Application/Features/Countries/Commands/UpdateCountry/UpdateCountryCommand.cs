using MediatR;
using rihal.challenge.Application.Models.DTOs.ClassDtos;
using rihal.challenge.Application.Models.DTOs.CountryDtos;
using rihal.challenge.Application.Models.DTOs.StudentDtos;

namespace rihal.challenge.Application.Features.Countries.Commands.UpdateCountry
{
    public class UpdateCountryCommand : IRequest<bool>
    {
        public UpdateCountryDto Model { get; set; }
    }
}