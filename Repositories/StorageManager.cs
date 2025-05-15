using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace MusicDBApp.Repositories
{
    public class StorageManager
    {
        private SqlConnection conn;

        public StorageManager(string connectionString)
        {
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                Console.WriteLine("Connection successful");
            }

            catch (SqlException e)
            {
                Console.WriteLine("Connection is NOT successful \n");
                Console.WriteLine(e.Message);
            }

            catch (Exception ex)
            {
                Console.WriteLine("An error occoured \n");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
