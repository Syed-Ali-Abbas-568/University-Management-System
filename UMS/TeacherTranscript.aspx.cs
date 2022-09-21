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
    public partial class TeacherTranscript : System.Web.UI.Page
    {
        private string RegNo;
        private string student_reg_no;
        private string courseID;

        protected void Page_Load(object sender, EventArgs e)
        {
            RegNo = Session["username"].ToString();     //this is the the registration number of the teacher
            Error_1.Visible = false;
            Error_2.Visible = false;
            TransGrid.Visible = false;
            Error_3.Visible = false;
            Table1.Visible = false;
            Submit.Visible = false;
            Transcript_Table.Visible = false;
            //Success.Visible = false;
            //Failure.Visible = false;
            //Add__Attendance_Butt.Visible = false;

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
            Transcript_Table.Visible = false;
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

        private void Bind_Grid_Transcript_List(string courseid, string coursename)
        {
            int found;
            DataTable DT = new DataTable();
            myDAL objMyDal = new myDAL();
            found = objMyDal.Show_Students_In_Course(courseid, ref DT);

            //will display all students registerd in that course

            if (found > 0)
            {
                TransGrid.DataSource = DT;
                TransGrid.DataBind();
                TransGrid.Visible = true;
                Transcript_Table.Visible = false;

                for (int i = 0; i < TransGrid.Rows.Count; i++)
                {
                    TransGrid.Rows[i].Cells[1].Text = coursename;
                }


            }
            else
            {
                Error_2.Visible = true;
                TransGrid.DataSource = null;
                TransGrid.DataBind();

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
                    this.Bind_Grid_Transcript_List(courseID, course_name);
                    insert.Checked = false;

                }
            }





        }

        protected void GetTranscript_CheckedChanged(object sender, EventArgs e)
        {
            //RadioButton checkstatus = (RadioButton)sender;

            //GridViewRow row = (GridViewRow)checkstatus.NamingContainer;


            for (int i = 0; i < TransGrid.Rows.Count; i++)
            {
                RadioButton insert = (RadioButton)TransGrid.Rows[i].Cells[3].FindControl("GetTranscript");
                if (insert.Checked)
                {
                    courseID = TransGrid.Rows[i].Cells[0].Text;
                    myDAL objMyDal = new myDAL();
                    string course_name = TransGrid.Rows[i].Cells[1].Text;
                    student_reg_no = TransGrid.Rows[i].Cells[2].Text;


                    Session["courseID"] = courseID;
                    Session["RegNumber"] = student_reg_no;
                    DataTable DT = new DataTable();
                    int found = objMyDal.ViewCourseMarksStudent(student_reg_no, courseID,ref DT);


                    if (found > 0)  //transcript already exist only see transcript
                    {
                        Error_3.Text = "Transript Retrieved Successfully";
                        Error_3.ForeColor=System.Drawing.Color.Green;
                        Error_3.Visible = true;
                        Transcript_Table.Visible = true;
                        this.Bind_Grid_Retrieved_Transcript();


                    }
                    else      //allow for addition of transcript
                    {
                        Error_3.Text = "No Transcript Exist Please Add Marks";
                        Error_3.ForeColor = System.Drawing.Color.Red;
                        Error_3.Visible = true;
                        Table1.Visible = true;
                        Submit.Visible = true;



                    }
                    


                    insert.Checked = false;

                }
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            int Obtained = Int32.Parse(Obtained_Marks.Text.Trim());
            int Total = Int32.Parse(Total_Marks.Text.Trim());

            myDAL obj = new myDAL();

            student_reg_no = Session["RegNumber"].ToString();
            courseID = Session["courseID"].ToString();



           int val= obj.UpdateTranscript(student_reg_no, courseID, Obtained, Total);

          
        }



        private int Check_and_insert_grade(double num, int index)
        {
            if (num >= 80)      //Grade A
            {
                Transcript_Table.Rows[index].Cells[4].Text = "A";
                return 4;       //4 credits returned
            }
            else if (num >= 70) //Grade B
            {
                Transcript_Table.Rows[index].Cells[4].Text = "B";
                return 3;   //3 credits returned
            }
            else if (num >= 60) //Grade C
            {
                Transcript_Table.Rows[index].Cells[4].Text = "C";
                return 2; //credits returned
            }
            else if (num >= 50) //Grade D
            {
                Transcript_Table.Rows[index].Cells[4].Text = "D";
                return 1; //1 credit returned
            }
            else //grade F
            {
                Transcript_Table.Rows[index].Cells[4].Text = "F";
                return 0;   //0 credits returned
            }

        }
        private void Bind_Grid_Retrieved_Transcript()
        {
            int found;
            DataTable DT = new DataTable();
            myDAL objMyDal = new myDAL();
            found = objMyDal.ViewSpecificCourseTranscript(student_reg_no,courseID, ref DT);
            double gpa = 0;
            if (found > 0)
            {
                Transcript_Table.DataSource = DT;
                Transcript_Table.DataBind();

                for (int i = 0; i < Transcript_Table.Rows.Count; i++)
                {
                    int totalmarks = Convert.ToInt32(Transcript_Table.Rows[i].Cells[2].Text);
                    int obtained = Convert.ToInt32(Transcript_Table.Rows[i].Cells[3].Text);
                   
                    double sum = ((double)obtained / (double)totalmarks) * 100;

                   Check_and_insert_grade(sum, i);

                }
          

            }
            else
            {
                Transcript_Table.DataSource = null;
                Transcript_Table.DataBind();
             
            }
        }
    }
}