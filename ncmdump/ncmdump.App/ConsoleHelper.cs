using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ncmdump.App
{
    public static class ConsoleHelper
    {
        // 导入 Windows API 函数
        [DllImport( "kernel32.dll", SetLastError = true )]
        private static extern bool AllocConsole();

        [DllImport( "kernel32.dll" )]
        private static extern bool FreeConsole();

        [DllImport( "kernel32.dll" )]
        private static extern IntPtr GetConsoleWindow();

        [DllImport( "user32.dll" )]
        private static extern bool ShowWindow( IntPtr hWnd, int nCmdShow );

        private const int SW_HIDE = 0;
        private const int SW_SHOW = 5;

        /// <summary>
        /// 显示控制台窗口。
        /// </summary>
        public static void ShowConsole()
        {
            IntPtr consoleWindow = GetConsoleWindow();
            if (consoleWindow == IntPtr.Zero)
            {
                // 如果没有控制台窗口，则分配一个新的
                AllocConsole();
            } else
            {
                // 如果已有控制台窗口，则显示它
                ShowWindow( consoleWindow, SW_SHOW );
            }
        }

        /// <summary>
        /// 隐藏控制台窗口。
        /// </summary>
        public static void HideConsole()
        {
            IntPtr consoleWindow = GetConsoleWindow();
            if (consoleWindow != IntPtr.Zero)
            {
                ShowWindow( consoleWindow, SW_HIDE );
            }
        }

        /// <summary>
        /// 检查当前进程是否正在使用控制台。
        /// </summary>
        public static bool IsConsoleVisible()
        {
            return GetConsoleWindow() != IntPtr.Zero;
        }
    }
}
