using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace BankManagement_Assignment.view
{
    /// <summary>
    /// Rate1.xaml 的交互逻辑
    /// </summary>
    public partial class Rate1 : Page
    {
        BankEntities Bank = new BankEntities();

        public Rate1()
        {
            InitializeComponent();
            ////Bank.Rate.Load();
            ////var query = from t in Bank.Rate
            ////            select t;
            ////dataGrid1.ItemsSource = Bank.Rate.Local;
            //using (var db = new BankEntities())
            //{
            //    db.Rate.Load();
            //    dataGrid1.ItemsSource = db.Rate.Local;
            //}
            var query = Application.Query_Rate();

            dataGrid1.ItemsSource = query.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Save();
        }
    }
}
