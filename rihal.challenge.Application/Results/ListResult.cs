using System.Collections.Generic;

namespace rihal.challenge.Application.Models.Results
{
    public class ListResult<T> where T : class
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalCount { get; set; }
    }
}
