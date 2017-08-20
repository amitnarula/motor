using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace motor.web.common
{
    public class PageKeys
    {
        internal enum ImageHandlerActions
        {
            Document,
            ProfilePicture
        }
        internal enum DocumentActionStatus
        {
            PENDING=0,
            VERIFY = 1,
            SCHEDULE_INTERVIEW = 2,
            INTERVIEW_SCHEDULED = 3,
            REJECTED = 4
        }

        internal readonly static string AdminHome = "~/admin/admin.aspx";
        internal readonly static string LoginPage="~/login.aspx";
        internal readonly static string RiderHome = "~/user/rider.aspx";
        internal readonly static string DriverHome = "~/user/driver.aspx";
        internal readonly static string USERDATA = "USERDATA";
        internal readonly static string UnAuthorizedPage="~/unauthorized.aspx";
        internal readonly static string DriverDocumentsPage="~/user/driverDocuments.aspx";
        internal readonly static string ManageDriverDocumentStatusPage = "~/admin/managedocumentstatus.aspx";
        internal static readonly string ManageDriverDocumentsPage="~/admin/managedriverdocuments.aspx";
        internal static readonly string ErrorPage="~/error.aspx";

        internal static string GetImageHandlerUrl(ImageHandlerActions action)
        {
            string url = "~/image.ashx?";
            switch (action)
            {
                case ImageHandlerActions.Document:
                    url += "action=doc&";
                    break;
                case ImageHandlerActions.ProfilePicture:
                    url += "action=pp&";
                    break;
                default:
                    break;
            }
            return url;
        }
    }
}