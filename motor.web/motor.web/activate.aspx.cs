using motor.logic.common;
using motor.logic.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace motor.web
{
    public partial class activate : System.Web.UI.Page
    {
        UserService svc = new UserService();
        protected void Page_Load(object sender, EventArgs e)
        {
            ActivateUser();
        }

        private void ActivateUser()
        {
            string activationCode = Request.QueryString["activationCode"];
            string pad = Request.QueryString["pad"];
            if (!string.IsNullOrEmpty(activationCode))
            {
                string email = CommonUtils.DecryptParameter(activationCode);
                string phone = CommonUtils.DecryptParameter(pad);

                var user = svc.GetByPhoneNumber(phone);

                if (user != null)
                {
                    if (user.Email.Equals(email, StringComparison.InvariantCultureIgnoreCase))
                    {
                        if (user.IsEmailVerified == false)
                        {
                            user.IsEmailVerified = true;
                            svc.UpdateUser(user);
                        }
                        else
                            lblMessage.Text = "Email address has already been verified.";
                    }
                    else
                        lblMessage.Text = "Invalid activation code.";
                }
                else
                    lblMessage.Text = "Invalid activation code.";
            }
            else
            {
                lblMessage.Text = "Invalid activation code.";
            }
        }
    }
}