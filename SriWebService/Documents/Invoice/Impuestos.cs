using System.Xml.Serialization;

namespace SRIIntegration.Documents.Invoice
{
    [XmlRoot(ElementName = "impuestos")]
    public class Impuestos
    {
        [XmlElement(ElementName = "impuesto")]
        public Impuesto Impuesto { get; set; }
    }
}
