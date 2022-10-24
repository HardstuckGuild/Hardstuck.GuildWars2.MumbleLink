using System;
using System.IO.MemoryMappedFiles;
using System.Runtime.InteropServices;
using System.Threading;

namespace Hardstuck.GuildWars2.MumbleLink
{
    /// <summary>
    /// Main class from the package, implements IDisposable.
    /// </summary>
    public sealed class MumbleReader : IDisposable
    {
        #region definitions
        private bool _Disposed = false;
        private int _UpdateRate = 16;
        private readonly MemoryMappedFile _File;
        private readonly MemoryMappedViewStream _FileStream;
        private readonly Thread updateLoop;
        #endregion

        /// <summary>
        /// The update rate for the continuous update.
        /// </summary>
        public int UpdateRate
        {
            get => _UpdateRate;
            set
            {
                if (value > 0)
                {
                    _UpdateRate = value;
                }
                else
                {
                    _UpdateRate = 16;
                }
            }
        }

        /// <summary>
        /// Data obtained from the MumbleLink
        /// </summary>
        public LinkedMem Data { get; set; }

        /// <summary>
        /// Create an instance from MumbleReader class.
        /// </summary>
        /// <param name="continuousUpdate">Continuosly update the data</param>
        /// <param name="mapName">name for the memory map</param>
        public MumbleReader(bool continuousUpdate = true, string mapName = "MumbleLink")
        {
            _File = MemoryMappedFile.CreateOrOpen(mapName, Marshal.SizeOf<LinkedMem>());
            _FileStream = _File.CreateViewStream();

            if (continuousUpdate)
            {
                updateLoop = new Thread(UpdateViaThread);
                updateLoop.Start();
            }
        }

        /// <summary>
        /// Dispose of all resources held by the class.
        /// </summary>
        public void Dispose()
        {
            DisposeFlow(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose of resources held by the class.
        /// </summary>
        /// <param name="disposing">whether the dispose should happen</param>
        private void DisposeFlow(bool disposing)
        {
            if (_Disposed)
            {
                return;
            }

            _Disposed = true;

            if (disposing)
            {
                _FileStream?.Dispose();
                _File?.Dispose();
                updateLoop?.Join();
            }
        }

        /// <summary>
        /// Update the Mumble Link data manually.
        /// </summary>
        public void Update()
        {
            if (!_Disposed)
            {
                _FileStream.Position = 0; // reset read position

                unsafe
                {
                    // read shared memory block, copy into buffer
                    var buffer = new byte[_FileStream.Length];
                    _FileStream.Read(buffer, 0, buffer.Length);

                    fixed (byte* ptr = &buffer[0])
                    {
                        Data = (LinkedMem)Marshal.PtrToStructure((IntPtr)ptr, typeof(LinkedMem));
                    }
                }
            }
        }

        private void UpdateViaThread()
        {
            while (!_Disposed)
            {
                _FileStream.Position = 0; // reset read position

                unsafe
                {
                    // read shared memory block, copy into buffer
                    var buffer = new byte[_FileStream.Length];
                    _FileStream.Read(buffer, 0, buffer.Length);

                    fixed (byte* ptr = &buffer[0])
                    {
                        Data = (LinkedMem)Marshal.PtrToStructure((IntPtr)ptr, typeof(LinkedMem));
                    }
                }

                Thread.Sleep(1000 / UpdateRate); // forced update rate
            }
        }
    }
}
