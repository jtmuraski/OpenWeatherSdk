using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetarAPI.Models.DataModels;
using MetarAPI.Models.XmlModels;
using System.Xml.Serialization;
using System.IO;

namespace MetarAPI.Actions
{
    public static class Parser
    {
        // <summary>
        // This class proived the necessary methods to parse data received from NOAA from XML to the objects in the Models/DataModels folder
        // </summary>

        ///<summary>
        ///Take the Response object generated when serializing the XML response into a List of Metar objects for use in EF.
        ///</summary>
        public static List<Metar> ParseResponseToMetar(Response response)
        {
            List<Metar> MetarCollection = new List<Metar>();
            if(response is null)
            {
                return MetarCollection;
            }
            else if(response.Data is null)
            {
                return MetarCollection;
            }
            else if(response.Data.METAR is null)
            {
                return MetarCollection;
            }
            foreach (var data in response.Data.METAR)
            {
                List<Models.DataModels.SkyCondition> skyConditions = new List<Models.DataModels.SkyCondition>();
                if (data.SkyCondition is not null)
                {
                    foreach (var sky in data.SkyCondition)
                    {
                        skyConditions.Add(new Models.DataModels.SkyCondition()
                        {
                            CloudBaseFtAng = sky.CloudBaseFtAgl,
                            SkyCover = sky.SkyCover
                        });
                    }
                }
               
                List<Models.DataModels.QualityFlags> qualityControl = new List<Models.DataModels.QualityFlags>();
                if(data.QualityControlFlags is not null)
                {
                    foreach (var qual in data.QualityControlFlags)
                    {
                        qualityControl.Add(new Models.DataModels.QualityFlags()
                        {
                            AutoStation = qual.AutoStation
                        });
                    }
                }
             
                MetarCollection.Add(new Metar()
                {
                    RawText = data.RawText,
                    StationId = data.StationId,
                    ObservationTime = data.ObservationTime,
                    Latitude = data.Latitude,
                    Longtitude = data.Longitude,
                    TempC = data.TempC,
                    DewPointC = data.DewpointC,
                    WindDirDegree = data.WindDirDegrees,
                    WindSpeedKnots = data.WindSpeedKt,
                    VisibilityStatuteMi = data.VisibilityStatuteMi,
                    AltimeterInHg = data.AltimInHg,
                    SeaLevelPressureMb = data.SeaLevelPressureMb,
                    QualityControlFlags = qualityControl,
                    SkyConditions = skyConditions,
                    FlightCategory = data.FlightCategory,
                    ThreeHrPressureTEndencyMb = data.ThreeHrPressureTendencyMb,
                    MaxTC = data.MaxTC,
                    MinTC = data.MinTC,
                    PrecipIn = data.PrecipIn,
                    Pcp6hrIn = data.Pcp6hrIn,
                    MetarType = data.MetarType,
                    ElevationM = data.ElevationM
                });
            }

            return MetarCollection;
        }

        ///<summary>
        ///Deserialize the XML response from the NOAA API into the Response model
        /// </summary>
        public static Response DerserializeXml(string xml)
        {
            Response response;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Response));
            using (StringReader reader = new StringReader(xml))
            {
                response = (Response)xmlSerializer.Deserialize(reader);
            }

            return response;
        }

        ///<summary>
        ///UNDER DEVELOPMENT. Take a raw METAR string and parse it into a METAR type
        /// </summary>
        public static Metar ParseRawMetar(string rawMetar)
        {
            Metar metar = new Metar();
            return metar;
        }
    }
}
