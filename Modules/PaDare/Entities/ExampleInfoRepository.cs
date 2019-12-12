
using System.Collections.Generic;
using DotNetNuke.Data;

namespace GSN.Modules.PaDare.Entities
{
    public class PaDareInfoRepository
    {
        public void CreateItem(PaDareInfo i)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<PaDareInfo>();
                rep.Insert(i);
            }
        }

        public void DeleteItem(int itemId, int moduleId)
        {
            var i = GetItem(itemId, moduleId);
            DeleteItem(i);
        }

        public void DeleteItem(PaDareInfo i)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<PaDareInfo>();
                rep.Delete(i);
            }
        }

        public IEnumerable<PaDareInfo> GetItems(int moduleId)
        {
            IEnumerable<PaDareInfo> i;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<PaDareInfo>();
                i = rep.Get(moduleId);
            }
            return i;
        }

        public PaDareInfo GetItem(int itemId, int moduleId)
        {
            PaDareInfo i = null;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<PaDareInfo>();
                i = rep.GetById(itemId, moduleId);
            }
            return i;
        }

        public void UpdateItem(PaDareInfo i)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<PaDareInfo>();
                rep.Update(i);
            }
        }
    }
}