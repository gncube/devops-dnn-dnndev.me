
using DotNetNuke.Services.Exceptions;
using System;
using GSN.Modules.DigitalAssetUpload.Components;

namespace GSN.Modules.DigitalAssetUpload
{
    public partial class Edit : DigitalAssetUploadModuleBase
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

        #endregion

        #region Helper Methods

        private void BindData()
        {
            LocalizeModule();
			
			
        }

        private void LocalizeModule()
        {
            
        }

        #endregion
    }
}