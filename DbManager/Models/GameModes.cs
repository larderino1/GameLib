using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbManager.Models
{
    public class GameModes
    {
        public Guid ModeId { get; set; }

        [JsonIgnore]

        public Mode Mode { get; set; }

        public Guid GameId { get; set; }

        [JsonIgnore]

        public Game Game { get; set; }
    }
}
