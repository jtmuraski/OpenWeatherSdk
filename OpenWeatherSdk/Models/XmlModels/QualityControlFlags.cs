using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MetarAPI.Models.XmlModels
{
    [XmlRoot(ElementName = "quality_control_flags")]
    public class QualityControlFlags
    {

        [XmlElement(ElementName = "auto_station")]
        public string? AutoStation { get; set; }
    }
}
