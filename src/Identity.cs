using System.Text.Json.Serialization;

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
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Profession of the character
        /// </summary>
        [JsonPropertyName("profession")]
        public Profession Profession { get; set; }

        /// <summary>
        /// Specialisation of the character
        /// </summary>
        [JsonPropertyName("spec")]
        public EliteSpecialisation Specialisation { get; set; }

        /// <summary>
        /// Race of the character
        /// </summary>
        [JsonPropertyName("race")]
        public Race Race { get; set; }

        /// <summary>
        /// ID of the current map
        /// </summary>
        [JsonPropertyName("map_id")]
        public uint MapID { get; set; }

        /// <summary>
        /// ID of the server
        /// </summary>
        [JsonPropertyName("world_id")]
        public uint WorldID { get; set; }

        /// <summary>
        /// (PvP) Team colour
        /// </summary>
        [JsonPropertyName("team_color_id")]
        public uint TeamColorID { get; set; }

        /// <summary>
        /// Whether is character an active commander
        /// </summary>
        [JsonPropertyName("commander")]
        public bool IsCommander { get; set; }

        /// <summary>
        /// Current setting for FOV
        /// </summary>
        [JsonPropertyName("fov")]
        public float FOV { get; set; }

        /// <summary>
        /// Current setting for the UI size
        /// </summary>
        [JsonPropertyName("uisz")]
        public UISize UISize { get; set; }
    }
}
