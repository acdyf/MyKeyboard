
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyKeyboard.Methods
{
    internal static class Common
    {
        /// <summary>
        /// 转换字符串
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        static public string PowerToString(this object target)
        {
            return target == null ? string.Empty : target.ToString();
        }

        /// <summary>
        /// 查找对应虚拟按键码
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        internal static byte FintVirtualKey(string key)
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
        /// 判断是否为大写字母
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        internal static bool IsUpperLetter(string s)
        {
            return Regex.IsMatch(s, "^[A-Z]+$");
        }
    }
}
