
using DotNetNuke.Services.Exceptions;
using System;
using GSN.Modules.Documents.Components;
using DotNetNuke.Security;
using GSN.Modules.Documents.Entities;
using System.Web;
using DotNetNuke.Services.FileSystem;
using DotNetNuke.Security.Permissions;
using DotNetNuke.Security.Roles;
using DotNetNuke.Common;
using System.Linq;

namespace GSN.Modules.Documents
{
    public partial class Edit : DocumentsModuleBase
    {
        #region "Private Members"
        private DocumentsInfo documentsInfo;        

        //private readonly int DocumentId;


        #endregion

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
            var rc = new RoleController();
            var r = rc.GetRoleById(PortalId, GroupId);

            lblHeader.Text = r.RoleName;

            //Implement your edit logic for your module
            if (!Page.IsPostBack)
            {
                if(DocumentId > 0)
                {
                    var dc = new DocumentsInfoRepository();

                    var d = dc.GetItem(DocumentId, ModuleId);                    

                    if(d != null)
                    {
                        txtCohortStartDate.Text = d.CreatedOnDate.ToString("dd/MM/yyyy");
                        dplAction.SelectedValue = d.Action;
                        FileUploadControl.Visible = false;
                        hypDocumentFile.Visible = true;
                        var documentFile = (FileInfo)FileManager.Instance.GetFile(d.FileId);
                        var fileLink = new FileLinkClickController();
                        hypDocumentFile.NavigateUrl = fileLink.GetFileLinkClick(documentFile);
                        hypDocumentFile.Text = documentFile.FileName;
                        
                    }
                }
            }
            
            LocalizeModule();		
        }

        private void LocalizeModule()
        {
            
        }

        #endregion

        protected void btnSave_Click(object sender, EventArgs e)
        {
            PortalSecurity objSecurity = new PortalSecurity();

            var d = new DocumentsInfo();
            var dc = new DocumentsInfoRepository();
           

            if (Page.IsValid == true)
            {
                if (DocumentId > 0)
                {
                    d = dc.GetItem(DocumentId, ModuleId);
                    if(d != null)
                    {
                        d.CohortStartDate = DateTime.Parse(txtCohortStartDate.Text.ToString());
                        //d.Action = rdbAction.SelectedValue.ToString();
                        d.Action = dplAction.SelectedValue.ToString();
                        FileInfo documentFile = (FileInfo)FileManager.Instance.GetFile(d.FileId);
                        d.GroupId = GroupId;
                    }                    
                }
                else
                {
                    d = new DocumentsInfo()
                    {
                        CreatedByUserId = UserId,
                        CreatedOnDate = DateTime.UtcNow,
                        CohortStartDate = DateTime.Parse(txtCohortStartDate.Text.ToString()),
                        //Action = rdbAction.SelectedValue.ToString(),
                        Action = dplAction.SelectedValue.ToString(),
                        FileId = UploadFile(GroupId),
                        GroupId = GroupId,
                    };
                }

                d.LastModifiedOnDate = DateTime.Now;
                d.LastModifiedByUserId = UserId;
                d.ModuleId = ModuleId;

                if (d.DocumentId > 0)
                {
                    dc.UpdateItem(d);
                }
                else
                {
                    dc.CreateItem(d);
                }
                //Response.Redirect(DotNetNuke.Common.Globals.NavigateURL());
                //Response.Redirect(Globals.NavigateURL(PortalSettings.ActiveTab.TabID, PortalSettings, string.Empty , "groupId=" + GroupId.ToString()));
                Response.Redirect(Globals.NavigateURL(37, PortalSettings, string.Empty, "groupId=" + GroupId.ToString()));

            }
        }

        public int UploadFile()
        {
            //int documentFileId = 155; //FileID for dental-mirror.PNG

            int documentFileId = 155;
            var f = new FileInfo();
            var fc = new FileManager();


            if (FileUploadControl.HasFile)
            {
                var fo = FolderManager.Instance.GetFolder(PortalId, "Documents/");

                documentFileId = fc.AddFile(fo, FileUploadControl.PostedFile.FileName, FileUploadControl.PostedFile.InputStream, false, true, FileUploadControl.PostedFile.ContentType).FileId;               
            }

            return documentFileId;
        }

        public int UploadFile(int groupId)
        {
            int groupFileId = 155;
            var groupFolderPath = "Groups/" + groupId;
            var f = new FileInfo();
            var fc = new FileManager();

            if (groupId > 0 && FileUploadControl.HasFile)
            {
                var role = RoleController.Instance.GetRoleById(PortalId, groupId);
                var fo = FolderManager.Instance.GetFolder(PortalId, groupFolderPath);

                if (fo != null)
                {
                    groupFileId = fc.AddFile(fo, FileUploadControl.PostedFile.FileName, FileUploadControl.PostedFile.InputStream, false, true, FileUploadControl.PostedFile.ContentType).FileId;
                }
                else
                {
                    var pc = new PermissionController();
                    var browsePermission = pc.GetPermissionByCodeAndKey("SYSTEM_FOLDER", "BROWSE").Cast<PermissionInfo>().FirstOrDefault();
                    var readPermission = pc.GetPermissionByCodeAndKey("SYSTEM_FOLDER", "READ").Cast<PermissionInfo>().FirstOrDefault();
                    var writePermission = pc.GetPermissionByCodeAndKey("SYSTEM_FOLDER", "WRITE").Cast<PermissionInfo>().FirstOrDefault();


                    var groupFolder = FolderManager.Instance.AddFolder(PortalId, groupFolderPath);

                    groupFolder.FolderPermissions.Add(new FolderPermissionInfo(browsePermission) { FolderPath = groupFolder.FolderPath, RoleID = groupId, AllowAccess = true });
                    groupFolder.FolderPermissions.Add(new FolderPermissionInfo(readPermission) { FolderPath = groupFolder.FolderPath, RoleID = groupId, AllowAccess = true });
                    groupFolder.FolderPermissions.Add(new FolderPermissionInfo(writePermission) { FolderPath = groupFolder.FolderPath, RoleID = groupId, AllowAccess = true });

                    groupFolder.IsProtected = true;
                    FolderManager.Instance.UpdateFolder(groupFolder);

                    groupFileId = fc.AddFile(groupFolder, FileUploadControl.PostedFile.FileName, FileUploadControl.PostedFile.InputStream, false, true, FileUploadControl.PostedFile.ContentType).FileId;
                }

            }                

            return groupFileId;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Globals.NavigateURL(PortalSettings.ActiveTab.TabID, PortalSettings, string.Empty, "groupId=" + GroupId.ToString()));
        }
    }
}