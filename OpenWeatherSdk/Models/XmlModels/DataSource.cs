using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MetarAPI.Models.XmlModels
{
    [XmlRoot(ElementName = "data_source")]
    public class DataSource
    {

        [XmlAttribute(AttributeName = "name")]
        public string? Name { get; set; }
    }
}
