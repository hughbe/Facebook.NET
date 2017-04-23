using System;
using System.Net.Http;
using System.Security.Authentication;
using System.Text;
using Facebook.Models;
using Facebook.Requests;
using Newtonsoft.Json;

namespace Facebook
{
    public class GraphClient
    {
        public Version Version { get; }
        public string GraphApiBase { get; }
        public string AccessToken { get; }

        public GraphClient(Version version, string appId, string appSecret)
        {
            if (version == null)
            {
                throw new ArgumentNullException(nameof(version));
            }
            if (version.Revision > 0 || version.Build > 0)
            {
                throw new ArgumentException("Version must only have a major and minor component.", nameof(version));
            }
            if (appId == null)
            {
                throw new ArgumentNullException(nameof(appId));
            }
            if (string.IsNullOrWhiteSpace(appId))
            {
                throw new ArgumentException("Argument cannot be empty or white space.", nameof(appId));
            }
            if (appSecret == null)
            {
                throw new ArgumentNullException(nameof(appSecret));
            }
            if (string.IsNullOrWhiteSpace(appSecret))
            {
                throw new ArgumentException("Argument cannot be empty or white space.", nameof(appSecret));
            }

            Version = version;
            GraphApiBase = $"https://graph.facebook.com/v{Version.ToString(2)}";
            AccessToken = $"{appId}|{appSecret}";
        }

        public T GetPost<T>(PageRequest request) where T : Post
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            return ExecuteRequest<T>(ConstructRequest(request));
        }

        public PagedResponse<T> GetPosts<T>(PostsRequest request) where T : Post
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            return GraphPagedResponse<T>.ExecuteRequest(ConstructRequest(request));
        }

        public T GetComment<T>(CommentRequest request) where T : Comment
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            return ExecuteRequest<T>(ConstructRequest(request));
        }

        public PagedResponse<T> GetComments<T>(CommentsRequest request) where T: Comment
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            return GraphPagedResponse<T>.ExecuteRequest(ConstructRequest(request));
        }

        public T GetPage<T>(PageRequest request) where T : Page
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            return ExecuteRequest<T>(ConstructRequest(request));
        }

        private string ConstructRequest(Request request)
        {
            var builder = new StringBuilder();
            builder.Append(GraphApiBase);
            request.Format(builder);
            builder.Append($"access_token={AccessToken}");
            return builder.ToString();
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
