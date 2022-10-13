using System;
using System.Collections.Generic;
using System.Text;
using IDKEY = System.Int64;

namespace Ability.Core.Models
{
    public interface IEntity
    {
        IDKEY Id { get; set; }
    }
}
