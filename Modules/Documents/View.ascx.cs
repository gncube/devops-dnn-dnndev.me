
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Services.Exceptions;
using System;
using System.Web.UI;
using GSN.Modules.Documents.Components;
using DotNetNuke.Entities.Portals;
using GSN.Modules.Documents.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using DotNetNuke.Services.Localization;
using DotNetNuke.Entities.Users;
using DotNetNuke.UI.Utilities;
using DotNetNuke.Common;
using DotNetNuke.Services.FileSystem;
using GSN.Modules.Documents.Controllers;

namespace GSN.Modules.Documents
{
    public partial class View : DocumentsModuleBase, IActionable
    {
        //private PortalInfo portalInfo;
        private bool _hasDocuments;
        

        #region Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //PortalController portalController = new PortalController();

                if (!Page.IsPostBack)
                {
                    BindModule();
                }
            }
            catch (Exception exc)
            {
                // Module failed to load
                Exceptions.ProcessModuleLoadException(this, exc, IsEditable);
            }
        }

        #endregion

        #region Private Helper Methods

        private void BindModule()
        {
            var dc = new DocumentsInfoRepository();
            IEnumerable<DocumentsInfo> documents = dc.GetItemsByGroupId(ModuleId, GroupId);
            _hasDocuments = documents.Any();
            rptItemList.DataSource = documents;
            rptItemList.DataBind();

            LocalizeModule();		
        }
        
        private void LocalizeModule()
        {
            // do nothing
        }

        public string GetDisplayName(int userId)
        {
            string displayName = "";
            var uc = new UserController();
            var u = uc.GetUser(PortalSettings.PortalId, userId);
            if(u != null)
            {
                displayName = u.DisplayName;
            }
            else
            {
                displayName = "Super Unknown";
            }
            return displayName;
        }

        protected void rptItemListOnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (!_hasDocuments)
            {
                if (e.Item.ItemType == ListItemType.Header)
                {
                    HtmlGenericControl noRecordsDiv = (e.Item.FindControl("NoRecords") as HtmlGenericControl);
                    if (noRecordsDiv != null)
                    {
                        noRecordsDiv.Visible = true;
                    }
                }
            }

            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                var lnkEdit = e.Item.FindControl("lnkEdit") as HyperLink;
                var lnkDelete = e.Item.FindControl("lnkDelete") as LinkButton;
                var hypDocumentFile = e.Item.FindControl("hypDocumentFile") as HyperLink;
                var pnlAdminControls = e.Item.FindControl("pnlAdmin") as Panel;
                var lnkDownload = e.Item.FindControl("lnkDownload") as HyperLink;

                try
                {
                    var d = (DocumentsInfo)e.Item.DataItem;

                    var documentFile = (IFileInfo)FileManager.Instance.GetFile(d.FileId);
                    var fileLink = new FileLinkClickController();

                    if (fileLink != null)
                    {
                        hypDocumentFile.NavigateUrl = fileLink.GetFileLinkClick(documentFile);
                        //hypDocumentFile.Text = "&lt;i class=&quot;fa fa-download&quot;&gt;&lt;/i&gt; Download";
                        hypDocumentFile.CssClass = "btn btn-success";
                        hypDocumentFile.Visible = true;
                    }

                    if (IsEditable && lnkDelete != null && lnkEdit != null && pnlAdminControls != null)
                    {
                        pnlAdminControls.Visible = true;
                        lnkDelete.CommandArgument = d.DocumentId.ToString();  //t.MenuItemId.ToString();
                        lnkDelete.Enabled = lnkDelete.Visible = lnkEdit.Enabled = lnkEdit.Visible = true;

                        lnkEdit.NavigateUrl = EditUrl(string.Empty, string.Empty, "Edit", "did=" + d.DocumentId, "groupId=" + GroupId.ToString());
                        
                        //hypDocumentFile.NavigateUrl = fileLink.GetFileLinkClick(documentFile);

                        //lnkDownload.NavigateUrl = fileLink.GetFileIdFromLinkClick(documentFile);

                        //lnkDownload.NavigateUrl = fileLink.GetFileLinkClick(documentFile);

                        lnkDelete.Text = "Delete";

                        //ClientAPI.AddButtonConfirm(lnkDelete, Localization.GetString("ConfirmDelete", LocalResourceFile));                        
                    }
                    else
                    {
                        pnlAdminControls.Visible = false;
                    }
                }
                catch (Exception exc) //Module failed to load
                {
                    Exceptions.ProcessModuleLoadException(this, exc);
                }
            }
        }


        public void rptItemListOnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                Response.Redirect(EditUrl(string.Empty, string.Empty, "Edit", "did=" + e.CommandArgument, "groupId=" + GroupId.ToString()));
            }

            if (e.CommandName == "Delete")
            {
                var dc = new DocumentsInfoRepository();
                dc.DeleteItem(Convert.ToInt32(e.CommandArgument), ModuleId);
            }

            if(e.CommandName == "Download")
            {
                var dc = new DocumentsInfoRepository();
                var d = dc.GetItem(Convert.ToInt32(e.CommandArgument), ModuleId);
                var fc = new FileManager();
                var f = fc.GetFile(d.FileId);

                Response.Redirect(fc.GetUrl(f));
            }
            Response.Redirect(DotNetNuke.Common.Globals.NavigateURL());
        }





        #endregion

        #region IActionable Implementation

        public ModuleActionCollection ModuleActions
        {
            get
            {
                var actions = new ModuleActionCollection
                {
                    {
                        GetNextActionID(), 
						GetLocalizedString("View.MenuItem.Title"), string.Empty,
                        string.Empty,
                        string.Empty, EditUrl(), false, DotNetNuke.Security.SecurityAccessLevel.Edit, true, false
                    }
                };
                return actions;
            }
        }

        #endregion

        protected void btnNewDocument_Click(object sender, EventArgs e)
        {
            Response.Redirect(Globals.NavigateURL(PortalSettings.ActiveTab.TabID, PortalSettings, "Edit", "mid=" + ModuleId.ToString(), "groupId=" + GroupId.ToString()));
        }
    }
}