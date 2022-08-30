using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace rihal.challenge.Application.Common.Utilities
{
    public class HashingUtility
    {
        public static string GetHash(string input)
        {
            SHA256CryptoServiceProvider hashAlgorithm = new SHA256CryptoServiceProvider();
            byte[] byteValue = Encoding.UTF8.GetBytes(input);
            byte[] byteHash = hashAlgorithm.ComputeHash(byteValue);

            return Convert.ToBase64String(byteHash);
        }

        public static string GenerateRandomEncryptedTicket()
        {
            SHA256CryptoServiceProvider hashAlgorithm = new SHA256CryptoServiceProvider();
            byte[] byteValue = Encoding.UTF8.GetBytes(Guid.NewGuid().ToString("n"));
            byte[] byteHash = hashAlgorithm.ComputeHash(byteValue);
            string randomTicket = Convert.ToBase64String(byteHash);
            randomTicket = HttpUtility.UrlEncode(randomTicket);
            randomTicket = RemoveSpecialCharacters(randomTicket);
            return randomTicket;
        }

        public static string RemoveSpecialCharacters(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        public static string GenerateRandomPassword()
        {
            string[] randomChars = new[] { "abcdefghijkmnopqrstuvwxyz", "ABCDEFGHIJKLMNOPQRSTUVWXYZ", "0123456789" };

            Random rand = new Random(Environment.TickCount);
            List<char> chars = new List<char>();

            chars.Insert(rand.Next(0, chars.Count), randomChars[0][rand.Next(0, randomChars[0].Length)]);
            chars.Insert(rand.Next(0, chars.Count), randomChars[1][rand.Next(0, randomChars[1].Length)]);
            chars.Insert(rand.Next(0, chars.Count), randomChars[2][rand.Next(0, randomChars[2].Length)]);

            for (int i = chars.Count; i <= 8; i++)
            {
                string rcs = randomChars[rand.Next(0, randomChars.Length)];
                chars.Insert(rand.Next(0, chars.Count), rcs[rand.Next(0, rcs.Length)]);
            }

            return new string(chars.ToArray());
        }

        internal static string GenerateSalt()
        {
            RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();
            byte[] bytes = new byte[8];
            rngCsp.GetBytes(bytes);
            return Convert.ToBase64String(bytes);
        }

        public static string HashPassword(string password, out string salt)
        {
            salt = GenerateSalt();
            return GetMd5Hash(password + salt);
        }

        public static string HashPassword(string password, string salt)
        {
            return GetMd5Hash(password + salt);
        }


        #region Private Methods

        private static string GetMd5Hash(string input)
        {
            MD5 md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
        #endregion
    }
}
