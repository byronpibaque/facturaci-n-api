using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SRIIntegration.Response.Authorization
{
    [XmlRoot(ElementName = "autorizacion")]
    public class Authorization
    {

        [XmlElement(ElementName = "estado")]
        public string Estado { get; set; }

        [XmlElement(ElementName = "numeroAutorizacion")]
        public string NumeroAutorizacion { get; set; }

        [XmlElement(ElementName = "fechaAutorizacion")]
        public DateTime FechaAutorizacion { get; set; }

        [XmlElement(ElementName = "ambiente")]
        public string Ambiente { get; set; }

        [XmlElement(ElementName = "comprobante")]
        public string Comprobante { get; set; }

        [XmlElement(ElementName = "mensajes")]
        public object Mensajes { get; set; }
    }
}
