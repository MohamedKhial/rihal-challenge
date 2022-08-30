using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace rihal.challenge.Domain.Entities.AuthenticationAggregate
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public ApplicationRole()
        {

        }
        public ApplicationRole(string roleName) : base(roleName)
        {

        }
        public virtual ICollection<ApplicationUser> Users { get; set; }


    }
}
