
using System.Collections.Generic;
using System.Linq;
using Gsn.Modules.WebformsDemo.Entities;

namespace Gsn.Modules.WebformsDemo.Controllers
{
    public class WebformsDemoInfoController
    {
        private readonly WebformsDemoInfoRepository repo = null;

        public WebformsDemoInfoController() 
        {
            repo = new WebformsDemoInfoRepository();
        }

        public void CreateItem(WebformsDemoInfo i)
        {
            repo.CreateItem(i);
        }

        public void DeleteItem(int itemId, int moduleId)
        {
            repo.DeleteItem(itemId, moduleId);
        }

        public void DeleteItem(WebformsDemoInfo i)
        {
            repo.DeleteItem(i);
        }

        public IEnumerable<WebformsDemoInfo> GetItems(int moduleId)
        {
            var items = repo.GetItems(moduleId);
            return items;
        }

        public WebformsDemoInfo GetItem(int itemId, int moduleId)
        {
            var item = repo.GetItem(itemId, moduleId);
            return item;
        }

        public void UpdateItem(WebformsDemoInfo i)
        {
            repo.UpdateItem(i);
        }

        public WebformsDemoInfo GetItemByModuleId(int moduleId)
        {
            var items = GetItems(moduleId);

            return items.FirstOrDefault(i => i.ModuleId == moduleId);
        }
    }
}