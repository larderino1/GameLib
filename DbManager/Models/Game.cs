using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

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

        public double Price { get; set; }

        [JsonIgnore]
        public Category Category { get; set; }

        public Guid CategoryId { get; set; }
    }
}
