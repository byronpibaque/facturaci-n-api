using System.Xml.Serialization;

namespace SRIIntegration.Documents.Invoice
{
    [XmlRoot(ElementName = "infoAdicional")]
    public class InfoAdicional
    {
        [XmlElement(ElementName = "campoAdicional")]
        public List<CampoAdicional> CampoAdicional { get; set; }
    }
}
