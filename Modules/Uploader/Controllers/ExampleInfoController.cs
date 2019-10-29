
using System.Collections.Generic;
using System.Linq;
using GSN.Modules.Uploader.Entities;

namespace GSN.Modules.Uploader.Controllers
{
    public class UploaderInfoController
    {
        private readonly UploaderInfoRepository repo = null;

        public UploaderInfoController() 
        {
            repo = new UploaderInfoRepository();
        }

        public void CreateItem(UploaderInfo i)
        {
            repo.CreateItem(i);
        }

        public void DeleteItem(int itemId, int moduleId)
        {
            repo.DeleteItem(itemId, moduleId);
        }

        public void DeleteItem(UploaderInfo i)
        {
            repo.DeleteItem(i);
        }

        public IEnumerable<UploaderInfo> GetItems(int moduleId)
        {
            var items = repo.GetItems(moduleId);
            return items;
        }

        public UploaderInfo GetItem(int itemId, int moduleId)
        {
            var item = repo.GetItem(itemId, moduleId);
            return item;
        }

        public void UpdateItem(UploaderInfo i)
        {
            repo.UpdateItem(i);
        }

        public UploaderInfo GetItemByModuleId(int moduleId)
        {
            var items = GetItems(moduleId);

            return items.FirstOrDefault(i => i.ModuleId == moduleId);
        }
    }
}