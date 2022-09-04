using MediatR;

namespace rihal.challenge.Application.Features.Classes.Commands.DeleteClass
{
    public class DeleteClassCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
