<div class="dnnFormItem">
    <dnn:label ID="lblTitle" runat="server" />
    <asp:TextBox ID="txtTitle" CssClass="dnnFormRequired" runat="server" />
    <asp:RequiredFieldValidator ID="rqValTitle" CssClass="dnnFormMessage dnnFormError" runat="server"
        ControlToValidate="txtTitle" ErrorMessage="Title is required"></asp:RequiredFieldValidator>
</div>
<div class="dnnFormItem">
    <dnn:label ID="lblDescription" runat="server" />
    <asp:TextBox ID="txtDescription" CssClass="dnnFormRequired" runat="server" TextMode="MultiLine" Rows="3" />
    <asp:RequiredFieldValidator ID="rqValDescription" CssClass="dnnFormMessage dnnFormError" runat="server"
        ControlToValidate="txtDescription" ErrorMessage="Description is required"></asp:RequiredFieldValidator>
</div>

<ul class="dnnActions dnnClear">
    <li>
        <asp:LinkButton ID="btnSubmit" CssClass="dnnPrimaryAction" CausesValidation="true" onclick="btnSubmit_Click"
            runat="server">Save</asp:LinkButton>
    </li>
    <li>
        <asp:LinkButton ID="btnCancel" CssClass="dnnSecondaryAction" CausesValidation="false" onclick="btnCancel_Click"
            runat="server">Cancel</asp:LinkButton>
    </li>
</ul>