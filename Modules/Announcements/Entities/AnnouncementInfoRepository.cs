
using System.Collections.Generic;
using DotNetNuke.Data;

namespace GSN.Modules.Announcements.Entities
{
    public class AnnouncementInfoRepository
    {
        public void CreateItem(AnnouncementInfo i)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<AnnouncementInfo>();
                rep.Insert(i);
            }
        }

        public void DeleteItem(int itemId, int moduleId)
        {
            var i = GetItem(itemId, moduleId);
            DeleteItem(i);
        }

        public void DeleteItem(AnnouncementInfo i)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<AnnouncementInfo>();
                rep.Delete(i);
            }
        }

        public IEnumerable<AnnouncementInfo> GetItems(int moduleId)
        {
            IEnumerable<AnnouncementInfo> i;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<AnnouncementInfo>();
                i = rep.Get(moduleId);
            }
            return i;
        }

        public AnnouncementInfo GetItem(int itemId, int moduleId)
        {
            AnnouncementInfo i = null;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<AnnouncementInfo>();
                i = rep.GetById(itemId, moduleId);
            }
            return i;
        }

        public void UpdateItem(AnnouncementInfo i)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<AnnouncementInfo>();
                rep.Update(i);
            }
        }
    }
}