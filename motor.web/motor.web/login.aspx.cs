using motor.logic.common;
using motor.logic.model;
using motor.logic.services;
using motor.web.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace motor.web
{
    public partial class login : System.Web.UI.Page
    {
        private UserService svc = new UserService();
        RESTFx restFx = new RESTFx();

        private void Login()
        {
            var loginResult = svc.Login(txtMobile.Text, txtPassword.Text);
            if (loginResult != null)
            {
                //Generate Authentication token
                string authenticationToken = CommonUtils.Encrypt(loginResult.Id.ToString()); //generate token from user id

                //Update/insert authentication token
                svc.AddUpdateAuthenticationToken(new AuthenticationToken()
                {
                    Token = authenticationToken,
                    Expires = DateTime.UtcNow.AddDays(30), // valid for 30 days
                    UserId = loginResult.Id
                });



                //create session
                Session[PageKeys.USERDATA] = loginResult;

                //decide the landing page as per user type and landing
                switch (loginResult.UserType)
                {
                    case (short)UserType.SuperAdmin:
                        Response.Redirect(PageKeys.AdminHome);
                        break;
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
            else
                lblErrorMessage.Text = "Invalid credentials. Please try again";
        }
    

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }
        
    }
}