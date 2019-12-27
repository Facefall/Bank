using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace BankManagement_Assignment.viewControler
{
    /// <summary>
    /// EditEmployer.xaml 的交互逻辑
    /// </summary>
    public partial class EditEmployer : Window
    {
        Employer editEmployer;

        public EditEmployer()
        {
            InitializeComponent();
        }
        public EditEmployer(string Employer_ID)
        {
            InitializeComponent();

            showStudent(Employer_ID);
        }

        //显示学生的信息
        public void showStudent(string id)
        {
            var q = Application.Query_Employer().Where(s => s.Employer_ID == id);
            //var q = from t in context.Employer
            //        where t.Employer_ID == id
            //        select t;
            if (q != null)
            {
                editEmployer = q.FirstOrDefault();
                this.txtEMHao.Text = id;
                this.txtXingMing.Text = editEmployer.Name;
                if (editEmployer.Gender == "男")
                    this.radioM.IsChecked = true;
                else
                    this.radioF.IsChecked = true;

                this.txtAge.Text = editEmployer.Age.ToString();
                //显示照片
                if (editEmployer.Picture != null)
                {
                    MemoryStream ms = new MemoryStream(editEmployer.Picture);
                    BitmapImage bi = new BitmapImage();
                    bi.BeginInit();
                    bi.StreamSource = ms;
                    bi.EndInit();
                    this.imagePhoto.Source = bi;
                }
            }
        }

        string photofilePath = "";
        //浏览照片
        private void Buttonbrowse_Click_1(object sender, RoutedEventArgs e)
        {
            //清空image控件内的图片
            this.imagePhoto.Source = null;
            //打开对话框选择图像
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == true)
            {
                photofilePath = ofd.FileName;
                //图像显示到image控件内
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.UriSource = new Uri(photofilePath, UriKind.RelativeOrAbsolute);
                bi.EndInit();
                this.imagePhoto.Source = bi;
            }
        }
        //确定修改
        private void buttonOK_Click(object sender, RoutedEventArgs e)
        {
            editEmployer.Employer_ID = this.txtEMHao.Text;
            editEmployer.Name = this.txtXingMing.Text;
            editEmployer.Gender = this.radioM.IsChecked == true ? "男" : "女";
            editEmployer.Age = int.Parse(this.txtAge.Text);
            editEmployer.Sallery = double.Parse(this.txtSalary.Text);
            editEmployer.Password = this.txtPsw.Text;



            //照片(读取照片内容到字节数组bt中）
            if (photofilePath != "")
            {
                Stream mystream = File.OpenRead(photofilePath);
                byte[] bt = new byte[mystream.Length];
                mystream.Read(bt, 0, (int)mystream.Length);
                editEmployer.Picture = bt;
            }
            //保存对象的修改
            try
            {
                Application.Update_Employer(editEmployer);
                Application.Save();
                MessageBox.Show(string.Format("成功修改员工信息"));
            }
            catch (Exception err)
            {
                MessageBox.Show("修改员工失败！" + err);
            }
            this.Close();//关闭当前窗口
        }
        //取消
        private void ButtonCANCEL_Click(object sender, RoutedEventArgs e)
        {

            this.txtXingMing.Text = "";
            this.txtEMHao.Text = "";
            this.txtAge.Text = "";
            this.txtSalary.Text = "";
            this.txtPsw.Text = "";
            this.imagePhoto.Source = null;
        }
    }

}


