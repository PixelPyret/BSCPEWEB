using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

namespace BSCPEWEB.Models
{
    public class StudentContext 
    {
        public readonly MySqlConnection _mySqlConnection;


        public StudentContext(string connectionString)
        {
            _mySqlConnection = new MySqlConnection(connectionString);
        }
        public bool InsertStudent(Student student)
        {
            try
            {
                _mySqlConnection.Open();
                MySqlCommand sqlcommand = new MySqlCommand(
                    @"INSERT INTO user (Fname,Lname,email ,phone ,year,course)

                    VALUES

                    (@Fname,
                     @Lname,
                    @email ,
                    @phone ,
                    @year,
                    @course,",
                    _mySqlConnection);


                sqlcommand.Parameters.AddWithValue("@Firstname", student.Fname);
                sqlcommand.Parameters.AddWithValue("@Lastname", student.Lname);
                sqlcommand.Parameters.AddWithValue("@Email", student.email);
                sqlcommand.Parameters.AddWithValue("@Phone", student.phone);
                sqlcommand.Parameters.AddWithValue("@Course", student.course);
               

                //sqlcommand.Parameters.AddWithValue("@Lname", "Suemith");
                //sqlcommand.Parameters.AddWithValue("@Fname", "Joseph Manuel");
                //sqlcommand.Parameters.AddWithValue("@Mname", "None");
                //sqlcommand.Parameters.AddWithValue("@Suffix", "None");
                //sqlcommand.Parameters.AddWithValue("@Street", "Zone 4");
                //sqlcommand.Parameters.AddWithValue("@Municipality", "Sta. Cruz");
                //sqlcommand.Parameters.AddWithValue("@Province", "D");
                //sqlcommand.Parameters.AddWithValue("@birthdate", student.Bdate);
                //sqlcommand.Parameters.AddWithValue("@gender", "Male");
                //sqlcommand.Parameters.AddWithValue("@phonenumber", 09914673214);
                //sqlcommand.Parameters.AddWithValue("@studentemail", "josephmanuelsuemith@gmail.com");
                //sqlcommand.Parameters.AddWithValue("@yearlevel", 4);
                //sqlcommand.Parameters.AddWithValue("@courses", "COE");

                int rowsAffected = sqlcommand.ExecuteNonQuery();

                _mySqlConnection.Close();
                return rowsAffected > 0;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }


        }
        public bool TestConnection()
        {
            try
            {
                _mySqlConnection.Open();
                _mySqlConnection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

