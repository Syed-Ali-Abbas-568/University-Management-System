using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UMS
{
    public partial class Student : System.Web.UI.MasterPage
    {
        protected void LogOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }
    }
}