using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MetarAPI.Models.XmlModels
{
    [XmlRoot(ElementName = "response")]
    public class Response
    {

        [XmlElement(ElementName = "request_index")]
        public int? RequestIndex { get; set; }

        [XmlElement(ElementName = "data_source")]
        public DataSource? DataSource { get; set; }

        [XmlElement(ElementName = "request")]
        public Request? Request { get; set; }

        [XmlElement(ElementName = "errors")]
        public object? Errors { get; set; }

        [XmlElement(ElementName = "warnings")]
        public object? Warnings { get; set; }

        [XmlElement(ElementName = "time_taken_ms")]
        public int TimeTakenMs { get; set; }

        [XmlElement(ElementName = "data")]
        public Data? Data { get; set; }

        [XmlAttribute(AttributeName = "xsd")]
        public string? Xsd { get; set; }

        [XmlAttribute(AttributeName = "xsi")]
        public string? Xsi { get; set; }

        [XmlAttribute(AttributeName = "version")]
        public string? Version { get; set; }

        [XmlAttribute(AttributeName = "noNamespaceSchemaLocation")]
        public string? NoNamespaceSchemaLocation { get; set; }

        [XmlText]
        public string? Text { get; set; }
    }
}
