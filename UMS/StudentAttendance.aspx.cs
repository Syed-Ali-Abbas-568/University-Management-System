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
    public partial class StudentAttendance : System.Web.UI.Page
    {
        private string RegNo;
  
        protected void Page_Load(object sender, EventArgs e)
        {
           
            RegNo = Session["username"].ToString();
            lblErrorMessage.Visible = false;
            Error_no_course.Visible = false;
            AttendPercentage.Visible = false;
            if (!IsPostBack)
            {
                this.Bind_Grid_Current();
           
                
            }
        }
        private void Bind_Grid(string cid)
        {
            int found;
            DataTable DT = new DataTable();
            myDAL objMyDal = new myDAL();
            found = objMyDal.StudentAttendance(RegNo,cid,ref DT);

            if (found > 0)
            {
                StudentDetails.DataSource = DT;
                StudentDetails.DataBind();
                StudentDetails.Visible = true;
                lblErrorMessage.Visible = false;

                AttendPercentage.Text ="Attendance Percentage: " + (objMyDal.StudentAttendancePercentage(RegNo, cid)).ToString()+"%";


                AttendPercentage.Visible = true;

                
            }
            else
            {   

                StudentDetails.DataSource = null;
                StudentDetails.DataBind();
                lblErrorMessage.Visible = true;
                StudentDetails.Visible = false;
                AttendPercentage.Visible = false;
            }
        }
        private void Bind_Grid_Current()
        {
            int found;
            DataTable DT = new DataTable();
            myDAL objMyDal = new myDAL();
            found = objMyDal.CurrentStudentCourses(RegNo, ref DT);
            if (found > 0)
            {
                CurrentCourses.DataSource = DT;
                CurrentCourses.DataBind();
               
            }
            else
            {
                CurrentCourses.DataSource = null;
                CurrentCourses.DataBind();
                
                Error_no_course.Visible = true;
                CurrentCourses.Visible = false;
            }
        }

        protected void AttendanceSelected_CheckedChanged(object sender, EventArgs e)
        {
            
            RadioButton checkstatus = (RadioButton)sender;
           
            GridViewRow row = (GridViewRow)checkstatus.NamingContainer;
            


            for (int i = 0; i < CurrentCourses.Rows.Count; i++)
            {
                RadioButton insert = (RadioButton)CurrentCourses.Rows[i].Cells[2].FindControl("AttendanceSelected");
                if (insert.Checked)
                {
                    string courseID = CurrentCourses.Rows[i].Cells[0].Text;
                    myDAL objMyDal = new myDAL();
                    this.Bind_Grid(courseID);
                    insert.Checked = false;

                   
                }
            }
         
      

        }
    }
}