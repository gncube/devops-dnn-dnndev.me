
using System;

namespace GSN.Modules.Announcements.Entities
{
    public interface IAnnouncementInfo
    {
        int AnnouncementId { get; set; }
        int ModuleId { get; set; }
        string Title { get; set; }
        string URL { get; set; }
        string Description { get; set; }
        DateTime ExpireDate { get; set; }
        DateTime PublishDate { get; set; }
        int ViewOrder { get; set; }
        bool IsDeleted { get; set; }
        int CreatedByUserId { get; set; }
        DateTime CreatedOnDate { get; set; }
        int LastUpdatedByUserId { get; set; }
        DateTime LastUpdatedOnDate { get; set; }
     }
}
