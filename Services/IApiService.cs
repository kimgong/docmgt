namespace DocMgt.Services
{
    /// <summary>
    /// API 服务接口
    /// </summary>
    public interface IApiService
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        bool Login(string username, string password);

        /// <summary>
        /// 用户登出
        /// </summary>
        void Logout();

        /// <summary>
        /// 获取文档列表
        /// </summary>
        string GetDocumentList(int categoryId = 0, string keyword = "");

        /// <summary>
        /// 上传文档
        /// </summary>
        bool UploadDocument(string filePath, int categoryId, string description);

        /// <summary>
        /// 下载文档
        /// </summary>
        bool DownloadDocument(int documentId, string savePath);

        /// <summary>
        /// 删除文档
        /// </summary>
        bool DeleteDocument(int documentId);

        /// <summary>
        /// 获取分类列表
        /// </summary>
        string GetCategoryList();
    }
}
