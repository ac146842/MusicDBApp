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

    // method to seperate rows from each other for visibility
    static void PrintLine()
    {
        Console.WriteLine(new string('-', Console.WindowWidth - 1));
    }

    // retrives username from database
    public string getUsername(string username)
    {
        string sqlString = "SELECT User_Name FROM tblUser WHERE User_Name = @User_Name";

        using (SqlCommand cmd = new SqlCommand(sqlString, conn))
        {
            cmd.Parameters.AddWithValue("@User_Name", username);


            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    username = reader["User_Name"].ToString();
                }
            }
        }
        return (username);
    }

    // retrives password matching a username from database 
    public string getPassword(string username)
    {
        string Password = "";
        string sqlString = "SELECT Password FROM tblUser WHERE User_Name = @User_Name";
        using (SqlCommand cmd = new SqlCommand(sqlString, conn))
        {
            cmd.Parameters.AddWithValue("@User_Name", username);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    Password = reader["Password"].ToString();
                }
            }
        }
        return Password;
    }

    // retrives role ID matching a username from database
    public int getRoleID(string username)
    {
        int roleID = 0;

        string sqlString = "SELECT Role_ID FROM tblUser WHERE User_Name = @User_Name";


        using (SqlCommand cmd = new SqlCommand(sqlString, conn))
        {
            cmd.Parameters.AddWithValue("@User_Name", username);


            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    roleID = Convert.ToInt32(reader["Role_ID"]);
                }
            }
        }
        return (roleID);
    }

    // retrives user ID matching a username from database
    public int getUserID(string username)
    {
        int userID = 0;

        string sqlString = "SELECT User_ID FROM tblUser WHERE User_Name = @User_Name";

        using (SqlCommand cmd = new SqlCommand(sqlString, conn))
        {
            cmd.Parameters.AddWithValue("@User_Name", username);


            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    userID = Convert.ToInt32(reader["User_ID"]);
                }
            }
        }
        return (userID);
    }

    // Registers a new user in the database
    public int RegisterUser(string username, string password, int roleID, int newAge)
    {
        string sql = "INSERT INTO tblUser (User_Name, Password, Age, Role_ID) VALUES (@username, @password, @age, @roleID)";

        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@age", newAge);
            cmd.Parameters.AddWithValue("@roleID", roleID);

            return cmd.ExecuteNonQuery();
        }
    }

    // Checks if a user with the given username exists in the database
    public bool UserExists(string username)
    {
        string sql = "SELECT COUNT(*) FROM tblUser WHERE User_Name = @username";

        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            cmd.Parameters.AddWithValue("@username", username);
            int count = (int)cmd.ExecuteScalar();
            return count > 0;
        }
    }

    // Checks if a record label exists in the database
    public bool RecordLabelExists(int recordLabelID)
    {
        using (SqlCommand cmd = new SqlCommand("SELECT COUNT(1) FROM tblRecordLabel WHERE RecordLabel_ID = @RecordLabel_ID", conn))
        {
            cmd.Parameters.AddWithValue("@RecordLabel_ID", recordLabelID);
            return (int)cmd.ExecuteScalar() > 0;
        }
    }

    // Checks if an artist exists in the database
    public bool ArtistExists(int artistID)
    {
        using (SqlCommand cmd = new SqlCommand("SELECT COUNT(1) FROM tblArtist WHERE Artist_ID = @Artist_ID", conn))
        {
            cmd.Parameters.AddWithValue("@Artist_ID", artistID);
            return (int)cmd.ExecuteScalar() > 0;
        }
    }

    // Checks if a vinyl exists in the database
    public bool VinylExists(int vinylID)
    {
        using (SqlCommand cmd = new SqlCommand("SELECT COUNT(1) FROM tblVinyl WHERE Vinyl_ID = @Vinyl_ID", conn))
        {
            cmd.Parameters.AddWithValue("@Vinyl_ID", vinylID);
            return (int)cmd.ExecuteScalar() > 0;
        }
    }

    // Checks if a genre exists in the database
    public bool GenreExists(int genreID)
    {
        using (SqlCommand cmd = new SqlCommand("SELECT COUNT(1) FROM tblGenre WHERE Genre_ID = @Genre_ID", conn))
        {
            cmd.Parameters.AddWithValue("@Genre_ID", genreID);
            return (int)cmd.ExecuteScalar() > 0;
        }
    }

    // Checks if a review exists in the database
    public bool ReviewIDExists(int reviewID)
    {
        using (SqlCommand cmd = new SqlCommand("SELECT COUNT(1) FROM tblReviews WHERE Review_ID = @Review_ID", conn))
        {
            cmd.Parameters.AddWithValue("@Review_ID", reviewID);
            return (int)cmd.ExecuteScalar() > 0;
        }
    }

    // Checks if a review comment exists in the database
    public bool ReviewCommentIDExists(int reviewCommentID)
    {
        using (SqlCommand cmd = new SqlCommand("SELECT COUNT(1) FROM tblReviewComments WHERE ReviewComment_ID = @ReviewComment_ID", conn))
        {
            cmd.Parameters.AddWithValue("@ReviewComment_ID", reviewCommentID);
            return (int)cmd.ExecuteScalar() > 0;
        }
    }

    // Retrieves all records from the tblRecordLabel 
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

    // Retrieves all records from the tblArtist
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

    // Retrieves all records from the tblVinyl
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
                    vinyls.Add(new Vinyl(VinylName, ArtistID, VinylID, DateOfRelease));
                }
            }
        }
        return vinyls;
    }

    // Retrieves all records from the tblGenre
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

    // Retrieves all records from the tblReviews
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

    // Retrieves all records from the tblReviewComments
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

    // runs sql simple queries
    public void SmpQry1()
    {
        string sqlString = "SELECT * FROM tblGenre ORDER by Genre_ID;";

        using (SqlCommand cmd = new SqlCommand(sqlString, conn))
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                PrintLine();
                while (reader.Read())
                {
                    string GenreName = reader["Genre_Name"].ToString();
                    int GenreID = Convert.ToInt32(reader["Genre_ID"]);
                    Console.WriteLine($"Name: {GenreName}");
                    PrintLine();
                }
            }
        }
    }

    public void SmpQry2()
    {
        string sqlString = "SELECT * FROM tblRecordLabel ORDER by RecordLabel_ID;";

        using (SqlCommand cmd = new SqlCommand(sqlString, conn))
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                PrintLine();
                while (reader.Read())
                {
                    string RecordLabelName = reader["RecordLabel_Name"].ToString();
                    int RecordLabelID = Convert.ToInt32(reader["RecordLabel_ID"]);
                    Console.WriteLine($"Name: {RecordLabelName}");
                    PrintLine();
                }
            }
        }
    }


    public void SmpQry3()
    {
        string sqlString = "SELECT * FROM tblReviewComments ORDER BY CAST(Short_Review AS NVARCHAR(MAX));";

        using (SqlCommand cmd = new SqlCommand(sqlString, conn))
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                PrintLine();
                while (reader.Read())
                {
                    string ShortReview = (reader["Short_Review"]).ToString();
                    int ReviewID = Convert.ToInt32(reader["Review_ID"]);
                    int ReviewCommentID = Convert.ToInt32(reader["ReviewComment_ID"]);
                    DateTime ReviewDate = Convert.ToDateTime(reader["Review_Date"]);
                    Console.WriteLine($"Review: {ShortReview}, Date and Time: {ReviewCommentID}");
                    PrintLine();
                }
            }
        }
    }

    public void SmpQry4()
    {
        string sqlString = "SELECT * FROM tblReviews ORDER by Review_ID;";

        using (SqlCommand cmd = new SqlCommand(sqlString, conn))
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                PrintLine();
                while (reader.Read())
                {
                    string ReviewerName = reader["Reviewer_Name"].ToString();
                    int ReviewID = Convert.ToInt32(reader["Review_ID"]);
                    int VinylID = Convert.ToInt32(reader["Vinyl_ID"]);
                    decimal OutOf5 = Convert.ToDecimal(reader["Out_Of_5"]);
                    Console.WriteLine($"Reviewer Name: {ReviewerName}, Rating: {OutOf5}");
                    PrintLine();
                }
            }
        }
    }

    public void SmpQry5()
    {
        string sqlString = "SELECT * FROM tblVinyl ORDER by Vinyl_ID;";

        using (SqlCommand cmd = new SqlCommand(sqlString, conn))
        {
            PrintLine();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int VinylID = Convert.ToInt32(reader["Vinyl_ID"]);
                    int ArtistID = Convert.ToInt32(reader["Artist_ID"]);
                    string VinylName = reader["Vinyl_Name"].ToString();
                    DateTime DateOfRelease = Convert.ToDateTime(reader["Date_Of_Release"]);
                    Console.WriteLine($"Vinyl Name: {VinylName}, Release date: {DateOfRelease:yyyy-MM-dd}");
                    PrintLine();
                }
            }
        }
    }

    // runs sql advanced queries
    public void AdvQry1()
    {
        string sqlString = "SELECT Artist_Name, Artist_ID, RecordLabel_ID FROM TblArtist WHERE Artist_Name LIKE 'A%' ORDER BY CAST(Artist_Name AS NVARCHAR(MAX));";

        using (SqlCommand cmd = new SqlCommand(sqlString, conn))
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                PrintLine();
                while (reader.Read())
                {
                    string artistName = reader["Artist_Name"].ToString();
                    int artistID = Convert.ToInt32(reader["Artist_ID"]);
                    int recordLabelID = Convert.ToInt32(reader["RecordLabel_ID"]);
                    Console.WriteLine($"Artist Name: {artistName}");
                    PrintLine();
                }
            }
        }
    }

    public void AdvQry2()
    {
        string sqlString = "SELECT Genre_Name, Description FROM tblGenre WHERE CAST(Genre_Name AS NVARCHAR(MAX)) > 'M' ORDER BY CAST(Genre_Name AS NVARCHAR(MAX));";

        using (SqlCommand cmd = new SqlCommand(sqlString, conn))
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                PrintLine();
                while (reader.Read())
                {
                    string GenreName = reader["Genre_Name"].ToString();
                    string Description = reader["Description"].ToString();
                    Console.WriteLine($"Genre Name: {GenreName}, Description: {Description}");
                    PrintLine();
                }
            }
        }
    }

    public void AdvQry3()
    {
        string sqlString = "SELECT Reviewer_Name, Out_Of_5 FROM TblReviews WHERE Out_Of_5 > 3 ORDER BY Out_Of_5;";

        using (SqlCommand cmd = new SqlCommand(sqlString, conn))
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                PrintLine();
                while (reader.Read())
                {
                    string ReviewerName = reader["Reviewer_Name"].ToString();
                    string OutOf5 = reader["Out_Of_5"].ToString();
                    Console.WriteLine($"Reviewer Name: {ReviewerName}, Rating: {OutOf5}");
                    PrintLine();
                }
            }
        }
    }

    public void AdvQry4()
    {
        string sqlString = "SELECT Review_Date, Short_Review FROM tblReviewComments WHERE Review_Date BETWEEN '2010-12-31' AND '2020-12-31' ORDER BY Review_Date;";

        using (SqlCommand cmd = new SqlCommand(sqlString, conn))
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                PrintLine();
                while (reader.Read())
                {
                    DateTime ReviewDate = Convert.ToDateTime(reader["Review_Date"]);
                    string ShortReview = reader["Short_Review"].ToString();
                    Console.WriteLine($"Short Review: {ShortReview}, Review Date: {ReviewDate:yyyy-MM-dd}");
                    PrintLine();
                }
            }
        }
    }

    public void AdvQry5()
    {
        string sqlString = "SELECT Short_Review, Review_Date FROM tblReviewComments WHERE LEN(CAST(Short_Review AS NVARCHAR(MAX))) <= 30 ORDER BY Short_Review; ";

        using (SqlCommand cmd = new SqlCommand(sqlString, conn))
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                PrintLine();
                while (reader.Read())
                {
                    DateTime ReviewDate = Convert.ToDateTime(reader["Review_Date"]);
                    string ShortReview = reader["Short_Review"].ToString();
                    Console.WriteLine($"Short Review: {ShortReview}, Review Date: {ReviewDate.ToString("yyyy-MM-dd")}");
                    PrintLine();
                }
            }
        }
    }

    // runs sql complex queries
    public void CmxQry1()
    {
        string sqlString = "SELECT a.Artist_Name, AVG(r.Out_Of_5) AS AvgRating, a.RecordLabel_ID FROM TblArtist a, TblVinyl v, TblReviews r WHERE a.Artist_ID = v.Artist_ID  AND v.Vinyl_ID = r.Vinyl_ID GROUP BY a.Artist_Name, a.RecordLabel_ID";

        using (SqlCommand cmd = new SqlCommand(sqlString, conn))
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                PrintLine();
                while (reader.Read())
                {
                    string artistName = reader["Artist_Name"].ToString();
                    decimal avgRating = Convert.ToDecimal(reader["AvgRating"]);
                    string RecordLabelID = reader["RecordLabel_ID"].ToString();
                    Console.WriteLine($"Artist Name: {artistName}, Average Rating: {avgRating:F2}");
                    PrintLine();
                }
            }
        }
    }

    public void CmxQry2()
    {
        string sqlString = "SELECT a.Artist_Name, COUNT(v.Vinyl_ID) AS VinylCount FROM tblArtist a, tblVinyl v WHERE a.Artist_ID = v.Artist_ID GROUP BY a.Artist_Name ORDER BY VinylCount DESC;";

        using (SqlCommand cmd = new SqlCommand(sqlString, conn))
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                PrintLine();
                while (reader.Read())
                {
                    string artistName = reader["Artist_Name"].ToString();
                    int vinylCount = Convert.ToInt32(reader["VinylCount"]);
                    Console.WriteLine($"Artist Name: {artistName}, Vinyl Count: {vinylCount}");
                    PrintLine();
                }
            }
        }
    }

    public void CmxQry3()
    {
        string sqlString = "SELECT a.Artist_ID, a.Artist_Name, MIN(v.Date_Of_Release) AS EarliestDate FROM TblArtist a, TblVinyl v WHERE a.Artist_ID = v.Artist_ID GROUP BY a.Artist_ID, a.Artist_Name ORDER BY EarliestDate;";

        using (SqlCommand cmd = new SqlCommand(sqlString, conn))
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                PrintLine();
                while (reader.Read())
                {
                    string artistName = reader["Artist_Name"].ToString();
                    DateTime earliestDate = Convert.ToDateTime(reader["EarliestDate"]);
                    Console.WriteLine($"Artist Name: {artistName}, Earliest Date: {earliestDate:yyyy-MM-dd}");
                    PrintLine();
                }
            }
        }
    }

    public void CmxQry4()
    {
        string sqlString = "SELECT a.Artist_Name, v.Vinyl_Name, MAX(r.Out_Of_5) AS HighestVinyl FROM TblArtist a, TblVinyl v, TblReviews r WHERE a.Artist_ID = v.Artist_ID AND v.Vinyl_ID = r.Vinyl_ID GROUP BY a.Artist_Name, v.Vinyl_Name ORDER BY HighestVinyl DESC;";

        using (SqlCommand cmd = new SqlCommand(sqlString, conn))
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                PrintLine();
                while (reader.Read())
                {
                    string artistName = reader["Artist_Name"].ToString();
                    decimal highestRating = Convert.ToDecimal(reader["HighestVinyl"]);
                    Console.WriteLine($"Artist Name: {artistName}, Highest Rating: {highestRating:F2}");
                    PrintLine();
                }
            }
        }
    }

    public void CmxQry5()
    {
        string sqlString = "SELECT r.RecordLabel_ID, r.RecordLabel_Name, COUNT(a.Artist_Name) AS TotalArtists FROM TblRecordLabel r, TblArtist a WHERE r.RecordLabel_ID = a.RecordLabel_ID GROUP BY r.RecordLabel_ID, r.RecordLabel_Name;";

        using (SqlCommand cmd = new SqlCommand(sqlString, conn))
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                PrintLine();
                while (reader.Read())
                {
                    string recordLabelName = reader["RecordLabel_Name"].ToString();
                    int totalArtists = Convert.ToInt32(reader["TotalArtists"]);
                    Console.WriteLine($"Record Label: {recordLabelName}, Total Artists: {totalArtists:F0}");
                    PrintLine();
                }
            }
        }
    }

    // runs sql Update Record Label Name query
    public int UpdateRecordLabelsName(int recordLabelID, string recordLabelName)
    {
        using (SqlCommand cmd = new SqlCommand($"UPDATE tblRecordLabel SET RecordLabel_Name = @RecordLabel_Name WHERE RecordLabel_ID = @RecordLabel_ID", conn))
        {
            cmd.Parameters.AddWithValue("@RecordLabel_Name", recordLabelName);
            cmd.Parameters.AddWithValue("@RecordLabel_ID", recordLabelID);
            return cmd.ExecuteNonQuery();
        }
    }

    // runs sql Update Artist Name query
    public int UpdateArtistsName(int ArtistID, string ArtistName)
    {
        using (SqlCommand cmd = new SqlCommand($"UPDATE tblArtist SET Artist_Name = @Artist_Name WHERE Artist_ID = @Artist_ID", conn))
        {
            cmd.Parameters.AddWithValue("@Artist_Name", ArtistName);
            cmd.Parameters.AddWithValue("@Artist_ID", ArtistID);
            return cmd.ExecuteNonQuery();
        }
    }

    // runs sql Update Vinyl Name query
    public int UpdateVinylsName(int VinylID, string VinylName)
    {
        using (SqlCommand cmd = new SqlCommand($"UPDATE tblVinyl SET Vinyl_Name = @Vinyl_Name WHERE Vinyl_ID = @Vinyl_ID", conn))
        {
            cmd.Parameters.AddWithValue("@Vinyl_Name", VinylName);
            cmd.Parameters.AddWithValue("@Vinyl_ID", VinylID);
            return cmd.ExecuteNonQuery();
        }
    }

    // runs sql Update Genre Name query
    public int UpdateGenresName(int genreID, string genreName)
    {
        using (SqlCommand cmd = new SqlCommand($"UPDATE tblGenre SET Genre_Name = @Genre_Name WHERE Genre_ID = @Genre_ID", conn))
        {
            cmd.Parameters.AddWithValue("@Genre_Name", genreName);
            cmd.Parameters.AddWithValue("@Genre_ID", genreID);
            return cmd.ExecuteNonQuery();
        }
    }

    // runs sql Update Reviewers Name query
    public int UpdateReviewersName(int ReviewID, string ReviewerName)
    {
        using (SqlCommand cmd = new SqlCommand($"UPDATE tblReviews SET Reviewer_Name = @Reviewer_Name WHERE Review_ID = @Review_ID", conn))
        {
            cmd.Parameters.AddWithValue("@Reviewer_Name", ReviewerName);
            cmd.Parameters.AddWithValue("@Review_ID", ReviewID);
            return cmd.ExecuteNonQuery();
        }
    }

    // runs sql Update Review Comments query
    public int UpdateReviewComments(int ReviewCommentID, string ShortReview)
    {
        using (SqlCommand cmd = new SqlCommand($"UPDATE tblReviewComments SET Short_Review = @Short_Review WHERE ReviewComment_ID = @ReviewComment_ID", conn))
        {
            cmd.Parameters.AddWithValue("@Short_Review", ShortReview);
            cmd.Parameters.AddWithValue("@ReviewComment_ID", ReviewCommentID);
            return cmd.ExecuteNonQuery();
        }
    }

    // Inserts a new record label into the database
    public int InsertLocationRecordLabels(RecordLabel recordLabel)
    {
        using (SqlCommand cmd = new SqlCommand($"INSERT INTO tblRecordLabel (RecordLabel_Name) VALUES (@RecordLabel_Name); SELECT SCOPE_IDENTITY();", conn))
        {
            cmd.Parameters.AddWithValue("@RecordLabel_Name", recordLabel.RecordLabel_Name);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }
    }

    // Inserts a new artist into the database
    public int InsertLocationArtists(Artist artist)
    {
        using (SqlCommand cmd = new SqlCommand($"INSERT INTO tblArtist (Artist_Name, RecordLabel_ID) VALUES (@Artist_Name, @RecordLabel_ID); SELECT SCOPE_IDENTITY();", conn))
        {
            cmd.Parameters.AddWithValue("@Artist_Name", artist.Artist_Name);
            cmd.Parameters.AddWithValue("@RecordLabel_ID", artist.RecordLabel_ID);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }
    }

    // Inserts a new vinyl into the database
    public int InsertLocationVinyls(Vinyl vinyl)
    {
        using (SqlCommand cmd = new SqlCommand($"INSERT INTO tblVinyl (Vinyl_Name, Artist_ID, Date_Of_Release) VALUES (@Vinyl_Name, @Artist_ID, @Date_Of_Release); SELECT SCOPE_IDENTITY();", conn))
        {
            cmd.Parameters.AddWithValue("@Vinyl_Name", vinyl.Vinyl_Name);
            cmd.Parameters.AddWithValue("@Artist_ID", vinyl.Artist_ID);
            cmd.Parameters.AddWithValue("@Date_Of_Release", vinyl.Date_Of_Release);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }
    }

    // Inserts a new genre into the database
    public int InsertLocationGenres(Genres genre)
    {
        using (SqlCommand cmd = new SqlCommand($"INSERT INTO tblGenre (genre_Name, Description) VALUES (@Genre_Name, @Description); SELECT SCOPE_IDENTITY();", conn))
        {
            cmd.Parameters.AddWithValue("@Genre_Name", genre.Genre_Name);
            cmd.Parameters.AddWithValue("@Description", genre.Description);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }
    }

    // Inserts a new review into the database
    public int InsertLocationReviews(Reviews review)
    {
        using (SqlCommand cmd = new SqlCommand($"INSERT INTO tblReviews (Vinyl_ID, Reviewer_Name, Out_Of_5) VALUES (@Vinyl_ID, @Reviewer_Name, @Out_Of_5); SELECT SCOPE_IDENTITY();", conn))
        {
            cmd.Parameters.AddWithValue("@Vinyl_ID", review.Vinyl_ID);
            cmd.Parameters.AddWithValue("@Reviewer_Name", review.Reviewer_Name);
            cmd.Parameters.AddWithValue("@Out_Of_5", review.Out_Of_5);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }
    }

    // Inserts a new review comment into the database
    public int InsertLocationReviewComments(ReviewComments reviewComments)
    {
        using (SqlCommand cmd = new SqlCommand("INSERT INTO tblReviewComments (Review_ID, Short_Review, Review_Date) VALUES (@Review_ID, @Short_Review, @Review_Date); SELECT SCOPE_IDENTITY();", conn))               
        {
            cmd.Parameters.AddWithValue("@Review_ID", reviewComments.Review_ID);
            cmd.Parameters.AddWithValue("@Short_Review", reviewComments.Short_Review);
            cmd.Parameters.AddWithValue("@Review_Date", reviewComments.Review_Date);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }
    }

    // Deletes records by name
    public int DeleteRecordLabelByName(string recordLabelName)
    {
        using (SqlCommand cmd = new SqlCommand($"DELETE FROM tblRecordLabel WHERE  RecordLabel_Name = @recordLabelName", conn))
        {
            cmd.Parameters.AddWithValue($"@recordLabelName", recordLabelName);
            return cmd.ExecuteNonQuery();
        }
    }

    // Deletes artists by name
    public int DeleteArtistByName(string artistName)
    {
        using (SqlCommand cmd = new SqlCommand($"DELETE FROM tblArtist WHERE Artist_Name = @artistName", conn))
        {
            cmd.Parameters.AddWithValue($"@artistName", artistName);
            return cmd.ExecuteNonQuery();
        }
    }

    // Deletes vinyl by name
    public int DeleteVinylByName(string vinylName)
    {
        using (SqlCommand cmd = new SqlCommand($"DELETE FROM tblVinyl WHERE Vinyl_Name = @vinylName", conn))
        {
            cmd.Parameters.AddWithValue($"@vinylName", vinylName);
            return cmd.ExecuteNonQuery();
        }
    }

    // Deletes genres by name
    public int DeleteGenreByName(string genreName)
    {
        using (SqlCommand cmd = new SqlCommand($"DELETE FROM tblGenre WHERE Genre_Name = @genreName", conn))
        {
            cmd.Parameters.AddWithValue($"@genreName", genreName);
            return cmd.ExecuteNonQuery();
        }
    }

    // Deletes reviews by id
    public int DeleteReviewByName(int reviewID)
    {
        using (SqlCommand cmd = new SqlCommand($"DELETE FROM tblReviews WHERE Review_ID = @Review_ID", conn))
        {
            cmd.Parameters.AddWithValue($"@Review_ID", reviewID);
            return cmd.ExecuteNonQuery();
        }
    }

    // Deletes review comments by id
    public int DeleteReviewCommentByID(int ReviewCommentID)
    {
        using (SqlCommand cmd = new SqlCommand($"DELETE FROM tblReviewComments WHERE ReviewComment_ID = @ReviewComment_ID", conn))
        {
            cmd.Parameters.AddWithValue($"@ReviewComment_ID", ReviewCommentID);
            return cmd.ExecuteNonQuery();
        }
    }

    // closes sql database server connection
    public void CloseConnection()
    {
        if (conn != null && conn.State == ConnectionState.Open)
        {
            conn.Close();
            Console.WriteLine("connection closed.");
        }
    }
}