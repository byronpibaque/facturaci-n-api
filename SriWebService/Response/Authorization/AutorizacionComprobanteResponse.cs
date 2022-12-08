using SRIIntegration.Response.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SRIIntegration.Response.Authorization
{
    [XmlRoot(ElementName = "autorizacionComprobanteResponse", Namespace = "http://ec.gob.sri.ws.autorizacion")]
    public class AutorizacionComprobanteResponse 
    {
        [XmlElement(ElementName = "RespuestaAutorizacionComprobante", Namespace = "")]
        public AuthorizationResponse RespuestaAutorizacionComprobante { get; set; }
        [XmlAttribute(AttributeName = "ns2")]
        public string Ns2 { get; set; }

        [XmlText]
        public string Text { get; set; }
    }
}
