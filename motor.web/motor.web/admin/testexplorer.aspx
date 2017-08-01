<%@ Page Title="" Language="C#" MasterPageFile="~/motoradmin.master" AutoEventWireup="true" CodeBehind="testexplorer.aspx.cs" Inherits="motor.web.testexplorer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="adminHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="adminContent" runat="server">
    <h2>API REST Client</h2>
    <asp:Button Text="Login" ID="btnLogin" runat="server" OnClick="btnLogin_Click" />
    <asp:Button Text="Save Document Info" runat="server" ID="btnSaveDocumentInfo" OnClick="btnSaveDocumentInfo_Click" />
    <asp:Button Text="Save Document Data" runat="server" ID="btnSaveDocumentData" />
    <br />
    <asp:Literal ID="litResponse" runat="server"></asp:Literal>
</asp:Content>
