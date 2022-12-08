using System.Xml.Serialization;

namespace SRIIntegration.Response.Reception
{
    [XmlRoot(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public class Body
    {

        [XmlElement(ElementName = "validarComprobanteResponse", Namespace = "http://ec.gob.sri.ws.recepcion")]
        public ValidarComprobanteResponse ValidarComprobanteResponse { get; set; }
    }
}
