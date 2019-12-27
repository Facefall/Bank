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
    /// query1.xaml 的交互逻辑
    /// </summary>
    public partial class query1 : Page
    {
        private void showAll()
        {
            var queryRecord = Application.Query_Record();
            var queryRecordAccount = queryRecord.Join(
                Application.Query_Account().Select(_ => _),
                c => c.Account_ID,
                s => s.Account_ID,
                (c, s) => new
                {
                    s.Account_ID,
                    s.ID_Number,
                    s.Account_Type,
                    s.Name,
                    s.Money,
                    c.Operation_Type,
                    c.Trading_Time
                });
            ListBox.ItemsSource = queryRecordAccount.ToList();
        }
        public query1()
        {
            InitializeComponent();
            showAll();
        }

        private void Button_search(object sender, RoutedEventArgs e)
        {
            string content = Textbox.Text;
            string type = QueryTypeBox.Text;
            var date = dp.SelectedDate; // 选取的日期
            // 填了第一个筛选条件
            if (content !=  "")
            {
                // 填了第一个筛选条件, 没填第二个
                if(date == null)
                {
                    var queryRecord = Application.Query_Record();
                    switch (type)
                    {
                        case "身份证":
                            var queryAccount = Application.Query_Account().Where(s=>s.ID_Number == content);
                            var queryRecordAccount = queryRecord.Join(
                                queryAccount,
                                c => c.Account_ID,
                                s => s.Account_ID,
                                (c, s) => new
                                {
                                    s.Account_ID,
                                    s.ID_Number,
                                    s.Account_Type,
                                    s.Name,
                                    s.Money,
                                    c.Operation_Type,
                                    c.Trading_Time
                                });
                            ListBox.ItemsSource = queryRecordAccount.ToList();
                            break;
                        case "账号":
                            var queryAccount2 = Application.Query_Account().Where(s => s.Account_ID == content);
                            var queryRecordAccount2 = queryRecord.Join(
                                queryAccount2,
                                c => c.Account_ID,
                                s => s.Account_ID,
                                (c, s) => new
                                {
                                    s.Account_ID,
                                    s.ID_Number,
                                    s.Account_Type,
                                    s.Name,
                                    s.Money,
                                    c.Operation_Type,
                                    c.Trading_Time
                                });
                            ListBox.ItemsSource = queryRecordAccount2.ToList();
                            break;
                    }
                }
                // 填了第一个第二个筛选条件
                else
                {
                    var queryRecord = Application.Query_Record().Where(s => s.Trading_Time == date);
                    switch (type)
                    {
                        case "身份证":
                            var queryAccount = Application.Query_Account().Where(s => s.ID_Number == content);
                            var queryRecordAccount = queryRecord.Join(
                                queryAccount,
                                c => c.Account_ID,
                                s => s.Account_ID,
                                (c, s) => new
                                {
                                    s.Account_ID,
                                    s.ID_Number,
                                    s.Account_Type,
                                    s.Name,
                                    s.Money,
                                    c.Operation_Type,
                                    c.Trading_Time
                                });
                            ListBox.ItemsSource = queryRecordAccount.ToList();
                            break;
                        case "账号":
                            var queryAccount2 = Application.Query_Account().Where(s => s.Account_ID == content);
                            var queryRecordAccount2 = queryRecord.Join(
                                queryAccount2,
                                c => c.Account_ID,
                                s => s.Account_ID,
                                (c, s) => new
                                {
                                    s.Account_ID,
                                    s.ID_Number,
                                    s.Account_Type,
                                    s.Name,
                                    s.Money,
                                    c.Operation_Type,
                                    c.Trading_Time
                                });
                            ListBox.ItemsSource = queryRecordAccount2.ToList();
                            break;
                    }
                }
            }
            // 第一个筛选条件没填
            else if(content == "")
            {
                if(date == null)
                {
                    showAll();
                }
                else
                {
                    var queryAccount = Application.Query_Account();
                    var queryRecord = Application.Query_Record().Where(s => s.Trading_Time == date);
                    var queryRecordAccount = queryRecord.Join(
                        queryAccount,
                        c => c.Account_ID,
                        s => s.Account_ID,
                        (c, s) => new
                        {
                            s.Account_ID,
                            s.ID_Number,
                            s.Account_Type,
                            s.Name,
                            s.Money,
                            c.Operation_Type,
                            c.Trading_Time
                        });
                    ListBox.ItemsSource = queryRecordAccount.ToList();
                }
            }
        }
        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    string query_according = Textbox.Text;
        //    string type = QueryTypeBox.Text;
        //    var selected_date = dp.SelectedDate; // 选取的日期
        //    if (type == "当日汇总")
        //    {
        //        // 新建一个gridview, 里面填上查询结果
        //        GridView gridview2 = new GridView();
        //        gridview2.AllowsColumnReorder = true;
        //        gridview2.ColumnHeaderToolTip = "汇总";
        //        GridViewColumn column1 = new GridViewColumn();
        //        column1.DisplayMemberBinding = new Binding("Record_ID");
        //        column1.Header = "交易ID";
        //        column1.Width = 120;
        //        gridview2.Columns.Add(column1);
        //        ListBox.View = gridview2;


        //        //{
        //        //    TimeSpan ts = DateTime.Now - s.Trading_Time;
        //        //    double a = ts.TotalDays;

        //        //}
        //        //var date1 = DateTime.Parse("2019-12-25");
        //        //var date2 = date1.AddDays(1);
        //        var date3 = DateTime.Now.Date;
        //        //var query = Application.Query_Record().Where(s => s.Trading_Time.Date >= date1 && s.Trading_Time <= date2).Select(s => s);
        //        //var query = Application.Query_Record().Where(s=>DbFunctions.TruncateTime(s.Trading_Time)==date3).Select(s => s);
        //        var query = Application.Query_Record().Where(s => s.Trading_Time >= date3 && s.Trading_Time < DbFunctions.AddDays(date3, 1)).Select(s => s);

        //        ListBox.Items.Clear();

        //        MessageBox.Show("1");
        //        foreach (var item in query) ListBox.Items.Add(item);

        //    }
        //    else if (query_according == null)
        //    {
        //        var query = Application.Query_Account().Select(s => s);
        //        ListBox.Items.Clear();
        //        foreach (var item in query) ListBox.Items.Add(item);
        //    }
        //    else
        //    {
        //        var query = Application.Query_Account();
        //        switch (type)
        //        {
        //            case "身份证":
        //                query = query.Where(s => s.ID_Number == query_according).Select(s => s);
        //                break;
        //            case "账号":
        //                query = query.Where(s => s.Account_ID == query_according).Select(s => s);
        //                break;
        //            case "姓名":
        //                query = query.Where(s => s.Name == query_according).Select(s => s);
        //                break;
        //        }
        //        ListBox.Items.Clear();
        //        foreach (var item in query) ListBox.Items.Add(item);
        //    }
        //}

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
