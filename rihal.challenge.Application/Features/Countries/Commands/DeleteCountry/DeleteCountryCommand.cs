using MediatR;

namespace rihal.challenge.Application.Features.Countries.Commands.DeleteCountry
{
    public class DeleteCountryCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
