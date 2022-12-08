using System.Xml.Serialization;

namespace SRIIntegration.Response.Reception
{
    [XmlRoot("RespuestaRecepcionComprobante")]
    public class ReceptionResponse
    {
        [XmlElement("estado")]
        public string Status { get; set; }

        [XmlArray(ElementName = "comprobantes")]
        [XmlArrayItem(typeof(Voucher), ElementName = "comprobante")]
        public List<Voucher> Vouchers { get; set; }
    }
}
