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

namespace motor.web
{
    public partial class manageDriverDocuments : System.Web.UI.Page
    {
        UserService usrSvc = new UserService();
        
        private string GetDocumentStatus(short status)
        {
            return Enum.GetName(typeof(DocumentStatus), status);
        }
        private void LoadDriverDocuments()
        {
            grdDriverDocuments.DataSource = usrSvc.GetAllDocuments();
            grdDriverDocuments.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
                LoadDriverDocuments();
        }

        protected void grdDriverDocuments_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DriverDocument doc = ((DriverDocument)e.Row.DataItem);

                long documentId = doc.Id;
                Image imgVehImg1 = e.Row.FindControl("imgVehImg1") as Image;
                imgVehImg1.ImageUrl = PageKeys.GetImageHandlerUrl(PageKeys.ImageHandlerActions.Document) + "type=" + DocumentType.VehicleImage1.ToString() + "&docId=" + documentId;

                Image imgVehImg2 = e.Row.FindControl("imgVehImg2") as Image;
                imgVehImg2.ImageUrl = PageKeys.GetImageHandlerUrl(PageKeys.ImageHandlerActions.Document) + "type=" + DocumentType.VehicleImage2.ToString() + "&docId=" + documentId;

                Image imgVehImg3 = e.Row.FindControl("imgVehImg3") as Image;
                imgVehImg3.ImageUrl = PageKeys.GetImageHandlerUrl(PageKeys.ImageHandlerActions.Document) + "type=" + DocumentType.LicenseImage.ToString() + "&docId=" + documentId;

                Label lblStatus = e.Row.FindControl("lblDocumentStatus") as Label;
                lblStatus.Text = GetDocumentStatus(doc.Status);

            }
        }

        protected void grdDriverDocuments_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "action")
            {
                var docId = Convert.ToInt64(e.CommandArgument);
                Response.Redirect(PageKeys.ManageDriverDocumentStatusPage + "?docId=" + docId);
            }
        }
    }
}