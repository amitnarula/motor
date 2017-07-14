﻿using motor.logic.common;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[PageKeys.USERDATA] == null)
                Response.Redirect(PageKeys.LoginPage);
        }
    }
}