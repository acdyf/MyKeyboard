using MyKeyboard.Methods;
using System;
using System.Globalization;
using System.Windows.Data;

namespace MyKeyboard.Resources
{
    [ValueConversion(typeof(object), typeof(object))]
    public sealed class CharacterConverter : IValueConverter
    {
        public object Convert(object values, Type targetType, object parameter, CultureInfo culture)
        {
            string s = values.PowerToString();
            return Common.GetKeyState(VirtualKeys.CapsLock) ? s.ToUpper() : s.ToLower();
        }

        public object[] ConvertBack(object value, Type targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
