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

namespace OpenWeatherSdk.Services
{
    public static class OpenWeatherActions
    {
        ///<summary>
        /// Get a short weather summary for a time range. Defaults to 2 days.
        /// </summary>
        /// <returns>Returns a ShortSummary datatype</returns>
        public static GetShortSummary GetShortSummary()
        {
            GetShortSummary response = new GetShortSummary();
            // ---Get the Url from the config.json doc and validate the contents---
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

            // ---Set up and execute the HttpClient---
            string baseUrl = urlValues["Connections"]["SummaryUrl"].ToString();
            // TODO: Add the start and end date parameters
            //--------------------------------------------

            //--------------------------------------------
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseUrl);
            var apiResponse = client.GetAsync(baseUrl).Result;
            string body = "";
            if (apiResponse.IsSuccessStatusCode)
                body = apiResponse.Content.ReadAsStringAsync().Result;
            else
            {
                var errorResponse = new GetShortSummary();
                errorResponse.ApiResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                errorResponse.ApiResponse.Headers.Add("Message", "The API call was unable to get a response");
                return errorResponse;
            }

            // ---Parse the response into the usable model---
            var SummaryCollection = System.Text.Json.JsonSerializer.Deserialize<List<ShortSummary>>(body);
            response.ShortSummaryCollection = SummaryCollection;
            response.ApiResponse.StatusCode = System.Net.HttpStatusCode.OK;
            return response;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
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
