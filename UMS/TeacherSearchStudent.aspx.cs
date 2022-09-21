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
    public partial class TeacherSearchStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StudentDetails.Visible = false;
            Error_1.Visible = false;
            BasicInfo.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string RegNo = StudentRegNo.Text.Trim();        //student registration number 
            int found;
            DataTable DT = new DataTable();
            myDAL objMyDal = new myDAL();
            found = objMyDal.SearchStudent(RegNo, ref DT);
            StudentDetails.DataSource = DT;
            StudentDetails.DataBind();


            if (found > 0)
            {
                StudentDetails.Visible = true;
                Error_1.Visible = false;
                BasicInfo.Visible = true;
            }
            else
            {
                StudentDetails.Visible = false;
                Error_1.Visible = true;
                BasicInfo.Visible = false;
            }
        }
    }
}