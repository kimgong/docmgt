using System.Windows;

namespace DocMgt.Helpers
{
    /// <summary>
    /// MessageBox 帮助类
    /// </summary>
    public static class MessageBoxHelper
    {
        public static MessageBoxResult Show(string message, string caption = "提示", MessageBoxButton buttons = MessageBoxButton.OK, MessageBoxImage image = MessageBoxImage.Information)
        {
            return MessageBox.Show(Application.Current.MainWindow, message, caption, buttons, image);
        }

        public static bool Confirm(string message, string caption = "确认")
        {
            return Show(message, caption, MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes;
        }
    }
}
