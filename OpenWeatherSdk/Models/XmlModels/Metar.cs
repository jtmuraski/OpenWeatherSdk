using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MetarAPI.Models.XmlModels
{
    [XmlRoot(ElementName = "METAR")]
    public class METAR
    {

        [XmlElement(ElementName = "sky_condition")]
        public List<SkyCondition>? SkyCondition { get; set; }

        [XmlElement(ElementName = "flight_category")]
        public string? FlightCategory { get; set; }

        [XmlElement(ElementName = "three_hr_pressure_tendency_mb")]
        public double ThreeHrPressureTendencyMb { get; set; }

        [XmlElement(ElementName = "maxT_c")]
        public decimal MaxTC { get; set; }

        [XmlElement(ElementName = "minT_c")]
        public decimal MinTC { get; set; }

        [XmlElement(ElementName = "precip_in")]
        public double PrecipIn { get; set; }

        [XmlElement(ElementName = "pcp6hr_in")]
        public double Pcp6hrIn { get; set; }

        [XmlElement(ElementName = "metar_type")]
        public string? MetarType { get; set; }

        [XmlElement(ElementName = "elevation_m")]
        public double ElevationM { get; set; }

        [XmlElement(ElementName = "raw_text")]
        public string? RawText { get; set; }

        [XmlElement(ElementName = "station_id")]
        public string? StationId { get; set; }

        [XmlElement(ElementName = "observation_time")]
        public DateTime ObservationTime { get; set; }

        [XmlElement(ElementName = "latitude")]
        public double Latitude { get; set; }

        [XmlElement(ElementName = "longitude")]
        public double Longitude { get; set; }

        [XmlElement(ElementName = "temp_c")]
        public double TempC { get; set; }

        [XmlElement(ElementName = "dewpoint_c")]
        public double DewpointC { get; set; }

        [XmlElement(ElementName = "wind_dir_degrees")]
        public int WindDirDegrees { get; set; }

        [XmlElement(ElementName = "wind_speed_kt")]
        public int WindSpeedKt { get; set; }

        [XmlElement(ElementName = "visibility_statute_mi")]
        public double VisibilityStatuteMi { get; set; }

        [XmlElement(ElementName = "altim_in_hg")]
        public double AltimInHg { get; set; }

        [XmlElement(ElementName = "sea_level_pressure_mb")]
        public decimal SeaLevelPressureMb { get; set; }

        [XmlElement(ElementName = "quality_control_flags")]
        public List<QualityControlFlags>? QualityControlFlags { get; set; }
    }
}
