
using System;

namespace GSN.Modules.Sermon.Entities
{
    public interface ISermonInfo
    {
        int ItemId { get; set; }
        int ModuleId { get; set; }
        string Title { get; set; }
        string Description { get; set; }
        bool IsDeleted { get; set; }
        int CreatedByUserId { get; set; }
        DateTime CreatedOnDate { get; set; }
        int LastUpdatedByUserId { get; set; }
        DateTime LastUpdatedOnDate { get; set; }
     }
}
