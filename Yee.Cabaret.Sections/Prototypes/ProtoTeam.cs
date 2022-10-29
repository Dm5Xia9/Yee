using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Section.Abstractions;
using Yee.Section.Base;

namespace Yee.Cabaret.Sections.Prototypes
{
    public class ProtoTeam : BaseYeeProto<List<Employee>>
    {
    }

    public class Employee
    {
        [DisplayName("Имя")]
        public ProtoString Name { get; set; }
        [DisplayName("Должность")]
        public ProtoString Post { get; set; }
        [DisplayName("Изображение")]
        public ProtoImg Img { get; set; }
    }
}
