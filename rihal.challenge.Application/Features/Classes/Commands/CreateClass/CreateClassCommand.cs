using MediatR;
using rihal.challenge.Application.Models.DTOs.ClassDtos;
using rihal.challenge.Domain.Entities;

namespace rihal.challenge.Application.Features.Classes.Commands.CreateClass
{
    public class CreateClassCommand : IRequest<Class>
    {
        public CreateClassDto Model { get; set; }
    }
}