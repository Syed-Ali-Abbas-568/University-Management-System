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
    public partial class DirectorCourses : System.Web.UI.Page
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
            found = objMyDal.ViewAllCourses(ref DT);
            DepartmentDetails.DataSource = DT;
            DepartmentDetails.DataBind();

        }

        protected void UnEnroll_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < DepartmentDetails.Rows.Count; i++)
            {

                CheckBox insert = (CheckBox)DepartmentDetails.Rows[i].Cells[0].FindControl("Mark_Student");
                if (insert.Checked)
                {

                    myDAL objMyDal = new myDAL();

                    string RegNo = DepartmentDetails.Rows[i].Cells[0].Text;
                    int found = objMyDal.DeleteCourse(RegNo);


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
            string RegNo = RegNotxt.Text.Trim();        //did
            string name = Name.Text.Trim();             //dname



            myDAL obj = new myDAL();
            int found = obj.AddCourse(RegNo, name);

            if (found == 1)
            {

                Error_1.Visible = true;
                Error_1.Text = "Course has been successfully added";
                this.Bind_Grid();
            }
            else if (found == 2)
            {
                Error_1.Visible = true;
                Error_1.Text = "Course cannot be added because it already exists";
            }
            else
            {
                Error_1.Visible = true;
                Error_1.Text = "Failed to add Course please check inserted data";
            }
        }
    }
}