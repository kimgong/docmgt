using System.Windows;
using DocMgt.Views;

namespace DocMgt
{
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // 显示登录窗口
            var loginView = new LoginView();
            if (loginView.ShowDialog() == true)
            {
                // 登录成功，显示主窗口
                var mainWindow = new MainWindow();
                mainWindow.Show();
            }
            else
            {
                // 登录失败或取消，退出应用
                Shutdown();
            }
        }
    }
}
