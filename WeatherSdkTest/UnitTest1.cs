using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenWeatherSdk.Services;
using OpenWeatherSdk.Models.ApiCallResponseModels;

namespace WeatherSdkTest
{
    [TestClass]
    public class TestWeatherSummary
    {
        [TestMethod]
        public void SummaryNoArguments()
        {
            // ---Arrange---
            // NA

            // ---Act---
            ShortSummaryResponse test = OpenWeatherActions.GetShortSummary();
           

            // ---Assert---
            Assert.AreEqual(OpenWeatherSdk.Models.Enums.ApiCallStatus.NoResult, test.ApiResponse, test.Message);
            


        }

        [TestMethod]
        public void SummaryWithArguments()
        {
            // ---Arrange---
            // N/A

            // ---Act---
            ShortSummaryResponse dateTest = OpenWeatherActions.GetShortSummary(new System.DateTime(2022, 08, 01), new System.DateTime(2022, 08, 02));

            // ---Assert---
            Assert.AreEqual(OpenWeatherSdk.Models.Enums.ApiCallStatus.Complete, dateTest.ApiResponse, dateTest.Message);
        }
    }
}