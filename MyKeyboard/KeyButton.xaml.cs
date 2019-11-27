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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyKeyboard
{
    /// <summary>
    /// KeyButton.xaml 的交互逻辑
    /// </summary>
    public partial class KeyButton : Button
    {
        public KeyButton()
        {
            InitializeComponent();
        }

        #region Properties

        #region 文本
        /// <summary>
        /// 左上文本属性
        /// </summary>
        public static readonly DependencyProperty LeftTopTextProperty = DependencyProperty.Register("LeftTopText", typeof(string), typeof(KeyUc));
        /// <summary>
        /// 左上文本
        /// </summary>
        public string LeftTopText
        {
            get { return (string)GetValue(LeftTopTextProperty); }
            set { SetValue(LeftTopTextProperty, value); }
        }

        /// <summary>
        /// 左下文本属性
        /// </summary>
        public static readonly DependencyProperty LeftBottomProperty = DependencyProperty.Register("LeftBottomText", typeof(string), typeof(KeyUc));
        /// <summary>
        /// 左下文本
        /// </summary>
        public string LeftBottomText
        {
            get { return (string)GetValue(LeftBottomProperty); }
            set { SetValue(LeftBottomProperty, value); }
        }

        /// <summary>
        /// 右上文本属性
        /// </summary>
        public static readonly DependencyProperty RightTopTextProperty = DependencyProperty.Register("RightTopText", typeof(string), typeof(KeyUc));
        /// <summary>
        /// 右上文本
        /// </summary>
        public string RightTopText
        {
            get { return (string)GetValue(RightTopTextProperty); }
            set { SetValue(RightTopTextProperty, value); }
        }

        /// <summary>
        /// 右下文本属性
        /// </summary>
        public static readonly DependencyProperty RightBottomProperty = DependencyProperty.Register("RightBottomText", typeof(string), typeof(KeyUc));
        /// <summary>
        /// 右下文本
        /// </summary>
        public string RightBottomText
        {
            get { return (string)GetValue(RightBottomProperty); }
            set { SetValue(RightBottomProperty, value); }
        }
        #endregion

        #region 图案
        /// <summary>
        /// 居中几何图案属性
        /// </summary>
        public static readonly DependencyProperty MidGeoProperty = DependencyProperty.Register("MidGeo", typeof(Geometry), typeof(KeyUc));
        /// <summary>
        /// 居中几何图案
        /// </summary>
        public Geometry MidGeo
        {
            get { return (Geometry)GetValue(MidGeoProperty); }
            set { SetValue(MidGeoProperty, value); }
        }
        #endregion

        #region 特殊
        /// <summary>
        /// 常亮属性
        /// </summary>
        public static readonly DependencyProperty AlwaysLightProperty = DependencyProperty.Register("AlwaysLight", typeof(bool), typeof(KeyUc));
        /// <summary>
        /// 常亮
        /// </summary>
        public bool AlwaysLight
        {
            get { return (bool)GetValue(AlwaysLightProperty); }
            set { SetValue(AlwaysLightProperty, value); }
        }

        /// <summary>
        /// 大小写敏感属性
        /// </summary>
        public static readonly DependencyProperty CaseSensitiveProperty = DependencyProperty.Register("CaseSensitive", typeof(bool), typeof(KeyUc));
        /// <summary>
        /// 大小写敏感
        /// </summary>
        public bool CaseSensitive
        {
            get { return (bool)GetValue(CaseSensitiveProperty); }
            set { SetValue(CaseSensitiveProperty, value); }
        }
        #endregion

        #endregion
    }
}
