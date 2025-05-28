using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using MusicDBApp.Model;

namespace MusicDBApp.Repos;

// .mdf file stored in Onedrive>12TPI>DBfile
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
        string sqlString = "SELECT * FROM tblGenre";
        using (SqlCommand cmd = new SqlCommand(sqlString, conn))
        {
            using (SqlDataReader reader = cmd.ExecuteReader()) 
            {
                while (reader.Read())
                {
                    int GenreID = Convert.ToInt32(reader["Genre_ID"]);
                    string GenreName = reader["Genre_Name"].ToString();
                    genres.Add(new Genres(GenreName, GenreID));
                }
            }
        }
        return genres;
    }

    public int UpdateGenresName(int genreID, string genreName)
    {
        using (SqlCommand cmd = new SqlCommand($"UPDATE Genres SET Genre_Name = @Genre_Name WHERE Genre_ID = @Genre_ID", conn))
        {
            cmd.Parameters.AddWithValue("@Genre_Name", genreName);
            cmd.Parameters.AddWithValue("@Genre_ID", genreID);
            return cmd.ExecuteNonQuery();
        }
    }
    public int InsertLocation(Genres genre)
    {
        using (SqlCommand cmd = new SqlCommand($"INSERT INTO tblGenre GenreName VALUES @GenreName; SELECT SCOPE_IDENTITY(); ", conn))
        {
            cmd.Parameters.AddWithValue("@Genre_Name", genre.Genre_Name);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }
    }

    public int DeleteLocationByName(string genreName)
    {
        using (SqlCommand cmd = new SqlCommand($"DELETE FROM tblGenre WHERE Genre_Name = @GenreName", conn))
        {
            cmd.Parameters.AddWithValue($"@Genre_Name", genreName);
            return cmd.ExecuteNonQuery();
        }
    }
    public void CloseConnection()
    {
        if (conn != null && conn.State == ConnectionState.Open)
        {
            conn.Close();
            Console.WriteLine("connection closed");
        }
    }
}
