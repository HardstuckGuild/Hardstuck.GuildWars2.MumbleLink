using System;
using System.IO.MemoryMappedFiles;
using System.Runtime.InteropServices;
using System.Threading;

namespace Hardstuck.GuildWars2.MumbleLink
{
    public class MumbleReader : IDisposable
    {
        private bool _Disposed = false;
        private int _UpdateRate = 16;
        private readonly MemoryMappedFile _File;
        private readonly MemoryMappedViewStream _FileStream;
        private readonly Thread updateLoop;

        public int Tick { get; set; } = 0;
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
        public LinkedMem Data { get; set; }

        public MumbleReader(bool continuousUpdate = true, string mapName = "MumbleLink")
        {
            _File = MemoryMappedFile.CreateOrOpen(mapName, Marshal.SizeOf<LinkedMem>());
            _FileStream = _File.CreateViewStream();

            if (continuousUpdate)
            {
                updateLoop = new Thread(UpdateWiaThread);
                updateLoop.Start();
            }
        }

        public void Dispose()
        {
            DisposeFlow(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void DisposeFlow(bool disposing)
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
                updateLoop?.Abort();
            }
        }

        public void Update()
        {
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

        private void UpdateWiaThread()
        {
            while (!_Disposed)
            {
                Tick++;

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
