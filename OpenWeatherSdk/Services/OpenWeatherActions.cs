using OpenWeatherSdk.Models;
using OpenWeatherSdk.Models.ApiCallResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using AWSSDK;
using Amazon.APIGateway;

namespace OpenWeatherSdk.Services
{
    public static class OpenWeatherActions
    {
        ///<summary>
        /// Get a short weather summary for a time range. Defaults to 2 days.
        /// </summary>
        /// <param name="StartDate">Date to start the search</param>
        /// <param name="EndDate">Date to end the search</param>
        /// <returns>Returns a ShortSummary datatype</returns>
        public static GetShortSummary GetShortSummary()
        {
            GetShortSummary response = new GetShortSummary();
            string json = "";
            using (StreamReader reader = new StreamReader("config.json"))
            {
                json = reader.ReadToEnd();
            }
            dynamic urlValues = JObject.Parse(json);
            if(urlValues is null)
            {
                var errorResponse = new GetShortSummary();
                errorResponse.ApiResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                errorResponse.ApiResponse.Headers.Add("Message", "The config file containing API Connection data is either missing or inaccessible at this time");
                return errorResponse;  

            }
            else if(!urlValues.ContainsKey("Connections"))
            {
                var errorResponse = new GetShortSummary();
                errorResponse.ApiResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                errorResponse.ApiResponse.Headers.Add("Message", "The URL for the Metar Summary resource is currently missing or unavailable at this time");
                return errorResponse;
            }
            else if(!urlValues.Connections.ContainsKey("MetarUrl"))
            {
                var errorResponse = new GetShortSummary();
                errorResponse.ApiResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                errorResponse.ApiResponse.Headers.Add("Message", "The URL for the Metar Summary resource is currently missing or unavailable at this time");
                return errorResponse;
            }
            string baseUrl = urlValues["Connections"]["MetarUrl"].ToString();

            Amazon.APIGateway.Api
            
            return response;
        }
        public static GetShortSummary GetShortSummary(DateTime startDate, DateTime? endDate)
        {
            GetShortSummary response = new GetShortSummary();
            if (endDate is null)
                endDate = DateTime.Now;
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage();
            

            return response;
        }
    }
}
