using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using IDKEY = System.Int64;

namespace Ability.Core.Models
{
    [Table("Roles")]
    public class AbilityRole : IdentityRole<IDKEY>, IEntity
    {
        public AbilityRole()
        {
        }

        public AbilityRole(string roleName)
        {
            Name = roleName;
        }

        //public static string Admin = "Admin";
        //public static string Operator = "Operator";
        //public static string Editor = "Editor";
    }
}
