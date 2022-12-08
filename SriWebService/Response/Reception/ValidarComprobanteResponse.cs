using SRIIntegration.Response.Common;
using System.Xml.Serialization;

namespace SRIIntegration.Response.Reception
{
    [XmlRoot(ElementName = "validarComprobanteResponse", Namespace = "http://ec.gob.sri.ws.recepcion")]
    public class ValidarComprobanteResponse
    {

        [XmlElement(ElementName = "RespuestaRecepcionComprobante", Namespace = "")]
        public ReceptionResponse RespuestaRecepcionComprobante { get; set; }

        [XmlAttribute(AttributeName = "ns2")]
        public string Ns2 { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

}
