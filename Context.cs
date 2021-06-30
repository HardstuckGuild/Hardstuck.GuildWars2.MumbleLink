using System.Runtime.InteropServices;

namespace Hardstuck.GuildWars2.MumbleLink
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct Context
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 28)]
        private byte[] _ServerAddress;
        public byte[] ServerAddress
        {
            get => _ServerAddress;
            set => _ServerAddress = value;
        }
        public uint MapID { get; set; }
        public MapType MapType { get; set; }
        public uint ShardID { get; set; }
        public uint Instance { get; set; }
        public uint BuildID { get; set; }
        public UIState UIState { get; set; }
        public ushort CompassWidth { get; set; }
        public ushort CompassHeight { get; set; }
        public float CompassRotation { get; set; }
        public Vector2D PlayerCoordinates { get; set; }
        public Vector2D MapCenterCoordinates { get; set; }
        public float MapScale { get; set; }
        public uint ProcessID { get; set; }
        public Mounts MountIndex { get; set; }
    }
}
