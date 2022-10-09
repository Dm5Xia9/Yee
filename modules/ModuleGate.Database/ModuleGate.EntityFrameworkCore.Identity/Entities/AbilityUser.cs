using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using IDKEY = System.Int64;


namespace Ability.Core.Models
{
    [Table("Users")]
    public class AbilityUser : IdentityUser<IDKEY>, IEntity
    {
        /// <summary>
        /// Navigation property for the roles this user belongs to.
        /// </summary>
        public virtual ICollection<AbilityUserRole> Roles { get; } = new List<AbilityUserRole>();

        /// <summary>
        /// Navigation property for the claims this user possesses.
        /// </summary>
        public virtual ICollection<AbilityUserClaim> Claims { get; } = new List<AbilityUserClaim>();

        /// <summary>
        /// Navigation property for this users login accounts.
        /// </summary>
        public virtual ICollection<AbilityUserLogin> Logins { get; } = new List<AbilityUserLogin>();
    }
}
