using System.Collections.ObjectModel;
using DocMgt.Models;

namespace DocMgt.ViewModels
{
    /// <summary>
    /// 主窗口 ViewModel
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private string _statusMessage;
        private User _currentUser;

        public string StatusMessage
        {
            get { return _statusMessage; }
            set { SetProperty(ref _statusMessage, value); }
        }

        public User CurrentUser
        {
            get { return _currentUser; }
            set { SetProperty(ref _currentUser, value); }
        }

        public ObservableCollection<Document> Documents { get; set; }
        public ObservableCollection<Category> Categories { get; set; }

        public MainViewModel()
        {
            Documents = new ObservableCollection<Document>();
            Categories = new ObservableCollection<Category>();
            StatusMessage = "就绪";
        }
    }
}
