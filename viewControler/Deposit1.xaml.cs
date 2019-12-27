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

namespace BankManagement_Assignment.view
{
    /// <summary>
    /// Deposite1.xaml 的交互逻辑
    /// 存款页面
    /// </summary>
    /// 
    public partial class Deposite1 : Page
    {
        public string accountID;
        public double money;
        public Deposite1()
        {
            InitializeComponent();
        }

        //点击确认存款按钮
        //金额大于0
        //要求账号名 存在
        private void Deposite_Confirm(object sender, RoutedEventArgs e)
        {
            if (money >= 0)
            {
                var query = Application.Query_Account().Where(s => s.Account_ID == AccountIdBox.Text);
                if (query.Count() == 1)
                {
                    query.First().Money += double.Parse(moneyBox.Text); 
                    Application.Save();
                }
            }
            moneyBox.Text = "";
        }
    }
}
