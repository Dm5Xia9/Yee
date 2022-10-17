using Ability.Core.Models;

namespace Yee.Blog.Models
{
    public class BlogCategory : BaseRecord
    {
        public string Name { get; set; }
        public List<BlogItem> BlogItems { get; set; }
    }
}
