using rihal.challenge.Application.Common.Configurations;
using rihal.challenge.Application.Contracts.Infrastructure;
using System;
using System.IO;

namespace rihal.challenge.Infrastructure.Files
{
    public class FileHandler : IFileHandler
    {
        private readonly ConfigurationsManager _configurationsManager;

        public FileHandler(ConfigurationsManager configurationsManager)
        {
            _configurationsManager = configurationsManager;
        }
        public string SaveFile(byte[] fileBytes, string fileExtension)
        {
            string newFileName = $"{Guid.NewGuid()}{fileExtension}";
            string _path = Path.Combine(_configurationsManager.UploadableFilesPath, newFileName);
            File.WriteAllBytes(_path, fileBytes);
            return _path;
        }
    }
}
