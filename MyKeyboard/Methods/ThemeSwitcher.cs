using MyKeyboard.Enums;
using System;
using System.Windows;

namespace MyKeyboard.Methods
{
    /// <summary>
    /// 主题切换工具
    /// </summary>
    public class ThemeSwitcher
    {
        /// <summary>
        /// 切换主题
        /// </summary>
        /// <param name="theme">Theme枚举</param>
        /// <param name="element">FrameworkElement对象</param>
        public static void SwitchTheme(Themes theme, FrameworkElement element)
        {
            element.Resources.MergedDictionaries.RemoveAt(element.Resources.MergedDictionaries.Count - 1);
            element.Resources.MergedDictionaries.Add(new ResourceDictionary()
            {
                Source = GetThemeUri(theme)
            }) ;
        }

        /// <summary>
        /// 获取主题资源文件
        /// </summary>
        /// <param name="theme"></param>
        /// <returns></returns>
        public static Uri GetThemeUri(Themes theme)
        {
            Uri uri = null;
            switch (theme)
            {
                default:
                case Themes.DEFAULT:
                    uri = new Uri("/MyKeyboard;component/Resources/Colors/Colors.xaml", UriKind.Relative);
                    break;
                case Themes.LIGHT:
                    uri = new Uri("/MyKeyboard;component/Resources/Colors/ColorsLight.xaml", UriKind.Relative);
                    break;
            }
            return uri;
        }
    }
}
