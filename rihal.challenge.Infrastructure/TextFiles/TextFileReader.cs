using rihal.challenge.Application.Contracts.Infrastructure;
using System.IO;
using System.Threading.Tasks;

namespace rihal.challenge.Infrastructure.TextFiles
{
    public class TextFileReader : ITextFileReader
    {
        public async Task<string> ReadAsync(string filePath)
        {
            using (Stream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                StreamReader reader = new StreamReader(stream);
                string content = await reader.ReadToEndAsync();
                reader.Close();
                stream.Close();
                return content;
            }
        }
    }
}
