using MyKeyboard.Methods;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;

namespace MyKeyboard
{
    /// <summary>
    /// KeyBoardUc.xaml 的交互逻辑
    /// </summary>
    public partial class KeyBoardUc : UserControl
    {
        #region Constructor
        /// <summary>
        /// 键盘控件
        /// </summary>
        public KeyBoardUc()
        {
            InitializeComponent();
        }
        #endregion

        #region Events
        /// <summary>
        /// 加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (!this.IsInDesignMode())
            {
                Init();
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            Window targetWindow = Window.GetWindow(this);
            IntPtr a = new WindowInteropHelper(targetWindow).Handle;
            int temp = NativeMethods.GetWindowLong(a, -20);
            NativeMethods.SetWindowLong(a, -20, temp | 0x08000000);
        }
        #endregion
    }
}
