
using DotNetNuke.Data;
using DotNetNuke.Framework;
using System.Collections.Generic;
using GSN.Modules.Conference.Data;
using GSN.Modules.Conference.Models;

namespace GSN.Modules.Conference.Data
{
    public interface IConferenceInfoRepository
    {
        void CreateItem(ConferenceInfo t);
        void DeleteItem(int itemId, int moduleId);
        void DeleteItem(ConferenceInfo t);
        IEnumerable<ConferenceInfo> GetItems(int moduleId);
                ConferenceInfo GetItem(int itemId, int moduleId);
        void UpdateItem(ConferenceInfo t);
        }

        public class ConferenceInfoRepository : ServiceLocator<IConferenceInfoRepository, ConferenceInfoRepository>, IConferenceInfoRepository
        {
                public void CreateItem(ConferenceInfo t)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository <ConferenceInfo > ();
                rep.Insert(t);
            }
        }

        public void DeleteItem(int itemId, int moduleId)
        {
            var t = GetItem(itemId, moduleId);
            DeleteItem(t);
        }

        public void DeleteItem(ConferenceInfo t)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository <ConferenceInfo > ();
                rep.Delete(t);
            }
        }

        public IEnumerable<ConferenceInfo> GetItems(int moduleId)
        {
            IEnumerable <ConferenceInfo > t;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository <ConferenceInfo > ();
                t = rep.Get(moduleId);
            }
            return t;
        }

        public ConferenceInfo GetItem(int itemId, int moduleId)
        {
                    ConferenceInfo t;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository <ConferenceInfo > ();
                t = rep.GetById(itemId, moduleId);
            }
            return t;
        }

        public void UpdateItem(ConferenceInfo t)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository <ConferenceInfo > ();
                rep.Update(t);
            }
        }

        protected override System.Func<IConferenceInfoRepository> GetFactory()
        {
            return () => new ConferenceInfoRepository();
        }

    }
}
