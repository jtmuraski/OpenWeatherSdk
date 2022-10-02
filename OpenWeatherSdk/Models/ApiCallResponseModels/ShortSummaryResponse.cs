using OpenWeatherSdk.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherSdk.Models.ApiCallResponseModels
{
    public class ShortSummaryResponse
    {
        public List<ShortSummary> ShortSummaryCollection {get; set;}
        public ApiCallStatus ApiResponse { get; set; }
        public string Message { get; set; }

    }
}
