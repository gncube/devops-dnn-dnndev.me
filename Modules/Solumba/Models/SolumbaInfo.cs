
using DotNetNuke.ComponentModel.DataAnnotations;
using System;
using System.Web.Caching;

namespace GSN.Modules.Solumba.Models
{
    [TableName("GSN_Solumba")]
    //setup the primary key for table
    [PrimaryKey("SolumbaId", AutoIncrement = true)]
    //configure caching using PetaPoco
    [Cacheable("SolumbaInfo", CacheItemPriority.Default, 20)]
    //scope the objects to the ModuleId of a module on a page (or copy of a module on a page)
    [Scope("ModuleId")]
    public class SolumbaInfo : ISolumbaInfo
    {
        public SolumbaInfo()
        {
            SolumbaId = -1;
        }

        public int SolumbaId { get; set; }

        public int ModuleId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int CreatedByUserId { get; set; }

        public DateTime CreatedOnDate { get; set; }

        public int LastUpdatedByUserId { get; set; }

        public DateTime LastUpdatedOnDate { get; set; }
    }
}
