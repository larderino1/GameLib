using Newtonsoft.Json;
using System;

namespace DbManager.Models
{
    public class Game
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Studio { get; set; }

        public string Author { get; set; }

        public string Country { get; set; }

        public DateTime AnonceDate { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string PhotoUrl { get; set; }

        [JsonIgnore]
        public Category Category { get; set; }

        public Guid CategoryId { get; set; }

        [JsonIgnore]
        public Genre Genre { get; set; }

        public Guid GenreId { get; set; }

        [JsonIgnore]

        public Mode Mode { get; set; }

        public Guid ModeId { get; set; }

        [JsonIgnore]
        public Platform Platform { get; set; }

        public Guid PlatformId { get; set; }
    }
}
