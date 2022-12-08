using System.Text;

namespace SRIIntegration.SoapClient
{
    public class HttpClientConnection
    {
        private readonly HttpClient _client;
        private string UrlEndpoint;
        public HttpClientConnection(string endpointUrl)
        {
            _client= new HttpClient();
            UrlEndpoint = endpointUrl;
        }

        public async Task<HttpResponseMessage> PostRequest(string path, object body)
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(UrlEndpoint + path)
            };
            requestMessage.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("text/xml"));
            string strContent = (string)body;
            StringContent content = new StringContent(strContent, Encoding.UTF8, "text/xml");
            requestMessage.Content = content; 
            HttpResponseMessage response = await _client.SendAsync(requestMessage);
            return response;
        }
    }
}
