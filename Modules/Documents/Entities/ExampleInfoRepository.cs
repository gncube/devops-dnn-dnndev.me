
using System.Collections.Generic;
using DotNetNuke.Data;

namespace GSN.Modules.Documents.Entities
{
    public class DocumentsInfoRepository
    {
        public void CreateItem(DocumentsInfo i)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<DocumentsInfo>();
                rep.Insert(i);
            }
        }

        public void DeleteItem(int itemId, int moduleId)
        {
            var i = GetItem(itemId, moduleId);
            DeleteItem(i);
        }

        public void DeleteItem(DocumentsInfo i)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<DocumentsInfo>();
                rep.Delete(i);
            }
        }

        public IEnumerable<DocumentsInfo> GetItems(int moduleId)
        {
            IEnumerable<DocumentsInfo> i;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<DocumentsInfo>();
                i = rep.Get(moduleId);
            }
            return i;
        }

        public DocumentsInfo GetItem(int itemId, int moduleId)
        {
            DocumentsInfo i = null;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<DocumentsInfo>();
                i = rep.GetById(itemId, moduleId);
            }
            return i;
        }

        public void UpdateItem(DocumentsInfo i)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<DocumentsInfo>();
                rep.Update(i);
            }
        }
    }
}