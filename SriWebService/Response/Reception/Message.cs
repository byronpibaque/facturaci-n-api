using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SRIIntegration.Response.Reception
{
    public class Message
    {
        [XmlElement("identificador")]
        public string Identifier { get; set; }

        [XmlElement("mensaje")]
        public string message { get; set; }

        [XmlElement("informacionAdicional")]
        public string AdditionalInformation { get; set; }

        [XmlElement("tipo")]
        public string Type { get; set; }
    }
}
