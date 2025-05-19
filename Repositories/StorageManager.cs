using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicDBApp.Model;
using Microsoft.Data.SqlClient;
using MusicDBApp.DBfile.Model;
using Microsoft.Identity.Client;


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
                using (SqlDataReader reader = cmd.ExecuteReader()) 
                {
                    while (reader.Read())
                    {
                        int genreID = Convert.ToInt32(reader["Genre_ID"]);
                        string GenreName = reader["Genre_Name"].ToString();
                        genres.Add(new Genres(GenreID, GenreName));
                    }
                }
            }
            return genres;
        }
    }
}
