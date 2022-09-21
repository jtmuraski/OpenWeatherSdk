using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MetarAPI.Models.XmlModels
{
    [XmlRoot(ElementName = "Station")]
    public class Station
    {
        [XmlElement(ElementName = "station_id")]
        public string? StationId { get; set; }

        [XmlElement(ElementName = "wmo_id")]
        public string? WmoId { get; set; }

        [XmlElement(ElementName = "latitude")]
        public double Latitude { get; set; }

        [XmlElement(ElementName = "longtitude")]
        public double Longtitude { get; set; }

        [XmlElement(ElementName = "site")]
        public string? Site { get; set; }

        [XmlElement(ElementName = "state")]
        public string? State { get; set; }

        [XmlElement(ElementName = "country")]
        public string? Country { get; set; }

        [XmlElement(ElementName = "site_type")]
        [XmlText(typeof(string))]
        public List<string>? SiteType { get; set; }
    }
}
