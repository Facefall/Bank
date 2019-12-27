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
using System.Windows.Threading;


namespace BankManagement_Assignment.view
{
    /// <summary>
    /// WithDraw1.xaml 的交互逻辑
    /// </summary>
    public partial class WithDraw1 : Page
    {
        private double money;
        public WithDraw1()
        {
            InitializeComponent();
        }

        private void WithDraw_Click(object sender, RoutedEventArgs e)
        {
            var query = Application.Query_Account().Where(s => s.Account_ID == AccountIdBox.Text);
            var account = query.First();

            money = double.Parse(MoneyBox.Text);

            double? interest = 0;

            var DueTime = ((DateTime)account.到期时间);
            var DueTimeYear = ((DateTime)account.到期时间).Year;
            var DueTimeMonth = ((DateTime)account.到期时间).Month;

            var Now = DateTime.Now;
            var NowYear = DateTime.Now.Year;
            var NowMonth = DateTime.Now.Month;

            if (account.Account_Type == Application.TYPE_DEMAND_DEPOSITE)
            {

            }
            else if (account.Account_Type == Application.TYPE_INSTALLMENT_FIXED_DEPOSITE)
            {
                var months = (DueTimeYear - NowYear) * 12 + (DueTimeMonth - NowMonth);

                //小于零 DueTime < Now
                //等于零 DueTime = Now 
                //大于零 DueTime > Now
                //到期后没有取款
                if (account.是否按规定存款 == 0)
                {
                    interest = account.Money * 0.00015;
                }
                else if ((DueTime).CompareTo(Now) <= 0)
                {
                    interest = account.Money * account.Fixed_deposit * 12;
                    interest += (interest + account.Money) * 0.00025;
                }
            }
            else if (account.Account_Type == Application.TYPE_FIXED_DEPOSITE)
            {
                //提前取款
                if (DueTime.CompareTo(Now) > 0) interest = account.Money * Application.RATE_FIXED_DEPOSITE_ADVANCED;
                //到期取款
                else if (DueTime.CompareTo(Now) == 0) interest = account.Money * account.Rate;
                //超期取款
                else
                {
                    if (account.Terms == Application.TERMS_1_YEAR) interest = account.Money * Application.RATE_FIXED_DEPOSITE_1_YEAR;

                    if (account.Terms == Application.TERMS_3_YEAR) interest = account.Money * Application.RATE_FIXED_DEPOSITE_3_YEAR;

                    if (account.Terms == Application.TERMS_5_YEAR) interest = account.Money * Application.RATE_FIXED_DEPOSITE_3_YEAR;

                    //超期利息
                    interest += (interest + account.Money) * Application.RATE_FIXED_DEPOSITE_OVERPASSED;
                }
            }

            var record = new Record();
            record.Account_ID = account.Account_ID;
            record.Capital = account.Money;
            record.Interest = interest;
            record.Trading_Amount = account.Money + interest;
            record.Trading_Time = DateTime.Now;
            //TODO 操作类型

            //Application.Add_Record(record);
            Show_Result();
            MoneyBox.Text = "";
            Application.Save();

        }


        //TODO 控制鼠标点击间隔
        private void Show_Result(bool flag = true)
        {
            string success = "成功";
            string faliure = "失败";
            SnackbarOne.IsActive = true;
            if (flag == true)
            {
                SnackbarOne.Message.Content = success;
            }
            else
            {
                SnackbarOne.Message.Content = faliure;
            }
            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = TimeSpan.FromMilliseconds(700);
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            SnackbarOne.IsActive = false;
        }
    }
}
