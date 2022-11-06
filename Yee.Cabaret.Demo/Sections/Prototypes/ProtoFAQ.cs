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
    public class ProtoFAQ : BaseYeeProto<FAQ>
    {
    }

    public class ProtoQuestions : BaseYeeProto<List<Question>>
    {
    }

    public class FAQ
    {
        [DisplayName("Заголовок")]
        public ProtoString Header { get; set; }
        [DisplayName("Описание")]
        public ProtoString Description { get; set; }
    }

    public class Question
    {
        [DisplayName("Текст вопроса")]
        public ProtoString QuestionText { get; set; }
        [DisplayName("Текст ответа")]
        public ProtoTextArea Answer { get; set; }
    }
}
