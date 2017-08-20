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
    public partial class motorprivate : System.Web.UI.MasterPage
    {
        private void CheckUserValidity()
        {
            if (Session[PageKeys.USERDATA] == null)
                Response.Redirect(PageKeys.LoginPage);
            else
            {
                User usr = (User)Session[PageKeys.USERDATA];
                if (usr != null && usr.IsEmailVerified == false)
                {
                    Response.Redirect(PageKeys.ErrorPage + "?msg=Please verify your email first.");
                }
                else
                    lblMessage.Text = "Welcome," + usr.Firstname + " " + usr.Lastname;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CheckUserValidity();
        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            Session.Remove(PageKeys.USERDATA);
            Response.Redirect(PageKeys.LoginPage);
            
        }

        protected void lnkProfile_Click(object sender, EventArgs e)
        {

        }
    }
}