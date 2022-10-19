using System.Runtime.InteropServices;

namespace Hardstuck.GuildWars2.MumbleLink
{
    /// <summary>
    /// GW2 specific context
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct Context
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 28)]
        private byte[] _ServerAddress;
        /// <summary>
        /// IP address of the current instance
        /// </summary>
        public byte[] ServerAddress
        {
            get => _ServerAddress;
            set => _ServerAddress = value;
        }

        /// <summary>
        /// ID of the map
        /// </summary>
        public uint MapID { get; set; }

        /// <summary>
        /// Type of the map
        /// </summary>
        public MapType MapType { get; set; }

        /// <summary>
        /// Current gamemode, resolved from map type
        /// </summary>
        public GameMode GameMode
        {
            get
            {
                if (MapType == MapType.PvP || MapType == MapType.Tournament)
                {
                    return GameMode.PvP;
                }
                if (MapType == MapType.WvW || MapType == MapType.WvW_BBL
                    || MapType == MapType.WvW_EBG || MapType == MapType.WvW_EotM
                    || MapType == MapType.WvW_GBL || MapType == MapType.WvW_Lounge
                    || MapType == MapType.WvW_OS || MapType == MapType.WvW_RBL)
                {
                    return GameMode.WvW;
                }
                if (UIState.HasFlag(UIState.IsInCompetitiveGamemode))
                {
                    return GameMode.PvP;
                }
                return GameMode.PvE;
            }
        }

        /// <summary>
        /// ID of the shard (region)
        /// </summary>
        public uint ShardID { get; set; }

        /// <summary>
        /// ID for the current instance
        /// </summary>
        public uint Instance { get; set; }

        /// <summary>
        /// Current build number
        /// </summary>
        public uint BuildID { get; set; }

        /// <summary>
        /// The current state of the UI (opened panels etc.)
        /// </summary>
        public UIState UIState { get; set; }

        /// <summary>
        /// Width of the map
        /// </summary>
        public ushort CompassWidth { get; set; }

        /// <summary>
        /// Height of the map
        /// </summary>
        public ushort CompassHeight { get; set; }

        /// <summary>
        /// Current rotation heading of the map
        /// </summary>
        public float CompassRotation { get; set; }

        /// <summary>
        /// Map coordinate for the current character
        /// </summary>
        public Vector2D PlayerCoordinates { get; set; }

        /// <summary>
        /// Map coordinate for the current character relative to the map
        /// </summary>
        public Vector2D MapCenterCoordinates { get; set; }

        /// <summary>
        /// Zoom value of the map
        /// </summary>
        public float MapScale { get; set; }

        /// <summary>
        /// ID of the running process (PID)
        /// </summary>
        public uint ProcessID { get; set; }

        /// <summary>
        /// Indicates, the character mount state, whether it is mounted and on which mount
        /// </summary>
        public Mounts MountIndex { get; set; }
    }
}
