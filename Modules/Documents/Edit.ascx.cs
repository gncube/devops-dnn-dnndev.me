
using DotNetNuke.Services.Exceptions;
using System;
using GSN.Modules.Documents.Components;
using DotNetNuke.Security.Permissions;
using DotNetNuke.Services.FileSystem;
using DotNetNuke.Common.Utilities;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace GSN.Modules.Documents
{
    public partial class Edit : DocumentsModuleBase
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

        private bool CheckRolesMatch(ModulePermissionCollection ModuleRoles, FolderPermissionCollection FileRoles)
        {
            Hashtable objFileRoles = new Hashtable();
            bool blnNotMatching = false;
            string strRolesForMessage = "";

            List<PermissionInfoBase> fileRolesList = FileRoles.ToList();
            IEnumerable<PermissionInfoBase> fileReadRoles = from fileRole in fileRolesList
                                                            where fileRole.PermissionKey == "READ"
                                                            select fileRole;
            foreach (FolderPermissionInfo fileRole in fileReadRoles)
            {
                if (!fileRole.RoleName == "")
                {
                    objFileRoles.Add(fileRole.RoleName, fileRole.RoleName);
                    if (fileRole.RoleName == DotNetNuke.Common.Globals.glbRoleAllUsersName)
                        return true;
                }
            }

            List<PermissionInfoBase> moduleRolesList = ModuleRoles.ToList();
            IEnumerable<PermissionInfoBase> moduleReadRoles = from moduleRole in moduleRolesList
                                                              where moduleRole.PermissionKey == "READ"
                                                              select moduleRole;
            foreach (ModulePermissionInfo moduleRole in moduleReadRoles)
            {
                if (moduleRole.PermissionKey == "READ" && !objFileRoles.ContainsKey(moduleRole.RoleName))
                {
                    // A view role exists for the module that is not available for the file
                    blnNotMatching = true;
                    if (strRolesForMessage != string.Empty)
                        strRolesForMessage = strRolesForMessage + ", ";
                    strRolesForMessage = strRolesForMessage + moduleRole.RoleName;
                }
            }
            if (blnNotMatching)
            {
                // Warn user that roles do not match
                DotNetNuke.UI.Skins.Skin.AddModuleMessage(this, DotNetNuke.Services.Localization.Localization.GetString("msgFileSecurityWarning.Text", this.LocalResourceFile).Replace("[$ROLELIST]", Interaction.IIf(strRolesForMessage.IndexOf(",") >= 0, "s", "").ToString() + "'" + strRolesForMessage + "'"), DotNetNuke.UI.Skins.Controls.ModuleMessage.ModuleMessageType.YellowWarning);
                return false;
            }
            else
                return true;
        }


        private bool CheckFileExists(string Url)
        {
            int intFileId;
            DotNetNuke.Services.FileSystem.FileInfo objFile = new DotNetNuke.Services.FileSystem.FileInfo();
            bool blnAddWarning;

            if (Url == string.Empty)
            {
                // File not selected
                DotNetNuke.UI.Skins.Skin.AddModuleMessage(this, DotNetNuke.Services.Localization.Localization.GetString("msgNoFileSelected.Text", this.LocalResourceFile), DotNetNuke.UI.Skins.Controls.ModuleMessage.ModuleMessageType.YellowWarning);
                return false;
            }
            else
                switch (GetURLType(Url))
                {
                    case object _ when Entities.Tabs.TabType.File:
                        {
                            if (Url.ToLower().StartsWith("fileid=") == false)
                                // to handle legacy scenarios before the introduction of the FileServerHandler
                                Url = "FileID=" + FileManager.Instance.GetFile(PortalSettings.PortalId, Url).FileId;

                            intFileId = int.Parse(UrlUtils.GetParameterValue(Url));

                            objFile = (DotNetNuke.Services.FileSystem.FileInfo)FileManager.Instance.GetFile(intFileId);

                            blnAddWarning = false;
                            if (objFile == null)
                                blnAddWarning = true;
                            else
                                switch (objFile.StorageLocation)
                                {
                                    case object _ when DotNetNuke.Services.FileSystem.FolderController.StorageLocationTypes.InsecureFileSystem:
                                        {
                                            blnAddWarning = !System.IO.File.Exists(objFile.PhysicalPath);
                                            break;
                                        }

                                    case object _ when DotNetNuke.Services.FileSystem.FolderController.StorageLocationTypes.SecureFileSystem:
                                        {
                                            blnAddWarning = !System.IO.File.Exists(objFile.PhysicalPath + glbProtectedExtension);
                                            break;
                                        }

                                    case object _ when DotNetNuke.Services.FileSystem.FolderController.StorageLocationTypes.DatabaseSecure:
                                        {
                                            blnAddWarning = false;  // Database-stored files cannot be deleted seperately
                                            break;
                                        }
                                }

                            if (blnAddWarning)
                            {
                                // Display a "file not found" warning
                                DotNetNuke.UI.Skins.Skin.AddModuleMessage(this, DotNetNuke.Services.Localization.Localization.GetString("msgFileDeleted.Text", this.LocalResourceFile), DotNetNuke.UI.Skins.Controls.ModuleMessage.ModuleMessageType.YellowWarning);
                                return false;
                            }

                            break;
                        }

                    case object _ when Entities.Tabs.TabType.Url:
                        {
                            break;
                        }
                }
            return true;
        }

        private void Update(bool Override)
        {
            try
            {
                // Only Update if Input Data is Valid
                if (Page.IsValid == true)
                {
                    if (!Override)
                    {
                        // Test file exists, security
                        if (!CheckFileExists(ctlUrl.Url) || !CheckFileSecurity(ctlUrl.Url))
                        {
                            this.cmdUpdateOverride.Visible = true;
                            this.cmdUpdate.Visible = false;

                            // '' Display page-level warning instructing users to click update again if they want to ignore the warning
                            DotNetNuke.UI.Skins.Skin.AddPageMessage(this.Page, DotNetNuke.Services.Localization.Localization.GetString("msgFileWarningHeading.Text", this.LocalResourceFile), DotNetNuke.Services.Localization.Localization.GetString("msgFileWarning.Text", this.LocalResourceFile), Skins.Controls.ModuleMessage.ModuleMessageType.YellowWarning);
                            return;
                        }
                    }

                    DocumentInfo objDocument;
                    DocumentController objDocuments = new DocumentController();

                    // Get existing document record
                    objDocument = objDocuments.GetDocument(ItemID, ModuleId);

                    if (objDocument == null)
                    {
                        // New record
                        objDocument = new DocumentInfo();
                        objDocument.ItemId = ItemID;
                        objDocument.ModuleId = ModuleId;

                        objDocument.CreatedByUserId = UserInfo.UserID;

                        // Default ownerid value for new documents is current user, may be changed
                        // by the value of the dropdown list (below)
                        objDocument.OwnedByUserId = UserId;
                    }

                    objDocument.Title = txtName.Text;
                    objDocument.Url = ctlUrl.Url;
                    objDocument.Description = txtDescription.Text;
                    objDocument.ForceDownload = chkForceDownload.Checked;
                    objDocument.ModifiedByUserId = UserInfo.UserID;

                    if (lstOwner.Visible)
                    {
                        if (lstOwner.SelectedValue != string.Empty)
                            objDocument.OwnedByUserId = Convert.ToInt32(lstOwner.SelectedValue);
                        else
                            objDocument.OwnedByUserId = -1;
                    }
                    else
                    {
                    }

                    if (txtCategory.Visible)
                        objDocument.Category = txtCategory.Text;
                    else if (lstCategory.SelectedItem.Text == Services.Localization.Localization.GetString("None_Specified"))
                        objDocument.Category = "";
                    else
                        objDocument.Category = lstCategory.SelectedItem.Value;

                    if (txtSortIndex.Text == string.Empty)
                        objDocument.SortOrderIndex = 0;
                    else
                        objDocument.SortOrderIndex = Convert.ToInt32(txtSortIndex.Text);

                    // Create an instance of the Document DB component

                    if (Common.Utilities.Null.IsNull(ItemID))
                        objDocuments.AddDocument(objDocument);
                    else
                        objDocuments.UpdateDocument(objDocument);

                    // url tracking
                    UrlController objUrls = new UrlController();
                    objUrls.UpdateUrl(PortalId, ctlUrl.Url, ctlUrl.UrlType, ctlUrl.Log, ctlUrl.Track, ModuleId, ctlUrl.NewWindow);

                    ModuleController.SynchronizeModule(ModuleId);
                    DataCache.RemoveCache("DNN_Documents;" + TabModuleId + ";anon-doclist");

                    // Redirect back to the portal home page
                    Response.Redirect(NavigateURL(), true);
                }
            }
            catch (Exception exc)
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }


        #endregion
    }
}