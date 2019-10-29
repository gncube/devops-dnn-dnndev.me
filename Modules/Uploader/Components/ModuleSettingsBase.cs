
using DotNetNuke.Services.Localization;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Framework.JavaScriptLibraries;
using System;

namespace GSN.Modules.Uploader.Components
{
    public abstract class UploaderModuleSettingsBase : ModuleSettingsBase
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
                return Localization.GetString(LocalizationKey, this.LocalResourceFile);
            }
            else
            {
                return string.Empty;
            }
        }

        #endregion
    }
}