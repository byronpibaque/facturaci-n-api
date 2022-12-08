using System.Xml.Serialization;

namespace SRIIntegration.Response.Reception
{
    public class Voucher
    {
        [XmlElement("claveAcceso")]
        public string AccessKey { get; set; }

        [XmlArray(ElementName = "mensajes")]
        [XmlArrayItem(typeof(Message), ElementName = "mensaje")]
        public List<Message> Messages { get; set; }
    }
}
