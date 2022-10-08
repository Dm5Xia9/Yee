using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Text;
using IDKEY = System.Int64;

namespace Ability.Core.Models
{
    public class AbilityUserRole : IdentityUserRole<IDKEY> { }
    public class AbilityUserClaim : IdentityUserClaim<IDKEY> { }
    public class AbilityUserLogin : IdentityUserLogin<IDKEY> { }
    public class AbilityRoleClaim : IdentityRoleClaim<IDKEY> { }
    public class AbilityUserToken : IdentityUserToken<IDKEY> { }
}
