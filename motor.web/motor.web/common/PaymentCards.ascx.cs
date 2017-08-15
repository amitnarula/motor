using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RestSharp;
using motor.logic.model;
using motor.logic.common;
using motor.logic.services;

namespace motor.web.common
{
    public partial class PaymentCards : System.Web.UI.UserControl
    {
        RESTFx fx = new RESTFx();

        private string FetchAuthenticationToken()
        {
            User usr = (User)Session[PageKeys.USERDATA];
            if (usr == null)
                throw new ArgumentException("usr");

            var authenticationToken = usr.AuthenticationTokens.SingleOrDefault();

            if (authenticationToken != null)
                return authenticationToken.Token;
            return string.Empty;
        }

        private void BindExpiryDropDowns()
        {
            for (int count = 1; count < 13; count++)
            {
                ddlMonth.Items.Add(new ListItem() {
                    Text = count.ToString(),
                    Value = count.ToString()
                });
            }
            for (int count = DateTime.UtcNow.Year; count < DateTime.UtcNow.Year+30; count++)
            {
                ddlYear.Items.Add(new ListItem() {
                    Text = count.ToString(),
                    Value = count.ToString()
                });
            }
        }

        private void BindPaymentCards()
        {
            var result =  new PaymentCardsRESTFx().DoRequest(Method.GET, "users/getpaymentcards", 
                null, FetchAuthenticationToken());
            if (result!= null)
            {
                grdPaymentCards.DataSource = result.Data.PaymentCards;
                grdPaymentCards.DataBind();
            }
        }
        private void ClearFields()
        {
            txtCardNumber.Text = string.Empty;
            txtCardName.Text = string.Empty;
            txtCVV.Text = string.Empty;
            ddlMonth.SelectedIndex = -1;
            ddlYear.SelectedIndex = -1;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                BindExpiryDropDowns();
                BindPaymentCards();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
           var result = fx.DoRequest(Method.POST, "users/AddUpdateCard", new
            {
                CardNumber = txtCardNumber.Text,
                Name = txtCardName.Text,
                CVV=txtCVV.Text,
                ExpiryMonth = Convert.ToInt32(ddlMonth.SelectedValue),
                ExpiryYear = Convert.ToInt32(ddlYear.SelectedValue)

            }, FetchAuthenticationToken());

            BindPaymentCards();
            ClearFields();
        }

        protected void grdPaymentCards_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var row = ((Button)e.CommandSource).NamingContainer as GridViewRow;
            PaymentCardResponseData data = row.DataItem as PaymentCardResponseData;
            long cardId = Convert.ToInt64(e.CommandArgument);
            if(e.CommandName== "editCard")
            {
                txtCardName.Text = data.CardName;
                txtCardNumber.Text = data.CardNumber;
                txtCVV.Text = data.CVV;
                ddlMonth.SelectedValue = data.ExpiryMonth.ToString();
                ddlYear.SelectedValue = data.ExpiryYear.ToString();

            }
            else if(e.CommandName =="deleteCard")
            {
                var result =  fx.DoRequest(Method.DELETE, "users/RemovePaymentCard",new {CardId = cardId }, FetchAuthenticationToken());
                BindPaymentCards();
            }
        }
    }
}