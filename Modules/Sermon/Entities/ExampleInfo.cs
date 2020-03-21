
using System;
using System.Web.Caching;
using DotNetNuke.ComponentModel.DataAnnotations;

namespace GSN.Modules.Sermon.Entities
{
    [TableName("GSN_Sermon")]
    [PrimaryKey("ItemId", AutoIncrement = true)]
    [Cacheable("SermonInfo", CacheItemPriority.Default, 20)]
    [Scope("ModuleId")]
    public class SermonInfo : ISermonInfo
    {
        public int ItemId { get; set; }

        public int ModuleId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsDeleted { get; set; }

        public int CreatedByUserId { get; set; }

        public DateTime CreatedOnDate { get; set; }

        public int LastUpdatedByUserId { get; set; }

        public DateTime LastUpdatedOnDate { get; set; }
    }
}
