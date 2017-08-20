<%@ Page Title="" Language="C#" MasterPageFile="~/motordriver.master" AutoEventWireup="true" CodeBehind="driverDocuments.aspx.cs" Inherits="motor.web.user.driverDocuments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="driverHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="driverContent" runat="server">
    <table width="50%">
        <colgroup>
            <col width="30%" />
            <col width="40%" />
            <col width="30%" />
        </colgroup>
        <tr>
            <td>
                <asp:Label Text="SSN:" runat="server" /></td>
            <td>
                <asp:TextBox runat="server" ID="txtSSN" MaxLength="12" />
            </td>
            <td>
                <asp:RequiredFieldValidator ErrorMessage="Please enter SSN" ValidationGroup="gpBasicInfo" ControlToValidate="txtSSN" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label Text="Driving License Number:" runat="server" /></td>
            <td>
                <asp:TextBox runat="server" ID="txtLicenseNumber" MaxLength="10" />
            </td>
            <td>
                <asp:RequiredFieldValidator ErrorMessage="Please enter license number" ValidationGroup="gpBasicInfo" ControlToValidate="txtLicenseNumber" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label Text="Vehicle number:" runat="server" /></td>
            <td>
                <asp:TextBox runat="server" ID="txtVehicleNumber" MaxLength="10" />
            </td>
            <td>
                <asp:RequiredFieldValidator ErrorMessage="Please enter vehicle number" ValidationGroup="gpBasicInfo" ControlToValidate="txtVehicleNumber" runat="server" />
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button Text="Save" ID="btnSave" ValidationGroup="gpBasicInfo" runat="server" OnClick="btnSave_Click" />
            </td>
            <td>&nbsp;</td>
        </tr>

    </table>
    <asp:Panel runat="server" ID="pnlDriverDocuments">
        <table>
            <colgroup>
                <col width="30%" />
                <col width="40%" />
                <col width="30%" />
            </colgroup>
            <tr>
                <td>
                    <asp:Label ID="lblVehiclePic1" runat="server" Text="Vehicle picture 1:"></asp:Label>
                </td>
                <td>
                    <asp:FileUpload ID="filUploadVehPic1" runat="server" />
                    <asp:Button ID="btnUploadVehPic1" runat="server" Text="Upload" OnClick="btnUploadDocument_Click" ValidationGroup="gpUploadImage1" />
                    <asp:CustomValidator  runat="server" ID="customValImg1" ControlToValidate="filUploadVehPic1" OnServerValidate="customVal_ServerValidate"  ValidationGroup="gpUploadImage1" ErrorMessage="(Allowed types: jpg, jpeg, gif, png)" ClientValidationFunction="UploadFileCheck"></asp:CustomValidator>
                    <asp:RequiredFieldValidator ErrorMessage="Please select image" ControlToValidate="filUploadVehPic1" runat="server" ValidationGroup="gpUploadImage1" />
                </td>
                <td>
                    <asp:Image ID="imgPreviewVehPic1" runat="server" Height="100px" Width="150px" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblVehiclePic2" runat="server" Text="Vehicle picture 2:"></asp:Label>
                </td>
                <td>
                    <asp:FileUpload ID="filUploadVehPic2" runat="server" />
                    <asp:Button ID="btnUploadVehPic2" runat="server" Text="Upload" OnClick="btnUploadDocument_Click" ValidationGroup="gpUploadImage2" />
                    <asp:CustomValidator runat="server" ID="customValImg2" ControlToValidate="filUploadVehPic2"  OnServerValidate="customVal_ServerValidate"  ValidationGroup="gpUploadImage2" ErrorMessage="(Allowed types: jpg, jpeg, gif, png)" ClientValidationFunction="UploadFileCheck"></asp:CustomValidator>
                    
                    <asp:RequiredFieldValidator ErrorMessage="Please select image" ControlToValidate="filUploadVehPic2" runat="server" ValidationGroup="gpUploadImage2" />
                </td>
                <td>
                    <asp:Image ID="imgPreviewVehPic2" runat="server" Height="100px" Width="150px" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblDrivingLicense" runat="server" Text="Driving license copy:"></asp:Label>
                </td>
                <td>
                    <asp:FileUpload ID="filUploadLicPic" runat="server" />
                    <asp:Button ID="btnUploadLicenseCopy" runat="server" Text="Upload" OnClick="btnUploadDocument_Click" ValidationGroup="gpUploadImage3" />
                    <asp:CustomValidator runat="server" ID="customValImg3" ControlToValidate="filUploadLicPic" OnServerValidate="customVal_ServerValidate" ValidationGroup="gpUploadImage3" ErrorMessage="(Allowed types: jpg, jpeg, gif, png)" ClientValidationFunction="UploadFileCheck"></asp:CustomValidator>
                    
                    <asp:RequiredFieldValidator ErrorMessage="Please select image" ControlToValidate="filUploadLicPic" runat="server" ValidationGroup="gpUploadImage3" />
                </td>
                <td>
                    <asp:Image ID="imgPreviewLicense" runat="server" Height="100px" Width="150px" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label Text="" ID="lblMessage" runat="server" />
                </td>
                <td></td>
                <td></td>
            </tr>
        </table>
    </asp:Panel>
    <script type="text/javascript">
        function UploadFileCheck(source, arguments) {
            var sFile = arguments.Value;
            arguments.IsValid = ((sFile.match(/\.jpe?g$/i)) ||
                (sFile.match(/\.gif$/i)) ||
                (sFile.match(/\.bmp$/i)) ||
                (sFile.match(/\.tif?f$/i)) ||
                (sFile.match(/\.png$/i)));
        }
    </script>
</asp:Content>
