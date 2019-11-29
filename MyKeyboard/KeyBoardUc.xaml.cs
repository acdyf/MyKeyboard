using MyKeyboard.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            this.DataContext = new KeyBoardUcViewModel();
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
            Init();
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
