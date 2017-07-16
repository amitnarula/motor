﻿<%@ Page Title="" Language="C#" MasterPageFile="~/motoradmin.master" AutoEventWireup="true" CodeBehind="manageDriverDocuments.aspx.cs" Inherits="motor.web.manageDriverDocuments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="adminHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="adminContent" runat="server">
    <asp:GridView runat="server" ID="grdDriverDocuments" AutoGenerateColumns="False" OnRowDataBound="grdDriverDocuments_RowDataBound">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Document ID" />
            <asp:BoundField DataField="SSN" HeaderText="SSN" />
            <asp:BoundField DataField="LicenseNumber" HeaderText="License Number" />
            <asp:TemplateField>
                <HeaderTemplate>
                    Vehicle Image 1
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Image ID="imgVehImg1" Height="100" Width="150"  runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    Vehicle Image 2
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Image ID="imgVehImg2" Height="100" Width="150"  runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    Vehicle Image 3
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Image ID="imgVehImg3" Height="100" Width="150"  runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            
        </Columns>
        
    </asp:GridView>
</asp:Content>
