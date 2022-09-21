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
    public partial class TeacherInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Error_1.Visible = false;
                this.Bind_Grid();
            }
        }
        private void Bind_Grid()
        {
            int found;
            DataTable DT = new DataTable();
            myDAL objMyDal = new myDAL();
            found = objMyDal.ViewAllTeachers(ref DT);
            TeacherDetails.DataSource = DT;
            TeacherDetails.DataBind();

        }

        protected void UnEnroll_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < TeacherDetails.Rows.Count; i++)
            {

                CheckBox insert = (CheckBox)TeacherDetails.Rows[i].Cells[8].FindControl("Mark_Student");
                if (insert.Checked)
                {

                    myDAL objMyDal = new myDAL();

                    string RegNo = TeacherDetails.Rows[i].Cells[0].Text;
                    int found = objMyDal.DeleteTeacher(RegNo);


                }



            }
            this.Bind_Grid();
        }

        protected void Mark_Student_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkstatus = (CheckBox)sender;
            checkstatus.Checked = true;


        }

        protected void Enroll_Butt_Click(object sender, EventArgs e)
        {
            string RegNo = RegNotxt.Text.Trim();
            string name = Name.Text.Trim();
            string pass = Password.Text.Trim();
            string Dep_ID = Department.Text.Trim();
            string Dob = DOB.Text.Trim();
            string email = Emailtxt.Text.Trim();
            string phone = Phone.Text.Trim();
            string cnic = CNIC.Text.Trim();

            char gender;
            if (Gender.SelectedValue == "Male")
            {
                gender = 'M';
            }
            else
            {
                gender = 'F';
            }
            myDAL obj = new myDAL();
            int found = obj.AddTeacher(RegNo, pass, email, name, Dob, cnic, Dep_ID, phone, gender);
            if (found == 1)
            {

                Error_1.Visible = true;
                Error_1.Text = "Teacher has been successfully added";
                this.Bind_Grid();
            }
            else if (found == 2)
            {
                Error_1.Visible = true;
                Error_1.Text = "Teacher cannot be added because it already exists";
            }
            else
            {
                Error_1.Visible = true;
                Error_1.Text = "Failed to add Teacher please check inserted data";
            }
        }
    }
}
