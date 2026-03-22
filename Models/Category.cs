using System;

namespace DocMgt.Models
{
    /// <summary>
    /// 分类模型
    /// </summary>
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ParentId { get; set; }
        public int SortOrder { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
