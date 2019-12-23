
using DotNetNuke.Data;
using DotNetNuke.Framework;
using System.Collections.Generic;
using GSN.Modules.Solumba.Data;
using GSN.Modules.Solumba.Models;

namespace GSN.Modules.Solumba.Data
{
    public interface ISolumbaInfoRepository
    {
        void CreateItem(SolumbaInfo t);
void DeleteItem(int itemId, int moduleId);
void DeleteItem(SolumbaInfo t);
IEnumerable<SolumbaInfo> GetItems(int moduleId);
        SolumbaInfo GetItem(int itemId, int moduleId);
void UpdateItem(SolumbaInfo t);
}

public class SolumbaInfoRepository : ServiceLocator<ISolumbaInfoRepository, SolumbaInfoRepository>, ISolumbaInfoRepository
{
        public void CreateItem(SolumbaInfo t)
{
    using (IDataContext ctx = DataContext.Instance())
    {
        var rep = ctx.GetRepository <SolumbaInfo > ();
        rep.Insert(t);
    }
}

public void DeleteItem(int itemId, int moduleId)
{
    var t = GetItem(itemId, moduleId);
    DeleteItem(t);
}

public void DeleteItem(SolumbaInfo t)
{
    using (IDataContext ctx = DataContext.Instance())
    {
        var rep = ctx.GetRepository <SolumbaInfo > ();
        rep.Delete(t);
    }
}

public IEnumerable<SolumbaInfo> GetItems(int moduleId)
{
    IEnumerable <SolumbaInfo > t;
    using (IDataContext ctx = DataContext.Instance())
    {
        var rep = ctx.GetRepository <SolumbaInfo > ();
        t = rep.Get(moduleId);
    }
    return t;
}

public SolumbaInfo GetItem(int itemId, int moduleId)
{
            SolumbaInfo t;
    using (IDataContext ctx = DataContext.Instance())
    {
        var rep = ctx.GetRepository <SolumbaInfo > ();
        t = rep.GetById(itemId, moduleId);
    }
    return t;
}

public void UpdateItem(SolumbaInfo t)
{
    using (IDataContext ctx = DataContext.Instance())
    {
        var rep = ctx.GetRepository <SolumbaInfo > ();
        rep.Update(t);
    }
}

protected override System.Func<ISolumbaInfoRepository> GetFactory()
{
    return () => new SolumbaInfoRepository();
}
    }
}
