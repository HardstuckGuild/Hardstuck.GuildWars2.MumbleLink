using System.Runtime.InteropServices;
using System.Text.Json;

namespace Hardstuck.GuildWars2.MumbleLink
{
    /// <summary>
    /// Linked memory struct, designed for GW2 Mumble Link
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct LinkedMem
    {
        /// <summary>
        /// UI version
        /// </summary>
        public uint UIVersion { get; set; }

        /// <summary>
        /// UI tick value
        /// </summary>
        public uint UITick { get; set; }

        /// <summary>
        /// Avatar position vector
        /// </summary>
        public Vector3D AvatarPosition { get; set; }

        /// <summary>
        /// Avatar front vector
        /// </summary>
        public Vector3D AvatarFront { get; set; }

        /// <summary>
        /// Avatar top vector
        /// </summary>
        public Vector3D AvatarTop { get; set; }

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        private string _Name;
        /// <summary>
        /// Memory map name
        /// </summary>
        public string Name
        {
            get => _Name;
            set => _Name = value;
        }

        /// <summary>
        /// Camera position vector
        /// </summary>
        public Vector3D CameraPosition { get; set; }

        /// <summary>
        /// Camera front vector
        /// </summary>
        public Vector3D CameraFront { get; set; }

        /// <summary>
        /// Camera top vector
        /// </summary>
        public Vector3D CameraTop { get; set; }

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        private string _IdentityString;
        /// <summary>
        /// JSON text of the Identity, GW2 specific value
        /// </summary>
        public string IdentityString
        {
            get => _IdentityString;
            set => _IdentityString = value;
        }

        /// <summary>
        /// The character's identity
        /// </summary>
        public Identity Identity
        {
            get
            {
                try
                {
                    return JsonSerializer.Deserialize<Identity>(_IdentityString);
                }
                catch
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Character length of the context
        /// </summary>
        public uint ContextLength { get; set; }

        /// <summary>
        /// GW2 specific context
        /// </summary>
        public Context Context { get; set; }

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2048)]
        private string _Description;

        /// <summary>
        /// Description of the memory map
        /// </summary>
        public string Description
        {
            get => _Description;
            set => _Description = value;
        }
    }
}
