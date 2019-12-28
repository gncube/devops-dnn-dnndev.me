using DotNetNuke.Framework.JavaScriptLibraries;
using DotNetNuke.Web.Mvc.Framework.ActionFilters;
using DotNetNuke.Web.Mvc.Framework.Controllers;
using System;
using System.Web.Mvc;
using GSN.Modules.Conference.Components;
using GSN.Modules.Conference.Data;
using GSN.Modules.Conference.Models;

namespace GSN.Modules.Conference.Controllers
{
    [DnnHandleError]
    public class ConferenceController : DnnController
    {

      public ActionResult Delete(int itemId)
      {
          ConferenceInfoRepository.Instance.DeleteItem(itemId, ModuleContext.ModuleId);
          return RedirectToDefaultRoute();
      }


      public ActionResult Edit(int itemId = -1)
      {
          DotNetNuke.Framework.JavaScriptLibraries.JavaScript.RequestRegistration(CommonJs.DnnPlugins);

          var item = (itemId == -1)
            ? new ConferenceInfo { ModuleId = ModuleContext.ModuleId }
            : ConferenceInfoRepository.Instance.GetItem(itemId, ModuleContext.ModuleId);

          return View(item);
      }

      [HttpPost]
      [DotNetNuke.Web.Mvc.Framework.ActionFilters.ValidateAntiForgeryToken]
      public ActionResult Edit(ConferenceInfo item)
      {
          if (item.ConferenceId == -1)
          {
              item.CreatedByUserId = User.UserID;
              item.CreatedOnDate = DateTime.UtcNow;
              item.LastUpdatedByUserId = User.UserID;
              item.LastUpdatedOnDate = DateTime.UtcNow;

              ConferenceInfoRepository.Instance.CreateItem(item);
          }
          else
          {
              var existingItem = ConferenceInfoRepository.Instance.GetItem(item.ConferenceId, item.ModuleId);
              existingItem.LastUpdatedByUserId = User.UserID;
              existingItem.LastUpdatedOnDate = DateTime.UtcNow;
              existingItem.Title = item.Title;
              existingItem.Description = item.Description;

              ConferenceInfoRepository.Instance.UpdateItem(existingItem);
          }

          return RedirectToDefaultRoute();
      }

      [ModuleAction(ControlKey = "Edit", TitleKey = "AddItem")]
      public ActionResult Index()
      {
          var items = ConferenceInfoRepository.Instance.GetItems(ModuleContext.ModuleId);
          return View(items);
      }
    }
}
