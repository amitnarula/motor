<%@ Page Title="" Language="C#" MasterPageFile="~/motorpublic.Master" AutoEventWireup="true" CodeBehind="download.aspx.cs" Inherits="motor.web.download" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <table width="40%">
        <colgroup>
            <col width="40%" />
            <col width="60%" />
        </colgroup>
        <tr>
            <td>
                <asp:TextBox runat="server" ID="txtMobile" MaxLength="20" />(XXX)XXXXXXX

            </td>

            <td>
                <asp:Button Text="Download App" runat="server" ValidationGroup="gpDownload" OnClick="Unnamed1_Click" /><asp:RegularExpressionValidator ID="regExpMobile" Display="Dynamic" ErrorMessage="Please enter valid mobile number" ValidationExpression="\(?\d{3}\)?-? *\d{3}-? *-?\d{4}" ValidationGroup="gpDownload" ControlToValidate="txtMobile" runat="server" />
                <asp:RequiredFieldValidator Display="Dynamic" ErrorMessage="Please enter phone number" ControlToValidate="txtMobile" runat="server" ValidationGroup="gpDownload" />
            </td>
        </tr>
    </table>
    <asp:Label Text="" ID="lblInfo" runat="server" />

</asp:Content>
