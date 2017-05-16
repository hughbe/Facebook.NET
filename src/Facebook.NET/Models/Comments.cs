namespace Facebook.Models
{
    public class Comments
    {
        private CommentsSummary _summary;
        public CommentsSummary Summary
        {
            get => _summary ?? (_summary = new CommentsSummary());
            set => _summary = value;
        }

        public override string ToString() => Summary.ToString();
    }
}
