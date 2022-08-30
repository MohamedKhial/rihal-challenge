using System.Threading.Tasks;

namespace rihal.challenge.Application.Contracts.Infrastructure
{
    public interface ITextFileReader
    {
        public Task<string> ReadAsync(string filePath);
    }
}
