namespace Facebook.Models
{
    public class Place
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Location Location { get; set; }

        public override string ToString() => Location.ToString();
    }
}
