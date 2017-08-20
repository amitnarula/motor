<%@ Page Title="" Language="C#" MasterPageFile="~/motorprivate.Master" AutoEventWireup="true" CodeBehind="unauthorized.aspx.cs" Inherits="motor.web.unauthorized" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h2>You are not authorized to view this content.</h2>
    <asp:Label Text="[reason]" ID="lblMessageReason" runat="server" />
</asp:Content>
