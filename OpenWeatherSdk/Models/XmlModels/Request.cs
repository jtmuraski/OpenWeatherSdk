using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MetarAPI.Models.XmlModels
{
    [XmlRoot(ElementName = "request")]
    public class Request
    {

        [XmlAttribute(AttributeName = "type")]
        public string? Type { get; set; }
    }
}
