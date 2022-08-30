using System;
using System.ComponentModel.DataAnnotations;

namespace rihal.challenge.Domain.Entities.AuthenticationAggregate
{
    public class AspNetRefreshToken
    {
        #region Constructors
        private AspNetRefreshToken()
        {
        }

        public AspNetRefreshToken(string userName, Guid clientId, DateTime issuedUtc,
            DateTime expiresUtc, string protectedTicket)
        {
            UserName = userName;
            ClientId = clientId;
            IssuedUtc = issuedUtc;
            ExpiresUtc = expiresUtc;
            ProtectedTicket = protectedTicket;
        }

        #endregion

        public Guid Id { get; private set; }

        [Required]
        [MaxLength(50)]
        public string UserName { get; private set; }

        [Required]
        [MaxLength(50)]
        public Guid ClientId { get; private set; }

        [Required]
        public DateTime IssuedUtc { get; set; }

        [Required]
        public DateTime ExpiresUtc { get; private set; }

        [Required]
        public string ProtectedTicket { get; private set; }
    }
}