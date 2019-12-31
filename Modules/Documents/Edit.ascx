<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Edit.ascx.cs" Inherits="GSN.Modules.Documents.Edit" %>
<%@ Import Namespace="DotNetNuke.Services.Localization" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/labelcontrol.ascx" %>
<%@ Register TagPrefix="dnn" Assembly="DotNetNuke.Web" Namespace="DotNetNuke.Web.UI.WebControls" %>
<%@ Register TagPrefix="dnn" Assembly="DotNetNuke.Web.Deprecated" Namespace="DotNetNuke.Web.UI.WebControls" %>

<link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">

<h1><asp:Label ID="lblHeader" runat="server"></asp:Label></h1>
<p></p>
<p></p>
<div class="dnnForm">

    <fieldset>
        <div class="dnnFormItem">
            <dnn:Label runat="server" ControlName="txtCohortStartDate" Text="Cohort Start Date" HelpText="Cohort Start Date" />
            <%--<dnn:DnnDatePicker ID="dpStartDate" runat="server" />--%>
            <asp:TextBox ID="txtCohortStartDate" runat="server" CssClass="dnnFormRequired datepicker" />
            <asp:CompareValidator ID="valCohortStartDate" 
                resourcekey="valCohortStartDate.ErrorMessage" 
                Operator="DataTypeCheck" Type="Date" runat="server" 
                Display="Dynamic" 
                ControlToValidate="txtCohortStartDate" CssClass="dnnFormMessage dnnFormError" />
        </div>

<%--        <div class="dnnFormItem">
            <dnn:Label runat="server" ControlName="rdbAction" Text="Action" HelpText="Select action" CssClass="dnnFormRequired" />
            <asp:RadioButtonList runat="server" ID="rdbAction"
                RepeatDirection="Horizontal" CssClass="dnnFormRadioButtons">
                <asp:ListItem Text="New Cohort" />
                <asp:ListItem Text="End of programme" />
            </asp:RadioButtonList>
        </div>--%>

        <div class="dnnFormItem">
            <dnn:Label runat="server" ControlName="dplAction" ResourceKey="Choice" Text="Action" HelpText="Select action" CssClass="dnnFormRequired" />
            <asp:DropDownList runat="server" ID="dplAction" CssClass="form-control">
                <asp:ListItem Text="-- Select the action --" />
                <asp:ListItem Text="New cohort" />
                <asp:ListItem Text="End of progarmme" />
                <asp:ListItem Text="Dec 19" />
                <asp:ListItem Text="Mar 20" />
                <asp:ListItem Text="Jun 20" />
                <asp:ListItem Text="Sep 20" />
                <asp:ListItem Text="Dec 20" />
            </asp:DropDownList>
        </div>

        <div class="form-group dnnFormItem">
            <dnn:Label runat="server" cssclass="dnnFormRequired" Text="NA Upload" HelpText="Upload the document" />
            <asp:FileUpload id="FileUploadControl" runat="server"  />
            <p></p>
            <asp:LinkButton ID="btnDocumentUpload" runat="server" CssClass="btn btn-default" Visible="false"></asp:LinkButton>
            <asp:HyperLink ID="hypDocumentFile" runat="server" CssClass="btn btn-warning" Visible="false"></asp:HyperLink>
        </div>
    </fieldset>
        <ul class="dnnActions dnnClear">
        <li><asp:LinkButton runat="server" CssClass="dnnPrimaryAction" ID="btnSave" OnClick="btnSave_Click">Save</asp:LinkButton></li>
        <li><asp:LinkButton runat="server" CssClass="dnnSecondaryAction" ID="btnCancel" OnClick="btnCancel_Click">Cancel</asp:LinkButton></li>
    </ul>
</div>


<script type="text/javascript">
    /*globals jQuery, window, Sys */

    $(function () { // will trigger when the document is ready
        $('.datepicker').datepicker(
            {
                changeMonth: true,
                changeYear: true,
                minDate: "-2Y",
                maxDate: "+5Y +10D",
                dateFormat: 'dd/mm/yy'
            }
        ); //Initialise any date pickers
    });
</script>