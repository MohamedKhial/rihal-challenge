using MediatR;
using rihal.challenge.Application.Models.DTOs.StudentDtos;

namespace rihal.challenge.Application.Features.Students.Commands.UpdateStudent
{
    public class UpdateStudentCommand : IRequest<bool>
    {
        public UpdateStudentDto Model { get; set; }
    }
}