using BankManagement_Assignment.viewControler;
using Microsoft.Win32;
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
    /// StuffManage.xaml 的交互逻辑
    /// </summary>
    public partial class StuffManage : Page
    {
        public StuffManage()
        {
            InitializeComponent();
            var query = Application.Query_Employer();
            ListBox.ItemsSource = query.ToList();

            //var photofilePath = "";
            //OpenFileDialog ofd = new OpenFileDialog();
            //if (ofd.ShowDialog() == true)
            //{
            //    photofilePath = ofd.FileName;
            //    //照片显示到image控件内
            //    BitmapImage bi = new BitmapImage();
            //    bi.BeginInit();
            //    bi.UriSource = new Uri(photofilePath, UriKind.RelativeOrAbsolute);
            //    bi.EndInit();

            //}
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //OperateRecord page = new OperateRecord();
            //NavigationService ns = NavigationService.GetNavigationService(this);
            //ns.Navigate(page);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
        ///////////js
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            AddStuff w = new AddStuff();
            w.ShowDialog();
            var query = Application.Query_Employer();
            ListBox.ItemsSource = query.ToList();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //获得用户选定的行对象
            var item = ListBox.SelectedItem as Employer;
            if (item == null)
            {
                MessageBox.Show("请先选择要删除的学生信息！");
                return;
            }
            MessageBoxResult result = MessageBox.Show("您确定要删除该学生的信息吗？", "删除确认", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                var context = new BankEntities();
                var q = from t in context.Employer
                        where t.Employer_ID == item.Employer_ID
                        select t;
                if (q != null)
                {
                    try
                    {
                        context.Employer.Remove(q.FirstOrDefault());
                        int i = context.SaveChanges();
                        MessageBox.Show(string.Format("成功删除{0}个学生信息", i));
                    }
                    catch
                    {
                        MessageBox.Show("删除失败！");
                    }
                }
            }
            var query = Application.Query_Employer();
            ListBox.ItemsSource = query.ToList();

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            var item = ListBox.SelectedItem as Employer;
            if (item == null)
            {
                MessageBox.Show("请先选择要修改的学生信息！");
                return;
            }
            EditEmployer edit = new EditEmployer(item.Employer_ID);
            edit.ShowDialog();
            var query = Application.Query_Employer();
            ListBox.ItemsSource = query.ToList();

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (QueryTypeBox.SelectedIndex == 0)
            {
                using (var context = new BankEntities())
                {
                    var q = from t1 in context.Employer
                            where t1.Employer_ID == key.Text
                            select t1;
                    foreach (var item in q)
                    {
                        ListBox.ItemsSource = q.ToList();
                    }

                }
            }
            else if (QueryTypeBox.SelectedIndex == 1)
            {
                using (var context = new BankEntities())
                {
                    var q = from t1 in context.Employer
                            where t1.Name == key.Text
                            select t1;
                    foreach (var item in q)
                    {
                        ListBox.ItemsSource = q.ToList();
                    }
                }
            }
        }
    }
}
