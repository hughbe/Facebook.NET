using Newtonsoft.Json;
using System.Net.Http;
using System.Security.Authentication;

namespace Facebook.Models
{
    internal class GraphPagedResponse<T> : PagedResponse<T>
    {
        public GraphPagedResponse(int pageNumber, int pageSize) : base(pageNumber, pageSize) { }

        private string RequestUrl { get; set; }

        [JsonProperty]
        private Paging Paging { get; set; }

        public override PagedResponse<T> PreviousPage()
        {
            // Nothing before.
            if (Paging?.Previous == null)
            {
                return null;
            }

            return ExecuteRequest(Paging?.Previous);
        }

        public override PagedResponse<T> NextPage()
        {
            // Nothing after.
            if (RequestUrl == null)
            {
                return null;
            }

            return ExecuteRequest(RequestUrl);
        }

        internal static GraphPagedResponse<T> ExecuteRequest(string requestUrl)
        {
            var httpHandler = new WinHttpHandler { SslProtocols = SslProtocols.Tls12 };

            using (HttpClient client = new HttpClient(httpHandler))
            {
                string responseString;
                try
                {
                    responseString = client.GetStringAsync(requestUrl).Result;
                }
                catch
                {
                    return null;
                }

                GraphPagedResponse<T> response = JsonConvert.DeserializeObject<GraphPagedResponse<T>>(responseString);
                response.RequestUrl = response.Paging?.Next;

                return response;
            }
        }
    }
}
