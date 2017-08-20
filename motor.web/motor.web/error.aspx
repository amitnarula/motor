<%@ Page Title="" Language="C#" MasterPageFile="~/motorpublic.Master" AutoEventWireup="true" CodeBehind="error.aspx.cs" Inherits="motor.web.error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <h1>
        <asp:Literal Text="[errorreason]" ID="litMessageReason" runat="server" /></h1>
</asp:Content>
