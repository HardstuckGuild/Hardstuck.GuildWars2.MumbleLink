using Newtonsoft.Json;

namespace Hardstuck.GuildWars2.MumbleLink
{
    public class Identity
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("profession")]
        public Profession Profession { get; set; }

        [JsonProperty("spec")]
        public EliteSpecialization Specialization { get; set; }

        [JsonProperty("race")]
        public Race Race { get; set; }

        [JsonProperty("map_id")]
        public uint MapID { get; set; }

        [JsonProperty("world_id")]
        public uint WorldID { get; set; }

        [JsonProperty("team_color_id")]
        public uint TeamColorID { get; set; }

        [JsonProperty("commander")]
        public bool IsCommander { get; set; }

        [JsonProperty("fov")]
        public float FOV { get; set; }

        [JsonProperty("uisz")]
        public UISize UISize { get; set; }
    }
}
