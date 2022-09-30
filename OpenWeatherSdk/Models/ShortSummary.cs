using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherSdk.Models
{
    public class ShortSummary
    {
        public int Id { get; set; }
        public string StationId { get; set; }
        public DateTime ObservationTime { get; set; }
        public double TempC { get; set; }
        public double AltimeterInHg { get; set; }
        public double PrecipIn { get; set; }
    }
}