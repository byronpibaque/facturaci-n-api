using System.Xml.Serialization;

namespace SRIIntegration.Documents.Invoice
{
    [XmlRoot(ElementName = "detalles")]
    public class Detalles
    {
        [XmlElement(ElementName = "detalle")]
        public Detalle Detalle { get; set; }
    }
}
