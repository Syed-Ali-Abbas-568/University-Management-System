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
    public partial class TeacherCourse : System.Web.UI.Page
    {
        private string RegNo;
        protected void Page_Load(object sender, EventArgs e)
        {
            RegNo = Session["username"].ToString();
            Error_1.Visible = false;
            Error_2.Visible = false;
            Table1.Visible = false;
            
            AttendanceGrid.Visible = false;
            StudentDetails.Visible = false;
           
            if (!IsPostBack)
            {
                this.Bind_Grid_Current();

            }

        }

        private void Bind_Grid_Current()
        {
            int found;
            DataTable DT = new DataTable();
            myDAL objMyDal = new myDAL();
            found = objMyDal.CurrentTeacherCourses(RegNo, ref DT);
            if (found > 0)
            {
                CurrentCourses.DataSource = DT;
                CurrentCourses.DataBind();
            }
            else
            {
                CurrentCourses.DataSource = null;
                CurrentCourses.DataBind();
                Error_1.Visible = true;
            }
        }
        private void Bind_Grid_Attendance(string cid)
        {

            int found;
            DataTable DT = new DataTable();
            myDAL objMyDal = new myDAL();
            found = objMyDal.SeeAllStudentAttendance(cid, ref DT);

            if (found > 0)
            {
                StudentDetails.DataSource = DT;
                StudentDetails.DataBind();
                StudentDetails.Visible = true;
                Table1.Visible = true;
                AttendanceGrid.Visible = true;
                Error_2.Visible = false;
           

            }
            else
            {

                StudentDetails.DataSource = null;
                StudentDetails.DataBind();
                Error_2.Visible = true;
                StudentDetails.Visible = false;
                Table1.Visible = false;
                AttendanceGrid.Visible = false;

            }


        }

        private void Bind_Grid_Attendance_Percentage(string courseid)
        {
            int found;
            DataTable DT = new DataTable();
            myDAL objMyDal = new myDAL();
            found = objMyDal.Student_List_Attendance(courseid, ref DT);

            if (found > 0)
            {
                AttendanceGrid.DataSource = DT;
                AttendanceGrid.DataBind();
                AttendanceGrid.Visible = true ;
                for (int i = 0; i < AttendanceGrid.Rows.Count; i++)
                {
                    string regID = AttendanceGrid.Rows[i].Cells[1].Text;
                    AttendanceGrid.Rows[i].Cells[2].Text = (objMyDal.StudentAttendancePercentage(regID, courseid)).ToString() +"%";
                               
                
                }
             

            }
            else
            
            {
                AttendanceGrid.DataSource = null;
                AttendanceGrid.DataBind();
               
            }
        }

        protected void GetInfo_CheckedChanged1(object sender, EventArgs e)
        {
         
            RadioButton checkstatus = (RadioButton)sender;

            GridViewRow row = (GridViewRow)checkstatus.NamingContainer;

            
            for (int i = 0; i < CurrentCourses.Rows.Count; i++)
            {
                RadioButton insert = (RadioButton)CurrentCourses.Rows[i].Cells[2].FindControl("GetInfo");
                if (insert.Checked)
                {
                  string courseID = CurrentCourses.Rows[i].Cells[0].Text;
                    myDAL objMyDal = new myDAL();
                    this.Bind_Grid_Attendance(courseID);
                    this.Bind_Grid_Attendance_Percentage(courseID);   
                    insert.Checked = false;

                }
            }

         



        }

       
        
    }
}