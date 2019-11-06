
using System.Collections.Generic;
using System.Linq;
using GSN.Modules.DigitalAssetUpload.Entities;

namespace GSN.Modules.DigitalAssetUpload.Controllers
{
    public class DigitalAssetUploadInfoController
    {
        private readonly DigitalAssetUploadInfoRepository repo = null;

        public DigitalAssetUploadInfoController() 
        {
            repo = new DigitalAssetUploadInfoRepository();
        }

        public void CreateItem(DigitalAssetUploadInfo i)
        {
            repo.CreateItem(i);
        }

        public void DeleteItem(int itemId, int moduleId)
        {
            repo.DeleteItem(itemId, moduleId);
        }

        public void DeleteItem(DigitalAssetUploadInfo i)
        {
            repo.DeleteItem(i);
        }

        public IEnumerable<DigitalAssetUploadInfo> GetItems(int moduleId)
        {
            var items = repo.GetItems(moduleId);
            return items;
        }

        public DigitalAssetUploadInfo GetItem(int itemId, int moduleId)
        {
            var item = repo.GetItem(itemId, moduleId);
            return item;
        }

        public void UpdateItem(DigitalAssetUploadInfo i)
        {
            repo.UpdateItem(i);
        }

        public DigitalAssetUploadInfo GetItemByModuleId(int moduleId)
        {
            var items = GetItems(moduleId);

            return items.FirstOrDefault(i => i.ModuleId == moduleId);
        }
    }
}