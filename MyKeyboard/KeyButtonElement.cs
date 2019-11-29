using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace MyKeyboard.Resources
{
    /// <summary>
    /// 键盘按钮依赖元素
    /// </summary>
    public class KeyButtonElement
    {
        #region GeometryProperty 图形属性

        /// <summary>
        /// 图形属性
        /// </summary>
        public static readonly DependencyProperty GeometryProperty = DependencyProperty.RegisterAttached(
            "Geometry", typeof(Geometry), typeof(KeyButtonElement), new PropertyMetadata(default(Geometry)));

        /// <summary>
        /// SET
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public static void SetGeometry(DependencyObject element, Geometry value)
            => element.SetValue(GeometryProperty, value);

        /// <summary>
        /// GET
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static Geometry GetGeometry(DependencyObject element)
            => (Geometry)element.GetValue(GeometryProperty);

        #endregion

        #region IsAlwaysLightProperty 是否常亮属性

        /// <summary>
        /// 是否常亮属性
        /// </summary>
        public static readonly DependencyProperty IsAlwaysLightProperty = DependencyProperty.RegisterAttached(
            "IsAlwaysLight", typeof(bool), typeof(KeyButtonElement), new PropertyMetadata(false));

        /// <summary>
        /// SET
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public static void SetIsAlwaysLight(DependencyObject element, bool value)
            => element.SetValue(IsAlwaysLightProperty, value);

        /// <summary>
        /// GET
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool GetIsAlwaysLight(DependencyObject element)
            => (bool)element.GetValue(IsAlwaysLightProperty);

        #endregion
    }
}
