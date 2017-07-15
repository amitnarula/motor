using motor.logic.common;
using motor.logic.model;
using motor.web.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace motor.web
{
    public partial class motoradmin : System.Web.UI.MasterPage
    {
        private void CheckUserPermissions()
        {
            if (Session[PageKeys.USERDATA] == null)
                Response.Redirect(PageKeys.LoginPage);
            else
            {
                User usr = (User)Session[PageKeys.USERDATA];
                if (usr != null && usr.UserType != (short)UserType.SuperAdmin)
                    Response.Redirect(PageKeys.UnAuthorizedPage);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CheckUserPermissions();
        }
    }
}