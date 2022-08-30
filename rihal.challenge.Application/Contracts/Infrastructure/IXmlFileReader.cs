using System.Collections.Generic;

namespace rihal.challenge.Application.Contracts.Infrastructure
{
    public interface IXmlFileReader<T> where T : class
    {
        List<T> ToList(string filePath, string xmlRootNode);
    }
}
