
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Services.Localization;
using DotNetNuke.Security;
using System;
using GSN.Modules.Uploader.Components;

namespace GSN.Modules.Uploader
{
    public partial class Settings : UploaderModuleSettingsBase
    {
        #region Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // do nothing
            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        #endregion

        #region Base Method Implementations

        /// <summary>
        /// LoadSettings loads the settings from the Database and displays them
        /// </summary>
        public override void LoadSettings()
        {
            try
            {
				/* EXAMPLE 
                var setting = Settings["SettingName"];
				if (setting != null)
				{
					txtTextBox.Text = setting.ToString();
				}
				*/
            }
            catch (Exception exc) // module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        /// <summary>
        /// UpdateSettings saves the modified settings to the Database
        /// </summary>
        public override void UpdateSettings()
        {
            try
            {
				var ctlModule = new ModuleController();
                var security = new PortalSecurity();
				
				/* EXAMPLE
				ctlModule.UpdateTabModuleSetting(TabModuleId, ¨SettingName¨, security.InputFilter(txtTextbox.Text.Trim(), PortalSecurity.FilterFlag.NoMarkup));
				ctlModule.UpdateModuleSetting(ModuleId, ¨SettingName¨, security.InputFilter(txtTextbox.Text.Trim(), PortalSecurity.FilterFlag.NoMarkup));
				*/
                
				// synchronize the module settings
                ModuleController.SynchronizeModule(ModuleId);
            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        #endregion
    }
}