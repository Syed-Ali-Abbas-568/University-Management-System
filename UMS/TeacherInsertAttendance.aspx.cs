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
    public partial class TeacherInsertAttendance : System.Web.UI.Page
    {
        private string RegNo;
        protected void Page_Load(object sender, EventArgs e)
        {
            RegNo = Session["username"].ToString();     //this is the the registration number of the teacher
            Error_1.Visible = false;
            Error_2.Visible = false;
            AttendanceGrid.Visible = false;
            Table2.Visible = false;
            Success.Visible = false;
            Failure.Visible = false;
            Add__Attendance_Butt.Visible = false;

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

        private void Bind_Grid_Attendance_List(string courseid, string coursename)
        {
            int found;
            DataTable DT = new DataTable();
            myDAL objMyDal = new myDAL();
            found = objMyDal.Show_Students_In_Course(courseid, ref DT);

            //will display all students registerd in that course

            if (found > 0)
            {
                AttendanceGrid.DataSource = DT;
                AttendanceGrid.DataBind();
                AttendanceGrid.Visible = true;
                Add__Attendance_Butt.Visible = true;
                Table2.Visible = true;
                for (int i = 0; i < AttendanceGrid.Rows.Count; i++)
                {
                    AttendanceGrid.Rows[i].Cells[1].Text = coursename;
                }


            }
            else
            {
                Error_2.Visible = true;
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
                    string course_name = CurrentCourses.Rows[i].Cells[1].Text;
                    this.Bind_Grid_Attendance_List(courseID,course_name);
                    insert.Checked = false;

                }
            }





        }

        protected void Add__Attendance_Butt_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < AttendanceGrid.Rows.Count; i++)
            {
                string courseid = AttendanceGrid.Rows[i].Cells[0].Text;
                string registrationNo = AttendanceGrid.Rows[i].Cells[2].Text;
                string Date = Date_New.Text;


                char status='P';
                DropDownList insert = (DropDownList)AttendanceGrid.Rows[i].Cells[3].FindControl("Status_Att");
                if (insert.SelectedValue == "A")
                {
                    status = 'A';
                }
                else
                {
                    status = 'P';
                }

                myDAL obj = new myDAL();
                int found=obj.InsertAttendance(registrationNo, courseid, Date, status);

                if (found == 0)
                {

                    Failure.Visible = true;

                }
                else
                {
                    Success.Visible = true;
                
                }
            }


        }

        //protected void Add__Attendance_Butt_Click(object sender, EventArgs e)
        //{

        //    Table1.Rows[0].Cells[0].Visible = false;
        //    AttendanceGrid.Columns[0].Visible = false;
        //    AttendanceGrid.Columns[2].Visible = false;
        //    AttendanceGrid.Columns[3].Visible = false;







        //    for (int i = 0; i < AttendanceGrid.Rows.Count; i++)
        //    {
        //        CheckBox insert = (CheckBox)AttendanceGrid.Rows[i].Cells[3].FindControl("Insert_Attendance");
        //        if (insert.Checked)
        //        {
        //            AttendanceGrid.Rows[i].Cells[1].BackColor = System.Drawing.Color.DarkOrange;

        //        }


        //    }





        //}

        //protected void Submit_Click(object sender, EventArgs e)
        //{

        //    Table1.Rows[0].Cells[0].Visible = true;

        //    AttendanceGrid.Columns[0].Visible = true;
        //    AttendanceGrid.Columns[2].Visible = true;
        //    AttendanceGrid.Columns[3].Visible = true;

        //    Table2.Visible = false;
        //    Submit.Visible = false;
        //    string date = Date.Text.Trim();
        //    for (int i = 0; i < AttendanceGrid.Rows.Count; i++)
        //    {
        //        CheckBox insert = (CheckBox)AttendanceGrid.Rows[i].Cells[3].FindControl("Insert_Attendance");
        //        if (insert.Checked)
        //        {
        //            AttendanceGrid.Rows[i].Cells[1].BackColor = System.Drawing.Color.FromArgb(10607858);
        //            string regno = AttendanceGrid.Rows[i].Cells[1].Text;

        //        }


        //    }




        //}
    }
}