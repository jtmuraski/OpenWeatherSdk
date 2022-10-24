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
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System.Reflection;
using OpenWeatherSdk.Models.Enums;

namespace OpenWeatherSdk.Services
{
    public static class OpenWeatherActions
    {
        private static EnvSettings env = EnvSettings.Production;
        /// <summary>
        /// Private function for the public functions to call the API URL after the date parameters have been established
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private static ShortSummaryResponse CallShortSummary(DateTime start, DateTime end)
        {
            ShortSummaryResponse response = new ShortSummaryResponse();
            // --Build the URL--
            Console.WriteLine("Building the URL...");
            string json = "";
            if (env == EnvSettings.Development)
            {
                using (StreamReader reader = new StreamReader("Resources\\config.json"))
                {
                    json = reader.ReadToEnd();
                }
            }
            else
            {
                var assembly = Assembly.GetCallingAssembly();
                Console.WriteLine(assembly.FullName.ToString());
                var resourceName = "OpenWeatherSdk.Resources.config.json";
                if (assembly.GetManifestResourceStream(resourceName) is null)
                {
                    Console.WriteLine("Assembly could not be found. Using hard JSON");
                    json = @"{
                              ""Connections"": {
                                ""SummaryUrl"": ""https://u8tivo4gja.execute-api.us-east-2.amazonaws.com/test/metar/shortsummary""
                                            }
                              }";
                }
                else
                {
                    Console.WriteLine("Assembly FOund. Accessign config.json now");
                    using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            json = reader.ReadToEnd();
                        }
                    }
                }
            }
            
            dynamic urlValues = JObject.Parse(json);
            if (urlValues is null)
            {
                var errorResponse = new ShortSummaryResponse();
                errorResponse.ApiResponse = Models.Enums.ApiCallStatus.Error;
                errorResponse.Message = "The config file containing API Connection data is either missing or inaccessible at this time";
                Console.WriteLine(errorResponse.Message);
                return errorResponse;

            }
            else if (!urlValues.ContainsKey("Connections"))
            {
                var errorResponse = new ShortSummaryResponse();
                errorResponse.ApiResponse = Models.Enums.ApiCallStatus.Error;
                errorResponse.Message = "The Connections group URL repo is currently missing or unavailable at this time";
                Console.WriteLine(errorResponse.Message);
                return errorResponse;
            }
            else if (!urlValues.Connections.ContainsKey("SummaryUrl"))
            {
                var errorResponse = new ShortSummaryResponse();
                errorResponse.ApiResponse = Models.Enums.ApiCallStatus.Error;
                errorResponse.Message = "The URL for the Metar Summary resource is currently missing or unavailable at this time";
                Console.WriteLine(errorResponse.Message);
                return errorResponse;
            }
            Console.WriteLine("The URL has been built");
            // --Build parameters--
            Console.WriteLine("Assigning parameter values");
            string baseUrl = urlValues["Connections"]["SummaryUrl"].ToString();
            var queryParams = new Dictionary<string, string>()
            {
                ["StartDate"] = start.ToShortDateString(),
                ["EndDate"] = end.ToShortDateString()
            };
            var query = QueryHelpers.AddQueryString(baseUrl, queryParams);
            Console.WriteLine("Parameters have been added");

            // --Build and Execute the HttpClient--
            Console.WriteLine("Calling the API");
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
            if (string.IsNullOrEmpty(body))
            {
                var nullResponse = new ShortSummaryResponse();
                nullResponse.ApiResponse = Models.Enums.ApiCallStatus.NoResult;
                nullResponse.Message = "The API returned a null result";
                Console.WriteLine(nullResponse.Message);
                return nullResponse;
            }
            Console.WriteLine("API has been queried");
            // ---Parse the response into the usable model---
            var SummaryCollection = System.Text.Json.JsonSerializer.Deserialize<List<ShortSummary>>(body);
            if (SummaryCollection is null)
            {
                response.ApiResponse = Models.Enums.ApiCallStatus.NoResult;
            }
            else
            {
                response.ShortSummaryCollection = SummaryCollection;
                response.ApiResponse = Models.Enums.ApiCallStatus.Complete;
                Console.WriteLine("Number of Results: " + SummaryCollection.Count);
            }
            return response;
        }
        ///<summary>
        /// Get a short weather summary for a time range. Defaults to 2 days.
        /// </summary>
        /// <returns>Returns a ShortSummary datatype</returns>
        public static ShortSummaryResponse GetShortSummary()
        {
            return CallShortSummary(DateTime.Now.AddDays(-2), DateTime.Now);
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
            DateTime end = new DateTime();
            if (endDate is null)
                end = DateTime.Now;
            else
                end = endDate??DateTime.Now;

            return CallShortSummary(startDate, end);
        }
    }
}
