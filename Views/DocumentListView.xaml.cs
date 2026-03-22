using System.Windows;
using System.Windows.Controls;
using DocMgt.Models;
using DocMgt.Helpers;

namespace DocMgt.Views
{
    public partial class DocumentListView : UserControl
    {
        public DocumentListView()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            // TODO: 从 API 加载文档列表
            // 模拟数据
            dgDocuments.ItemsSource = new System.Collections.ObjectModel.ObservableCollection<Document>
            {
                new Document { Id = 1, Title = "测试文档 1", Category = "技术文档", Version = 1, CreatedTime = System.DateTime.Now, Status = "正常" },
                new Document { Id = 2, Title = "测试文档 2", Category = "管理文档", Version = 1, CreatedTime = System.DateTime.Now.AddDays(-1), Status = "正常" },
            };
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            // TODO: 调用搜索 API
        }

        private void Upload_Click(object sender, RoutedEventArgs e)
        {
            // TODO: 实现上传功能
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void Download_Click(object sender, RoutedEventArgs e)
        {
            // TODO: 实现下载功能
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            // TODO: 实现删除功能
        }

        private void Preview_Click(object sender, RoutedEventArgs e)
        {
            // TODO: 实现预览功能
        }
    }
}
