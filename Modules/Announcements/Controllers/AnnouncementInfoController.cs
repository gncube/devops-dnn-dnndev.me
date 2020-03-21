
using System.Collections.Generic;
using System.Linq;
using GSN.Modules.Announcements.Entities;

namespace GSN.Modules.Announcements.Controllers
{
    public class AnnouncementInfoController
    {
        private readonly AnnouncementInfoRepository repo = null;

        public AnnouncementInfoController() 
        {
            repo = new AnnouncementInfoRepository();
        }

        public void CreateItem(AnnouncementInfo i)
        {
            repo.CreateItem(i);
        }

        public void DeleteItem(int itemId, int moduleId)
        {
            repo.DeleteItem(itemId, moduleId);
        }

        public void DeleteItem(AnnouncementInfo i)
        {
            repo.DeleteItem(i);
        }

        public IEnumerable<AnnouncementInfo> GetItems(int moduleId)
        {
            var items = repo.GetItems(moduleId);
            return items;
        }

        public AnnouncementInfo GetItem(int itemId, int moduleId)
        {
            var item = repo.GetItem(itemId, moduleId);
            return item;
        }

        public void UpdateItem(AnnouncementInfo i)
        {
            repo.UpdateItem(i);
        }

        public AnnouncementInfo GetItemByModuleId(int moduleId)
        {
            var items = GetItems(moduleId);

            return items.FirstOrDefault(i => i.ModuleId == moduleId);
        }
    }
}