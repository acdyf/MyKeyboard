using System.Windows;

namespace WpfApp1
{
    /// <summary>y
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        int temp = 0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (temp == 0)
            {
                KeyBoardUc.SwitchTheme(MyKeyboard.Enums.Themes.LIGHT);
                temp = 1;
            }
            else
            {
                KeyBoardUc.SwitchTheme(MyKeyboard.Enums.Themes.DEFAULT);
                temp = 0;
            }
        }
    }
}
