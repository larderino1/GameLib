using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbManager.Models
{
    public class GameGenres
    {
        public Guid GameId { get; set; }

        [JsonIgnore]
        public Game Game { get; set; }

        public Guid GenreId { get; set; }

        [JsonIgnore]

        public Genre Genre { get; set; }
    }
}
