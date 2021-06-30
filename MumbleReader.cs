using System;
using System.IO.MemoryMappedFiles;
using System.Runtime.InteropServices;
using System.Threading;

namespace Hardstuck.GuildWars2.MumbleLink
{
    public class MumbleLink : IDisposable
    {
        private bool _Disposed;
        private readonly MemoryMappedFile _File;
        private readonly MemoryMappedViewStream _FileStream;

        public int Tick { get; set; } = 0;
        public int UpdateRate { get; set; } = 16;
        public LinkedMem Data { get; set; }

        public MumbleLink(string mapName)
        {
            _File = MemoryMappedFile.CreateOrOpen(mapName, Marshal.SizeOf<LinkedMem>());
            _FileStream = _File.CreateViewStream();

            Thread loop = new Thread(Update);
            loop.Start();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (_Disposed)
            {
                return;
            }

            _Disposed = true;

            if (disposing)
            {
                _FileStream.Dispose();
                _File.Dispose();
            }
        }

        private void Update()
        {
            while (!_Disposed)
            {
                Tick++;

                _FileStream.Position = 0; // reset read position

                unsafe
                {
                    // read shared memory block, copy into buffer
                    byte[] buffer = new byte[_FileStream.Length];
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
