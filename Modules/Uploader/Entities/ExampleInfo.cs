
using System;
using System.Web.Caching;
using DotNetNuke.ComponentModel.DataAnnotations;

namespace GSN.Modules.Uploader.Entities
{
    [TableName("gsn_Uploader")]
    [PrimaryKey("ItemId", AutoIncrement = true)]
    [Cacheable("UploaderInfo", CacheItemPriority.Default, 20)]
    [Scope("ModuleId")]
    public class UploaderInfo : IUploaderInfo
    {
        public int ItemId { get; set; }

        public int ModuleId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int CreatedByUserId { get; set; }

        public DateTime CreatedByDate { get; set; }

        public int LastUpdatedByUserId { get; set; }

        public DateTime LastUpdatedByDate { get; set; }
    }
}