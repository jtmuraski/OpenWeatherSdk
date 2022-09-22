using OpenWeatherSdk.Models;
using OpenWeatherSdk.Models.ApiCallResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherSdk.Services
{
    public static class OpenWeatherActions
    {
        private string _url = "aws.com";
        ///<summary>
        /// Get a short weather summary for a time range. Defaults to 2 days.
        /// </summary>
        /// <param name="StartDate">Date to start the search</param>
        /// <param name="EndDate">Date to end the search</param>
        /// <returns>Returns a ShortSummary datatype</returns>
        public static GetShortSummary GetShortSummary()
        {
            GetShortSummary response = new GetShortSummary();

            return response;
        }

        public static GetShortSummary GetShortSummary(DateTime startDate, DateTime? endDate)
        {
            GetShortSummary response = new GetShortSummary();
            if (endDate is null)
                endDate = DateTime.Now;
            HttpClient client = new HttpClient();
            client.BaseAddress = _url;
            HttpRequestMessage request = new HttpRequestMessage();
            

            return response;
        }
    }
}
