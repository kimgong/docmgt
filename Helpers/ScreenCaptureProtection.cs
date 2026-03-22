using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;

namespace DocMgt.Helpers
{
    /// <summary>
    /// 防截屏保护
    /// </summary>
    public static class ScreenCaptureProtection
    {
        // Windows API 常量
        private const int WS_EX_TOPMOST = -1;
        private const int SWP_NOSIZE = 0x0001;
        private const int SWP_NOMOVE = 0x0002;
        private const int SWP_NOACTIVATE = 0x0010;
        private const int SWP_FRAMECHANGED = 0x0020;

        // 键盘钩子相关
        private static IntPtr _hookId = IntPtr.Zero;
        private static LowLevelKeyboardProc _proc = HookCallback;
        private static Window _protectedWindow;

        // 用户32.dll 导入
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        // 键盘常量
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_SYSKEYDOWN = 0x0104;

        // 需要拦截的按键
        private static readonly int[] _blockedKeys = {
            (int)Key.PrintScreen,  // PrtScreen
            (int)Key.LWin,  // Win+Shift+S
             (int)Key.RWin// Win+Shift+S
        };

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// 启用防截屏保护
        /// </summary>
        public static void EnableProtection(Window window)
        {
            _protectedWindow = window;

            // 设置窗口为顶部，防止被截图工具捕获
            var helper = new WindowInteropHelper(window);
            SetWindowPos(helper.Handle, (IntPtr)WS_EX_TOPMOST, 0, 0, 0, 0,
                SWP_NOMOVE | SWP_NOSIZE | SWP_NOACTIVATE | SWP_FRAMECHANGED);

            // 安装键盘钩子
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                _hookId = SetWindowsHookEx(WH_KEYBOARD_LL, _proc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }

            // 监听 Alt+F4
            window.KeyDown += Window_KeyDown;
        }

        /// <summary>
        /// 禁用防截屏保护
        /// </summary>
        public static void DisableProtection(Window window)
        {
            if (_hookId != IntPtr.Zero)
            {
                UnhookWindowsHookEx(_hookId);
                _hookId = IntPtr.Zero;
            }

            if (window != null)
            {
                window.KeyDown -= Window_KeyDown;
            }

            _protectedWindow = null;
        }

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && (wParam == (IntPtr)WM_KEYDOWN || wParam == (IntPtr)WM_SYSKEYDOWN))
            {
                int vkCode = Marshal.ReadInt32(lParam);

                // 拦截 PrtScreen 键
                if (vkCode == (int)Key.PrintScreen || vkCode == 44) // 44 是 VK_SNAPSHOT
                {
                    return (IntPtr)1; // 拦截按键
                }

                // 拦截 Alt+Tab
                if (vkCode == (int)Key.Tab)
                {
                    if (Keyboard.IsKeyDown(Key.LeftAlt) || Keyboard.IsKeyDown(Key.RightAlt))
                    {
                        return (IntPtr)1;
                    }
                }

                // 拦截 Alt+F4
                if (vkCode == (int)Key.F4)
                {
                    if (Keyboard.IsKeyDown(Key.LeftAlt) || Keyboard.IsKeyDown(Key.RightAlt))
                    {
                        return (IntPtr)1;
                    }
                }

                // 拦截 Win 键
                if (vkCode == (int)Key.LWin || vkCode == (int)Key.RWin)
                {
                    return (IntPtr)1;
                }
            }

            return CallNextHookEx(_hookId, nCode, wParam, lParam);
        }

        private static void Window_KeyDown(object sender, KeyEventArgs e)
        {
            // 拦截窗口内的 F12 等按键
            if (e.Key == Key.F12 || e.Key == Key.PrintScreen)
            {
                e.Handled = true;
            }

            // 拦截 Ctrl+Alt+Delete (无法完全拦截，系统会处理)
            if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
            {
                if (Keyboard.IsKeyDown(Key.LeftAlt) || Keyboard.IsKeyDown(Key.RightAlt))
                {
                    if (e.Key == Key.Delete)
                    {
                        e.Handled = true;
                    }
                }
            }
        }
    }
}
