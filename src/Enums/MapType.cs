namespace Hardstuck.GuildWars2.MumbleLink
{
    /// <summary>
    /// Type of the map
    /// </summary>
    public enum MapType : uint
    {
        /// <summary>
        /// Automatic redirect is in progress
        /// </summary>
        AutoRedirect = 0,

        /// <summary>
        /// Character creation screen
        /// </summary>
        CharacterCreation = 1,

        /// <summary>
        /// PvP map
        /// </summary>
        PvP = 2,

        /// <summary>
        /// GvG map (I wish)
        /// </summary>
        GvG = 3,

        /// <summary>
        /// An Instance
        /// </summary>
        Instance = 4,

        /// <summary>
        /// General PvE
        /// </summary>
        PvE = 5,

        /// <summary>
        /// Tournament (SPvP)
        /// </summary>
        Tournament = 6,

        /// <summary>
        /// Tutorial map
        /// </summary>
        Tutorial = 7,

        /// <summary>
        /// User made tournament (not in game)
        /// </summary>
        UserTournament = 8,

        /// <summary>
        /// WvW - Eternal Battlegrounds
        /// </summary>
        WvW_EBG = 9,

        /// <summary>
        /// WvW - Blue Borderlands
        /// </summary>
        WvW_BBL = 10,

        /// <summary>
        /// WvW - Green Borderlands
        /// </summary>
        WvW_GBL = 11,

        /// <summary>
        /// WvW - Red Borderlands
        /// </summary>
        WvW_RBL = 12,

        /// <summary>
        /// WvW - Reward - scrapped
        /// </summary>
        WVW_REWARD = 13,

        /// <summary>
        /// WvW - Obsidian Sanctum
        /// </summary>
        WvW_OS = 14,

        /// <summary>
        /// WvW - Edge of the Mists
        /// </summary>
        WvW_EotM = 15,

        /// <summary>
        /// Mini PvE maps like Mistlock Sanctuary, Aerodrome, etc.
        /// </summary>
        PvE_Mini = 16,

        /// <summary>
        /// Big battle - scrapped
        /// </summary>
        BIG_BATTLE = 17,

        /// <summary>
        /// WvW - Lounge (Armstice Bastion)
        /// </summary>
        WvW_Lounge = 18,

        /// <summary>
        /// General WvW
        /// </summary>
        WvW = 19,
    }
}
