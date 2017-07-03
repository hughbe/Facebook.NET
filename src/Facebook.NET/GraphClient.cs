using System;
using System.Net.Http;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using Facebook.Models;
using Facebook.Requests;
using Pagination.Primitives;
using Newtonsoft.Json;

namespace Facebook
{
    public class GraphClient
    {
        public Version Version { get; }
        public string GraphApiBase { get; }
        public string AccessToken { get; }

        /// <summary>
        /// Constructs a GraphClient, the main entrypoint into accessing the Graph API.
        /// </summary>
        /// <param name="version">The Facebook Graph API version, e.g. 2.9.</param>
        /// <param name="appId">The Facebook API ID registered at https://developers.facebook.com/apps.</param>
        /// <param name="appSecret">The Facebook API Secret registered at https://developers.facebook.com/apps.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="version"/> is null
        /// -or-
        /// <paramref name="appId"/> is null
        /// -or-
        /// <paramref name="appSecret"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="version"/> has a revision or build
        /// -or- 
        /// <paramref name="appId"/> is empty or whitespace
        /// -or-
        /// <paramref name="appSecret"/> is empty or whitespace.
        /// </exception>
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

        /// <summary>
        /// Calls https://graph.facebook.com/vX.Y/{request.PostId}.
        /// </summary>
        /// <param name="request">The details of the request (PostId) to send to the graph API.</param>
        /// <returns>The post with the given Id of request.PostId if the post exists, else null.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="request"/> is null</exception>
        public async Task<Post> GetPost(PostRequest request) => await GetPost<Post>(request);

        /// <summary>
        /// Calls https://graph.facebook.com/vX.Y/{request.PostId}.
        /// </summary>
        /// <typeparam name="T">A constructable subclass of Post to use. This allows deserializing data into custom subclasses that add extra metadata.</typeparam>
        /// <param name="request">The details of the request (PostId) to send to the graph API.</param>
        /// <returns>The post with the given Id of request.PostId if the post exists, else null.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="request"/> is null</exception>
        public async Task<T> GetPost<T>(PostRequest request) where T : Post
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            return await ExecuteRequest<T>(ConstructRequest(request));
        }

        /// <summary>
        /// Calls https://graph.facebook.com/vX.Y/{request.PageId/{request.Edge}.
        /// </summary>
        /// <param name="request">The details of the request (PageId, Since, Until, Limit) to send to the graph API.</param>
        /// <returns>The list of posts under request.PageId in the given range request.Since and request.Until if the page exists, else null.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="request"/> is null</exception>
        public async Task<PagedResponse<Post>> GetPosts(PostsRequest request) => await GetPosts<Post>(request);

        /// <summary>
        /// Calls https://graph.facebook.com/vX.Y/{request.PageId/{request.Edge}.
        /// </summary>
        /// <typeparam name="T">A constructable subclass of Page to use. This allows deserializing data into custom subclasses that add extra metadata.</typeparam>
        /// <param name="request">The details of the request (PageId, Since, Until, Limit) to send to the graph API.</param>
        /// <returns>The list of posts under request.PageId in the given range request.Since and request.Until if the page exists, else null.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="request"/> is null</exception>
        public async Task<PagedResponse<T>> GetPosts<T>(PostsRequest request) where T : Post
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            return await GraphPagedResponse<T>.ExecuteRequest(ConstructRequest(request));
        }

        /// <summary>
        /// Calls https://graph.facebook.com/vX.Y/{request.CommentId}.
        /// </summary>
        /// <param name="request">The details of the request (CommentId) to send to the graph API.</param>
        /// <returns>The comment with the given Id of request.CommentId if the comment exists, else null.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="request"/> is null</exception>
        public async Task<Comment> GetComment(CommentRequest request) => await GetComment<Comment>(request);

        /// <summary>
        /// Calls https://graph.facebook.com/vX.Y/{request.CommentId}.
        /// </summary>\
        /// <typeparam name="T">A constructable subclass of Comment to use. This allows deserializing data into custom subclasses that add extra metadata.</typeparam>
        /// <param name="request">The details of the request (CommentId) to send to the graph API.</param>
        /// <returns>The comment with the given Id of request.CommentId if the comment exists, else null.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="request"/> is null</exception>
        public async Task<T> GetComment<T>(CommentRequest request) where T : Comment
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            return await ExecuteRequest<T>(ConstructRequest(request));
        }
        /// <summary>
        /// Calls https://graph.facebook.com/vX.Y/{request.ParentId/comments.
        /// </summary>
        /// <param name="request">The details of the request (ParentId, Since, Until, Limit) to send to the graph API.</param>
        /// <returns>The list of comments under request.ParentId, the id of a post or a comment, in the given range request.Since and request.Until if the parnet exists, else null.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="request"/> is null</exception>
        public async Task<PagedResponse<Comment>> GetComments(CommentsRequest request) => await GetComments<Comment>(request);

        /// <summary>
        /// Calls https://graph.facebook.com/vX.Y/{request.ParentId/comments.
        /// </summary>
        /// <typeparam name="T">A constructable subclass of Comment to use. This allows deserializing data into custom subclasses that add extra metadata.</typeparam>
        /// <param name="request">The details of the request (ParentId, Since, Until, Limit) to send to the graph API.</param>
        /// <returns>The list of comments under request.ParentId, the id of a post or a comment, in the given range request.Since and request.Until if the parnet exists, else null.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="request"/> is null</exception>
        public async Task<PagedResponse<T>> GetComments<T>(CommentsRequest request) where T: Comment
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            return await GraphPagedResponse<T>.ExecuteRequest(ConstructRequest(request));
        }

        /// <summary>
        /// Calls https://graph.facebook.com/vX.Y/{request.PageId}.
        /// </summary>
        /// <typeparam name="T">A constructable subclass of Page to use. This allows deserializing data into custom subclasses that add extra metadata.</typeparam>
        /// <param name="request">The details of the request (PageId) to send to the graph API.</param>
        /// <returns>The page with the given Id of request.PageId if the page exists, else null.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="request"/> is null</exception>
        public async Task<T> GetPage<T>(PageRequest request) where T : Page
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            return await ExecuteRequest<T>(ConstructRequest(request));
        }

        private string ConstructRequest(Request request)
        {
            var builder = new StringBuilder();
            builder.Append(GraphApiBase);
            request.Format(builder);
            builder.Append($"access_token={AccessToken}");
            return builder.ToString();
        }

        private async static Task<T> ExecuteRequest<T>(string requestUrl)
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
                try
                {
                    string responseString = await client.GetStringAsync(requestUrl);
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
