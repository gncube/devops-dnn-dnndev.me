
using DotNetNuke.Services.Localization;
using System;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Framework.JavaScriptLibraries;

namespace GSN.Modules.DemoWF.Components
{
    public abstract class DemoWFModuleBase : PortalModuleBase
    {

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
        protected DemoWFModuleBase()
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
                return (IsEditable && PortalSettings.UserMode == DotNetNuke.Entities.Portals.PortalSettings.Mode.Edit);
            }
        }

        #endregion
    }
}