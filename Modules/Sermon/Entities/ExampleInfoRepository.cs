
using System.Collections.Generic;
using DotNetNuke.Data;

namespace GSN.Modules.Sermon.Entities
{
    public class SermonInfoRepository
    {
        public void CreateItem(SermonInfo i)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<SermonInfo>();
                rep.Insert(i);
            }
        }

        public void DeleteItem(int itemId, int moduleId)
        {
            var i = GetItem(itemId, moduleId);
            DeleteItem(i);
        }

        public void DeleteItem(SermonInfo i)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<SermonInfo>();
                rep.Delete(i);
            }
        }

        public IEnumerable<SermonInfo> GetItems(int moduleId)
        {
            IEnumerable<SermonInfo> i;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<SermonInfo>();
                i = rep.Get(moduleId);
            }
            return i;
        }

        public SermonInfo GetItem(int itemId, int moduleId)
        {
            SermonInfo i = null;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<SermonInfo>();
                i = rep.GetById(itemId, moduleId);
            }
            return i;
        }

        public void UpdateItem(SermonInfo i)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<SermonInfo>();
                rep.Update(i);
            }
        }
    }
}