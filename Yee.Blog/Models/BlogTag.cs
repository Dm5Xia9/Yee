using Ability.Core.Models;

namespace Yee.Blog.Models
{
    public class BlogTag : BaseRecord
    {
        public string TagName { get; set; }

        public List<BlogItem> BlogItems { get; set; }
    }
}
