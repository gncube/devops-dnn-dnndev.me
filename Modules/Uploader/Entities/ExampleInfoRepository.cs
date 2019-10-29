
using System.Collections.Generic;
using DotNetNuke.Data;

namespace GSN.Modules.Uploader.Entities
{
    public class UploaderInfoRepository
    {
        public void CreateItem(UploaderInfo i)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<UploaderInfo>();
                rep.Insert(i);
            }
        }

        public void DeleteItem(int itemId, int moduleId)
        {
            var i = GetItem(itemId, moduleId);
            DeleteItem(i);
        }

        public void DeleteItem(UploaderInfo i)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<UploaderInfo>();
                rep.Delete(i);
            }
        }

        public IEnumerable<UploaderInfo> GetItems(int moduleId)
        {
            IEnumerable<UploaderInfo> i;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<UploaderInfo>();
                i = rep.Get(moduleId);
            }
            return i;
        }

        public UploaderInfo GetItem(int itemId, int moduleId)
        {
            UploaderInfo i = null;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<UploaderInfo>();
                i = rep.GetById(itemId, moduleId);
            }
            return i;
        }

        public void UpdateItem(UploaderInfo i)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<UploaderInfo>();
                rep.Update(i);
            }
        }
    }
}