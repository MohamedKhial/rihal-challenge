using System;

namespace rihal.challenge.Domain.Entities
{
    public class JsonResponse
    {
        public JsonResponse()
        {

        }
        public JsonResponse(string requestKey, string responseBody, DateTime lastUpdatedDate)
        {
            RequestKey = requestKey;
            ResponseBody = responseBody;
            LastUpdatedDate = lastUpdatedDate;
        }

        public string RequestKey { get; set; }
        public string ResponseBody { get; set; }
        public DateTime LastUpdatedDate { get; set; } = DateTime.Now;
    }
}
