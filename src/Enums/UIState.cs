using System;

namespace Hardstuck.GuildWars2.MumbleLink
{
    /// <summary>
    /// State of the UI
    /// </summary>
    [Flags]
    public enum UIState : uint
    {
        /// <summary>
        /// No state specified
        /// </summary>
        NoState = 0,

        /// <summary>
        /// Whether map is opened
        /// </summary>
        IsMapOpen = 1,

        /// <summary>
        /// Whether the map is position top right
        /// </summary>
        IsCompassTopRight = 2,

        /// <summary>
        /// Whether map has rotation enabled
        /// </summary>
        IsCompassRotationEnabled = 4,

        /// <summary>
        /// Whether the current Windows window focus is on the game
        /// </summary>
        IsGameFocused = 8,

        /// <summary>
        /// Whether the map is a competitive gamemode
        /// </summary>
        IsInCompetitiveGamemode = 16,

        /// <summary>
        /// Whether chat window is focused
        /// </summary>
        IsTextboxFocused = 32,

        /// <summary>
        /// Whether the character is in combat
        /// </summary>
        IsInCombat = 64,
    }
}
