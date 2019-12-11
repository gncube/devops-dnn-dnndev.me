
using DotNetNuke.Services.Exceptions;
using System;
using GSN.SkinObjects.Search.Components;

namespace GSN.SkinObjects.Search
{
    public partial class View : SearchModuleBase
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
               // do something
            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

    }
}