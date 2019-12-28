
using DotNetNuke.ComponentModel.DataAnnotations;
using System;
using System.Web.Caching;

namespace GSN.Modules.Conference.Models
{
    [TableName("GSN_Conference")]
    //setup the primary key for table
    [PrimaryKey("ConferenceId", AutoIncrement = true)]
    //configure caching using PetaPoco
    [Cacheable("ConferenceInfo", CacheItemPriority.Default, 20)]
    //scope the objects to the ModuleId of a module on a page (or copy of a module on a page)
    [Scope("ModuleId")]
    public class ConferenceInfo : IConferenceInfo
    {
        public ConferenceInfo()
        {
            ConferenceId = -1;
        }

        public int ConferenceId { get; set; }

        public int ModuleId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int CreatedByUserId { get; set; }

        public DateTime CreatedOnDate { get; set; }

        public int LastUpdatedByUserId { get; set; }

        public DateTime LastUpdatedOnDate { get; set; }
    }
}
