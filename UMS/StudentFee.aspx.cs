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
    public partial class StudentFee : System.Web.UI.Page
    {
        string RegNo;
        protected void Page_Load(object sender, EventArgs e)
        {
            RegNo = Session["username"].ToString();
            DataTable DT = new DataTable();
            myDAL obj = new myDAL();
            obj.CurrentStudentCourses(RegNo, ref DT);


            int num_of_course = DT.Rows.Count;
            Num_of_couses.Text = num_of_course.ToString() ;

            num_of_course = num_of_course * 7500;
            Total_Payable.Text= num_of_course.ToString() + " Rs";

        }

    }
}