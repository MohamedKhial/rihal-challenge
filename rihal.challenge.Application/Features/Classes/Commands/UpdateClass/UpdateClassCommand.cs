using MediatR;
using rihal.challenge.Application.Models.DTOs.ClassDtos;
using rihal.challenge.Application.Models.DTOs.StudentDtos;

namespace rihal.challenge.Application.Features.Classes.Commands.UpdateClass
{
    public class UpdateClassCommand : IRequest<bool>
    {
        public UpdateClassDto Model { get; set; }
    }
}