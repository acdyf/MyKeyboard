using MyKeyboard.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyKeyboard
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constructor
        public MainWindow()
        {
            InitializeComponent();
        }
        #endregion

        #region Events
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            IntPtr a = new WindowInteropHelper(this).Handle;
            int temp = NativeMethods.GetWindowLong(a, -20);
            NativeMethods.SetWindowLong(a, -20, temp | 0x08000000);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //拖拽
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void ButtonEx_Click(object sender, RoutedEventArgs e)
        {
            if (sender is ButtonEx buttonEx)
            {
                string tag = buttonEx.Tag.ToString();

                //buttonEx.IsAlwaysLight = !buttonEx.IsAlwaysLight;
                PressKey(tag);
            }
        }

        /// <summary>
        /// 按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonEx_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is ButtonEx buttonEx)
            {
                //buttonEx.IsAlwaysLight = !buttonEx.IsAlwaysLight;
                if (!Common.GetKeyState(VirtualKeys.CapsLock))
                {
                    NativeMethods.Keybd_event((byte)VirtualKeys.CapsLock, 0, NativeMethods.KEYEVENTF_EXTENDEDKEY | 0, 0);
                    NativeMethods.Keybd_event((byte)VirtualKeys.CapsLock, 0, NativeMethods.KEYEVENTF_EXTENDEDKEY | NativeMethods.KEYEVENTF_KEYUP, 0);
                }
                byte bkey = Common.FintVirtualKey(buttonEx.Tag.ToString());
                NativeMethods.Keybd_event(bkey, 0, NativeMethods.KEYEVENTF_EXTENDEDKEY | 0, 0);
                NativeMethods.Keybd_event(bkey, 0, NativeMethods.KEYEVENTF_EXTENDEDKEY | NativeMethods.KEYEVENTF_KEYUP, 0);
            }
        }

        /// <summary>
        /// 抬起
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonEx_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (sender is ButtonEx buttonEx)
            {
                //buttonEx.IsAlwaysLight = !buttonEx.IsAlwaysLight;
                if (!Common.GetKeyState(VirtualKeys.CapsLock))
                {
                    NativeMethods.Keybd_event((byte)VirtualKeys.CapsLock, 0, NativeMethods.KEYEVENTF_EXTENDEDKEY | NativeMethods.KEYEVENTF_KEYUP, 0);
                }
                byte bkey = Common.FintVirtualKey(buttonEx.Tag.ToString());
                NativeMethods.Keybd_event(bkey, 0, NativeMethods.KEYEVENTF_EXTENDEDKEY | NativeMethods.KEYEVENTF_KEYUP, 0);
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// 按下按键
        /// </summary>
        private void PressKey(string key)
        {
            //注意不是找【ASCII码】 是找【虚拟键盘码】 
            if (Common.IsUpperLetter(key))//字母
            {
                //举例:
                //A的虚拟键盘码65,这只是A的【虚拟键盘码】和【ASCII码】 恰好一致,小写a根本就没有虚拟键盘码,
                //模拟按键时直接给A,不考虑a——即不考虑输出的最终是什么,只考虑操作的是什么按键
                byte bkey = Common.FintVirtualKey(key);
                NativeMethods.Keybd_event(bkey, 0x45, NativeMethods.KEYEVENTF_EXTENDEDKEY | 0, 0);
                NativeMethods.Keybd_event(bkey, 0x45, NativeMethods.KEYEVENTF_EXTENDEDKEY | NativeMethods.KEYEVENTF_KEYUP, 0);
            }
            //else if ()//Shift Caps Ctrl Alt
            //{ }
            //else if ()//数字
            //{ }
            //else if ()//符号
            //{ }
            //else//其他
            //{ }
        }
        #endregion
    }
}