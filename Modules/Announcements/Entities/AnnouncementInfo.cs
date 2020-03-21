
using System;
using System.Web.Caching;
using DotNetNuke.ComponentModel.DataAnnotations;

namespace GSN.Modules.Announcements.Entities
{
    [TableName("GSN_Announcements")]
    [PrimaryKey("AnnouncementId", AutoIncrement = true)]
    [Cacheable("AnnouncementInfo", CacheItemPriority.Default, 20)]
    [Scope("ModuleId")]
    public class AnnouncementInfo : IAnnouncementInfo
    {
        public int AnnouncementId { get;set; }
        public int ModuleId { get;set; }
        public string Title { get;set; }
        public string URL { get;set; }
        public string Description { get;set; }
        public DateTime ExpireDate { get;set; }
        public DateTime PublishDate { get;set; }
        public int ViewOrder { get;set; }
        public bool IsDeleted { get;set; }
        public int CreatedByUserId { get;set; }
        public DateTime CreatedOnDate { get;set; }
        public int LastUpdatedByUserId { get;set; }
        public DateTime LastUpdatedOnDate { get;set; }
    }
}
