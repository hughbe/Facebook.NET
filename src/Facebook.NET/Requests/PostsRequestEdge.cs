namespace Facebook.Requests
{
    public enum PostsRequestEdge
    {
        /// <summary>
        /// All posts published by the page or by others on the page.
        /// </summary>
        Feed,

        /// <summary>
        /// All posts published by the page only.
        /// </summary>
        Posts,

        /// <summary>
        /// All public posts in which the page has been tagged. 
        /// </summary>
        Tagged
    }
}
