using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using DocMgt.Helpers;

namespace DocMgt
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            Closed += MainWindow_Closed;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // 启用防截屏保护
            ScreenCaptureProtection.EnableProtection(this);
            LoadFileList();
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            // 禁用防截屏保护
            ScreenCaptureProtection.DisableProtection(this);
        }

        private void LoadFileList()
        {
            // TODO: 从服务器获取文件列表
            // 模拟数据
            FileList.ItemsSource = new ObservableCollection<FileItem>
            {
                new FileItem { Name = "测试文档 1.pdf", Path = "/docs/test1.pdf" },
                new FileItem { Name = "测试文档 2.docx", Path = "/docs/test2.docx" },
                new FileItem { Name = "测试图片 1.png", Path = "/images/test1.png" },
            };
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            LoadFileList();
        }

        private void FileList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var file = FileList.SelectedItem as FileItem;
            if (file != null)
            {
                FileNameText.Text = file.Name;
                // TODO: 加载文件预览
                // PreviewBrowser.Navigate(file.Path);
            }
        }
    }

    public class FileItem
    {
        public string Name { get; set; }
        public string Path { get; set; }
    }
}
