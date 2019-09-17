<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Edit.ascx.cs" Inherits="GSN.Modules.Documents.Edit" %>
<%@ Import Namespace="DotNetNuke.Services.Localization" %>
<%@ Register TagPrefix="Portal" TagName="URL" Src="~/controls/URLControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/labelcontrol.ascx" %>

<div class="dnnForm dnnEditDocs dnnClear" id="dnnEditDocs"><div class="dnnFormItem dnnFormHelp dnnClear"><p class="dnnFormRequired"><span><%=LocalizeString("RequiredFields")%></span></p></div>
    <div class="dnnFormItem">
        <dnn:label id="plName" runat="server" controlname="txtName" suffix=":" CssClass="dnnFormRequired" />
        <asp:textbox id="txtName" runat="server" maxlength="150" CssClass="dnnFormRequired" />
        <asp:requiredfieldvalidator id="valName" runat="server" cssclass="dnnFormMessage dnnFormError" resourcekey="Name.ErrorMessage" display="Dynamic" errormessage="You Must Enter A Title For The Document" controltovalidate="txtName" />
    </div>
    <div class="dnnFormItem">
        <dnn:label id="plOwner" runat="server" controlname="lstOwner" suffix=":" />
        <asp:dropdownlist id="lstOwner" runat="server" Visible="False" />
        <asp:label id="lblOwner" runat="server" />
        <asp:linkbutton id="lnkChange" runat="server" cssclass="dnnSecondaryAction" resourcekey="lnkChangeOwner" causesvalidation="False" text="Change Owner" />
    </div>
    <div class="dnnFormItem">
        <dnn:label id="plURL" runat="server" controlname="ctlURL" suffix=":" />
        <div class="dnnRight">
            <portal:url id="ctlURL" runat="server" showtabs="False" shownone="True" urltype="F" shownewwindow="True" ShowSecure="True" ShowDatabase="True" />
        </div>
    </div>
</div>