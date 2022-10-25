using Ability.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Yee.Page.Models
{
    public class YeeComponentValues : BaseRecord
    {

        public YeeComponentValues()
        {
            Id = Guid.NewGuid();
            Childs = new List<YeeComponentValues>();
        }

        [Column(TypeName = "jsonb")]
        public YeeCSharpLink ComponentRef { get; set; }

        public List<YeeProperty> Properties { get; set; }

        public List<YeePage> Pages { get; set; }

        public bool IsHeader { get; set; }

        public Guid? ParentId { get; set; }

        public bool IsFlexable { get; set; }

        [Column(TypeName = "jsonb")]
        public FlexOptions FlexOptions { get; set; }
        public YeeComponentValues Parent { get; set; }
        public List<YeeComponentValues> Childs { get; set; }

        public int Order { get; set; }
        public Dictionary<string, JObject> ToDictionary()
        {
            return Properties?.ToDictionary(p => p.Property, p => Newtonsoft.Json.Linq.JObject.Parse(p.YeePropertyValue.Value));
        }
    }

    public class FlexOptions
    {

        public FlexOptions()
        {

        }

        public FlexOptions(Guid idMainComponent)
        {
            var id = Guid.NewGuid();
            FlexRows = new List<FlexRow>
            {
                new FlexRow
                {
                    Gutter = 0,
                    Cols = new List<FlexCol>
                    {
                        new FlexCol
                        {
                            Guid = id,
                            Span = 24
                        }
                    }
                },
            };
            Values = new List<FlexValue>
            {
                new FlexValue
                {
                    ComponentId = idMainComponent,
                    ColId = id
                }
            };
            MainColId = id;
        }

        public Guid MainColId { get; set; }
        public List<FlexRow> FlexRows { get; set; }

        public List<FlexValue> Values { get; set; }
    }

    public class FlexValue
    {
        public Guid ColId { get; set; }
        public Guid ComponentId { get; set; }
    }

    public class FlexRow
    {
        public int Gutter { get; set; }   
        public List<FlexCol> Cols { get; set; }
    }

    public class FlexCol
    {
        public Guid Guid { get; set; }
        public int Span { get; set; }
        public static readonly int MaxSpanSum = 24;

        //public long? ComponentId { get; set; }
    }


}
