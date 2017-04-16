namespace Facebook.Models
{
    public class Profile
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public override string ToString() => Name;
    }
}
