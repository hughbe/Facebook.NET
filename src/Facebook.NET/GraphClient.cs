using Facebook.Models;
using Facebook.Requests;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Security.Authentication;
using System.Text;

namespace Facebook
{
    public class GraphClient
    {
        private string GraphApiBase { get; }
        private string AccessToken { get; }

        public GraphClient(string version, string appId, string appSecret)
        {
            GraphApiBase = $"https://graph.facebook.com/v{version}";
            AccessToken = $"{appId}|{appSecret}";
        }

        public PagedResponse<T> GetPosts<T>(PostsRequest request) where T : Post
        {
            return ConstructRequest<T>(request.PageId, request.Edge.ToString(), request);
        }

        public Page GetPage(PageRequest request)
        {
            return ConstructRequest<Page>(request.PageId, request);
        }

        private GraphPagedResponse<T> ConstructRequest<T>(string node, string api, PagedRequest request)
        {
            var builder = new StringBuilder();
            builder.AppendFormat("{0}/{1}/{2}?access_token={3}&", GraphApiBase, node, api, AccessToken);
            request.Format(builder);

            return GraphPagedResponse<T>.ExecuteRequest(builder.ToString());
        }

        private T ConstructRequest<T>(string node, Request request)
        {
            var builder = new StringBuilder();
            builder.AppendFormat("{0}/{1}?access_token={2}&", GraphApiBase, node, AccessToken);
            request.Format(builder);

            return ExecuteRequest<T>(builder.ToString());
        }

        private static T ExecuteRequest<T>(string requestUrl)
        {
            var httpHandler = new WinHttpHandler { SslProtocols = SslProtocols.Tls12 };

            using (HttpClient client = new HttpClient(httpHandler))
            {
                try
                {
                    string responseString = client.GetStringAsync(requestUrl).Result;
                    return JsonConvert.DeserializeObject<T>(responseString);
                }
                catch (AggregateException)
                {
                    return default(T);
                }
            }
        }
    }
}
