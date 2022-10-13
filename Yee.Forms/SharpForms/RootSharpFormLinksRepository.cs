using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Yee.Abstractions;
using Yee.Forms.Abstractions;

namespace Yee.Forms.SharpForms
{
    public class RootSharpFormLinksRepository : ISharpFormLinksRepository
    {
        private readonly IRootOptions _rootOptions;
        private readonly List<RootSharpFormLink> _current;
        private const string TagFormLinks = "TagFormLinks";
        public RootSharpFormLinksRepository(IRootOptions rootOptions)
        {
            _rootOptions = rootOptions;
            _current = _rootOptions.Get<List<RootSharpFormLink>>(TagFormLinks);
            if(_current == null)
            {
                _current = new List<RootSharpFormLink>();
                _rootOptions.Set(TagFormLinks, _current);
            }
        }

        public void AddOrUpdate(SharpFormLink form)
        {
            _current.Add(new RootSharpFormLink(form.Type, form.Properties)
            {
                Id = form.Id
            });

            _rootOptions.Set(TagFormLinks, _current);
        }

        public Dictionary<Type, SharpFormLink> GetAllForms()
        {
            return _current
                .Where(p => p.Type != null)
                .ToDictionary(p => p.Type, p => (SharpFormLink)p);
        }


    }

    public class RootSharpFormLink: SharpFormLink
    {
        public RootSharpFormLink()
        {
        }

        public RootSharpFormLink(Type type, Dictionary<PropertyInfo, Guid> properties)
        {
            Type = type;
            Properties = properties;
        }

        [JsonIgnore]
        public override Type Type
        {
            get
            {
                return Type.GetType(TypeName);
            }
            set
            {
                TypeName = value.ToString();
            }
        }

        public string TypeName { get; set; }

        [JsonIgnore]
        public override Dictionary<PropertyInfo, Guid> Properties
        {
            get
            {
                return PropertyNames
                    .ToDictionary(p => Type.GetProperty(p.Key), p => p.Value);
            }
            set
            {
                PropertyNames = value
                    .ToDictionary(p => p.Key.Name, p => p.Value);
            }
        }

        public Dictionary<string, Guid> PropertyNames { get; set; }

    }
}
