
using System;
using System.Web.Caching;
using DotNetNuke.ComponentModel.DataAnnotations;

namespace GSN.Modules.PaDare.Entities
{
    [TableName("GSN_PaDare")]
    [PrimaryKey("ItemId", AutoIncrement = true)]
    [Cacheable("PaDareInfo", CacheItemPriority.Default, 20)]
    [Scope("ModuleId")]
    public class PaDareInfo : IPaDareInfo
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