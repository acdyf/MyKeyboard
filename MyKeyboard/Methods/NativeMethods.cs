/*--------------------------------------------------------------------------
Copyright (C) 2019  有限公司版权所有。   
功能描述：PInvoke类 
创建时间：2019-11-25
创建人员：dingyf
--------------------------------------------------------------------------*/
using System;
using System.Runtime.InteropServices;

namespace MyKeyboard.Methods
{
    /// <summary>
    /// PInvoke类 
    /// </summary>
    internal class NativeMethods
    {
        /// <summary>
        /// 扩展键盘
        /// </summary>
        public const uint KEYEVENTF_EXTENDEDKEY = 0x1;

        /// <summary>
        /// 按键放开
        /// </summary>
        public const uint KEYEVENTF_KEYUP = 0x2;

        /// <summary>
        /// 获取按键状态
        /// </summary>
        /// <param name="nVirtKey"></param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Interoperability", "CA1401:PInvokesShouldNotBeVisible")]
        [DllImport("user32.dll")]
        internal static extern short GetKeyState(int nVirtKey);


        /// <summary>
        /// 键盘按下
        /// </summary>
        /// <param name="bVk"></param>
        /// <param name="bScan"></param>
        /// <param name="dwFlags"></param>
        /// <param name="dwExtraInfo"></param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Portability", "CA1901:PInvokeDeclarationsShouldBePortable", MessageId = "3")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Interoperability", "CA1401:PInvokesShouldNotBeVisible")]
        [DllImport("user32.dll", EntryPoint = "keybd_event")]
        internal static extern void Keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="nIdex"></param>
        /// <returns></returns>
        [DllImport("User32.dll")]
        internal static extern int GetWindowLong(IntPtr hWnd, int nIdex);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="nIndex"></param>
        /// <param name="dwNewLong"></param>
        /// <returns></returns>
        [DllImport("User32.dll")]
        internal static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
    }
}
