using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SRIIntegration.Response.Common
{
    public class ComprobanteResponse
    {
        [XmlAttribute(AttributeName = "ns2")]
        public string Ns2 { get; set; }

        [XmlText]
        public string Text { get; set; }
    }
}
