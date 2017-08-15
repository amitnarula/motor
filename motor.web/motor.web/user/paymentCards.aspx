<%@ Page Title="" Language="C#" MasterPageFile="~/motorrider.master" AutoEventWireup="true" CodeBehind="paymentCards.aspx.cs" Inherits="motor.web.user.paymentCards" %>
<%@ Register src="../common/PaymentCards.ascx" tagname="PaymentCards" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="riderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="riderContent" runat="server">
    <uc1:PaymentCards ID="ucPaymentCards" runat="server" />
</asp:Content>
