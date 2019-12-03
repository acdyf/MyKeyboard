using MyKeyboard.Methods;
using System;
using System.Globalization;
using System.Windows.Data;

namespace MyKeyboard.Resources
{
    /// <summary>
    /// 比较转换器
    /// </summary>
    [ValueConversion(typeof(object), typeof(object))]
    public sealed class CompareConverter : IValueConverter
    {
        /// <summary>
        /// 为真时值
        /// </summary>
        public object TrueValue { get; set; }

        /// <summary>
        /// 为假时值
        /// </summary>
        public object FalseValue { get; set; }

        /// <summary>
        /// 比较
        /// </summary>
        /// <param name="value">绑定源生成的值</param>
        /// <param name="targetType">绑定目标属性的类型</param>
        /// <param name="parameter">要使用的转换器参数</param>
        /// <param name="culture">要用在转换器中的区域性</param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string v1 = value.PowerToString(), v2;
            if (value is Enum)
            {
                v2 = Enum.Parse(value.GetType(), parameter.PowerToString()).PowerToString();
            }
            else
            {
                v2 = parameter.PowerToString();
            }

            return string.Compare(v1, v2, true) == 0 ? TrueValue : FalseValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
