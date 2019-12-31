
using DotNetNuke.Services.Localization;
using System;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Framework.JavaScriptLibraries;

namespace GSN.Modules.Documents.Components
{
    public abstract class DocumentsModuleBase : PortalModuleBase
    {
        public int DocumentId 
        { 
            get 
            {
                var qs = Request.QueryString["did"];
                if (qs != null)
                    return Convert.ToInt32(qs);
                return -1;
            }  
        }

        public int GroupId
        {
            get
            {
                var groupId = Request.QueryString["groupid"];
                if (groupId != null)
                    return Convert.ToInt32(groupId);
                return -1;
            }
        }

        #region Localization
        protected string GetLocalizedString(string LocalizationKey)
        {
            if (!string.IsNullOrEmpty(LocalizationKey))
            {
                return Localization.GetString(LocalizationKey, this.LocalResourceFile);
            }
            else
            {
                return string.Empty;
            }
        }

        protected string GetLocalizedString(string LocalizationKey, string LocalResourceFilePath)
        {
            if (!string.IsNullOrEmpty(LocalizationKey))
            {
                return Localization.GetString(LocalizationKey, LocalResourceFilePath);
            }
            else
            {
                return string.Empty;
            }
        }
        #endregion

        #region Event Handlers
        protected DocumentsModuleBase()
        {
            Load += Page_Load;
        }

        private void Page_Load(object sender, EventArgs e)
        {
            // request that the DNN framework load the jQuery script into the markup
            JavaScript.RequestRegistration(CommonJs.DnnPlugins);

        }
        #endregion

        #region Security

        protected bool CurrentUserCanEdit
        {
            get
            {
                //return (IsEditable && PortalSettings.UserMode == DotNetNuke.Entities.Portals.PortalSettings.Mode.Edit);
                return true;
            }
        }

        #endregion
    }
}