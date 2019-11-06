
using System.Collections.Generic;
using DotNetNuke.Data;

namespace GSN.Modules.DigitalAssetUpload.Entities
{
    public class DigitalAssetUploadInfoRepository
    {
        public void CreateItem(DigitalAssetUploadInfo i)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<DigitalAssetUploadInfo>();
                rep.Insert(i);
            }
        }

        public void DeleteItem(int itemId, int moduleId)
        {
            var i = GetItem(itemId, moduleId);
            DeleteItem(i);
        }

        public void DeleteItem(DigitalAssetUploadInfo i)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<DigitalAssetUploadInfo>();
                rep.Delete(i);
            }
        }

        public IEnumerable<DigitalAssetUploadInfo> GetItems(int moduleId)
        {
            IEnumerable<DigitalAssetUploadInfo> i;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<DigitalAssetUploadInfo>();
                i = rep.Get(moduleId);
            }
            return i;
        }

        public DigitalAssetUploadInfo GetItem(int itemId, int moduleId)
        {
            DigitalAssetUploadInfo i = null;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<DigitalAssetUploadInfo>();
                i = rep.GetById(itemId, moduleId);
            }
            return i;
        }

        public void UpdateItem(DigitalAssetUploadInfo i)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<DigitalAssetUploadInfo>();
                rep.Update(i);
            }
        }
    }
}