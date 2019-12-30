
using System;

namespace GSN.Modules.DemoWF.Entities
{
    public interface IDemoWFInfo
    {
        int ItemId { get; set; }
        int ModuleId { get; set; }
        string Title { get; set; }
        string Description { get; set; }
        int CreatedByUserId { get; set; }
        DateTime CreatedByDate { get; set; }
        int LastUpdatedByUserId { get; set; }
        DateTime LastUpdatedByDate { get; set; }
    }
}