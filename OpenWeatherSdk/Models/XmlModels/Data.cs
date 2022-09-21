using static System.Collections.Specialized.BitVector32;
using System.Diagnostics.Metrics;
using System.Xml.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetarAPI.Models.XmlModels
{
    [XmlRoot(ElementName = "data")]
    public class Data
    {

        [XmlElement(ElementName = "METAR")]
        public List<METAR>? METAR { get; set; }

        [XmlElement(ElementName = "Station")]
        public List<Station>? Stations { get; set; }

        [XmlAttribute(AttributeName = "num_results")]
        public int NumResults { get; set; }

        [XmlText]
        public string? Text { get; set; }
    }
}