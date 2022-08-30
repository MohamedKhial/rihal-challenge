namespace rihal.challenge.Application.Contracts.Services
{
    public interface ICurrentLanguageService
    {
        string GetCurrentLanguage();
        bool IsNative();
    }
}
