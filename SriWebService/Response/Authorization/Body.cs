using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SRIIntegration.Response.Authorization
{
    [XmlRoot(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public class Body
    {
        [XmlElement(ElementName = "autorizacionComprobanteResponse", Namespace = "http://ec.gob.sri.ws.autorizacion")]
        public AutorizacionComprobanteResponse AutorizacionComprobanteResponse { get; set; }
    }
}
