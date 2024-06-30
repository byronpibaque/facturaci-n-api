using System.Text;

namespace SriWebService.SoapClient
{
    public class HttpClientConnection
    {
        private readonly HttpClient _client;
        private readonly string _urlEndpoint;

        public HttpClientConnection(string endpointUrl)
        {
            _client = new HttpClient();
            _urlEndpoint = endpointUrl;
        }

        public async Task<HttpResponseMessage> PostRequest(string path, string xmlContent)
        {
            try
            {
                // Construir la URL completa para la solicitud
                string requestUrl = _urlEndpoint.TrimEnd('/') + "/" + path.TrimStart('/');

                // Configurar la solicitud HTTP POST
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, requestUrl);
                request.Content = new StringContent(xmlContent, Encoding.UTF8, "text/xml");

                // Enviar la solicitud HTTP y obtener la respuesta
                HttpResponseMessage response = await _client.SendAsync(request);

                return response;
            }
            catch (Exception ex)
            {
                // Manejar cualquier error de manera adecuada
                throw new HttpRequestException($"Error al enviar solicitud HTTP POST: {ex.Message}", ex);
            }
        }
    }
}