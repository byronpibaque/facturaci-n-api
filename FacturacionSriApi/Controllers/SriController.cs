using System.Net;
using System.Text;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc;
using SRIIntegration.Response.Authorization;
using SRIIntegration.Response.Reception;
using SriWebService.SoapClient;

namespace FacturacionSriApi.Controllers
{
    [Route("api/sri")]
    [ApiController]
    public class SriController : ControllerBase
    {
        private readonly HttpClientConnection _clientReception;
        private readonly HttpClientConnection _clientAuthorization;

        public SriController()
        {
            _clientReception = new HttpClientConnection("https://celcer.sri.gob.ec/comprobantes-electronicos-ws");
            _clientAuthorization = new HttpClientConnection("https://celcer.sri.gob.ec/comprobantes-electronicos-ws");
        }

        [HttpPost("reception")]
        public async Task<IActionResult> Reception([FromBody] string xmlFilePath)
        {
            try
            {
                string xmlContent = System.IO.File.ReadAllText(xmlFilePath);

                string base64XmlInvoice = Convert.ToBase64String(Encoding.UTF8.GetBytes(xmlContent));

                string strContent = GetReceptionSoap(base64XmlInvoice);

                var response = await _clientReception.PostRequest("/RecepcionComprobantesOffline?wsdl", strContent);
                string contentResponse = await response.Content.ReadAsStringAsync();

                XmlSerializer serializer = new XmlSerializer(typeof(ReceptionEnvelope));
                ReceptionEnvelope test;
                using (StringReader reader = new StringReader(contentResponse))
                {
                    test = (ReceptionEnvelope)serializer.Deserialize(reader)!;
                }

                if (response.StatusCode == HttpStatusCode.OK && test != null)
                {
                    return Ok(test);
                }

                return StatusCode((int)response.StatusCode, contentResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al procesar el archivo XML: {ex.Message}");
            }
        }

        [HttpPost("authorization")]
        public async Task<IActionResult> Authorization([FromBody] string accessKey)
        {
            try
            {
                string strContent = GetAuthorizationSoap(accessKey);

                var response = await _clientAuthorization.PostRequest("/AutorizacionComprobantesOffline", strContent);
                string contentResponse = await response.Content.ReadAsStringAsync();

                XmlSerializer serializer = new XmlSerializer(typeof(AuthorizationEnvelope));
                AuthorizationEnvelope test;
                using (StringReader reader = new StringReader(contentResponse))
                {
                    test = (AuthorizationEnvelope)serializer.Deserialize(reader)!;
                }

                if (response.StatusCode == HttpStatusCode.OK && test != null)
                {
                    return Ok(test);
                }

                return StatusCode((int)response.StatusCode, contentResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al procesar la clave de acceso: {ex.Message}");
            }
        }

        private string GetReceptionSoap(string base64XML)
        {
            string soapXML = $@"
                <soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/""
                                  xmlns:ec=""http://ec.gob.sri.ws.recepcion"">
                    <soapenv:Header/>
                    <soapenv:Body>
                        <ec:validarComprobante>
                            <xml>{base64XML}</xml>
                        </ec:validarComprobante>
                    </soapenv:Body>
                </soapenv:Envelope>";
            return soapXML;
        }

        private string GetAuthorizationSoap(string accessKey)
        {
            string soapXML = $@"
                <soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/""
                                  xmlns:ec=""http://ec.gob.sri.ws.autorizacion"">
                    <soapenv:Header/>
                    <soapenv:Body>
                        <ec:autorizacionComprobante>
                            <claveAccesoComprobante>{accessKey}</claveAccesoComprobante>
                        </ec:autorizacionComprobante>
                    </soapenv:Body>
                </soapenv:Envelope>";
            return soapXML;
        }
    }
}
