using motor.logic.common;
using motor.logic.model;
using motor.logic.services;
using motor.web.common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace motor.web.user
{
    public partial class driverDocuments : System.Web.UI.Page
    {
        UserService userService = new UserService();

        private bool ValidateFileSize(FileUpload flUpload)
        {
            decimal size = Math.Round(((decimal)flUpload.PostedFile.ContentLength / (decimal)1024), 2);
            if (size > 100)
            {
                return false;
            }
            return true;
        }

        private DriverDocument GetDriverDocument()
        {
            User usr = GetLoggedInUser();
            DriverDocument doc = null;
            if (usr != null)
            {
                doc = userService.GetDocumentByUserId(usr.Id);

            }
            return doc;
        }

        private void SaveDocumentImage(Button sender)
        {
            Stream fs = null;
            BinaryReader br = null;
            byte[] bytes = null;
            DriverDocument doc = GetDriverDocument();
            if (doc == null)
                throw new ArgumentNullException("DriverDocument");
            DocumentType docType = DocumentType.VehicleImage1;
            if (sender.ID == btnUploadVehPic1.ID)
            {
                fs = filUploadVehPic1.PostedFile.InputStream;
                docType = DocumentType.VehicleImage1;
            }
            else if (sender.ID == btnUploadVehPic2.ID)
            {
                fs = filUploadVehPic2.PostedFile.InputStream;
                docType = DocumentType.VehicleImage2;
            }
            else if (sender.ID == btnUploadLicenseCopy.ID)
            {
                fs = filUploadLicPic.PostedFile.InputStream;
                docType = DocumentType.LicenseImage;
                
            }
            br = new BinaryReader(fs);
            bytes = br.ReadBytes((Int32)fs.Length);
            if (userService.SaveDocumentImage(doc.Id, bytes, docType))
                lblMessage.Text = "Image uploaded successfully";

            //if all the document/images have been uploaded send the email
            if (doc.VehiclePicture1 != null && doc.VehiclePicture2 != null && doc.LicensePicture != null)
            {
                User usr = GetLoggedInUser();
                CommonUtils.SendEmail(EmailTemplate.DocumentsReceived, usr.Email, usr.Firstname, usr.Lastname);
            }
            
        }

        private User GetLoggedInUser()
        {
            return (User)Session[PageKeys.USERDATA];
        }

        private void LoadDriverDocuments()
        {
            DriverDocument doc = GetDriverDocument();
            if (doc == null)
                pnlDriverDocuments.Enabled = false;
            else
            {
                txtSSN.Text = doc.SSN;
                txtLicenseNumber.Text = doc.LicenseNumber;
                txtVehicleNumber.Text = doc.VehicleNumber;
                string imageHandlerUrl = PageKeys.GetImageHandlerUrl(PageKeys.ImageHandlerActions.Document);
                imgPreviewVehPic1.ImageUrl = imageHandlerUrl + "type="+DocumentType.VehicleImage1.ToString()+"&docId="+doc.Id;
                imgPreviewVehPic2.ImageUrl = imageHandlerUrl + "type=" + DocumentType.VehicleImage2.ToString() + "&docId=" + doc.Id;
                imgPreviewLicense.ImageUrl = imageHandlerUrl + "type=" + DocumentType.LicenseImage.ToString() + "&docId=" + doc.Id;


                pnlDriverDocuments.Enabled = true;
            }
        }

        private void SaveDocumentInfo()
        {
            DriverDocument doc = GetDriverDocument();
            if (doc == null)
            {
                doc = new DriverDocument();
                doc.UserId = GetLoggedInUser().Id;
                doc.LicenseNumber = txtLicenseNumber.Text;
                doc.SSN = txtSSN.Text;
                doc.VehicleNumber = txtVehicleNumber.Text;
                doc.Status = (short)DocumentStatus.Pending;
                userService.InsertDocumentInfo(doc);
            }
            else
            {
                doc.LicenseNumber = txtLicenseNumber.Text;
                doc.SSN = txtSSN.Text;
                doc.VehicleNumber = txtVehicleNumber.Text;
                userService.UpdateDocumentInfo(doc);
            }
            lblMessage.Text = "Document information saved successfully.";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadDriverDocuments();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SaveDocumentInfo();
            LoadDriverDocuments();
        }

        protected void btnUploadDocument_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
                SaveDocumentImage((Button)sender);

            LoadDriverDocuments();
        }

        protected void customVal_ServerValidate(object source, ServerValidateEventArgs args)
        {
            CustomValidator customValidator = (CustomValidator)source;
            FileUpload flUpload = null;
            if (customValidator.ID == customValImg1.ID)
                flUpload = filUploadVehPic1;
            else if (customValidator.ID == customValImg2.ID)
                flUpload = filUploadVehPic2;
            else if (customValidator.ID == customValImg3.ID)
                flUpload = filUploadLicPic;
            if (!ValidateFileSize(flUpload))
            {
                customValidator.ErrorMessage = "File size must not exceed 100 KB.";
                args.IsValid = false;
            }
        }
    }
}