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
    public class ProtoTestimonial : BaseYeeProto<TestimonialsPanel>
    {
    }

    public class ProtoTestimonialItems : BaseYeeProto<List<Testimonial>>
    {
    }

    public class TestimonialsPanel
    {
        [DisplayName("Подзаголовок")]
        public ProtoString SubHeader { get; set; }
        [DisplayName("Заголовок")]
        public ProtoString Header { get; set; }
        [DisplayName("Изображение")]
        public ProtoImg Img { get; set; }
    }

    public class Testimonial
    {
        [DisplayName("Автор")]
        public ProtoString Author { get; set; }
        [DisplayName("Текст")]
        public ProtoString Text { get; set; }
        [DisplayName("Дополнение")]
        public ProtoString Caption { get; set; }
        [DisplayName("Аватар")]
        public ProtoImg Avatar { get; set; }
    }
}
