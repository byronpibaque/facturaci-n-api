using System.Xml.Serialization;

namespace SRIIntegration.Response.Authorization
{
    [XmlRoot(ElementName = "RespuestaAutorizacionComprobante")]
    public class AuthorizationResponse
    {
        [XmlElement(ElementName = "claveAccesoConsultada")]
        public string ClaveAccesoConsultada { get; set; }

        [XmlElement(ElementName = "numeroComprobantes")]
        public int NumeroComprobantes { get; set; }

        [XmlArray(ElementName = "autorizaciones")]
        [XmlArrayItem(typeof(Authorization), ElementName = "autorizacion")]
        public List<Authorization> Authorizations { get; set; }
    }
}
