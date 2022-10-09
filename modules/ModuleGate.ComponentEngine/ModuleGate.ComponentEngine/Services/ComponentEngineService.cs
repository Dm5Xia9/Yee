using Microsoft.AspNetCore.Components;
using ModuleGate.ComponentEngine.Components;
using ModuleGate.ComponentEngine.Components.DomElements;
using ModuleGate.ComponentEngine.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleGate.ComponentEngine.Services
{
    public class ComponentEngineService : IComponentEngineService
    {
        public RenderFragment GetPage()
        {
            var segment = new Segment();
            var list = new ElementsList();
            var element = new ListItem { Attributes = new Dictionary<string, string> { { "class", "el1" } }, InnerHtml = "<div>el1</div>" };
            var element1 = new ListItem { Attributes = new Dictionary<string, string> { { "class", "el2" } }, InnerHtml = "<div>el2</div>" };
            var element2 = new ListItem { Attributes = new Dictionary<string, string> { { "class", "el3" } }, InnerHtml = "<div>el3</div>" };
            list.Childs.Add(GetRenderFragment(element));
            list.Childs.Add(GetRenderFragment(element1));
            list.Childs.Add(GetRenderFragment(element2));
            segment.Childs.Add(GetRenderFragment(list));
            return GetRenderFragment(segment);
        }

        private RenderFragment GetRenderFragment(BaseDomElement item)
        {
            if (item == null)
                return null;
            var type = item.GetType();
            if (type == null)
                return null;
            var parameters = type.GetProperties()
                //.Where(p => p.GetCustomAttributes(true).Any(a => a.GetType() is ParameterAttribute))
                .ToDictionary(k => k.Name, v => v.GetValue(item));
            //var parameters = new Dictionary<string, object>
            //{
            //    { nameof(BaseDomElement.Name), item.Name },
            //    { nameof(BaseDomElement.Attributes), item.Attributes },
            //    { nameof(BaseDomElement.Childs), item.Childs }
            //};
            RenderFragment result = b =>
            {
                b.OpenComponent(1, type);
                foreach (var param in parameters)
                    b.AddAttribute(1, param.Key, param.Value);
                b.CloseComponent();
            };
            return result;
        }

        //private RenderFragment GetInnerHtml(string html)
        //{
            
        //}
    }
}
