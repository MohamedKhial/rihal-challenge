using System;

namespace rihal.challenge.Domain.Entities
{
    public class ProductJosnResponse
    {
        public Guid Id { get; set; }
        public string UrlKey { get; set; }
        public string ResponseBody { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public int Rank { get; set; }
    }
}
