using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Linq;

namespace rihal.challenge.WebApi.Common
{
    /// <summary>
    /// 
    /// </summary>
    public static class HttpRequestHeaderHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        public static string GetClientIdFromHeader(HttpRequest request)
        {
            request.Headers.TryGetValue("Authorization", out StringValues authHeader);
            ExtractClientIdAndSecretFromHeader(authHeader, out string clientId, out string clientSecret);

            return clientId;
        }
        public static void TryGetClientInfoFromHeader(HttpRequest request, out string clientId, out string clientSecret)
        {
            request.Headers.TryGetValue("Authorization", out StringValues authHeader);
            ExtractClientIdAndSecretFromHeader(authHeader, out clientId, out clientSecret);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="authHeader"></param>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        public static void ExtractClientIdAndSecretFromHeader(string authHeader, out string clientId, out string clientSecret)
        {
            clientId = string.Empty;
            clientSecret = string.Empty;

            bool isClientInfoExist = string.IsNullOrEmpty(authHeader) == false && (authHeader.ToString().StartsWith("Basic") || authHeader.ToString().StartsWith("basic"));
            if (isClientInfoExist)
            {
                string encodedClientAndSecret = authHeader.Substring("Basic ".Length).Trim();
                if (authHeader.ToString().StartsWith("basic"))
                {
                    encodedClientAndSecret = authHeader.Substring("basic ".Length).Trim();
                }
                byte[] decodedClientAndSecret = Convert.FromBase64String(encodedClientAndSecret);
                //var clientAndSecret = Encoding.GetEncoding("iso-8859-1").GetString(decodedClientAndSecret);
                string clientAndSecret = System.Text.Encoding.Unicode.GetString(decodedClientAndSecret);
                System.Collections.Generic.List<string> clientAndSecretSplitted = clientAndSecret.Split(':').ToList();

                if (clientAndSecretSplitted.Any())
                {
                    clientId = clientAndSecretSplitted[0];
                    if (clientAndSecretSplitted.Count > 1)
                    {
                        clientSecret = clientAndSecretSplitted[1];
                    }
                }
            }
        }
    }
}
