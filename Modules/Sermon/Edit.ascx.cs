
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Web.Client.ClientResourceManagement;
using System;
using GSN.Modules.Sermon.Components;
using GSN.Modules.Sermon.Entities;

namespace GSN.Modules.Sermon
{
    public partial class Edit : SermonModuleBase
    {
        #region Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                BindData();
            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            ClientResourceManager.RegisterStyleSheet(this.Page, base.ControlPath + "resources/css/module.css");
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var t = new SermonInfo();
            var tc = new SermonInfoRepository();

            if (ItemId > 0)
            {
                t = tc.GetItem(ItemId, ModuleId);
                t.Title = txtTitle.Text.Trim();
                t.Description = txtDescription.Text.Trim();
            }
            else
            {
                t = new SermonInfo()
                {
                  CreatedByUserId = UserId,
                  CreatedOnDate = DateTime.Now,
                  Title = txtTitle.Text.Trim(),
                  Description = txtDescription.Text.Trim(),
                };
            }

            t.LastUpdatedOnDate = DateTime.Now;
            t.LastUpdatedByUserId = UserId;
            t.ModuleId = ModuleId;

            if (t.ItemId > 0)
            {
                tc.UpdateItem(t);
            }
            else
            {
                tc.CreateItem(t);
            }
            Response.Redirect(DotNetNuke.Common.Globals.NavigateURL());
        }


        protected void btnCancel_Click(object sender, EventArgs e)
        {
          Response.Redirect(DotNetNuke.Common.Globals.NavigateURL());
        }

        #endregion

        #region Helper Methods

        private void BindData()
        {
            if (!Page.IsPostBack)
            {
                if (ItemId > 0)
                {
                    var tc = new SermonInfoRepository();

                    var t = tc.GetItem(ItemId, ModuleId);
                    if (t != null)
                    {                        
                        txtTitle.Text = t.Title;
                        txtDescription.Text = t.Description;
                    }
                }
            }


            LocalizeModule();
        }

        private void LocalizeModule()
        {
            
        }

        #endregion
    }
}
