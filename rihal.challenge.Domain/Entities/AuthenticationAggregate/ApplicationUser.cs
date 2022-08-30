using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace rihal.challenge.Domain.Entities.AuthenticationAggregate
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        #region Constructors

        private ApplicationUser()
        {
        }

        public ApplicationUser(string userName, string email, string fullName, string nickName, string status,
            bool isSocialNetworkLinked = false)
        {
            UserName = userName;
            FullName = fullName;
            NickName = nickName;
            Email = email;
            IsSocialNetworkLinked = isSocialNetworkLinked;
            IsActive = true;
            IsDeleted = false;
            CreationDate = DateTime.Now;
            Status = status;
        }

        public ApplicationUser(Guid id, string userName, string email, string password, string phoneNumber,
            string fullName, string nickName, string status,
            bool isSocialNetworkLinked = false)
        {

            Id = id;
            UserName = userName;
            FullName = fullName;
            NickName = nickName;
            Email = email;
            PhoneNumber = phoneNumber;
            IsSocialNetworkLinked = isSocialNetworkLinked;
            IsActive = true;
            IsDeleted = false;
            CreationDate = DateTime.Now;
            Status = status;
            _passwordHasher = new PasswordHasher<ApplicationUser>();
            PasswordHash = _passwordHasher.HashPassword(this, password);
        }

        #endregion

        #region Members

        public string FullName { get; private set; }
        public string NickName { get; private set; }
        public Guid? ProfilePhotoId { get; private set; }
        public DateTime CreationDate { get; private set; }
        public DateTime? LastLoginTime { get; private set; }
        public bool IsActive { get; private set; }
        public bool IsDeleted { get; private set; }
        public bool IsSocialNetworkLinked { get; private set; }
        public string Status { get; set; }

        public virtual ICollection<ApplicationRole> Roles { get; set; }

        #endregion

        private readonly IPasswordHasher<ApplicationUser> _passwordHasher;

        #region Public Methods

        public void Update(string email,
            string fullName, string nickName, string phoneNumber, Guid? ProfilePhotoId, string status)
        {
            FullName = fullName;
            NickName = nickName;
            Email = email;
            this.ProfilePhotoId = ProfilePhotoId;
            PhoneNumber = phoneNumber;
            Status = status;
        }

        public void Deactivate()
        {
            IsActive = false;
        }

        public void Activate()
        {
            IsActive = true;
        }

        public void Delete()
        {
            IsDeleted = true;
        }

        public bool IsAllowed()
        {
            return IsDeleted == false && IsActive == true;
        }


        #endregion

    }

}
