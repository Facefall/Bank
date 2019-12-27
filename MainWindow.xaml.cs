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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BankManagement_Assignment
{

    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    /// 
    //
    public partial class MainWindow : Window
    {
         
        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            this.SourceInitialized += MainWindow_SourceInitialized;
        }
        void MainWindow_SourceInitialized(object sender, System.EventArgs e)
        {
            LoginWindow login = new LoginWindow();
            login.ShowDialog();
            MainPage.Source = new Uri("viewControler/MainPage1.xaml", UriKind.Relative);
        }

        public void route(string path) => MainPage.Source = new Uri("viewControler/" + path + ".xaml", UriKind.Relative);
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button item = e.Source as Button;
            if (item != null)
            {
                route(item.Name.ToString());
            }
        }


        private void Page_Minimize(object sender, RoutedEventArgs e) => this.WindowState = WindowState.Minimized;

        private void Page_Close(object sender, RoutedEventArgs e)
        {
            Application.Close();
            Application.Current.Shutdown();
        }

        private void GridBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }

    

}
