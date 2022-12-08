using System.Xml.Serialization;

namespace SRIIntegration.Documents.Invoice
{
    [XmlRoot(ElementName = "campoAdicional")]
    public class CampoAdicional
    {
        [XmlAttribute(AttributeName = "nombre")]
        public string Nombre { get; set; }
        [XmlText]
        public string Text { get; set; }
    }
}
