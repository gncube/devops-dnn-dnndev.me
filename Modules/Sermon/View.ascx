<%@ Control Language="c#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="GSN.Modules.Sermon.View" %>
<%@ Import Namespace="DotNetNuke.Services.Localization" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/labelcontrol.ascx" %>

<asp:Repeater ID="rptItemList" runat="server">
    <HeaderTemplate>
        <div id="pnl_example_items">
            <div id="NoRecords" runat="server" visible="false">
                <%=LocalizeString("NoRecords")%>
            </div>
    </HeaderTemplate>
    <ItemTemplate>
        <asp:Label ID="lblTitle" runat="server" CssClass="" Text='<%#DataBinder.Eval(Container.DataItem,"Title").ToString() %>'></asp:Label>
        <asp:Label ID="lblDescription" CssClass="" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Description").ToString() %>'></asp:Label>
        
        <asp:Panel ID="pnlAdmin" CssClass="admin-actions" runat="server" Visible="false">
            <asp:HyperLink ID="lnkEdit" runat="server" ResourceKey="EditItem.Text" Visible="false" Enabled="false" />
            <asp:LinkButton ID="lnkDelete" runat="server" ResourceKey="DeleteItem.Text" Visible="false" Enabled="false" CommandName="Delete" />
        </asp:Panel>
    </ItemTemplate>
    <FooterTemplate>

    </FooterTemplate>
</asp:Repeater>
