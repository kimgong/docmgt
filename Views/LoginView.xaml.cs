using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DocMgt.Helpers;

namespace DocMgt.Views
{
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void Phone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // 只允许输入数字
            e.Handled = !Regex.IsMatch(e.Text, "^[0-9]+$");
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string phone = txtPhone.Text.Trim();
            string password = txtPassword.Password;

            if (string.IsNullOrEmpty(phone))
            {
                txtError.Text = "请输入手机号";
                txtError.Visibility = Visibility.Visible;
                return;
            }

            if (phone.Length != 11)
            {
                txtError.Text = "手机号格式不正确";
                txtError.Visibility = Visibility.Visible;
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                txtError.Text = "请输入密码";
                txtError.Visibility = Visibility.Visible;
                return;
            }

            // TODO: 调用登录验证 API
            // 模拟登录成功
            MessageBoxHelper.Show("登录成功！", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
            this.DialogResult = true;
        }
    }
}
