<%@ Control Language="c#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="GSN.Modules.Documents.View" %>
<%@ Import Namespace="DotNetNuke.Services.Localization" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/labelcontrol.ascx" %>

<div class="row margin-bottom-20">
    <div class="col-md-12">
        <asp:LinkButton ID="btnNewDocument" runat="server" CssClass="btn btn-primary pull-right" OnClick="btnNewDocument_Click">
        <i class="fa fa-upload"></i> Upload completed file
        </asp:LinkButton>
    </div>
</div>

<asp:Repeater ID="rptItemList" runat="server" OnItemDataBound="rptItemListOnItemDataBound" OnItemCommand="rptItemListOnItemCommand">
    <HeaderTemplate>
        <div id="pnl_restarauntmenu_items">
            <div id="NoRecords" runat="server" class="alert alert-info" role="alert" visible="false">
                <%=LocalizeString("NoRecords")%>
            </div>
    </HeaderTemplate>

    <ItemTemplate>
        <asp:Panel ID="pnlMenuitem" CssClass="menu-item" runat="server">
            <%--<div class="item-imagearea">
                <asp:Image ID="imgItemPic" CssClass="itemimages-main" Width="225" Height="150" runat="server" />
                <asp:Panel ID="pnlFeatures" CssClass="itemimages-feature" runat="server" />
            </div>--%>
            <div class="documents">
                <i class="fa fa-file-excel-o fa-4x fa-pull-left"></i>
                <div class="pull-right">
                    <%--<a href='<%#DataBinder.Eval(Container.DataItem,"FileId") %>'
                        type="button"
                        class="btn btn-success">
                        <i class="fa fa-download"></i>Download
                    </a>--%>
                    <%--<asp:LinkButton ID="lnkDownload" runat="server" CssClass="btn btn-success" CommandName="Download"><i class="fa fa-download"></i> Download</asp:LinkButton>--%>
                    <asp:HyperLink ID="hypDocumentFile" runat="server" CssClass="btn btn-success" Visible="false"><i class="fa fa-download"></i> Download</asp:HyperLink>
                </div>
                <h4>
                    <strong>
                        <asp:Label ID="lblName" CssClass="strong" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"CohortStartDate", "{0:dd MMM yyyy}") %>' />
                        Cohort</strong>
                    <span class="label label-info"><%#DataBinder.Eval(Container.DataItem,"Action").ToString() %></span>
                </h4>
                <ul class="list-inline">
                    <li>
                        <strong>Posted by: </strong><a href="mailto:<%#GetDisplayName(Convert.ToInt32(DataBinder.Eval(Container.DataItem,"CreatedByUserId"))) %>"><%#GetDisplayName(Convert.ToInt32(DataBinder.Eval(Container.DataItem,"CreatedByUserId"))) %></a>
                    </li>
                    <li>on <%#DataBinder.Eval(Container.DataItem,"CreatedOnDate", "{0:dd MMM yyyy}") %></li>
                </ul>

                <%--<asp:Label ID="lblCreatedByUserId" CssClass="item-desc" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"CreatedByUserId") %>' />--%>

                <asp:Panel ID="pnlAdmin" CssClass="admin-actions" runat="server" Visible="false">
                    <asp:HyperLink ID="lnkEdit" runat="server" ResourceKey="EditItem.Text" Visible="false" Enabled="false">Edit</asp:HyperLink>
                    <asp:LinkButton ID="lnkDelete" runat="server" ResourceKey="DeleteItem.Text" Visible="false" Enabled="false" CommandName="Delete">Delete</asp:LinkButton>
                </asp:Panel>
            </div>
            <hr class="bg-primary" />
        </asp:Panel>
    </ItemTemplate>

    <FooterTemplate>
        </div>
    </FooterTemplate>
</asp:Repeater>


