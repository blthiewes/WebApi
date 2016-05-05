using System.Collections.Generic;
using System.Xml.Serialization;

namespace RestfulApi.ServiceModel
{
    [XmlRoot("PagedCollection")]
    public class PagedCollection<T>
    {
        public List<T> Items { get; set; }

        public int Offset { get; set; }

        public int Limit { get; set; }

        public int Total { get; set; }
    }
}
