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

namespace BankManagement_Assignment.MainPage
{
    /// <summary>
    /// MainPage.xaml 的交互逻辑
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        //开户
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            double money;
            if(double.TryParse(MoneyBox.Text, out money))
            {
                Account account = new Account();
                account.Name = NameBox.Text;
                account.Password = PasswordBox.Password;
                account.ID_Number = IDBox.Text;
                account.Money = money;
                if (AccountTypeBox.Text == "定期1年")
                {
                    account.Terms = Application.TERMS_1_YEAR;
                    account.Account_Type = Application.TYPE_FIXED_DEPOSITE;

                }
                else if (AccountTypeBox.Text == "定期3年")
                {
                    account.Terms = Application.TERMS_3_YEAR;
                    account.Account_Type = Application.TYPE_FIXED_DEPOSITE;
                }
                else if (AccountTypeBox.Text == "定期5年")
                {
                    account.Terms = Application.TERMS_5_YEAR;
                    account.Account_Type = Application.TYPE_FIXED_DEPOSITE;
                }
                else if (AccountTypeBox.Text == " 活期")
                {
                    account.Terms = null;
                    account.Account_Type = Application.TYPE_DEMAND_DEPOSITE;
                }
                else
                {
                    account.Terms = Application.TERMS_1_YEAR;
                    account.Account_Type = Application.TYPE_INSTALLMENT_FIXED_DEPOSITE;
                    account.Fixed_deposit = money;
                }
                account.Opening_Time = DateTime.Now;
                account.Rate = Application.Get_Rate(account.Account_Type, account.Terms);
                Application.Add_Account(account);
            }

        }

        //计算利息
        //要先检查account 存款期限 存到哪一年
        //
        private void Calculate_Interest(Account account)
        {
            //var query = Application.Query_Record().Where(s => s.Account_ID == account.Account_ID);
            Record record = new Record();
            record.Account_ID = account.Account_ID;
            record.Trading_Time = DateTime.Now;
            record.Interest = account.Rate * account.Terms;

        }

    }
}
