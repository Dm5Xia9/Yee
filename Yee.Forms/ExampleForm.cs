using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Forms.Attributes;

namespace Yee.Forms
{
    [DisplayName("Тестовая форма")]
    [FormGetMethod]
    [DebugForm("test")]
    public class ExampleForm
    {
        [DisplayName("Идентификатор")]
        [Required]
        public Guid Id { get; set; }

        [DisplayName("Почта")]
        [Required]
        public string Email { get; set; }

        [DisplayName("Полное имя")]
        [Required]
        public string FullName { get; set; }
        
    }
}
