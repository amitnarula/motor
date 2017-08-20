using motor.logic.common;
using motor.logic.model;
using motor.logic.services;
using motor.web.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace motor.web.admin
{
    public partial class manageDocumentStatus : System.Web.UI.Page
    {
        UserService usrSvc = new UserService();

        private void GoToManageDriverDocumentsPage()
        {
            Response.Redirect(PageKeys.ManageDriverDocumentsPage);
        }

        private long FetchDocumentIdFromQueryString()
        {
            string documentId = Request.QueryString["docId"];
            if (string.IsNullOrEmpty(documentId))
                throw new ArgumentNullException("docId");
            return Convert.ToInt64(documentId);
        }

        private void LoadDriverDocumentDetails()
        {
            long docId = FetchDocumentIdFromQueryString();

            DriverDocument doc = usrSvc.GetDocumentById(docId);
            if (doc == null)
                throw new Exception("Document not found with the ID provided");

            lblFirstName.Text = doc.User.Firstname;
            lblLastName.Text = doc.User.Lastname;
            lblEmail.Text = doc.User.Email;
            lblDocumentId.Text = doc.Id.ToString();
            lblLicenseNumber.Text = doc.LicenseNumber;
            lblSSN.Text = doc.SSN.ToString();
            lblVehicleNumber.Text = doc.VehicleNumber;

            imgPreviewVehicleImage1.ImageUrl = PageKeys.GetImageHandlerUrl(PageKeys.ImageHandlerActions.Document) + "type=" + DocumentType.VehicleImage1.ToString() + "&docId=" + docId;
            imgPreviewVehicleImage2.ImageUrl = PageKeys.GetImageHandlerUrl(PageKeys.ImageHandlerActions.Document) + "type=" + DocumentType.VehicleImage2.ToString() + "&docId=" + docId;
            imgPreviewVehicleImage3.ImageUrl = PageKeys.GetImageHandlerUrl(PageKeys.ImageHandlerActions.Document) + "type=" + DocumentType.LicenseImage.ToString() + "&docId=" + docId;

            SetActionButtonStatus((DocumentStatus)doc.Status);
        }
        private void SetActionButtonStatus(DocumentStatus status)
        {
            switch (status)
            {
                case DocumentStatus.Pending:
                    btnAction.Text = PageKeys.DocumentActionStatus.VERIFY.ToString();
                    break;
                case DocumentStatus.Verified:
                    btnAction.Text = PageKeys.DocumentActionStatus.SCHEDULE_INTERVIEW.ToString();
                    break;
                case DocumentStatus.InterviewScheduled:
                    btnAction.Text = PageKeys.DocumentActionStatus.INTERVIEW_SCHEDULED.ToString();
                    btnAction.Enabled = false;
                    break;
                case DocumentStatus.Rejected:
                    btnAction.Text = PageKeys.DocumentActionStatus.REJECTED.ToString();
                    btnAction.Enabled = false;
                    btnReject.Enabled = false;
                    break;
                default:
                    break;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadDriverDocumentDetails();
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            usrSvc.UpdateDocumentStatus(FetchDocumentIdFromQueryString(), DocumentStatus.Rejected);
            CommonUtils.SendEmail(EmailTemplate.DocumentsRejected, lblEmail.Text, lblFirstName.Text, lblLastName.Text);
            GoToManageDriverDocumentsPage();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            GoToManageDriverDocumentsPage();
        }

        protected void btnAction_Click(object sender, EventArgs e)
        {
            if (btnAction.Text == PageKeys.DocumentActionStatus.VERIFY.ToString())
            {
                //verify the application/document by driver
                usrSvc.UpdateDocumentStatus(FetchDocumentIdFromQueryString(), DocumentStatus.Verified);
                CommonUtils.SendEmail(EmailTemplate.DocumentsVerified, lblEmail.Text, lblFirstName.Text, lblLastName.Text);

            }
            else if (btnAction.Text == PageKeys.DocumentActionStatus.SCHEDULE_INTERVIEW.ToString())
            {
                //Schedule the interview
                usrSvc.UpdateDocumentStatus(FetchDocumentIdFromQueryString(), DocumentStatus.InterviewScheduled);
                Dictionary<string, string> emailParams = new Dictionary<string, string>();
                emailParams.Add(EmailTemplateParams.InterviewDate.ToString(), DateTime.UtcNow.ToShortDateString());
                CommonUtils.SendEmail(EmailTemplate.ScheduleAnInterview, lblEmail.Text, lblFirstName.Text, lblLastName.Text, emailParams);
            }
            GoToManageDriverDocumentsPage();
            
        }
    }
}