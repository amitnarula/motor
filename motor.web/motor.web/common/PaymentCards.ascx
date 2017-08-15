<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PaymentCards.ascx.cs" Inherits="motor.web.common.PaymentCards" %>
<table width="40%">
    <tr>
        <td>
            <asp:Label ID="lblCardNumber" runat="server" Text="Card Number"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtCardNumber" MaxLength="16" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ErrorMessage="Please enter card number" ControlToValidate="txtCardNumber" ValidationGroup="btnSave" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblCardName" runat="server" Text="Card Name"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtCardName" MaxLength="100" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ErrorMessage="Please enter name" ControlToValidate="txtCardName" ValidationGroup="btnSave" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblExpiry" runat="server" Text="MM / YYYY"></asp:Label>
        </td>
        <td>
            <asp:DropDownList runat="server" ID="ddlMonth">
                
            </asp:DropDownList>
            <asp:DropDownList runat="server" ID="ddlYear">
                
            </asp:DropDownList>
        </td>
        
        
    </tr>
    <tr>
        <td>
            <asp:Label Text="CVV" ID="lblCVV" runat="server" />
        </td>
        <td>
            <asp:TextBox runat="server" ID="txtCVV" MaxLength="5" />
        </td>
        <td>
            <asp:RequiredFieldValidator ErrorMessage="Please enter CVV" ControlToValidate="txtCVV" ValidationGroup="btnSave" runat="server" />
        </td>
    </tr>
    <tr>
        <td></td>
        <td>
            <asp:Button Text="Save" ID="btnSave" runat="server" ValidationGroup="btnSave" OnClick="btnSave_Click" />
        </td>
    </tr>

</table>
<asp:GridView runat="server" AutoGenerateColumns="False" ID="grdPaymentCards" OnRowCommand="grdPaymentCards_RowCommand">
    <Columns>
        <asp:BoundField DataField="CardNumber" HeaderText="Card Number" />
        <asp:BoundField DataField="CardName" HeaderText="Name" />
        <asp:BoundField DataField="ExpiryMonth" HeaderText="Expiry Month" />
        <asp:BoundField DataField="ExpiryYear" HeaderText="Expiry Year" />
        <asp:TemplateField>
            <ItemTemplate>
                <asp:Button Text="Edit" ID="btnEdit" CommandName="editCard" CommandArgument='<%#Bind("Id") %>' runat="server" />
                <asp:Button Text="Delete" OnClientClick="return confirm('Do you want to remove this card?')" ID="btnDelete" CommandName="deleteCard" CommandArgument='<%#Bind("Id") %>' runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>

