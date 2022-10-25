using System;
using System.Collections.Generic;
using System.Text;
using IDKEY = System.Guid;

namespace Ability.Core.Models
{
    public interface IEntity
    {
        IDKEY Id { get; set; }
    }
}
