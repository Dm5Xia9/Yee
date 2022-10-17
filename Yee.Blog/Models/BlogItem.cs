using Ability.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yee.Blog.Models
{
    public class BlogItem : BaseRecord
    {
        public long AuthorId { get; set; }

        public string Title { get; set; }
        public string Cover { get; set; }

        public long? BlogCategoryId { get; set; }
        public BlogCategory BlogCategory { get; set; }

        public List<BlogTag> Tags { get; set; }
    }
}
