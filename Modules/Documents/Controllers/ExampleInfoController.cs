
using System.Collections.Generic;
using System.Linq;
using GSN.Modules.Documents.Entities;

namespace GSN.Modules.Documents.Controllers
{
    public class DocumentsInfoController
    {
        private readonly DocumentsInfoRepository repo = null;

        public DocumentsInfoController() 
        {
            repo = new DocumentsInfoRepository();
        }

        public void CreateItem(DocumentsInfo i)
        {
            repo.CreateItem(i);
        }

        public void DeleteItem(int itemId, int moduleId)
        {
            repo.DeleteItem(itemId, moduleId);
        }

        public void DeleteItem(DocumentsInfo i)
        {
            repo.DeleteItem(i);
        }

        public IEnumerable<DocumentsInfo> GetItems(int moduleId)
        {
            var items = repo.GetItems(moduleId);
            return items;
        }

        public DocumentsInfo GetItem(int itemId, int moduleId)
        {
            var item = repo.GetItem(itemId, moduleId);
            return item;
        }

        public void UpdateItem(DocumentsInfo i)
        {
            repo.UpdateItem(i);
        }

        public DocumentsInfo GetItemByModuleId(int moduleId)
        {
            var items = GetItems(moduleId);

            return items.FirstOrDefault(i => i.ModuleId == moduleId);
        }
    }
}