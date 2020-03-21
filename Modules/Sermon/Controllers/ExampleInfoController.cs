
using System.Collections.Generic;
using System.Linq;
using GSN.Modules.Sermon.Entities;

namespace GSN.Modules.Sermon.Controllers
{
    public class SermonInfoController
    {
        private readonly SermonInfoRepository repo = null;

        public SermonInfoController() 
        {
            repo = new SermonInfoRepository();
        }

        public void CreateItem(SermonInfo i)
        {
            repo.CreateItem(i);
        }

        public void DeleteItem(int itemId, int moduleId)
        {
            repo.DeleteItem(itemId, moduleId);
        }

        public void DeleteItem(SermonInfo i)
        {
            repo.DeleteItem(i);
        }

        public IEnumerable<SermonInfo> GetItems(int moduleId)
        {
            var items = repo.GetItems(moduleId);
            return items;
        }

        public SermonInfo GetItem(int itemId, int moduleId)
        {
            var item = repo.GetItem(itemId, moduleId);
            return item;
        }

        public void UpdateItem(SermonInfo i)
        {
            repo.UpdateItem(i);
        }

        public SermonInfo GetItemByModuleId(int moduleId)
        {
            var items = GetItems(moduleId);

            return items.FirstOrDefault(i => i.ModuleId == moduleId);
        }
    }
}