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

namespace motor.web.user
{
    public partial class profile : System.Web.UI.Page
    {
        
        UserService usrSvc = new UserService();

        private User GetUserData()
        {
            User user = (User)Session[PageKeys.USERDATA];
            if (user != null)
                user = usrSvc.Get(user.Id);
            return user;
        }
        
        private void LoadProfile()
        {
            User user = GetUserData();
            if(user!=null)
            {
                txtFirstname.Text = user.Firstname;
                txtLastname.Text = user.Lastname;
                txtMiddlename.Text = user.Middlename;
                txtEmail.Text = user.Email;
                txtPhone.Text = user.Phone;
                ddlCity.SelectedValue = user.City;

            }
        }
        private void SaveProfile()
        {
            var user = GetUserData();
            user.City = ddlCity.SelectedValue;
            Session[PageKeys.USERDATA] = user;

            if (usrSvc.UpdateUser(user))
                lblMessage.Text = "Profile changed successfully.";
            else
                lblMessage.Text = "An error occurred while operation";

            LoadProfile();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadProfile();
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            var user = GetUserData();
            string oldPassword = CommonUtils.Encrypt(txtOldPassword.Text);
            if (oldPassword == user.Password)
            {
                user.Password = CommonUtils.Encrypt(txtNewPassword.Text);
                if (usrSvc.UpdateUser(user))
                    lblMessage.Text = "Password changed successfully";

            }
            else
                lblMessage.Text = "Invalid old password";
        }

        protected void btnSaveProfile_Click(object sender, EventArgs e)
        {
            SaveProfile();
        }
    }
}