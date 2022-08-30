namespace rihal.challenge.Application.Contracts.Infrastructure
{
    public interface IFileHandler
    {
        string SaveFile(byte[] fileBytes, string fileExtension);
    }
}
