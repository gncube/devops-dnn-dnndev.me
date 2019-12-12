
using System.Collections.Generic;
using System.Linq;
using GSN.Modules.PaDare.Entities;

namespace GSN.Modules.PaDare.Controllers
{
    public class PaDareInfoController
    {
        private readonly PaDareInfoRepository repo = null;

        public PaDareInfoController() 
        {
            repo = new PaDareInfoRepository();
        }

        public void CreateItem(PaDareInfo i)
        {
            repo.CreateItem(i);
        }

        public void DeleteItem(int itemId, int moduleId)
        {
            repo.DeleteItem(itemId, moduleId);
        }

        public void DeleteItem(PaDareInfo i)
        {
            repo.DeleteItem(i);
        }

        public IEnumerable<PaDareInfo> GetItems(int moduleId)
        {
            var items = repo.GetItems(moduleId);
            return items;
        }

        public PaDareInfo GetItem(int itemId, int moduleId)
        {
            var item = repo.GetItem(itemId, moduleId);
            return item;
        }

        public void UpdateItem(PaDareInfo i)
        {
            repo.UpdateItem(i);
        }

        public PaDareInfo GetItemByModuleId(int moduleId)
        {
            var items = GetItems(moduleId);

            return items.FirstOrDefault(i => i.ModuleId == moduleId);
        }
    }
}