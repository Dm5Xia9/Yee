using System;
using System.Collections.Generic;
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
        public ProtoString SubHeader { get; set; }
        public ProtoString Header { get; set; }
        public ProtoImg Img { get; set; }
    }

    public class Testimonial
    {
        public ProtoString Author { get; set; }
        public ProtoString Text { get; set; }
        public ProtoString Caption { get; set; }
        public ProtoImg Avatar { get; set; }
    }
}
