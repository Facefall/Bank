using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Web;

namespace BankManagement_Assignment.view
{
    /// <summary>
    /// UpdatePassword1.xaml 的交互逻辑
    /// </summary>
    public partial class UpdatePassword1 : Page
    {
        public UpdatePassword1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordBox.Password.Trim() != PasswordBox2.Password.Trim())
            {
                MessageBox.Show("两次密码不一致");
                return;
            }
            //TODO 还需要更改管理员密码
            //疑惑： 是否应该与更改顾客账号写在一起
            //只是顾客账号
            var query = Application.Query_Account().Where(s => s.Account_ID == NameTextBox.Text);
            if (query.Count() == 1) query.First().Password = (PasswordBox.Password.Trim());            
            Application.Save();
        }

        public static string GetMD5(string sDataIn)
        {
            byte[] bytValue, bytHash;
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            bytValue = System.Text.Encoding.UTF8.GetBytes(sDataIn);
            bytHash = md5.ComputeHash(bytValue);
            md5.Clear();
            string sTemp = "";
            for (int i = 0; i < bytHash.Length; i++)    sTemp += bytHash[i].ToString("X").PadLeft(2, '0');
            return sTemp.ToLower();
        }
    }
}
