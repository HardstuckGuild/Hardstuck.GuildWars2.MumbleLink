using System;

namespace Hardstuck.GuildWars2.MumbleLink
{
    [Flags]
    public enum UIState : uint
    {
        IsMapOpen = 1,
        IsCompassTopRight = 2,
        IsCompassRotationEnabled = 4,
        IsGameFocused = 8,
        IsInCompetitiveGamemode = 16,
        IsTextboxFocused = 32,
        IsInCombat = 64
    }
}