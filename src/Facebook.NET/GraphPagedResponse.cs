using System;
using System.Net.Http;
using System.Security.Authentication;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Pagination.Primitives;

namespace Facebook.Models
{
    internal class GraphPagedResponse<T> : PagedResponse<T>
    {
        private string RequestUrl { get; set; }

        [JsonProperty]
        private Paging Paging { get; set; }

        /// <summary>
        /// Gets the previous page of data of length PageSize.
        /// </summary>
        /// <returns>The previous page of data if there is a previous page, else null. This represents a slice of data of length PageSize.</returns>
        public override async Task<PagedResponse<T>> PreviousPage()
        {
            // Nothing before.
            if (Paging?.Previous == null)
            {
                return null;
            }

            return await ExecuteRequest(Paging?.Previous);
        }

        /// <summary>
        /// Gets the next page of data of length PageSize.
        /// </summary>
        /// <returns>The next page of data if there is a next page, else null. This represents a slice of data of length PageSize.</returns>
        public override async Task<PagedResponse<T>> NextPage()
        {
            // Nothing after.
            if (RequestUrl == null)
            {
                return null;
            }

            return await ExecuteRequest(RequestUrl);
        }

        internal static async Task<GraphPagedResponse<T>> ExecuteRequest(string requestUrl)
        {
            HttpClient client = null;
            try
            {
                var httpHandler = new WinHttpHandler { SslProtocols = SslProtocols.Tls12 };
                client = new HttpClient(httpHandler);
            }
            catch (PlatformNotSupportedException)
            {
                client = new HttpClient();
            }

            using (client)
            {
                string responseString;
                try
                {
                    responseString = await client.GetStringAsync(requestUrl);
                }
                catch (Exception)
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
