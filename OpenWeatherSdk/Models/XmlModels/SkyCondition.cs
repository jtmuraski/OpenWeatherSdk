using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MetarAPI.Models.XmlModels
{
    [XmlRoot(ElementName = "sky_condition")]
    public class SkyCondition
    {

        [XmlAttribute(AttributeName = "sky_cover")]
        public string? SkyCover { get; set; }

        [XmlAttribute(AttributeName = "cloud_base_ft_agl")]
        public int CloudBaseFtAgl { get; set; }
    }
}
