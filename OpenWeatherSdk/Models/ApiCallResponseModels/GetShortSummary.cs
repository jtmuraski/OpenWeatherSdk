using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherSdk.Models.ApiCallResponseModels
{
    public class GetShortSummary
    {
        public List<ShortSummary> ShortSummaryCollection {get; set;}
        public HttpResponseMessage ApiResponse { get; set; }

    }
}
