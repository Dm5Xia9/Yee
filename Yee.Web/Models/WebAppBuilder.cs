using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Yee.Web.Models
{
    public class WebAppBuilder
    {
        internal Assembly Assembly { get; set; }
        public WebAppBuilder()
        {
            StaticFiles = new List<WebStaticFile>();
            Routers = new List<Type>();
            RootComponents = new List<Type>();
            HeadComponents = new List<Type>();
            FooterComponents = new List<Type>();
            PossibleHeadComponent = new List<Type>();
        }

        public List<WebStaticFile> StaticFiles { get; set; }
        public List<Type> Routers { get; set; }
        public List<Type> RootComponents { get; set; }
        public List<Type> HeadComponents { get; set; }
        public List<Type> FooterComponents { get; set; }

        public List<Type> PossibleHeadComponent { get; set; }
        public WebAppBuilder AddScript(string uri, bool asStandart = false)
        {
            StaticFiles.Add(new WebStaticFile
            {
                StaticFileType = StaticFileType.Sctipt,
                Uri = uri,
                AsStandard = asStandart,
            });

            return this;
        }

        //public WebAppBuilder AddStyle(string uri)
        //{
        //    StaticFiles.Add(new WebStaticFile
        //    {
        //        StaticFileType = StaticFileType.Style,
        //        Uri = uri,
        //    });

        //    return this;
        //}

        public WebAppBuilder AddRouter(Type type)
        {
            Routers.Add(type);

            return this;
        }

        public WebAppBuilder AddHead(Type type)
        {
            HeadComponents.Add(type);

            return this;
        }

        public WebAppBuilder AddFooter(Type type)
        {
            FooterComponents.Add(type);

            return this;
        }


        public WebAppBuilder AddRootComponent(Type type)
        {
            RootComponents.Add(type);

            return this;
        }
    }

    public class WebStaticFile
    {
        public bool AsStandard { get; set; }
        public string Uri { get; set; }
        public StaticFileType StaticFileType { get; set; }
    }
    public enum StaticFileType
    {
        Sctipt,
        Style
    }
}
