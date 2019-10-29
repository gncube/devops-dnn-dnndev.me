<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Edit.ascx.cs" Inherits="GSN.Modules.Documents.Edit" %>
<%@ Import Namespace="DotNetNuke.Services.Localization" %>
<%@ Register TagPrefix="Portal" TagName="URL" Src="~/controls/URLControl.ascx" %>
<%@ Register TagPrefix="Portal" TagName="Tracking" Src="~/controls/URLTrackingControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/labelcontrol.ascx" %>

<div class="dnnForm dnnEditDocs dnnClear" id="dnnEditDocs"><div class="dnnFormItem dnnFormHelp dnnClear"><p class="dnnFormRequired"><span><%=LocalizeString("RequiredFields")%></span></p></div>
    <div class="dnnFormItem">
        <dnn:label id="plName" runat="server" controlname="txtName" suffix=":" CssClass="dnnFormRequired" />
        <asp:textbox id="txtName" runat="server" maxlength="150" CssClass="dnnFormRequired" />
        <asp:requiredfieldvalidator id="valName" runat="server" cssclass="dnnFormMessage dnnFormError" resourcekey="Name.ErrorMessage" display="Dynamic" errormessage="You Must Enter A Title For The Document" controltovalidate="txtName" />
    </div>
    <div class="dnnFormItem">
        <dnn:label id="plURL" runat="server" controlname="ctlURL" suffix=":" />
        <div class="">
            <portal:url id="ctlURL" runat="server" showtabs="False" shownone="True" urltype="F" shownewwindow="True" ShowSecure="True" ShowDatabase="True" ShowFiles="False" />
        </div>
    </div>
    <div class="dnnFormItem">
        <asp:label id="lblAudit" runat="server" />
        <div class="dnnRight">
            <portal:tracking id="ctlTracking" runat="server" />
        </div>
    </div>
    <ul class="dnnActions dnnClear">
        <li><asp:linkbutton id="cmdUpdate" runat="server" cssclass="dnnPrimaryAction" resourcekey="cmdUpdate" text="Update" /></li>
        <li><asp:LinkButton ID="cmdUpdateOverride" runat="server" CssClass="dnnSecondaryAction" resourcekey="cmdUpdateOverride" Text="Update Anyway" Visible="False" /></li>
        <li><asp:linkbutton id="cmdCancel" runat="server" cssclass="dnnSecondaryAction" resourcekey="cmdCancel" causesvalidation="False" text="Cancel" /></li>
        <li><asp:linkbutton id="cmdDelete" runat="server" cssclass="dnnSecondaryAction" resourcekey="cmdDelete" causesvalidation="False" text="Delete" /></li>
    </ul>
</div>