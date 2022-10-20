using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Section.Abstractions;
using Yee.Section.Prototypes;

namespace Yee.Cabaret.Sections.Prototypes
{
    public class ProtoTestimonial : BaseYeeProto<Testimonial>
    {
    }

    public class TestimonialsPanel
    {
        public ProtoString SubHeader { get; set; }
        public ProtoString Header { get; set; }
        public ProtoImg Img { get; set; }
        public List<Testimonial> Testimonials { get; set; }
    }

    public class Testimonial
    {
        public ProtoString Author { get; set; }
        public ProtoString Text { get; set; }
        public ProtoString Caption { get; set; }
    }
}
