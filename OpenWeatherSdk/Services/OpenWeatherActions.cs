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
using Amazon.Lambda.APIGatewayEvents;
using System.Text.Json;
using System.Web;
using Microsoft.AspNetCore.WebUtilities;

namespace OpenWeatherSdk.Services
{
    public static class OpenWeatherActions
    {
        ///<summary>
        /// Get a short weather summary for a time range. Defaults to 2 days.
        /// </summary>
        /// <returns>Returns a ShortSummary datatype</returns>
        public static ShortSummaryResponse GetShortSummary()
        {
            ShortSummaryResponse response = new ShortSummaryResponse();
            // ---Get the Url from the config.json doc and validate the contents---
            string json = "";
            string dir = Directory.GetCurrentDirectory();
            using (StreamReader reader = new StreamReader("C:\\Projects\\GitHubRepos\\OpenWeatherSdk\\OpenWeatherSdk\\Resources\\config.json"))
            {
                json = reader.ReadToEnd();
            }
            dynamic urlValues = JObject.Parse(json);
            if(urlValues is null)
            {
                var errorResponse = new ShortSummaryResponse();
                errorResponse.ApiResponse = Models.Enums.ApiCallStatus.Error;
                errorResponse.Message = "The config file containing API Connection data is either missing or inaccessible at this time";
                return errorResponse;  

            }
            else if(!urlValues.ContainsKey("Connections"))
            {
                var errorResponse = new ShortSummaryResponse();
                errorResponse.ApiResponse= Models.Enums.ApiCallStatus.Error;   
                errorResponse.Message = "The URL for the Metar Summary resource is currently missing or unavailable at this time";
                return errorResponse;
            }
            else if(!urlValues.Connections.ContainsKey("MetarUrl"))
            {
                var errorResponse = new ShortSummaryResponse();
                errorResponse.ApiResponse = Models.Enums.ApiCallStatus.Error;
                errorResponse.Message = "The URL for the Metar Summary resource is currently missing or unavailable at this time";
                return errorResponse;
            }

            // ---Set up and execute the HttpClient---
            // --Build parameters--
            string baseUrl = urlValues["Connections"]["SummaryUrl"].ToString();
            DateTime startDate = DateTime.Now.AddDays(-2);
            DateTime endDate = DateTime.Now;
            var queryParams = new Dictionary<string, string>()
            {
                ["StartDate"] = startDate.ToShortDateString(),
                ["EndDate"] = endDate.ToShortDateString()
            };
            var query = QueryHelpers.AddQueryString(baseUrl, queryParams);

            // --Build and Execute the HttpClient--
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(query);
            var apiResponse = client.GetAsync(query).Result;
            string body = "";
            if (apiResponse.IsSuccessStatusCode)
                body = apiResponse.Content.ReadAsStringAsync().Result;
            else
            {
                var errorResponse = new ShortSummaryResponse();
                errorResponse.ApiResponse = Models.Enums.ApiCallStatus.Error;
                errorResponse.Message = "The API call was unable to get a response";
                return errorResponse;
            }

            // ---Parse the response into the usable model---
            var SummaryCollection = System.Text.Json.JsonSerializer.Deserialize<List<ShortSummary>>(body);
            if(SummaryCollection is null)
            {
                response.ApiResponse = Models.Enums.ApiCallStatus.NoResult;
            }
            else
            {
                response.ShortSummaryCollection = SummaryCollection;
                response.ApiResponse = Models.Enums.ApiCallStatus.Complete;
            }
            
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public static ShortSummaryResponse GetShortSummary(DateTime startDate, DateTime? endDate)
        {
            ShortSummaryResponse response = new ShortSummaryResponse();
            if (endDate is null)
                endDate = DateTime.Now;
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage();
            

            return response;
        }
    }
}
