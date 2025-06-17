using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.PortableExecutable;
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

    static void PrintLine()
    {
        Console.WriteLine(new string('-', Console.WindowWidth - 1));
    }

    static void PrintRow(params string[] columns)
    {
        int width = (Console.WindowWidth - columns.Length - 1) / columns.Length; 
        string row = "|";

        foreach (string column in columns)
        {
            row += column.PadRight(width).Substring(0, width) + "|";
        }

        Console.WriteLine(row);
    }

    public int GetUserID(int UserID)
    {
        int userID = 0;
        string sqlString = "SELECT User_ID FROM tblUser WHERE UserID = @User_ID AND Active = 1";

        using (SqlCommand cmd = new SqlCommand(sqlString, conn))
        {
            cmd.Parameters.AddWithValue("@User_ID", UserID);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    UserID = Convert.ToInt32(reader["User_ID"]);
                }
            }
        }
        return userID;
    }

    public List<RecordLabel> GetAllRecordLabel()
    {
        List<RecordLabel> recordLabels = new List<RecordLabel>();
        string sqlString = "SELECT * FROM tblRecordLabel";
        using (SqlCommand cmd = new SqlCommand(sqlString, conn))
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int RecordLabelID = Convert.ToInt32(reader["RecordLabel_ID"]);
                    string RecordLabelName = reader["RecordLabel_Name"].ToString();
                    recordLabels.Add(new RecordLabel(RecordLabelName, RecordLabelID));
                }
            }
        }
        return recordLabels;
    }

    public List<Artist> GetAllArtist()
    {
        List<Artist> artist = new List<Artist>();
        string sqlString = "SELECT * FROM tblArtist";
        using (SqlCommand cmd = new SqlCommand(sqlString, conn))
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string ArtistName = reader["Artist_Name"].ToString();
                    int ArtistID = Convert.ToInt32(reader["Artist_ID"]);
                    int RecordLabelID = Convert.ToInt32(reader["RecordLabel_ID"]);
                    artist.Add(new Artist(ArtistName, ArtistID, RecordLabelID));
                }
            }
        }
        return artist;
    }

    public List<Vinyl> GetAllVinyl()
    {
        List<Vinyl> vinyls = new List<Vinyl>();
        string sqlString = "SELECT * FROM tblVinyl";
        using (SqlCommand cmd = new SqlCommand(sqlString, conn))
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int VinylID = Convert.ToInt32(reader["Vinyl_ID"]);
                    int ArtistID = Convert.ToInt32(reader["Artist_ID"]);
                    string VinylName = reader["Vinyl_Name"].ToString();
                    DateTime DateOfRelease = Convert.ToDateTime(reader["Date_Of_Release"]);
                    vinyls.Add(new Vinyl(VinylName, VinylID, ArtistID, DateOfRelease));
                }
            }
        }
        return vinyls;
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
                    string Description = reader["Description"].ToString();
                    genres.Add(new Genres(GenreName, GenreID, Description));
                }
            }
        }
        return genres;
    }

    public List<Reviews> GetAllReviews()
    {
        List<Reviews> reviews = new List<Reviews>();
        string sqlString = "SELECT * FROM tblReviews";
        using (SqlCommand cmd = new SqlCommand(sqlString, conn))
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int ReviewID = Convert.ToInt32(reader["Review_ID"]);
                    string ReviewerName = reader["Reviewer_Name"].ToString();
                    int VinylID = Convert.ToInt32(reader["Vinyl_ID"]);
                    decimal OutOf5 = Convert.ToDecimal(reader["Out_Of_5"]);
                    reviews.Add(new Reviews(ReviewerName, ReviewID, VinylID, OutOf5));
                }
            }
        }
        return reviews;
    }

    public List<ReviewComments> GetAllReviewComments()
    {
        List<ReviewComments> reviewComments = new List<ReviewComments>();
        string sqlString = "SELECT * FROM tblReviewComments";
        using (SqlCommand cmd = new SqlCommand(sqlString, conn))
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string ShortReview = (reader["Short_Review"]).ToString();
                    int ReviewID = Convert.ToInt32(reader["Review_ID"]);
                    int ReviewCommentID = Convert.ToInt32(reader["ReviewComment_ID"]);
                    DateTime ReviewDate = Convert.ToDateTime(reader["Review_Date"]);
                    reviewComments.Add(new ReviewComments(ShortReview, ReviewID, ReviewCommentID, ReviewDate));

                }
            }
        }
        return reviewComments;
    }

    public void AdvQry1()
    {
        string sqlString = "SELECT Artist_Name, Artist_ID, RecordLabel_ID FROM TblArtist WHERE Artist_Name LIKE 'A%' ORDER BY Artist_Name;";

        using (SqlCommand cmd = new SqlCommand(sqlString, conn))
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                PrintLine();
                PrintRow("Artist Name", "Artist ID", "Record Label ID");

                while (reader.Read())
                {
                    string artistName = reader["Artist_Name"].ToString();
                    int artistID = Convert.ToInt32(reader["Artist_ID"]);
                    int recordLabelID = Convert.ToInt32(reader["RecordLabel_ID"]);

                    PrintLine();
                    PrintRow($"{artistName}", $"{artistID}", $"{recordLabelID}");
                    PrintLine();
                }
            }
        }
    }


    public int UpdateRecordLabelsName(int recordLabelID, string recordLabelName)
    {
        using (SqlCommand cmd = new SqlCommand($"UPDATE tblRecordLabel SET RecordLabel_Name = @RecordLabel_Name WHERE RecordLabel_ID = @RecordLabel_ID", conn))
        {
            cmd.Parameters.AddWithValue("@RecordLabel_Name", recordLabelName);
            cmd.Parameters.AddWithValue("@RecordLabel_ID", recordLabelID);
            return cmd.ExecuteNonQuery();
        }
    }

    public int UpdateArtistsName(int ArtistID, string ArtistName)
    {
        using (SqlCommand cmd = new SqlCommand($"UPDATE tblArtist SET Artist_Name = @Artist_Name WHERE Artist_ID = @Artist_ID", conn))
        {
            cmd.Parameters.AddWithValue("@Artist_Name", ArtistName);
            cmd.Parameters.AddWithValue("@Artist_ID", ArtistID);
            return cmd.ExecuteNonQuery();
        }
    }

    public int UpdateVinylsName(int VinylID, string VinylName)
    {
        using (SqlCommand cmd = new SqlCommand($"UPDATE tblVinyl SET Vinyl_Name = @Vinyl_Name WHERE Vinyl_ID = @Vinyl_ID", conn))
        {
            cmd.Parameters.AddWithValue("@Vinyl_Name", VinylName);
            cmd.Parameters.AddWithValue("@Vinyl_ID", VinylID);
            return cmd.ExecuteNonQuery();
        }
    }



    public int UpdateGenresName(int genreID, string genreName)
    {
        using (SqlCommand cmd = new SqlCommand($"UPDATE tblGenre SET Genre_Name = @Genre_Name WHERE Genre_ID = @Genre_ID", conn))
        {
            cmd.Parameters.AddWithValue("@Genre_Name", genreName);
            cmd.Parameters.AddWithValue("@Genre_ID", genreID);
            return cmd.ExecuteNonQuery();
        }
    }

    public int UpdateReviewersName(int ReviewID, string ReviewerName)
    {
        using (SqlCommand cmd = new SqlCommand($"UPDATE tblReviews SET Reviewer_Name = @Reviewer_Name WHERE Review_ID = @Review_ID", conn))
        {
            cmd.Parameters.AddWithValue("@Reviewer_Name", ReviewerName);
            cmd.Parameters.AddWithValue("@Review_ID", ReviewID);
            return cmd.ExecuteNonQuery();
        }
    }

    public int UpdateReviewComments(int ReviewCommentID, string ShortReview)
    {
        using (SqlCommand cmd = new SqlCommand($"UPDATE tblReviewComments SET ShortReview = @Short_Review WHERE ReviewCommentID = @ReviewCommentID", conn))
        {
            cmd.Parameters.AddWithValue("@Short_Review", ShortReview);
            cmd.Parameters.AddWithValue("@ReviewComment_ID", ReviewCommentID);
            return cmd.ExecuteNonQuery();
        }
    }

    public int InsertLocationRecordLabels(RecordLabel recordLabel)
    {
        using (SqlCommand cmd = new SqlCommand($"INSERT INTO tblRecordLabel (RecordLabel_Name) VALUES (@RecordLabel_Name); SELECT SCOPE_IDENTITY();", conn))
        {
            cmd.Parameters.AddWithValue("@RecordLabel_Name", recordLabel.RecordLabel_Name);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }
    }

    public int InsertLocationArtists(Artist artist)
    {
        using (SqlCommand cmd = new SqlCommand($"INSERT INTO tblArtist (Artist_Name, RecordLabel_ID) VALUES (@Artist_Name, @RecordLabel_ID); SELECT SCOPE_IDENTITY();", conn))
        {
            cmd.Parameters.AddWithValue("@Artist_Name", artist.Artist_Name);
            cmd.Parameters.AddWithValue("@RecordLabel_ID", artist.RecordLabel_ID);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }
    }

    public int InsertLocationGenres(Genres genre)
    {
        using (SqlCommand cmd = new SqlCommand($"INSERT INTO tblGenre (genre_Name, Description) VALUES (@Genre_Name, @Description); SELECT SCOPE_IDENTITY();", conn))
        {
            cmd.Parameters.AddWithValue("@Genre_Name", genre.Genre_Name);
            cmd.Parameters.AddWithValue("@Description", genre.Description);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }
    }


    public int DeleteLocationByName(string genreName)
    {
        using (SqlCommand cmd = new SqlCommand($"DELETE FROM tblGenre WHERE Genre_Name = @genreName", conn))
        {
            cmd.Parameters.AddWithValue($"@genreName", genreName);
            return cmd.ExecuteNonQuery();
        }
    }

    public int DeleteRecordLabelByName(string recordLabelName)
    {
        using (SqlCommand cmd = new SqlCommand($"DELETE FROM tblRecordLabel WHERE  RecordLabel_Name = @recordLabelName", conn))
        {
            cmd.Parameters.AddWithValue($"@recordLabelName", recordLabelName);
            return cmd.ExecuteNonQuery();
        }
    }




    public void CloseConnection()
    {
        if (conn != null && conn.State == ConnectionState.Open)
        {
            conn.Close();
            Console.WriteLine("connection closed.");
        }
    }
}