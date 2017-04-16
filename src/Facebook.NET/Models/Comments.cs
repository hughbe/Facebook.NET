namespace Facebook.Models
{
    public class Comments
    {
        public CommentsSummary Summary { get; set; }

        public override string ToString() => Summary.ToString();
    }
}
