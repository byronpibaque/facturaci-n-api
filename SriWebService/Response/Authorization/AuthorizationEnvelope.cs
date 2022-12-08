using SRIIntegration.Response.Common;
using System.Xml.Serialization;

namespace SRIIntegration.Response.Authorization
{
    [XmlRoot(ElementName = "Envelope", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public class AuthorizationEnvelope
    {
        [XmlElement(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        public Body Body { get; set; }

        [XmlAttribute(AttributeName = "soap")]
        public string Soap { get; set; }

        [XmlText]
        public string Text { get; set; }
    }
}
