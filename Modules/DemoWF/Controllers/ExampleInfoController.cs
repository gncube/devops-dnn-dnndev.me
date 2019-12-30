
using System.Collections.Generic;
using System.Linq;
using GSN.Modules.DemoWF.Entities;

namespace GSN.Modules.DemoWF.Controllers
{
    public class DemoWFInfoController
    {
        private readonly DemoWFInfoRepository repo = null;

        public DemoWFInfoController() 
        {
            repo = new DemoWFInfoRepository();
        }

        public void CreateItem(DemoWFInfo i)
        {
            repo.CreateItem(i);
        }

        public void DeleteItem(int itemId, int moduleId)
        {
            repo.DeleteItem(itemId, moduleId);
        }

        public void DeleteItem(DemoWFInfo i)
        {
            repo.DeleteItem(i);
        }

        public IEnumerable<DemoWFInfo> GetItems(int moduleId)
        {
            var items = repo.GetItems(moduleId);
            return items;
        }

        public DemoWFInfo GetItem(int itemId, int moduleId)
        {
            var item = repo.GetItem(itemId, moduleId);
            return item;
        }

        public void UpdateItem(DemoWFInfo i)
        {
            repo.UpdateItem(i);
        }

        public DemoWFInfo GetItemByModuleId(int moduleId)
        {
            var items = GetItems(moduleId);

            return items.FirstOrDefault(i => i.ModuleId == moduleId);
        }
    }
}