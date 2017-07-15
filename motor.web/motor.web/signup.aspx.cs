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
    public partial class signup : System.Web.UI.Page
    {
        UserService svc = new UserService();
        private void RegisterUser()
        {
            //check if phone number already exists
            if (svc.IsPhoneNumberAlreadyExists(txtMobile.Text))
                lblMessage.Text = "Phone number is already registered, please choose another one.";
            else
            {
                User obj = new User();
                obj.Firstname = txtFirstname.Text;
                obj.Lastname = txtLastname.Text;
                obj.Middlename = txtMiddlename.Text ?? null;
                obj.Phone = txtMobile.Text;
                obj.Email = txtEmail.Text;
                obj.CreatedOn = DateTime.UtcNow;
                obj.City = ddlCity.SelectedValue;
                obj.Password = CommonUtils.Encrypt(txtPassword.Text);
                obj.Source = ddlSource.SelectedValue;
                obj.UserType = Convert.ToInt16(ddlUserType.SelectedValue);
                obj.IsEmailVerified = false;

                string userActivationUrl = Request.Url.AbsoluteUri.Replace("signup.aspx", "activate.aspx?activationCode=" + CommonUtils.EncryptParameter(obj.Email) + "&pad=" + CommonUtils.EncryptParameter(obj.Phone));

                if (svc.RegisterUser(obj, userActivationUrl))
                {
                    //create session
                    Session[PageKeys.USERDATA] = obj;

                    switch (obj.UserType)
                    {
                        case (short)UserType.Rider:
                            Response.Redirect(PageKeys.RiderHome);
                            break;
                        case (short)UserType.Driver:
                            Response.Redirect(PageKeys.DriverHome);
                            break;
                        default:
                            break;
                    }
                }
            }
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void chkAgreement_Validate(object o, ServerValidateEventArgs e)
        {
            if (chkAgreement.Checked)
            {
                e.IsValid = true;
            }
            else
            {
                e.IsValid = false;
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterUser();
        }
    }
}