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
    public partial class profile : System.Web.UI.Page
    {
        
        UserService usrSvc = new UserService();

        private bool ValidateFileSize(FileUpload flUpload)
        {
            decimal size = Math.Round(((decimal)flUpload.PostedFile.ContentLength / (decimal)1024), 2);
            if (size > 100)
            {
                return false;
            }
            return true;
        }


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

                //Profile picture
                imgPPPreview.ImageUrl = PageKeys.GetImageHandlerUrl(PageKeys.ImageHandlerActions.ProfilePicture) + "userId=" + user.Id;

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

        protected void Page_Unload(object sender, EventArgs e)
        {

        }

        protected void btnPPUpload_Click(object sender, EventArgs e)
        {
            SaveProfilePicture();

        }

        private void SaveProfilePicture()
        {
            if (Page.IsValid)
            {
                var user = GetUserData();
                Stream fs = null;
                BinaryReader br = null;
                byte[] bytes = null;

                fs = ppFileUpload.PostedFile.InputStream;

                br = new BinaryReader(fs);
                bytes = br.ReadBytes((Int32)fs.Length);
                user.ProfilePicture = bytes;
                if (usrSvc.UpdateUser(user))
                {
                    lblMessage.Text = "Profile picture updated successfully.";
                }
            }
        }

        protected void customValPP_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!ValidateFileSize(ppFileUpload))
            {
                customValPP.ErrorMessage = "File size must not exceed 100 KB.";
                args.IsValid = false;
            }
        }
    }
}