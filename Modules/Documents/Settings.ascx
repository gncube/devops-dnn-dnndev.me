<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Settings.ascx.cs" Inherits="GSN.Modules.Documents.Settings" %>
<%@ Import Namespace="DotNetNuke.Services.Localization" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/labelcontrol.ascx" %>

<div class="dnnForm dnnDocSettings" id="dnnDocSettings">
    <h3>Added the settings</h3>
    <div class="dnnFormItem">
        <dnn:label id="plDefaultFolder" runat="server" controlname="cboDefaultFolder" suffix="" />
        <asp:DropDownList ID="cboDefaultFolder" runat="server" />
    </div>
</div>
