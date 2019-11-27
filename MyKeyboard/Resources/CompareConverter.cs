using MyKeyboard.Methods;
using System;
using System.Globalization;
using System.Windows.Data;

namespace MyKeyboard.Resources
{
    [ValueConversion(typeof(object), typeof(object))]
    public sealed class CompareConverter : IValueConverter
    {
        public object TrueValue { get; set; }
        public object FalseValue { get; set; }

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

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
