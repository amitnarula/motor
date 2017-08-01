using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RestSharp;

namespace motor.web
{
    public partial class testexplorer : System.Web.UI.Page
    {
        RestClient client = new RestClient("http://localhost:8282/api");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            RestRequest request = new RestRequest("users/login", Method.POST);
            
            var requestObject = new {PhoneNumber ="(123)1234567", Password ="123456" };
            request.AddJsonBody(requestObject);
            var response =  client.Execute(request);

            litResponse.Text = response.ToString();
        }

        protected void btnSaveDocumentInfo_Click(object sender, EventArgs e)
        {
            RestRequest request = new RestRequest("users/SaveDriverDocumentInfo", Method.POST);

            var requestObject = new { SSN = "123456789", LicenseNumber = "123456789" };
            request.AddJsonBody(requestObject);
            request.AddHeader("authToken", "BOII5FUynjpl5RZJJ8nW1g==");
            var result = client.Execute(request);
            
        }
    }
}