using rihal.challenge.Application.Contracts.Services;

namespace rihal.challenge.WebApi.Services
{
    public class CurrentLanguageService : ICurrentLanguageService
    {
        public string GetCurrentLanguage()
        {
            return System.Threading.Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName;
        }

        public bool IsNative()
        {
            bool isNative = GetCurrentLanguage().ToLower() != "en";
            return isNative;
        }
    }
}
