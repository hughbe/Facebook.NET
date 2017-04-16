namespace Facebook.Models
{
    public class Reactions
    {
        public ReactionsSummary Summary { get; set; }

        public override string ToString() => Summary.ToString();
    }
}
