using System;

namespace DocMgt.Models
{
    /// <summary>
    /// 文档模型
    /// </summary>
    public class Document
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string Category { get; set; }
        public int CategoryId { get; set; }
        public string Tags { get; set; }
        public int Version { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedTime { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
    }
}
