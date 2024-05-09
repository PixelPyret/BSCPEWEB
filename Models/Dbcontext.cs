using MySql.Data.MySqlClient;

namespace BSCPEWEB.Models
{
    public class Dbcontext
    {
        public readonly MySqlConnection _connection;
        private string connectionString;

        public Dbcontext(MySqlConnection connection)
        {
            _connection = connection;

        }

        public Dbcontext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool testconnection()
        {
            try
            {
                _connection.Open();
                _connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
