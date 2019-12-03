using MyKeyboard.Enums;
using MyKeyboard.Methods;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace MyKeyboard.ViewModel
{
    /// <summary>
    /// 键盘控件视图模型
    /// </summary>
    class KeyBoardUcViewModel : INotifyPropertyChanged
    {
        #region Events

        /// <summary>
        /// 属性改变
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Fileds

        /// <summary>
        /// 字母集合
        /// </summary>
        private ObservableCollection<string> characters = new ObservableCollection<string>();

        /// <summary>
        /// 当前键盘页码
        /// </summary>
        private int currentPage = 1;

        /// <summary>
        /// 按键常亮控制标识
        /// </summary>
        private bool alwaysLight = false;

        /// <summary>
        /// 跳转键盘页码
        /// </summary>
        private int goToPage = 2;

        #endregion

        #region Constructor

        /// <summary>
        /// 键盘控件视图模型
        /// </summary>
        public KeyBoardUcViewModel()
        {
            Init();
        }

        #endregion

        #region Properties

        #region 命令

        /// <summary>
        /// Cpas按下命令
        /// </summary>
        public ICommand CapsPressExecuteCommand { get; set; }

        /// <summary>
        /// 通用按键按下命令
        /// </summary>
        public ICommand KeyPressExecuteCommand { get; set; }

        /// <summary>
        /// 切换键盘按下命令
        /// </summary>
        public ICommand ChangeBoardPressExecuteCommand { get; set; }

        #endregion

        /// <summary>
        /// 字母集合属性
        /// </summary>
        public ObservableCollection<string> Characters
        {
            get => characters;
            set
            {
                characters = value;
                RaisePropertyChanged(nameof(Characters));
            }
        }

        /// <summary>
        /// 按键常亮控制标识
        /// </summary>
        public bool AlwaysLight
        {
            get => alwaysLight;
            set
            {
                alwaysLight = value;
                RaisePropertyChanged(nameof(this.AlwaysLight));
            }
        }

        /// <summary>
        /// 当前键盘页码
        /// </summary>
        public int CurrentPage
        {
            get => currentPage;
            set
            {
                currentPage = value;
                RaisePropertyChanged(nameof(this.CurrentPage));
            }
        }

        /// <summary>
        /// 跳转键盘页码
        /// </summary>
        public int GoToPage
        {
            get => goToPage;
            set
            {
                goToPage = value;
                RaisePropertyChanged(nameof(this.GoToPage));
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            Characters = new ObservableCollection<string>();
            for (int i = 1; i <= 26; i++)
            {
                Characters.Add(Common.IndexToChar(i).ToString());
            }
            CurrentPage = (int)KeyBoardPageIndex.Character;
            GoToPage = (int)KeyBoardPageIndex.Number;
            ChangeBoardPressExecuteCommand = new RelayCommand(ChangeBoardPress);
            CapsPressExecuteCommand = new RelayCommand(CapsLockPress);
            KeyPressExecuteCommand = new RelayCommand(KeyPress);
            CapsLockPress(null);
        }

        /// <summary>
        /// 属性改变通知
        /// </summary>
        /// <param name="propertyName">属性名称</param>
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// 切换键盘按键按下
        /// </summary>
        /// <param name="obj"></param>
        private void ChangeBoardPress(object obj)
        {
            if (obj != null)
            {
                var temp = Enum.Parse(typeof(KeyBoardPageIndex), obj.ToString());
                switch (temp)
                {
                    default:
                    case KeyBoardPageIndex.Character:
                        CurrentPage = (int)KeyBoardPageIndex.Character;
                        GoToPage = (int)KeyBoardPageIndex.Number;
                        break;
                    case KeyBoardPageIndex.Number:
                        CurrentPage = (int)KeyBoardPageIndex.Number;
                        GoToPage = (int)KeyBoardPageIndex.Character;
                        break;
                    case KeyBoardPageIndex.Third:
                        CurrentPage = (int)KeyBoardPageIndex.Third;
                        GoToPage = (int)KeyBoardPageIndex.Character;
                        break;
                }
            }
        }

        /// <summary>
        /// Caps按键按下
        /// </summary>
        /// <param name="obj"></param>
        private void CapsLockPress(object obj)
        {
            bool isCpasLock = Common.GetKeyState(VirtualKeys.CapsLock);
            if (obj != null)
            {
                byte bkey = Common.FindVirtualKey(obj.PowerToString());
                NativeMethods.Keybd_event(bkey, 0x45, NativeMethods.KEYEVENTF_EXTENDEDKEY | 0, 0);
                NativeMethods.Keybd_event(bkey, 0x45, NativeMethods.KEYEVENTF_EXTENDEDKEY | NativeMethods.KEYEVENTF_KEYUP, 0);
                isCpasLock = !isCpasLock;
            }

            for (int i = 0; i < Characters.Count; i++)
            {
                Characters[i] = isCpasLock ? Characters[i].ToUpper() : Characters[i].ToLower();
            }

            AlwaysLight = isCpasLock ? true : false;
        }

        /// <summary>
        /// 通用按键按下
        /// </summary>
        /// <param name="obj"></param>
        private void KeyPress(object obj)
        {
            if (obj != null)
            {
                byte bkey;
                string temp = obj.PowerToString();
                if (temp.ToLower().StartsWith("shift_"))
                {
                    bkey = Common.FindVirtualKey(temp.Substring(6));
                    NativeMethods.Keybd_event((byte)VirtualKeys.Shift, 0, NativeMethods.KEYEVENTF_EXTENDEDKEY | 0, 0);
                    NativeMethods.Keybd_event(bkey, 0, NativeMethods.KEYEVENTF_EXTENDEDKEY | 0, 0);
                    NativeMethods.Keybd_event(bkey, 0, NativeMethods.KEYEVENTF_EXTENDEDKEY | NativeMethods.KEYEVENTF_KEYUP, 0);
                    NativeMethods.Keybd_event((byte)VirtualKeys.Shift, 0, NativeMethods.KEYEVENTF_EXTENDEDKEY | NativeMethods.KEYEVENTF_KEYUP, 0);
                }
                else
                {
                    bkey = Common.FindVirtualKey(temp);
                    NativeMethods.Keybd_event(bkey, 0, NativeMethods.KEYEVENTF_EXTENDEDKEY | 0, 0);
                    NativeMethods.Keybd_event(bkey, 0, NativeMethods.KEYEVENTF_EXTENDEDKEY | NativeMethods.KEYEVENTF_KEYUP, 0);
                }
            }
        }

        #endregion
    }
}
