namespace Facebook.Models
{
    public class Reactions
    {
        private ReactionsSummary _summary;
        public ReactionsSummary Summary
        {
            get => _summary ?? (_summary = new ReactionsSummary());
            set => _summary = value;
        }

        public override string ToString() => Summary.ToString();
    }
}
