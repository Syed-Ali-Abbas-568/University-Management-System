using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using UMS.DAL;
namespace UMS
{
  
    public partial class WebForm1 : System.Web.UI.Page
    {
        private string RegNo;
        private string Pass;
        protected void Page_Load(object sender, EventArgs e)
        {
            RegNo=Session["username"].ToString();
            Pass = Session["Password"].ToString();
            if (!IsPostBack)
            {
                UserDetails.Text = "Welcome to UMS: ";
                this.Bind_Grid();
            }
        }


        private void Bind_Grid()
        {
            int found;
            DataTable DT = new DataTable();
            myDAL objMyDal = new myDAL();
            found = objMyDal.StudentLogin(RegNo, Pass, ref DT);
            StudentDetails.DataSource =DT;
            StudentDetails.DataBind();
            
        }

        //public override void VerifyRenderingInServerForm(Control control)
        //{
           
        //}
    }
    

}