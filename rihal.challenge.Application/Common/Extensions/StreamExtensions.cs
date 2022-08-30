using System.IO;

public static class StreamExtensions
{
    public static byte[] ReadFully(this Stream input)
    {
        using (MemoryStream memoryStream = new MemoryStream())
        {
            input.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }
    }
}