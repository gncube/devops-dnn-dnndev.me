
using System.Collections.Generic;
using DotNetNuke.Data;

namespace GSN.Modules.WebformsDemo.Entities
{
    public class WebformsDemoInfoRepository
    {
        public void CreateItem(WebformsDemoInfo i)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<WebformsDemoInfo>();
                rep.Insert(i);
            }
        }

        public void DeleteItem(int itemId, int moduleId)
        {
            var i = GetItem(itemId, moduleId);
            DeleteItem(i);
        }

        public void DeleteItem(WebformsDemoInfo i)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<WebformsDemoInfo>();
                rep.Delete(i);
            }
        }

        public IEnumerable<WebformsDemoInfo> GetItems(int moduleId)
        {
            IEnumerable<WebformsDemoInfo> i;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<WebformsDemoInfo>();
                i = rep.Get(moduleId);
            }
            return i;
        }

        public WebformsDemoInfo GetItem(int itemId, int moduleId)
        {
            WebformsDemoInfo i = null;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<WebformsDemoInfo>();
                i = rep.GetById(itemId, moduleId);
            }
            return i;
        }

        public void UpdateItem(WebformsDemoInfo i)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<WebformsDemoInfo>();
                rep.Update(i);
            }
        }
    }
}