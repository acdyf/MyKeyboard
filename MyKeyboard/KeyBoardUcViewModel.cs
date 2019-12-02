using MyKeyboard.Methods;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace MyKeyboard
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
        /// 要切换的键盘名称
        /// </summary>
        private string changeBoardName = "1";

        /// <summary>
        /// 要切换的键盘名称1
        /// </summary>
        private string changeBoardName1 = "2";

        /// <summary>
        /// 切换键盘按键显示内容
        /// </summary>
        private string boardContent = "123";

        /// <summary>
        /// 切换键盘按键显示内容1
        /// </summary>
        private string boardContent1 = "#+=";

        /// <summary>
        /// 按键常亮控制标识
        /// </summary>
        private bool alwaysLight = false;

        /// <summary>
        /// 字母键盘可见性
        /// </summary>
        private Visibility characterBoardVisibility = Visibility.Visible;

        /// <summary>
        /// 数字键盘可见性
        /// </summary>
        private Visibility numBoardVisibility = Visibility.Collapsed;

        /// <summary>
        /// 第三个键盘可见性
        /// </summary>
        private Visibility thirdBoardVisibility = Visibility.Collapsed;

        #region 26个字母
        private string a = "a";
        private string b = "b";
        private string c = "c";
        private string d = "d";
        private string e = "e";
        private string f = "f";
        private string g = "g";
        private string h = "h";
        private string i = "i";
        private string j = "j";
        private string k = "k";
        private string l = "l";
        private string m = "m";
        private string n = "n";
        private string o = "o";
        private string p = "p";
        private string q = "q";
        private string r = "r";
        private string s = "s";
        private string t = "t";
        private string u = "u";
        private string v = "v";
        private string w = "w";
        private string x = "x";
        private string y = "y";
        private string z = "z";
        #endregion

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

        #region 26个字母
        public string A
        {
            get => a;
            set
            {
                a = value;
                RaisePropertyChanged("A");
            }
        }
        public string B
        {
            get => b;
            set
            {
                b = value;
                RaisePropertyChanged("B");
            }
        }
        public string C
        {
            get => c;
            set
            {
                c = value;
                RaisePropertyChanged("C");
            }
        }
        public string D
        {
            get => d;
            set
            {
                d = value;
                RaisePropertyChanged("D");
            }
        }
        public string E
        {
            get => e;
            set
            {
                e = value;
                RaisePropertyChanged("E");
            }
        }
        public string F
        {
            get => f;
            set
            {
                f = value;
                RaisePropertyChanged("F");
            }
        }
        public string G
        {
            get => g;
            set
            {
                g = value;
                RaisePropertyChanged("G");
            }
        }
        public string H
        {
            get => h;
            set
            {
                h = value;
                RaisePropertyChanged("H");
            }
        }
        public string I
        {
            get => i;
            set
            {
                i = value;
                RaisePropertyChanged("I");
            }
        }
        public string J
        {
            get => j;
            set
            {
                j = value;
                RaisePropertyChanged("J");
            }
        }
        public string K
        {
            get => k;
            set
            {
                k = value;
                RaisePropertyChanged("K");
            }
        }
        public string L
        {
            get => l;
            set
            {
                l = value;
                RaisePropertyChanged("L");
            }
        }
        public string M
        {
            get => m;
            set
            {
                m = value;
                RaisePropertyChanged("M");
            }
        }
        public string N
        {
            get => n;
            set
            {
                n = value;
                RaisePropertyChanged("N");
            }
        }
        public string O
        {
            get => o;
            set
            {
                o = value;
                RaisePropertyChanged("O");
            }
        }
        public string P
        {
            get => p;
            set
            {
                p = value;
                RaisePropertyChanged("P");
            }
        }
        public string Q
        {
            get => q;
            set
            {
                q = value;
                RaisePropertyChanged("Q");
            }
        }
        public string R
        {
            get => r;
            set
            {
                r = value;
                RaisePropertyChanged("R");
            }
        }
        public string S
        {
            get => s;
            set
            {
                s = value;
                RaisePropertyChanged("S");
            }
        }
        public string T
        {
            get => t;
            set
            {
                t = value;
                RaisePropertyChanged("T");
            }
        }
        public string U
        {
            get => u;
            set
            {
                u = value;
                RaisePropertyChanged("U");
            }
        }
        public string V
        {
            get => v;
            set
            {
                v = value;
                RaisePropertyChanged("V");
            }
        }
        public string W
        {
            get => w;
            set
            {
                w = value;
                RaisePropertyChanged("W");
            }
        }
        public string X
        {
            get => x;
            set
            {
                x = value;
                RaisePropertyChanged("X");
            }
        }
        public string Y
        {
            get => y;
            set
            {
                y = value;
                RaisePropertyChanged("Y");
            }
        }
        public string Z
        {
            get => z;
            set
            {
                z = value;
                RaisePropertyChanged("Z");
            }
        }
        #endregion

        /// <summary>
        /// 按键常亮控制标识
        /// </summary>
        public bool AlwaysLight
        {
            get => alwaysLight;
            set
            {
                alwaysLight = value;
                RaisePropertyChanged("AlwaysLight");
            }
        }

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

        /// <summary>
        /// 字母键盘可见性
        /// </summary>
        public Visibility CharacterBoardVisibility
        {
            get => characterBoardVisibility;
            set
            {
                characterBoardVisibility = value;
                RaisePropertyChanged("CharacterBoardVisibility");
            }
        }

        /// <summary>
        /// 数字键盘可见性
        /// </summary>
        public Visibility NumBoardVisibility
        {
            get => numBoardVisibility;
            set
            {
                numBoardVisibility = value;
                RaisePropertyChanged("NumBoardVisibility");
            }
        }

        /// <summary>
        /// 要切换的键盘名称
        /// </summary>
        public string ChangeBoardName
        {
            get => changeBoardName;
            set
            {
                changeBoardName = value;
                RaisePropertyChanged("ChangeBoardName");
            }
        }

        /// <summary>
        /// 要切换的键盘名称1
        /// </summary>
        public string ChangeBoardName1
        {
            get => changeBoardName1; set
            {
                changeBoardName1 = value;
                RaisePropertyChanged("ChangeBoardName1");

            }
        }

        /// <summary>
        /// 切换键盘按键显示内容
        /// </summary>
        public string BoardContent
        {
            get => boardContent;
            set
            {
                boardContent = value;
                RaisePropertyChanged("BoardContent");
            }
        }

        /// <summary>
        /// 切换键盘按键显示内容1
        /// </summary>
        public string BoardContent1
        {
            get => boardContent1;
            set
            {
                boardContent1 = value;
                RaisePropertyChanged("BoardContent1");
            }
        }

        /// <summary>
        /// 第三个键盘可见性
        /// </summary>
        public Visibility ThirdBoardVisibility
        {
            get => thirdBoardVisibility;
            set
            {
                thirdBoardVisibility = value;
                RaisePropertyChanged("ThirdBoardVisibility");
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            CharacterBoardVisibility = Visibility.Visible;
            NumBoardVisibility = Visibility.Hidden;
            BoardContent = Common.GetBoardInfo().FirstOrDefault().Value;
            ChangeBoardName = "2";
            ChangeBoardPressExecuteCommand = new RelayCommand(ChangeBoardPress);
            CapsPressExecuteCommand = new RelayCommand(CapsLockPress);
            KeyPressExecuteCommand = new RelayCommand(KeyPress);
            CapsLockPress(null);
        }

        /// <summary>
        /// 属性改变通知
        /// </summary>
        /// <param name="propertyName">属性名称</param>
        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// 切换键盘按键按下
        /// </summary>
        /// <param name="obj"></param>
        public void ChangeBoardPress(object obj)
        {
            if (obj != null)
            {
                string temp = obj.PowerToString();
                switch (temp)
                {
                    default:
                    case "1":
                        CharacterBoardVisibility = Visibility.Visible;
                        NumBoardVisibility = Visibility.Collapsed;
                        ThirdBoardVisibility = Visibility.Collapsed;
                        BoardContent = Common.GetBoardInfo()["2"];
                        ChangeBoardName = "2";
                        break;
                    case "2":
                        CharacterBoardVisibility = Visibility.Collapsed;
                        NumBoardVisibility = Visibility.Visible;
                        ThirdBoardVisibility = Visibility.Collapsed;
                        BoardContent1 = Common.GetBoardInfo()["3"];
                        ChangeBoardName1 = "3";
                        BoardContent = Common.GetBoardInfo()["1"];
                        ChangeBoardName = "1";
                        break;
                    case "3":
                        NumBoardVisibility = Visibility.Collapsed;
                        CharacterBoardVisibility = Visibility.Collapsed;
                        ThirdBoardVisibility = Visibility.Visible;
                        BoardContent1 = Common.GetBoardInfo()["2"];
                        ChangeBoardName1 = "2";
                        BoardContent = Common.GetBoardInfo()["1"];
                        ChangeBoardName = "1";
                        break;
                }
            }
        }

        /// <summary>
        /// Caps按键按下
        /// </summary>
        /// <param name="obj"></param>
        public void CapsLockPress(object obj)
        {
            bool isCpasLock = Common.GetKeyState(VirtualKeys.CapsLock);
            if (obj != null)
            {
                byte bkey = Common.FindVirtualKey(obj.PowerToString());
                NativeMethods.Keybd_event(bkey, 0x45, NativeMethods.KEYEVENTF_EXTENDEDKEY | 0, 0);
                NativeMethods.Keybd_event(bkey, 0x45, NativeMethods.KEYEVENTF_EXTENDEDKEY | NativeMethods.KEYEVENTF_KEYUP, 0);
                isCpasLock = !isCpasLock;
            }
            A = isCpasLock ? "A" : "a";
            B = isCpasLock ? "B" : "b";
            C = isCpasLock ? "C" : "c";
            D = isCpasLock ? "D" : "d";
            E = isCpasLock ? "E" : "e";
            F = isCpasLock ? "F" : "f";
            G = isCpasLock ? "G" : "g";
            H = isCpasLock ? "H" : "h";
            I = isCpasLock ? "I" : "i";
            J = isCpasLock ? "J" : "j";
            K = isCpasLock ? "K" : "k";
            L = isCpasLock ? "L" : "l";
            M = isCpasLock ? "M" : "m";
            N = isCpasLock ? "N" : "n";
            O = isCpasLock ? "O" : "o";
            P = isCpasLock ? "P" : "p";
            Q = isCpasLock ? "Q" : "q";
            R = isCpasLock ? "R" : "r";
            S = isCpasLock ? "S" : "s";
            T = isCpasLock ? "T" : "t";
            U = isCpasLock ? "U" : "u";
            V = isCpasLock ? "V" : "v";
            W = isCpasLock ? "W" : "w";
            X = isCpasLock ? "X" : "x";
            Y = isCpasLock ? "Y" : "y";
            Z = isCpasLock ? "Z" : "z";

            AlwaysLight = isCpasLock ? true : false;
        }

        /// <summary>
        /// 通用按键按下
        /// </summary>
        /// <param name="obj"></param>
        public void KeyPress(object obj)
        {
            if (obj != null)
            {
                byte bkey;
                string temp = obj.PowerToString();
                if (temp.ToLower().StartsWith("shift_"))
                {
                    bkey = Common.FindVirtualKey(temp.Substring(6));
                    NativeMethods.Keybd_event((byte)VirtualKeys.Shift, 0x45, NativeMethods.KEYEVENTF_EXTENDEDKEY | 0, 0);
                    NativeMethods.Keybd_event(bkey, 0x45, NativeMethods.KEYEVENTF_EXTENDEDKEY | 0, 0);
                    NativeMethods.Keybd_event(bkey, 0x45, NativeMethods.KEYEVENTF_EXTENDEDKEY | NativeMethods.KEYEVENTF_KEYUP, 0);
                    NativeMethods.Keybd_event((byte)VirtualKeys.Shift, 0x45, NativeMethods.KEYEVENTF_EXTENDEDKEY | NativeMethods.KEYEVENTF_KEYUP, 0);
                }
                else
                {
                    bkey = Common.FindVirtualKey(temp);
                    NativeMethods.Keybd_event(bkey, 0x45, NativeMethods.KEYEVENTF_EXTENDEDKEY | 0, 0);
                    NativeMethods.Keybd_event(bkey, 0x45, NativeMethods.KEYEVENTF_EXTENDEDKEY | NativeMethods.KEYEVENTF_KEYUP, 0);
                }
            }
        }

        #endregion
    }
}
