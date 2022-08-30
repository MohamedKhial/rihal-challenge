using System;
using System.ComponentModel.DataAnnotations;

namespace rihal.challenge.Domain.Entities.AuthenticationAggregate
{
    public class AspNetClient
    {
        #region Constructors

        public AspNetClient() { }

        #endregion

        public Guid Id { get; set; }

        [Required]
        public string Secret { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public int RefreshTokenLifeTime { get; set; }

        [MaxLength(100)]
        public string AllowedOrigin { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public bool IsMustValidateSecret { get; set; }

    }
}