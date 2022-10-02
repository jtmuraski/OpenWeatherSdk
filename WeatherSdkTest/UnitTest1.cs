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
            // Arrange
            // NA

            // Act
            ShortSummaryResponse test = OpenWeatherActions.GetShortSummary();

            // Assert
            Assert.AreEqual(OpenWeatherSdk.Models.Enums.ApiCallStatus.NoResult, test.ApiResponse, test.Message);


        }
    }
}