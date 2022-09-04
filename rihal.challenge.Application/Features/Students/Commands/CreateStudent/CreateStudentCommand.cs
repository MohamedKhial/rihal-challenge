using MediatR;
using rihal.challenge.Application.Models.DTOs.StudentDtos;
using rihal.challenge.Domain.Entities;

namespace rihal.challenge.Application.Features.Students.Commands.CreateStudent
{
    public class CreateStudentCommand : IRequest<Student>
    {
        public CreateStudentDto Model { get; set; }
    }
}