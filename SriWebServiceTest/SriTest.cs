using SRIIntegration.Response.Authorization;
using SRIIntegration.Response.Reception;
using SRIIntegration.SoapClient;
using System.Net;
using System.Xml.Serialization;

namespace SriWebServiceTest
{
    public class SriTest
    {
        [Fact]
        public void ReceptionTest()
        {
            //Arrange
            string url = "https://celcer.sri.gob.ec/comprobantes-electronicos-ws";
            string path = "/RecepcionComprobantesOffline?wsdl";
            HttpClientConnection client = new HttpClientConnection(url);

            string base64XmlInvoice = "PD94bWwgdmVyc2lvbj0iIjEuMCIiIGVuY29kaW5nPSIidXRmLTgiIj8................"; //Factura en base64
            string strContent = GetReceptionSoap(base64XmlInvoice);

            //Act
            var response = client.PostRequest(path, strContent).Result;
            string contentResponse = response.Content.ReadAsStringAsync().Result;

            XmlSerializer serializer = new XmlSerializer(typeof(ReceptionEnvelope));
            ReceptionEnvelope test;
            using (StringReader reader = new StringReader(contentResponse))
            {
                test = (ReceptionEnvelope)serializer.Deserialize(reader)!;
            }

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(test);
        }

        [Fact]
        public void AuthorizationTest()
        {
            //Arrange
            string url = "https://celcer.sri.gob.ec/comprobantes-electronicos-ws";
            string path = "/AutorizacionComprobantesOffline";
            HttpClientConnection client = new HttpClientConnection(url);

            string accessKey = "0512202201110214395200110010010000000100000000113"; //cambiar accessKey por una valida
            string strContent = GetAuthorizationSoap(accessKey);
            
            //Act
            var response = client.PostRequest(path, strContent).Result;
            string contentResponse = response.Content.ReadAsStringAsync().Result;

            XmlSerializer serializer = new XmlSerializer(typeof(AuthorizationEnvelope));
            AuthorizationEnvelope test;
            using (StringReader reader = new StringReader(contentResponse))
            {
                test = (AuthorizationEnvelope)serializer.Deserialize(reader)!;
            }

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(test);
        }


        private string GetReceptionSoap(string base64XML)
        {
            string soapXML = @"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:ec=""http://ec.gob.sri.ws.recepcion"">
                <soapenv:Header/>
                <soapenv:Body>
                <ec:validarComprobante>
                <!--Optional:-->
                <xml>" + base64XML + @"</xml>
             </ec:validarComprobante>
            </soapenv:Body>
            </soapenv:Envelope>";
            return soapXML;
        }

        private string GetAuthorizationSoap(string accessKey)
        {
            string soapXML = @"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:ec=""http://ec.gob.sri.ws.autorizacion"">
                                   <soapenv:Header/>
                                   <soapenv:Body>
                                      <ec:autorizacionComprobante>
                                         <!--Optional:-->
                                         <claveAccesoComprobante>" + accessKey + @"</claveAccesoComprobante>
                                      </ec:autorizacionComprobante>
                                   </soapenv:Body>
                                </soapenv:Envelope>";
            return soapXML;
        }
    }
}