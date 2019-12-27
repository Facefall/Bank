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
    /// AddStuff.xaml 的交互逻辑
    /// </summary>
    public partial class AddStuff : Window
    {
        public AddStuff()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, RoutedEventArgs e)
        {
            Employer em = new Employer();
            em.Employer_ID = this.txtEMHao.Text;
            em.Name = this.txtXingMing.Text;
            em.Gender = "男";
            //年龄
            int num = -1;
            bool flag = int.TryParse(txtAge.Text, out num);
            if (flag)
            {
                em.Age = num;
            }
            else
            {
                MessageBox.Show("输入年纪类型不合法！");
            }
            //em.Gender = this.radioM.IsChecked == true ? (byte)1 : 0;

            double num1;
            bool flag1 = double.TryParse(txtSalary.Text, out num1);
            if (flag1)
            {
                em.Sallery = num1;
            }
            else
            {
                MessageBox.Show("输入工资类型不合法！");
            }

            em.Password = this.txtPsw.Text;
            if (photofilePath != "")
            {
                Stream mystream = File.OpenRead(photofilePath);
                byte[] bt = new byte[mystream.Length];
                mystream.Read(bt, 0, (int)mystream.Length);
                em.Picture = bt;
            }
            Application.Add_Employer(em);
            Application.Save();
            this.Close();

        }
        string photofilePath = "";
        //浏览照片
        private void Buttonbrowse_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == true)
            {
                photofilePath = ofd.FileName;
                //照片显示到image控件内
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.UriSource = new Uri(photofilePath, UriKind.RelativeOrAbsolute);
                bi.EndInit();
                this.imagePhoto.Source = bi;
            }
        }

        private void ButtonCANCEL_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
