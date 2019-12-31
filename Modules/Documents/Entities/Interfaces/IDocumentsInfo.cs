
using System;

namespace GSN.Modules.Documents.Entities
{
    public interface IDocumentsInfo
    {
        int DocumentId { get; set; }
        int ModuleId { get; set; }
        int GroupId { get; set; }
        DateTime CohortStartDate { get; set; }
        int FileId { get; set; }
        string Action { get; set; }
        int ContentItemID { get; set; }
        int CreatedByUserId { get; set; }
        DateTime CreatedOnDate { get; set; }
        int LastModifiedByUserId { get; set; }
        DateTime LastModifiedOnDate { get; set; }
    }
}