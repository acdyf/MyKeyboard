using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MyKeyboard.Methods
{
    /// <summary>
    /// 通用方法类
    /// </summary>
    internal static class Common
    {
        /// <summary>
        /// 键盘信息字典
        /// </summary>
        private static Dictionary<string, string> keyValuePairs;

        /// <summary>
        /// 获取键盘信息
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetBoardInfo()
        {
            if (keyValuePairs == null || keyValuePairs.Count == 0)
            {
                keyValuePairs = new Dictionary<string, string>
                {
                    { "1", "ABC" },
                    { "2", "123" },
                    { "3", "#+=" }
                };
            }
            return keyValuePairs;
        }

        /// <summary>
        /// 转换字符串
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static string PowerToString(this object target)
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
