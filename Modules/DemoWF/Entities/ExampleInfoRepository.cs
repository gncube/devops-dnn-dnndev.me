
using System.Collections.Generic;
using DotNetNuke.Data;

namespace GSN.Modules.DemoWF.Entities
{
    public class DemoWFInfoRepository
    {
        public void CreateItem(DemoWFInfo i)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<DemoWFInfo>();
                rep.Insert(i);
            }
        }

        public void DeleteItem(int itemId, int moduleId)
        {
            var i = GetItem(itemId, moduleId);
            DeleteItem(i);
        }

        public void DeleteItem(DemoWFInfo i)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<DemoWFInfo>();
                rep.Delete(i);
            }
        }

        public IEnumerable<DemoWFInfo> GetItems(int moduleId)
        {
            IEnumerable<DemoWFInfo> i;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<DemoWFInfo>();
                i = rep.Get(moduleId);
            }
            return i;
        }

        public DemoWFInfo GetItem(int itemId, int moduleId)
        {
            DemoWFInfo i = null;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<DemoWFInfo>();
                i = rep.GetById(itemId, moduleId);
            }
            return i;
        }

        public void UpdateItem(DemoWFInfo i)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<DemoWFInfo>();
                rep.Update(i);
            }
        }
    }
}