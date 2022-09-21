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
    public partial class StudentCourse : System.Web.UI.Page
    {
        private string RegNo;

        protected void Page_Load(object sender, EventArgs e)
        {
            RegNo = Session["username"].ToString();
            lblErrorMessage.Visible = false;
            ERROR_LABEL1.Visible = false;
            if (!IsPostBack)
            {
                this.Bind_Grid_Current();
                this.Bind_Grid_Available();
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
                lblErrorMessage.Visible = true;
            }
        }
        private void Bind_Grid_Available()
        {
            int found;
            DataTable DT = new DataTable();
            myDAL objMyDal = new myDAL();
            found = objMyDal.AvailableStudentCourses(RegNo, ref DT);
            if (found > 0)
            {
                CoursesAvailable.DataSource = DT;
                CoursesAvailable.DataBind();
            }
            else
            {
                CoursesAvailable.DataSource = null;
                CoursesAvailable.DataBind();

            }
        }
     
        
        protected void Submit_Click(object sender, EventArgs e)
        {//here a procedure will insert all these courses in database
            for (int i = 0; i < CoursesAvailable.Rows.Count; i++)
            {
                CheckBox insert = (CheckBox)CoursesAvailable.Rows[i].Cells[0].FindControl("Insert_Course");
                if (insert.Checked)
                {
                    string courseID = CoursesAvailable.Rows[i].Cells[1].Text;
                    myDAL objMyDal = new myDAL();

                    int found =objMyDal.RegisterCourseStudent(RegNo,courseID);                
                    if (found == 0)
                    {
                        ERROR_LABEL1.Visible = true;
                    }


                }
            }
            this.Bind_Grid_Current();
            this.Bind_Grid_Available();
            

        }

        protected void Insert_Course_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkstatus = (CheckBox)sender;
            GridViewRow row = (GridViewRow)checkstatus.NamingContainer;

        }
    }
}