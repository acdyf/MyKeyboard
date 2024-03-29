﻿using System.ComponentModel;

namespace MyKeyboard.Enums
{
    /// <summary>
    /// 键盘页码
    /// </summary>
    public enum KeyBoardPageIndex
    {
        [Description("字母键盘")]
        Character = 1,
        [Description("数字键盘")]
        Number = 2,
        [Description("第三键盘")]
        Third = 3,
    }
}
