
using System;
using System.Web.Caching;
using DotNetNuke.ComponentModel.DataAnnotations;
using DotNetNuke.Entities.Users;

namespace GSN.Modules.Documents.Entities
{
    [TableName("GSN_Documents")]
    [PrimaryKey("DocumentId", AutoIncrement = true)]
    [Cacheable("DocumentsInfo", CacheItemPriority.Default, 20)]
    [Scope("ModuleId")]
    public class DocumentsInfo : IDocumentsInfo
    {
        public int DocumentId { get; set; }

        public int ModuleId { get; set; }

        public int GroupId { get; set; }
        public DateTime CohortStartDate { get; set; }
        public int FileId { get; set; }
        public string Action { get; set; }
        public int ContentItemID { get; set; }

        public int CreatedByUserId { get; set; }

        public DateTime CreatedOnDate { get; set; }

        public int LastModifiedByUserId { get; set; }

        public DateTime LastModifiedOnDate { get; set; }

    }
}