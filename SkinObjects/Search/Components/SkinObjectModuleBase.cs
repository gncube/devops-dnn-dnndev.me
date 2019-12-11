using DotNetNuke.UI.Skins; 

namespace GSN.SkinObjects.Search.Components
{
    public class SearchModuleBase : SkinObjectBase 
	{
        public string ControlPath 
		{
            get 
			{
                return string.Concat(TemplateSourceDirectory, "/"); 
            }
        }
    }
}