<%@ Page Title="" Language="C#" MasterPageFile="~/motoradmin.master" AutoEventWireup="true" CodeBehind="manageDocumentStatus.aspx.cs" Inherits="motor.web.admin.manageDocumentStatus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="adminHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="adminContent" runat="server">
    <table width="50%">
        <tr>
            <td>
                <asp:Label Text="Document ID" runat="server" /></td>
            <td>
                <asp:Label Text="[documentID]" ID="lblDocumentId" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label Text="First name" runat="server" /></td>
            <td>
                <asp:Label ID="lblFirstName" Text="[firstname]" runat="server" />
            </td>
        </tr>
         <tr>
            <td>
                <asp:Label Text="Last name" runat="server" /></td>
            <td>
                <asp:Label ID="lblLastName" Text="[lastname]" runat="server" />
            </td>
        </tr>
         <tr>
            <td>
                <asp:Label Text="Email" runat="server" /></td>
            <td>
                <asp:Label ID="lblEmail" Text="[email]" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label Text="License Number" runat="server" /></td>
            <td>
                <asp:Label Text="[licensenumber]" ID="lblLicenseNumber" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label Text="SSN" runat="server" /></td>
            <td>
                <asp:Label Text="[SSN]" ID="lblSSN" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label Text="Vehicle No." runat="server" /></td>
            <td>
                <asp:Label Text="[vehiclenumber]" ID="lblVehicleNumber" runat="server" />
            </td>
        </tr>
         <tr>
            <td>
                <asp:Label Text="Document files" runat="server" /></td>
            <td>
                <asp:Image ID="imgPreviewVehicleImage1" Height="100" Width="150" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                </td>
            <td>
                <asp:Image ID="imgPreviewVehicleImage2" Height="100" Width="150" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                </td>
            <td>
                <asp:Image ID="imgPreviewVehicleImage3" Height="100" Width="150" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label Text="Actions" runat="server" /></td>
            <td>
                <asp:Button Text="[Action]" ID="btnAction" runat="server" OnClick="btnAction_Click" />
                <asp:Button Text="Reject" ID="btnReject" OnClientClick="javascript:return confirm('Are you sure you want to reject this application?')" OnClick="btnReject_Click" runat="server" />
                <asp:Button Text="Cancel" ID="btnCancel" OnClick="btnCancel_Click" runat="server" />
            </td>
        </tr>
        
    </table>
</asp:Content>
