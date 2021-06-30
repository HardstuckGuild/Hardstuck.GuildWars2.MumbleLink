﻿using System.Runtime.InteropServices;

namespace Hardstuck.GuildWars2.MumbleLink
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct LinkedMem
    {
        public uint UIVersion { get; set; }
        public uint UITick { get; set; }

        public Vector3D AvatarPosition { get; set; }
        public Vector3D AvatarFront { get; set; }
        public Vector3D AvatarTop { get; set; }

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        private string _Name;
        public string Name
        {
            get => _Name;
            set => _Name = value;
        }

        public Vector3D CameraPosition { get; set; }
        public Vector3D CameraFront { get; set; }
        public Vector3D CameraTop { get; set; }

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        private string _Identity;
        public string Identity
        {
            get => _Identity;
            set => _Identity = value;
        }
        public uint ContextLength { get; set; }
        public Context Context { get; set; }
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2048)]
        private string _Description;
        public string Description
        {
            get => _Description;
            set => _Description = value;
        }
    }
}
