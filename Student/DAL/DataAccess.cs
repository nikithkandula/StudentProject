using System;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Student.Models;
    
namespace Student.DAL
{
    public class DataAccess
    {
        private IConfiguration _configuration;
        //private Logger _logger;
        public DataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
            //_logger = logger;
        }


        public int AddStudent(StudentInfo studentInfo, string transActionId)
        {
            SqlConnection con = null;
            var studentId = 88;
            try
            {
               
                con = new SqlConnection(_configuration["ConnectionString"]);
                var CommandText = "insert into student (StudentId,LastName,FirstName,Address,City) values(" + studentId + "," + studentInfo.LastName + "','" + studentInfo.FirstName + "',' " + studentInfo.Address + " ', ' " + studentInfo.City + " ')";


                SqlCommand cm = new SqlCommand(CommandText, con);

                con.Open();

                cm.ExecuteNonQuery();

                
            }
            catch (Exception e)
            {
               // _logger.Log(transActionId, e.Message, e.StackTrace);
                return 0;
            }

            finally
            {
                con.Close();
            }

            return studentId;
        }



        public StudentInfo GetStudent(int id)
        {
            SqlConnection con = null;
            StudentInfo studentInfo = new StudentInfo();
            try
            {
                // Creating Connection  
                con = new SqlConnection("data source=localhost; database=School; User ID = sa; Password =Portal@790");
                var CommandText = "Select * from student where studentid =" + id;

                // writing sql query  
                SqlCommand cm = new SqlCommand(CommandText, con);


                // Opening Connection  
                con.Open();

                // Executing the SQL query  
                SqlDataReader sdr = cm.ExecuteReader();
                sdr.Read();
                studentInfo.LastName = Convert.ToString(sdr["LastName"]);
                studentInfo.FirstName = Convert.ToString(sdr["FirstName"]);
                studentInfo.Address = Convert.ToString(sdr["Address"]);
                studentInfo.City = Convert.ToString(sdr["City"]);

                // Iterating Data  
                //while (sdr.Read())
                //{
                // Displaying Record  
                //Console.WriteLine(sdr["StudentId"] + " " + sdr["LastName"] + " " + sdr["FirstName"] + " " + sdr["Address"] + " " + sdr["City"]);
                //}
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong." + e);
            }
            // Closing the connection  
            finally
            {
                con.Close();
            }



            return studentInfo;


        }



    }













}