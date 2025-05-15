using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicDBApp.Model;
using Microsoft.Data.SqlClient;
using MusicDBApp.DBfile.Model;


namespace MusicDBApp
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

        public List<Genres> GetAllGenres()
        {
            List<Genres> genres = new List<Genres>();
            string sqlString = "SELECT * FROM Genres";
            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {

            }
        }
    }
}
