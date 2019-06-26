
using DotNetNuke.Services.Exceptions;
using System;
using GSN.Modules.WebformsDemo.Components;

namespace GSN.Modules.WebformsDemo
{
    public partial class Edit : WebformsDemoModuleBase
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