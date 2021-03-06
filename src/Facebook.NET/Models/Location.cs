﻿namespace Facebook.Models
{
    public class Location
    {
        public string City { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }

        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public override string ToString() => City;
    }
}
