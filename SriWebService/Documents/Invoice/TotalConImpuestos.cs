using System.Xml.Serialization;

namespace SRIIntegration.Documents.Invoice
{
    [XmlRoot(ElementName = "totalConImpuestos")]
    public class TotalConImpuestos
    {
        [XmlElement(ElementName = "totalImpuesto")]
        public TotalImpuesto TotalImpuesto { get; set; }
    }
}
