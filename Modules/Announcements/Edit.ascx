<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Edit.ascx.cs" Inherits="GSN.Modules.Announcements.Edit" %>
<%@ Import Namespace="DotNetNuke.Services.Localization" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/labelcontrol.ascx" %>
<%@ Register TagPrefix="dnn" Assembly="DotNetNuke.Web" Namespace="DotNetNuke.Web.UI.WebControls" %>

<div class="dnnForm">
    <fieldset>
        <div class="dnnFormItem">
            <dnn:label ID="lblTitle" runat="server" />
            <asp:TextBox ID="txtTitle" CssClass="dnnFormRequired" runat="server" />
            <asp:RequiredFieldValidator ID="rqValTitle" CssClass="dnnFormMessage dnnFormError" runat="server" ControlToValidate="txtTitle"
                ErrorMessage="Title is required"></asp:RequiredFieldValidator>
        </div>
        <div class="dnnFormItem">
            <dnn:label ID="lblPicture" runat="server" />
            <dnn:DnnFilePicker runat="server" ID="fpPicture" FileFilter="jpg,png,gif" />
        </div>
        <div class="dnnFormItem">
            <dnn:label ID="lblPrice" runat="server" />
            <asp:TextBox ID="txtPrice" CssClass="dnnFormRequired" MaxLength="8" runat="server" Width="80px" />
            <asp:RequiredFieldValidator ID="rqValPrice" CssClass="dnnFormMessage dnnFormError" runat="server" ControlToValidate="txtPrice"
                ErrorMessage="Price is required"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="valCmpPrice" CssClass="dnnFormMessage dnnFormError" runat="server" Type="Double" ControlToValidate="txtPrice" 
                Operator="DataTypeCheck" ErrorMessage="Price must be a valid number"></asp:CompareValidator>
        </div>
        <div class="dnnFormItem">
            <dnn:label ID="lblDescription" runat="server" />
            <asp:TextBox ID="txtDescription" CssClass="dnnFormRequired" runat="server" TextMode="MultiLine" Rows="3" />
            <asp:RequiredFieldValidator ID="rqValDescription" CssClass="dnnFormMessage dnnFormError" runat="server" ControlToValidate="txtDescription"
                ErrorMessage="Description is required"></asp:RequiredFieldValidator>
        </div>
        <div class="dnnFormItem">
            <dnn:label ID="lblDailySpecial" runat="server" />
            <asp:CheckBox ID="chkDailySpecial" runat="server" />
        </div>
        <div class="dnnFormItem">
            <dnn:label ID="lblVegetarian" runat="server" />
            <asp:CheckBox ID="chkVegetarian" runat="server" />
        </div>
        <ul class="dnnActions dnnClear">
			<li>
                <asp:LinkButton ID="btnSubmit" CssClass="dnnPrimaryAction" CausesValidation="true" runat="server">Save</asp:LinkButton>
            </li>
			<li>
                <asp:LinkButton ID="btnCancel" CssClass="dnnSecondaryAction" CausesValidation="false" runat="server">Cancel</asp:LinkButton>
            </li>
		    </ul>
    </fieldset>
</div>