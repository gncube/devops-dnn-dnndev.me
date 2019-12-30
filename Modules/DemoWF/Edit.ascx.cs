
using DotNetNuke.Services.Exceptions;
using System;
using GSN.Modules.DemoWF.Components;

namespace GSN.Modules.DemoWF
{
    public partial class Edit : DemoWFModuleBase
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