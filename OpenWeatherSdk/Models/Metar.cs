using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetarAPI.Models.XmlModels;

namespace MetarAPI.Models.DataModels
{
    public class Metar
    {
        public int Id { get; set; }
        public string? RawText { get; set; }
        public string? StationId { get; set; }
        public DateTime ObservationTime { get; set; }
        public double Latitude { get; set; }
        public double Longtitude { get; set; }
        public double TempC { get; set; }
        public double DewPointC { get; set; }
        public int WindDirDegree { get; set; }
        public int WindSpeedKnots { get; set; }
        public double VisibilityStatuteMi { get; set; }
        public double AltimeterInHg { get; set; }
        public decimal SeaLevelPressureMb { get; set; }
        public List<QualityFlags>? QualityControlFlags { get; set; }
        public List<SkyCondition>? SkyConditions { get; set; }
        public string? FlightCategory { get; set; }
        public double ThreeHrPressureTEndencyMb { get; set; }
        public decimal MaxTC { get; set; }
        public decimal MinTC { get; set; }
        public double PrecipIn { get; set; }
        public double Pcp6hrIn { get; set; }
        public string? MetarType { get; set; }
        public double ElevationM { get; set; }
    }
}
