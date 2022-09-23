using Newtonsoft.Json;

namespace Hardstuck.GuildWars2.MumbleLink
{
    /// <summary>
    /// Mumble Link Identity class
    /// </summary>
    public sealed class Identity
    {
        /// <summary>
        /// Character name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Profession of the character
        /// </summary>
        [JsonProperty("profession")]
        public Profession Profession { get; set; }

        /// <summary>
        /// Specialisation of the character
        /// </summary>
        [JsonProperty("spec")]
        public EliteSpecialisation Specialisation { get; set; }

        /// <summary>
        /// Race of the character
        /// </summary>
        [JsonProperty("race")]
        public Race Race { get; set; }

        /// <summary>
        /// ID of the current map
        /// </summary>
        [JsonProperty("map_id")]
        public uint MapID { get; set; }

        /// <summary>
        /// ID of the server
        /// </summary>
        [JsonProperty("world_id")]
        public uint WorldID { get; set; }

        /// <summary>
        /// (PvP) Team colour
        /// </summary>
        [JsonProperty("team_color_id")]
        public uint TeamColorID { get; set; }

        /// <summary>
        /// Whether is character an active commander
        /// </summary>
        [JsonProperty("commander")]
        public bool IsCommander { get; set; }

        /// <summary>
        /// Current setting for FOV
        /// </summary>
        [JsonProperty("fov")]
        public float FOV { get; set; }

        /// <summary>
        /// Current setting for the UI size
        /// </summary>
        [JsonProperty("uisz")]
        public UISize UISize { get; set; }
    }
}
