using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//ADD the two namespaces mentioned below to access your databse probeperly
using System.Data;
using System.Data.SqlClient;
namespace UMS.DAL
{
    public class myDAL
    {
        //add a string that is the  reference to your database
        private static readonly string connString = System.Configuration.ConfigurationManager.ConnectionStrings["SqlCon1"].ConnectionString;
        //now create funciton for every query you want to perform

        //these Procedures help in login and diplaying basic information
        public int StudentLogin(String Name, String pass, ref DataTable DT)
        {

            int Found = 0;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("Studentinfo", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@rn", SqlDbType.VarChar, 10);
                cmd.Parameters.Add("@pass", SqlDbType.VarChar, 20);
                cmd.Parameters.Add("@Found", SqlDbType.Int).Direction = ParameterDirection.Output;

                // set parameter values
                cmd.Parameters["@rn"].Value = Name;
                cmd.Parameters["@pass"].Value = pass;

                cmd.ExecuteNonQuery();

                // read output value 
                Found = Convert.ToInt32(cmd.Parameters["@Found"].Value); //convert to output parameter to interger format

                if (Found == 1)
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))

                    {
                        da.Fill(ds);

                    }

                    DT = ds.Tables[0];

                }


                con.Close();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }

            return Found;

        }

        public int TeacherLogin(String Name, String pass, ref DataTable DT)
        {

            int Found = 0;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("teacherbasicinfo", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@rn", SqlDbType.VarChar, 10);
                cmd.Parameters.Add("@pass", SqlDbType.VarChar, 20);
                cmd.Parameters.Add("@Found", SqlDbType.Int).Direction = ParameterDirection.Output;

                // set parameter values
                cmd.Parameters["@rn"].Value = Name;
                cmd.Parameters["@pass"].Value = pass;

                cmd.ExecuteNonQuery();

                // read output value 
                Found = Convert.ToInt32(cmd.Parameters["@Found"].Value); //convert to output parameter to interger format

                if (Found == 1)
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))

                    {
                        da.Fill(ds);

                    }

                    DT = ds.Tables[0];

                }


                con.Close();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }

            return Found;

        }
        public int DirectorLogin(String Name, String pass, ref DataTable DT)
        {

            int Found = 0;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("DirectorInfo", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@rn", SqlDbType.VarChar, 10);
                cmd.Parameters.Add("@pass", SqlDbType.VarChar, 20);
                cmd.Parameters.Add("@Found", SqlDbType.Int).Direction = ParameterDirection.Output;

                // set parameter values
                cmd.Parameters["@rn"].Value = Name;
                cmd.Parameters["@pass"].Value = pass;


                cmd.ExecuteNonQuery();

                // read output value 
                Found = Convert.ToInt32(cmd.Parameters["@Found"].Value); //convert to output parameter to interger format

                if (Found == 1)
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))

                    {
                        da.Fill(ds);

                    }

                    DT = ds.Tables[0];

                }


                con.Close();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }

            return Found;

        }


        //Function to See the attendance of a student
        public int StudentAttendance(String Name, String courseID, ref DataTable DT)
        {

            int Found = 0;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("see_student_attendance", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@rn", SqlDbType.VarChar, 10);
                cmd.Parameters.Add("@cid", SqlDbType.VarChar, 10);
                cmd.Parameters.Add("@Found", SqlDbType.Int).Direction = ParameterDirection.Output;

                // set parameter values
                cmd.Parameters["@rn"].Value = Name;
                cmd.Parameters["@cid"].Value = courseID;



                cmd.ExecuteNonQuery();

                // read output value 
                Found = Convert.ToInt32(cmd.Parameters["@Found"].Value); //convert to output parameter to interger format

                if (Found == 1)
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))

                    {
                        da.Fill(ds);

                    }

                    DT = ds.Tables[0];

                }


                con.Close();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }

            return Found;

        }

        //Gets %age of attendance a student has
        public double StudentAttendancePercentage(String Name, String courseID)
        {

            int present = 0;
            int total = 0;
            double percentage = 0;

            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("AttendancePercentage", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@rn", SqlDbType.VarChar, 10);
                cmd.Parameters.Add("@cid", SqlDbType.VarChar, 10);
                cmd.Parameters.Add("@absents", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@totdays", SqlDbType.Int).Direction = ParameterDirection.Output;

                // set parameter values
                cmd.Parameters["@rn"].Value = Name;
                cmd.Parameters["@cid"].Value = courseID;



                cmd.ExecuteNonQuery();

                // read output value 
                present = Convert.ToInt32(cmd.Parameters["@absents"].Value); //convert to output parameter to interger format
                total = Convert.ToInt32(cmd.Parameters["@totdays"].Value);
                con.Close();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }
            if (total != 0)
            {

                percentage = (double)present / (double)total;
                percentage = percentage * 100;
            }

            return percentage;

        }

        //Displays the current courses a student is already registered in
        public int CurrentStudentCourses(String Name, ref DataTable DT)
        {

            int Found = 0;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("CurrentCourses", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@rn", SqlDbType.VarChar, 10);

                cmd.Parameters.Add("@Found", SqlDbType.Int).Direction = ParameterDirection.Output;

                // set parameter values
                cmd.Parameters["@rn"].Value = Name;



                cmd.ExecuteNonQuery();

                // read output value 
                Found = Convert.ToInt32(cmd.Parameters["@Found"].Value); //convert to output parameter to interger format

                if (Found == 1)
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))

                    {
                        da.Fill(ds);

                    }

                    DT = ds.Tables[0];

                }


                con.Close();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }

            return Found;

        }

        //Available Student Courses other then the selected ones
        public int AvailableStudentCourses(String Name, ref DataTable DT)
        {

            int Found = 0;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("AvailableCourses", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@rn", SqlDbType.VarChar, 10);

                cmd.Parameters.Add("@Found", SqlDbType.Int).Direction = ParameterDirection.Output;

                // set parameter values
                cmd.Parameters["@rn"].Value = Name;



                cmd.ExecuteNonQuery();

                // read output value 
                Found = Convert.ToInt32(cmd.Parameters["@Found"].Value); //convert to output parameter to interger format

                if (Found == 1)
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))

                    {
                        da.Fill(ds);

                    }

                    DT = ds.Tables[0];

                }


                con.Close();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }

            return Found;

        }

        //RegisterCourseStudent
        public int RegisterCourseStudent(String Name, String CourseID)
        {

            int Found = 0;
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("registercourse", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@rn", SqlDbType.VarChar, 10);
                cmd.Parameters.Add("@cid", SqlDbType.VarChar, 10);
                cmd.Parameters.Add("@Found", SqlDbType.Int).Direction = ParameterDirection.Output;

                // set parameter values
                cmd.Parameters["@rn"].Value = Name;
                cmd.Parameters["@cid"].Value = CourseID;


                cmd.ExecuteNonQuery();

                // read output value 
                Found = Convert.ToInt32(cmd.Parameters["@Found"].Value); //convert to output parameter to interger format
                con.Close();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }

            return Found;

        }



        //Function to return transcript of a given student
        public int ViewMarksStudent(String Name, ref DataTable DT)
        {

            int Found = 0;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("viewmarks", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@rn", SqlDbType.VarChar, 10);

                cmd.Parameters.Add("@Found", SqlDbType.Int).Direction = ParameterDirection.Output;

                // set parameter values
                cmd.Parameters["@rn"].Value = Name;



                cmd.ExecuteNonQuery();

                // read output value 
                Found = Convert.ToInt32(cmd.Parameters["@Found"].Value); //convert to output parameter to interger format

                if (Found == 1)
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))

                    {
                        da.Fill(ds);

                    }

                    DT = ds.Tables[0];

                }


                con.Close();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }

            return Found;
        }

        ////////////////////////////////////////////////////////////////////////
        ///////////////////////TEACHER FUNCTIONALITY//////////////////////////////
        ////////////////////////////////////////////////////////////////////////
        //Displays the current courses a student is already registered in
        public int CurrentTeacherCourses(String Name, ref DataTable DT)
        {

            int Found = 0;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("TeacherCourses", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@rn", SqlDbType.VarChar, 10);

                cmd.Parameters.Add("@Found", SqlDbType.Int).Direction = ParameterDirection.Output;

                // set parameter values
                cmd.Parameters["@rn"].Value = Name;



                cmd.ExecuteNonQuery();

                // read output value 
                Found = Convert.ToInt32(cmd.Parameters["@Found"].Value); //convert to output parameter to interger format

                if (Found == 1)
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))

                    {
                        da.Fill(ds);

                    }

                    DT = ds.Tables[0];

                }


                con.Close();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }

            return Found;

        }

        //Function to See the attendance of a Teacher in a certain course
        public int TeacherAttendance(String Name, String courseID, ref DataTable DT)
        {

            int Found = 0;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("see_teacher_attendance", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@rn", SqlDbType.VarChar, 10);
                cmd.Parameters.Add("@cid", SqlDbType.VarChar, 10);
                cmd.Parameters.Add("@Found", SqlDbType.Int).Direction = ParameterDirection.Output;

                // set parameter values
                cmd.Parameters["@rn"].Value = Name;
                cmd.Parameters["@cid"].Value = courseID;



                cmd.ExecuteNonQuery();

                // read output value 
                Found = Convert.ToInt32(cmd.Parameters["@Found"].Value); //convert to output parameter to interger format

                if (Found == 1)
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))

                    {
                        da.Fill(ds);

                    }

                    DT = ds.Tables[0];

                }


                con.Close();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }

            return Found;

        }
        //Gets %age of attendance a student has
        public double TeacherAttendancePercentage(String Name, String courseID)
        {

            double present = 0;
            double total = 0;

            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("TeacherAttendancePercentage", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@rn", SqlDbType.VarChar, 10);
                cmd.Parameters.Add("@cid", SqlDbType.VarChar, 10);
                cmd.Parameters.Add("@absents", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@totdays", SqlDbType.Int).Direction = ParameterDirection.Output;

                // set parameter values
                cmd.Parameters["@rn"].Value = Name;
                cmd.Parameters["@cid"].Value = courseID;



                cmd.ExecuteNonQuery();

                // read output value 
                present = Convert.ToInt32(cmd.Parameters["@absents"].Value); //convert to output parameter to interger format
                total = Convert.ToInt32(cmd.Parameters["@totdays"].Value); //convert to output parameter to interger format
                con.Close();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }
            if (total != 0)
            {
                total = present / total;
                total = total * 100;
            }

            return total;

        }


        public int SeeAllStudentAttendance(String courseID, ref DataTable DT)
        {

            int Found = 0;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("see_all_student_attendance", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add("@cid", SqlDbType.VarChar, 10);
                cmd.Parameters.Add("@Found", SqlDbType.Int).Direction = ParameterDirection.Output;

                // set parameter values

                cmd.Parameters["@cid"].Value = courseID;



                cmd.ExecuteNonQuery();

                // read output value 
                Found = Convert.ToInt32(cmd.Parameters["@Found"].Value); //convert to output parameter to interger format

                if (Found == 1)
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))

                    {
                        da.Fill(ds);

                    }

                    DT = ds.Tables[0];

                }


                con.Close();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }

            return Found;

        }

        public int SearchStudent(String Name, ref DataTable DT)
        {

            int Found = 0;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("StudentSearch", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@rn", SqlDbType.VarChar, 10);

                cmd.Parameters.Add("@Found", SqlDbType.Int).Direction = ParameterDirection.Output;

                // set parameter values
                cmd.Parameters["@rn"].Value = Name;


                cmd.ExecuteNonQuery();

                // read output value 
                Found = Convert.ToInt32(cmd.Parameters["@Found"].Value); //convert to output parameter to interger format

                if (Found == 1)
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))

                    {
                        da.Fill(ds);

                    }

                    DT = ds.Tables[0];

                }


                con.Close();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }

            return Found;

        }


        //Student List Attendance
        public int Student_List_Attendance(String cid, ref DataTable DT)
        {

            int Found = 0;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;


            try
            {
                cmd = new SqlCommand("Student_List_Attendance", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@cid", SqlDbType.VarChar, 10);

                cmd.Parameters.Add("@Found", SqlDbType.Int).Direction = ParameterDirection.Output;

                // set parameter values
                cmd.Parameters["@cid"].Value = cid;


                cmd.ExecuteNonQuery();

                // read output value 
                Found = Convert.ToInt32(cmd.Parameters["@Found"].Value); //convert to output parameter to interger format

                if (Found == 1)
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))

                    {
                        da.Fill(ds);

                    }

                    DT = ds.Tables[0];

                }


                con.Close();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }

            return Found;

        }
        //preocedure to insert attendance


        public int Show_Students_In_Course(String cid, ref DataTable DT)
        {

            int Found = 0;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;


            try
            {
                cmd = new SqlCommand("See_All_Student_Course", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@cid", SqlDbType.VarChar, 10);

                cmd.Parameters.Add("@Found", SqlDbType.Int).Direction = ParameterDirection.Output;

                // set parameter values
                cmd.Parameters["@cid"].Value = cid;


                cmd.ExecuteNonQuery();

                // read output value 
                Found = Convert.ToInt32(cmd.Parameters["@Found"].Value); //convert to output parameter to interger format

                if (Found == 1)
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))

                    {
                        da.Fill(ds);

                    }

                    DT = ds.Tables[0];

                }


                con.Close();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }

            return Found;

        }


        public int InsertAttendance(String RegNo, String courseID, string date, char status)
        {


            int Found = 0;

            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;


            try
            {
                cmd = new SqlCommand("addattendance", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@cid", SqlDbType.VarChar, 10);
                cmd.Parameters.Add("@rn", SqlDbType.VarChar, 10);


                cmd.Parameters.Add("@date", SqlDbType.Date);
                cmd.Parameters.Add("@status", SqlDbType.Char);



                cmd.Parameters.Add("@Found", SqlDbType.Int).Direction = ParameterDirection.Output;

                // set parameter values
                cmd.Parameters["@cid"].Value = courseID;
                cmd.Parameters["@rn"].Value = RegNo;
                cmd.Parameters["@date"].Value = date;
                cmd.Parameters["@status"].Value = status;



                cmd.ExecuteNonQuery();

                // read output value 
                Found = Convert.ToInt32(cmd.Parameters["@Found"].Value); //convert to output parameter to interger format

                if (Found == 1)
                {


                }


                con.Close();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }

            return Found;

        }

        public int ViewCourseMarksStudent(String Name, String cid, ref DataTable DT)
        {

            int Found = 0;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("Transcript_View_Course", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@rn", SqlDbType.VarChar, 10);
                cmd.Parameters.Add("@cid", SqlDbType.VarChar, 10);

                cmd.Parameters.Add("@Found", SqlDbType.Int).Direction = ParameterDirection.Output;

                // set parameter values
                cmd.Parameters["@rn"].Value = Name;
                cmd.Parameters["@cid"].Value = cid;



                cmd.ExecuteNonQuery();

                // read output value 
                Found = Convert.ToInt32(cmd.Parameters["@Found"].Value); //convert to output parameter to interger format

                if (Found == 1)
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))

                    {
                        da.Fill(ds);

                    }

                    DT = ds.Tables[0];

                }


                con.Close();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }

            return Found;
        }



        //procedure to update transcript of student
        public int UpdateTranscript(String RegNo, String courseID, int obtained, int total)
        {


            int Found = 0;

            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;


            try
            {
                cmd = new SqlCommand("addmarks", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@cid", SqlDbType.VarChar, 10);
                cmd.Parameters.Add("@rn", SqlDbType.VarChar, 10);


                cmd.Parameters.Add("@om", SqlDbType.Int);
                cmd.Parameters.Add("@total", SqlDbType.Int);



                cmd.Parameters.Add("@Found", SqlDbType.Int).Direction = ParameterDirection.Output;

                // set parameter values
                cmd.Parameters["@cid"].Value = courseID;
                cmd.Parameters["@rn"].Value = RegNo;
                cmd.Parameters["@om"].Value = obtained;
                cmd.Parameters["@total"].Value = total;




                cmd.ExecuteNonQuery();

                // read output value 
                Found = Convert.ToInt32(cmd.Parameters["@Found"].Value); //convert to output parameter to interger format

                if (Found == 1)
                {


                }


                con.Close();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }

            return Found;

        }

        //Function to only Display the transcript of a specific course
        //Function to return transcript of a given student
        public int ViewSpecificCourseTranscript(String Name, String cid, ref DataTable DT)
        {

            int Found = 0;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("ViewSelectedCourseMarks", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@rn", SqlDbType.VarChar, 10);
                cmd.Parameters.Add("@cid", SqlDbType.VarChar, 10);

                cmd.Parameters.Add("@Found", SqlDbType.Int).Direction = ParameterDirection.Output;

                // set parameter values
                cmd.Parameters["@rn"].Value = Name;
                cmd.Parameters["@cid"].Value = cid;



                cmd.ExecuteNonQuery();

                // read output value 
                Found = Convert.ToInt32(cmd.Parameters["@Found"].Value); //convert to output parameter to interger format

                if (Found == 1)
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))

                    {
                        da.Fill(ds);

                    }

                    DT = ds.Tables[0];

                }


                con.Close();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }

            return Found;
        }
        ////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////
        ///Director FUnctionalities
        ///


        //View all students
        public int ViewAllStudents(ref DataTable DT)
        {

            int Found = 0;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("ViewAllStudent", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add("@Found", SqlDbType.Int).Direction = ParameterDirection.Output;




                cmd.ExecuteNonQuery();

                // read output value 
                Found = Convert.ToInt32(cmd.Parameters["@Found"].Value); //convert to output parameter to interger format

                if (Found == 1)
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))

                    {
                        da.Fill(ds);

                    }

                    DT = ds.Tables[0];

                }


                con.Close();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }

            return Found;
        }


        //delete students
        public int DeleteStudent(String RegNo)
        {


            int Found = 0;

            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;


            try
            {
                cmd = new SqlCommand("delstudent", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@rn", SqlDbType.VarChar, 10);



                cmd.Parameters.Add("@Found", SqlDbType.Int).Direction = ParameterDirection.Output;

                // set parameter values
                cmd.Parameters["@rn"].Value = RegNo;



                cmd.ExecuteNonQuery();

                // read output value 
                Found = Convert.ToInt32(cmd.Parameters["@Found"].Value); //convert to output parameter to interger format

                if (Found == 1)
                {


                }


                con.Close();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }

            return Found;

        }


        ///Insert Student
        public int EnrollStudent(String RegNo, string pass, string email, string name, string dob, string cnic, string Department, string phone, char gender)
        {


            int Found = 0;

            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;


            try
            {
                cmd = new SqlCommand("insertstudent", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@rn", SqlDbType.VarChar, 10);
                cmd.Parameters.Add("@name", SqlDbType.VarChar, 20);
                cmd.Parameters.Add("@bithday", SqlDbType.Date);
                cmd.Parameters.Add("@email", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@no", SqlDbType.VarChar, 20);
                cmd.Parameters.Add("@idcard", SqlDbType.VarChar, 20);
                cmd.Parameters.Add("@gen", SqlDbType.Char);
                cmd.Parameters.Add("@dno", SqlDbType.VarChar, 20);
                cmd.Parameters.Add("@pass", SqlDbType.VarChar, 20);



                cmd.Parameters.Add("@Found", SqlDbType.Int).Direction = ParameterDirection.Output;

                // set parameter values
                cmd.Parameters["@rn"].Value = RegNo;


                cmd.Parameters["@name"].Value = name;
                cmd.Parameters["@bithday"].Value = dob;

                cmd.Parameters["@email"].Value = email;
                cmd.Parameters["@no"].Value = phone;
                cmd.Parameters["@idcard"].Value = cnic;
                cmd.Parameters["@gen"].Value = gender;
                cmd.Parameters["@dno"].Value = Department;
                cmd.Parameters["@pass"].Value = pass;


                cmd.ExecuteNonQuery();

                // read output value 
                Found = Convert.ToInt32(cmd.Parameters["@Found"].Value); //convert to output parameter to interger format

                if (Found == 1)
                {


                }


                con.Close();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }

            return Found;

        }
        //view all teachers
        public int ViewAllTeachers(ref DataTable DT)
        {

            int Found = 0;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("ViewAllTeacher", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add("@Found", SqlDbType.Int).Direction = ParameterDirection.Output;




                cmd.ExecuteNonQuery();

                // read output value 
                Found = Convert.ToInt32(cmd.Parameters["@Found"].Value); //convert to output parameter to interger format

                if (Found == 1)
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))

                    {
                        da.Fill(ds);

                    }

                    DT = ds.Tables[0];

                }


                con.Close();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }

            return Found;
        }


        //delete students
        public int DeleteTeacher(String RegNo)
        {


            int Found = 0;

            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;


            try
            {
                cmd = new SqlCommand("delteacher", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@rn", SqlDbType.VarChar, 10);



                cmd.Parameters.Add("@Found", SqlDbType.Int).Direction = ParameterDirection.Output;

                // set parameter values
                cmd.Parameters["@rn"].Value = RegNo;



                cmd.ExecuteNonQuery();

                // read output value 
                Found = Convert.ToInt32(cmd.Parameters["@Found"].Value); //convert to output parameter to interger format

                if (Found == 1)
                {


                }


                con.Close();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }

            return Found;

        }

        //add teacher
        public int AddTeacher(String RegNo, string pass, string email, string name, string dob, string cnic, string Department, string phone, char gender)
        {


            int Found = 0;

            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;


            try
            {
                cmd = new SqlCommand("insertteacher", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@rn", SqlDbType.VarChar, 10);
                cmd.Parameters.Add("@name", SqlDbType.VarChar, 20);
                cmd.Parameters.Add("@bithday", SqlDbType.Date);
                cmd.Parameters.Add("@email", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@no", SqlDbType.VarChar, 20);
                cmd.Parameters.Add("@idcard", SqlDbType.VarChar, 20);
                cmd.Parameters.Add("@gen", SqlDbType.Char);
                cmd.Parameters.Add("@dno", SqlDbType.VarChar, 20);
                cmd.Parameters.Add("@pass", SqlDbType.VarChar, 20);



                cmd.Parameters.Add("@Found", SqlDbType.Int).Direction = ParameterDirection.Output;

                // set parameter values
                cmd.Parameters["@rn"].Value = RegNo;


                cmd.Parameters["@name"].Value = name;
                cmd.Parameters["@bithday"].Value = dob;

                cmd.Parameters["@email"].Value = email;
                cmd.Parameters["@no"].Value = phone;
                cmd.Parameters["@idcard"].Value = cnic;
                cmd.Parameters["@gen"].Value = gender;
                cmd.Parameters["@dno"].Value = Department;
                cmd.Parameters["@pass"].Value = pass;


                cmd.ExecuteNonQuery();

                // read output value 
                Found = Convert.ToInt32(cmd.Parameters["@Found"].Value); //convert to output parameter to interger format

                if (Found == 1)
                {


                }


                con.Close();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }

            return Found;

        }



        //View all departments
        public int ViewAllDepartments(ref DataTable DT)
        {

            int Found = 0;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("ViewAllDepartment", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add("@Found", SqlDbType.Int).Direction = ParameterDirection.Output;




                cmd.ExecuteNonQuery();

                // read output value 
                Found = Convert.ToInt32(cmd.Parameters["@Found"].Value); //convert to output parameter to interger format

                if (Found == 1)
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))

                    {
                        da.Fill(ds);

                    }

                    DT = ds.Tables[0];

                }


                con.Close();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }

            return Found;
        }


        //Delete Department
        public int DeleteDepartment(String RegNo)
        {


            int Found = 0;

            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;


            try
            {
                cmd = new SqlCommand("DeleteDepartment", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@did", SqlDbType.VarChar, 10);



                cmd.Parameters.Add("@Found", SqlDbType.Int).Direction = ParameterDirection.Output;

                // set parameter values
                cmd.Parameters["@did"].Value = RegNo;



                cmd.ExecuteNonQuery();

                // read output value 
                Found = Convert.ToInt32(cmd.Parameters["@Found"].Value); //convert to output parameter to interger format

                if (Found == 1)
                {


                }


                con.Close();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }

            return Found;

        }


        //Procedure to Add department
        public int AddDepartment(String RegNo, string name)
        {


            int Found = 0;

            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;


            try
            {
                cmd = new SqlCommand("insertdepartment", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;



                cmd.Parameters.Add("@dno", SqlDbType.VarChar, 10);
                cmd.Parameters.Add("@dname", SqlDbType.VarChar, 20);

                cmd.Parameters.Add("@Found", SqlDbType.Int).Direction = ParameterDirection.Output;

                // set parameter values
                cmd.Parameters["@dno"].Value = RegNo;
                cmd.Parameters["@dname"].Value = name;



                cmd.ExecuteNonQuery();

                // read output value 
                Found = Convert.ToInt32(cmd.Parameters["@Found"].Value); //convert to output parameter to interger format

                if (Found == 1)
                {


                }


                con.Close();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }

            return Found;

        }


        //View all courses
        public int ViewAllCourses(ref DataTable DT)
        {

            int Found = 0;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("ViewAllCourses", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add("@Found", SqlDbType.Int).Direction = ParameterDirection.Output;




                cmd.ExecuteNonQuery();

                // read output value 
                Found = Convert.ToInt32(cmd.Parameters["@Found"].Value); //convert to output parameter to interger format

                if (Found == 1)
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))

                    {
                        da.Fill(ds);

                    }

                    DT = ds.Tables[0];

                }


                con.Close();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }

            return Found;
        }


        //Procedure to Add course
        public int AddCourse(String RegNo, string name)
        {


            int Found = 0;

            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;


            try
            {
                cmd = new SqlCommand("addcourse", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;



                cmd.Parameters.Add("@cid", SqlDbType.VarChar, 10);
                cmd.Parameters.Add("@cname", SqlDbType.VarChar, 20);

                cmd.Parameters.Add("@Found", SqlDbType.Int).Direction = ParameterDirection.Output;

                // set parameter values
                cmd.Parameters["@cid"].Value = RegNo;
                cmd.Parameters["@cname"].Value = name;



                cmd.ExecuteNonQuery();

                // read output value 
                Found = Convert.ToInt32(cmd.Parameters["@Found"].Value); //convert to output parameter to interger format

                if (Found == 1)
                {


                }


                con.Close();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }

            return Found;

        }


        //Delete Department
        public int DeleteCourse(String RegNo)
        {


            int Found = 0;

            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;


            try
            {
                cmd = new SqlCommand("delcourse", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@cid", SqlDbType.VarChar, 10);



                cmd.Parameters.Add("@Found", SqlDbType.Int).Direction = ParameterDirection.Output;

                // set parameter values
                cmd.Parameters["@cid"].Value = RegNo;



                cmd.ExecuteNonQuery();

                // read output value 
                Found = Convert.ToInt32(cmd.Parameters["@Found"].Value); //convert to output parameter to interger format

                if (Found == 1)
                {


                }


                con.Close();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }

            return Found;

        }

    }
}
