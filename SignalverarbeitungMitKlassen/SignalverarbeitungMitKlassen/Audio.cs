using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace SignalverarbeitungMitKlassen
{
    static class Audio
    {
        public static void Play(double[] signal, int samplingRate)
        {
            // Dies ist noch sehr unsauber!
            // TODO: auf Fehler reagieren; Speicherlecks vermeiden
            // TODO: Iterator statt komplettem Array benutzen

            short[] buffer = new short[signal.Length];
            for (int i = 0; i < signal.Length; i++)
            {
                buffer[i] = (short)(short.MaxValue * signal[i]);
            }
            GCHandle hBuffer = GCHandle.Alloc(buffer, GCHandleType.Pinned);

            IntPtr hWaveOut = IntPtr.Zero;
            NativeMethods.WAVEFORMATEX format = new NativeMethods.WAVEFORMATEX();
            format.wFormatTag = 1;
            format.nChannels = 1;
            format.nSamplesPerSec = (uint)samplingRate;
            format.nAvgBytesPerSec = (uint)(samplingRate * sizeof(short));
            format.nBlockAlign = sizeof(short);
            format.wBitsPerSample = 16;
            format.cbSize = 0;
            NativeMethods.waveOutOpen(ref hWaveOut, new IntPtr(-1), ref format, IntPtr.Zero, IntPtr.Zero, 0);
            NativeMethods.WAVEHDR header = new NativeMethods.WAVEHDR();
            header.lpData = Marshal.UnsafeAddrOfPinnedArrayElement(buffer, 0);
            header.dwBufferLength = (uint)(buffer.Length * sizeof(short));
            NativeMethods.waveOutPrepareHeader(hWaveOut, ref header, (uint)Marshal.SizeOf(header));
            NativeMethods.waveOutWrite(hWaveOut, ref header, (uint)Marshal.SizeOf(header));
            while ((header.dwFlags & 1) == 0)
            {
                System.Threading.Thread.Sleep(100);
            }
            NativeMethods.waveOutUnprepareHeader(hWaveOut, ref header, (uint)Marshal.SizeOf(header));
            NativeMethods.waveOutClose(hWaveOut);

            hBuffer.Free();
        }

        static class NativeMethods
        {
            [DllImport("winmm.dll", SetLastError = true)]
            internal static extern uint waveOutOpen(ref IntPtr hwo, IntPtr uDeviceID, ref WAVEFORMATEX pwfx, IntPtr dwCallback, IntPtr dwCallbackInstance, uint fdwOpen);

            [DllImport("winmm.dll", SetLastError = true)]
            internal static extern uint waveOutPrepareHeader(IntPtr hwo, ref WAVEHDR pwh, uint cbwh);

            [DllImport("winmm.dll", SetLastError = true)]
            internal static extern uint waveOutWrite(IntPtr hwo, ref WAVEHDR pwh, uint cbwh);

            [DllImport("winmm.dll", SetLastError = true)]
            internal static extern uint waveOutUnprepareHeader(IntPtr hwo, ref WAVEHDR pwh, uint cbwh);

            [DllImport("winmm.dll", SetLastError = true)]
            internal static extern uint waveOutClose(IntPtr hwo);

            [StructLayout(LayoutKind.Sequential)]
            internal struct WAVEFORMATEX
            {
                public ushort wFormatTag;
                public ushort nChannels;
                public uint nSamplesPerSec;
                public uint nAvgBytesPerSec;
                public ushort nBlockAlign;
                public ushort wBitsPerSample;
                public ushort cbSize;
            }

            [StructLayout(LayoutKind.Sequential)]
            internal struct WAVEHDR
            {
                public IntPtr lpData;
                public uint dwBufferLength;
                public uint dwBytesRecorded;
                public IntPtr dwUser;
                public uint dwFlags;
                public uint dwLoops;
                public IntPtr lpNext;
                public IntPtr reserved;
            }
        }
    }
}