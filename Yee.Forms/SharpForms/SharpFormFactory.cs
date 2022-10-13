using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Yee.Forms.Abstractions;
using Yee.Forms.Attributes;

namespace Yee.Forms.SharpForms
{
    public class SharpFormFactory : ISharpFormFactory
    {
        private readonly ISharpFormLinksRepository _sharpFormLinksProvider;
        private readonly Dictionary<Type, SharpFormLink> _currentLinks;
        private readonly Dictionary<Type, SharpForm> _cacheForms 
            = new Dictionary<Type, SharpForm>();
        public SharpFormFactory(CombineFormLinksRepository sharpFormLinksProvider)
        {
            _sharpFormLinksProvider = sharpFormLinksProvider;
            _currentLinks = _sharpFormLinksProvider.GetAllForms();
        }

        public SharpForm Create(Type type)
        {
            if (_cacheForms.ContainsKey(type))
                return _cacheForms[type];

            var isAddOrUpdate = false;
            SharpFormLink link;
            if (_currentLinks.ContainsKey(type))
                link = _currentLinks[type];
            else
            {
                link = new SharpFormLink
                {
                    Type = type,
                    Id = Guid.NewGuid(),
                    Properties = new Dictionary<PropertyInfo, Guid>()
                };
                isAddOrUpdate = true;
            }

            var form = new SharpForm();
            form.Type = type;

            form.DebugName = type
                 .GetCustomAttribute<DebugFormAttribute>()?.FriendlyName;

            form.Attributes = Attribute
                .GetCustomAttributes(type)
                .ToList();

            form.DisplayName = type
                .GetCustomAttribute<DisplayNameAttribute>()?.DisplayName ?? type.Name;

            form.Id = link.Id;

            form.Method = type
                .GetCustomAttribute<FormMethodAttribute>()?.Method ?? HttpConst.GET;

            form.Args = new List<YeeFormArg>();
            var props = type.GetProperties();
            foreach(var prop in props)
            {
                Guid propId;
                if (link.Properties.ContainsKey(prop))
                    propId = link.Properties[prop];
                else
                {
                    propId = Guid.NewGuid();
                    link.Properties.Add(prop, propId);
                    isAddOrUpdate = true;
                }
                var arg = new SharpFormArg();
                arg.Property = prop;
                arg.Type = prop.PropertyType;
                arg.DisplayName = prop
                    .GetCustomAttribute<DisplayNameAttribute>()?.DisplayName ?? prop.Name;

                arg.Required = prop.GetCustomAttribute<RequiredAttribute>() != null;

                arg.Id = propId;
                arg.Key = prop.Name;
                form.Args.Add(arg);
            }
            _cacheForms.Add(type, form);

            if (isAddOrUpdate)
            {
                _sharpFormLinksProvider.AddOrUpdate(link);
            }

            return form;
        }

 
    }
}
