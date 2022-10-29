using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Section.Abstractions;
using Yee.Section.Base;

namespace Yee.Cabaret.Sections.Prototypes
{
    public class ProtoFAQ : BaseYeeProto<FAQ>
    {
    }

    public class FAQ
    {
        public ProtoString Header { get; set; }
        public ProtoString Description { get; set; }
        public List<Question> Questions { get; set; }
    }

    public class Question
    {
        public ProtoString QuestionText { get; set; }
        public ProtoTextArea Answer { get; set; }
    }
}
