using System.Xml.Serialization;
using SRIIntegration.Response.Reception;

namespace SRIIntegration.Response.Common
{
    
    public class Envelope
    {
        [XmlAttribute(AttributeName = "soap")]
        public string Soap { get; set; }

        [XmlText]
        public string Text { get; set; }
    }
}
