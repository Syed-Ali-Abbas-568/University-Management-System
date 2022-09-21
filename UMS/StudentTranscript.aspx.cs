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
    public partial class StudentTranscript : System.Web.UI.Page
    {
        private string RegNo;

        protected void Page_Load(object sender, EventArgs e)
        {
            RegNo = Session["username"].ToString();
            lblErrorMessage.Visible = false;
   
            if (!IsPostBack)
            {
                this.Bind_Grid_Current();
                
            }
        }
        private int Check_and_insert_grade(double num,int index)
        {
            if (num >= 80)      //Grade A
            {
                Transcript.Rows[index].Cells[3].Text = "A";
                return 4;       //4 credits returned
            }
            else if (num >= 70) //Grade B
            {
                Transcript.Rows[index].Cells[3].Text = "B";
                return 3;   //3 credits returned
            }
            else if (num >= 60) //Grade C
            {
                Transcript.Rows[index].Cells[3].Text = "C";
                return 2; //credits returned
            }
            else if (num >= 50) //Grade D
            {
                Transcript.Rows[index].Cells[3].Text = "D";
                return 1; //1 credit returned
            }
            else //grade F
            {
                Transcript.Rows[index].Cells[3].Text = "F";
                return 0;   //0 credits returned
            }            
        
        }
        private void Bind_Grid_Current()
        {
            int found;
            DataTable DT = new DataTable();
            myDAL objMyDal = new myDAL();
            found = objMyDal.ViewMarksStudent(RegNo, ref DT);
            double gpa = 0;
            if (found > 0)
            {
                Transcript.DataSource = DT;
                Transcript.DataBind();

                for (int i = 0; i < Transcript.Rows.Count; i++)
                {
                    double totalmarks = Convert.ToInt32(Transcript.Rows[i].Cells[1].Text);
                    double obtained = Convert.ToInt32(Transcript.Rows[i].Cells[2].Text);
                    obtained = (obtained / totalmarks) * 100;
                    
                    gpa=gpa+ Check_and_insert_grade(obtained, i);

                }
                gpa = gpa /  Transcript.Rows.Count;
                CGPA.Text = "CGPA Obtained: " + gpa;

            }
            else
            {
                Transcript.DataSource = null;
                Transcript.DataBind();
                lblErrorMessage.Visible = true;
            }
        }
    }
}