using System;
using System.Net;
using System.Text;

namespace DocMgt.Services
{
    /// <summary>
    /// API 服务实现
    /// </summary>
    public class ApiService : IApiService
    {
        private readonly string _baseUrl = "http://localhost:8080/api";
        private string _token;

        public bool Login(string username, string password)
        {
            try
            {
                // TODO: 实现登录 API 调用
                // 模拟登录成功
                _token = "mock_token_" + Guid.NewGuid().ToString();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Logout()
        {
            _token = null;
        }

        public string GetDocumentList(int categoryId = 0, string keyword = "")
        {
            // TODO: 实现获取文档列表 API 调用
            return "[]";
        }

        public bool UploadDocument(string filePath, int categoryId, string description)
        {
            // TODO: 实现上传文档 API 调用
            return true;
        }

        public bool DownloadDocument(int documentId, string savePath)
        {
            // TODO: 实现下载文档 API 调用
            return true;
        }

        public bool DeleteDocument(int documentId)
        {
            // TODO: 实现删除文档 API 调用
            return true;
        }

        public string GetCategoryList()
        {
            // TODO: 实现获取分类列表 API 调用
            return "[]";
        }
    }
}
