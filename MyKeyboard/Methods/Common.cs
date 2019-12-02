using MyKeyboard.Enums;
using System;
using System.Windows.Controls;

namespace MyKeyboard.Methods
{
    /// <summary>
    /// 通用方法类
    /// </summary>
    internal static class Common
    {
        /// <summary>
        /// 索引转换字母
        /// </summary>
        /// <param name="index">当前索引</param>
        /// <param name="startIndex">起始索引 默认1</param>
        /// <returns></returns>
        internal static char IndexToChar(this int index, int startIndex = 1)
        {
            return (char)('A' + index - startIndex);
        }

        /// <summary>
        /// 转换字符串
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        internal static string PowerToString(this object target)
        {
            return target == null ? string.Empty : target.ToString();
        } 

        /// <summary>
        /// 查找对应虚拟按键码
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        internal static byte FindVirtualKey(string key)
        {
            byte b = 0;
            try
            {
                b = (byte)Enum.Parse(typeof(VirtualKeys), key);
            }
            catch (Exception)
            {
            }
            return b;
        }

        /// <summary>
        /// 获取按键状态
        /// </summary>
        /// <param name="Key"></param>
        /// <returns></returns>
        internal static bool GetKeyState(VirtualKeys Key)
        {
            return (NativeMethods.GetKeyState((int)Key) == 1);
        }

        /// <summary>
        /// 判断是否处于设计模式
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        internal static bool IsInDesignMode(this Control control)
        {
            return System.ComponentModel.DesignerProperties.GetIsInDesignMode(control);
        }
    }
}
