<%@ Page Title="" Language="C#" MasterPageFile="~/motorpublic.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="motor.web.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <h2>Login</h2>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <table width="50%">
        <tr>
            <td>
                <asp:Label Text="Phone number:" runat="server" />
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtMobile" TextMode="Phone" MaxLength="20" />
                
            </td>
            <td><asp:RegularExpressionValidator ID="regExpMobile" Display="Dynamic" ErrorMessage="Please enter valid mobile number" ValidationExpression="\(?\d{3}\)?-? *\d{3}-? *-?\d{4}" ValidationGroup="gpLogin" ControlToValidate="txtMobile" runat="server" />
                <asp:RequiredFieldValidator Display="Dynamic" ErrorMessage="Please enter phone number" ControlToValidate="txtMobile" runat="server" ValidationGroup="gpLogin" /></td>
        </tr>
        <tr>
            <td>
                <asp:Label Text="Password:" runat="server" />
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" MaxLength="8" />
            </td>
            <td><asp:RequiredFieldValidator ErrorMessage="Please enter password" ControlToValidate="txtPassword" runat="server" ValidationGroup="gpLogin" /></td>
        </tr>
        <tr>
            <td>
                <asp:Button Text="Login" runat="server" ID="btnLogin" ValidationGroup="gpLogin" OnClick="btnLogin_Click" />
            </td>
            <td colspan="2">
                <asp:HyperLink NavigateUrl="#" Text="Forgot Password" runat="server" />
            </td>
            
        </tr>
        <tr>
            <td>
                </td>
            <td colspan="2">
                <asp:Label Text="" ID="lblErrorMessage" runat="server" /> </td>
            
        </tr>
    </table>
</asp:Content>
