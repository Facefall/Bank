using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BankManagement_Assignment
{
    /// <summary>
    /// LoginWindow.xaml 的交互逻辑
    /// </summary>
    //public bool Contains(string value);;
    public partial class LoginWindow : Window
    {
       // string s = "a";
       // int[] a = new int [10];

       // a.Contains("a");
        public string username;
        //设置密码，不存储
        public string setPassword;
        public LoginWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            UserNamebox.Text = string.Empty;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Content.ToString())
            {
                case "登录":this.username = UserNamebox.Text;
                            this.Close();
                    //拿过数据校验,
                    //从后台数据库查询密码加密值
                    //一致,通过
                    //不然不能关闭
                            break;
                case "注册":
                            username = string.Empty;//表用户名为空,要注册
                            break;
            }
        }

        //private void Login_click(object sender, RoutedEventArgs e)
        //{
        //   

        //}

        private void LoginPage_Minimize(object sender, RoutedEventArgs e) => this.WindowState = WindowState.Minimized;

        private void LoginPage_Close(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
