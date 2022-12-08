using System.Xml.Serialization;

namespace SRIIntegration.Documents.Invoice
{
    [XmlRoot(ElementName = "pagos")]
    public class Pagos
    {
        [XmlElement(ElementName = "pago")]
        public Pago Pago { get; set; }
    }
}
