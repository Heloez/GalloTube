using System.Data;
using GalloTube.Interfaces;
using GalloTube.Models;
using MySql.Data.MySqlClient;

namespace GalloTube.Repositories;

public class MovieRepository : IMovieRepository
{
    readonly string connectionString = "server=localhost;port=3306;database=GalloFlixdb;uid=root;pwd=''";

    public void Create(Vídeo model)
    {
        MySqlConnection connection = new(connectionString);
        string sql = "insert into Movie(Title, OriginalTitle, Synopsis, MovieYear, Duration, AgeRating, Image) "
              + "values (@Title, @OriginalTitle, @Synopsis, @MovieYear, @Duration, @AgeRating, @Image)";
        MySqlCommand command = new(sql, connection)
        {
            CommandType = CommandType.Text
        };
        command.Parameters.AddWithValue("@Title", model.Title);
        command.Parameters.AddWithValue("@OriginalTitle", model.OriginalTitle);
        command.Parameters.AddWithValue("@Synopsis", model.Synopsis);
        command.Parameters.AddWithValue("@MovieYear", model.MovieYear);
        command.Parameters.AddWithValue("@Duration", model.Duration);
        command.Parameters.AddWithValue("@AgeRating", model.AgeRating);
        command.Parameters.AddWithValue("@Image", model.Image);
        
        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
    }

    public void Delete(int? id)
    {
        MySqlConnection connection = new(connectionString);
        string sql = "delete from Movie where Id = @Id";
        MySqlCommand command = new(sql, connection)
        {
            CommandType = CommandType.Text
        };
        command.Parameters.AddWithValue("@Id", id);
        
        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
    }

    public List<Video> ReadAll()
    {
        MySqlConnection connection = new(connectionString);
        string sql = "select * from Movie";
        MySqlCommand command = new(sql, connection)
        {
            CommandType = CommandType.Text
        };
        
        List<video> movies = new();
        connection.Open();
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
             Video video = new()
            {
                Id = reader.GetInt32("id"),
                Title = reader.GetString("title"),
                OriginalTitle = reader.GetString("originalTitle"),
                Synopsis = reader.GetString("synopsis"),
                MovieYear = reader.GetInt16("movieYear"),
                Duration = reader.GetInt16("duration"),
                AgeRating = reader.GetByte("ageRating"),
                Image = reader.GetString("image")
            };
            video.Add(video);
        }
        connection.Close();
        return video;
    }

    public video ReadById(int? id)
    {
        MySqlConnection connection = new(connectionString);
        string sql = "select * from Movie where Id = @Id";
        MySqlCommand command = new(sql, connection)
        {
            CommandType = CommandType.Text
        };
        command.Parameters.AddWithValue("@Id", id);
        
        connection.Open();
        MySqlDataReader reader = command.ExecuteReader();
        reader.Read();
        if (reader.HasRows)
        {
            Video video = new()
            {
                Id = reader.GetInt32("id"),
                Title = reader.GetString("title"),
                OriginalTitle = reader.GetString("originalTitle"),
                Synopsis = reader.GetString("synopsis"),
                MovieYear = reader.GetInt16("movieYear"),
                Duration = reader.GetInt16("duration"),
                AgeRating = reader.GetByte("ageRating"),
                Image = reader.GetString("image")
            };
            connection.Close();
            return video;
        }
        connection.Close();
        return null;
    }

    public void Update(Vídeo model)
    {
        MySqlConnection connection = new(connectionString);
        string sql = "update Movie set "
                        + "Title = @Title, "
                        + "OriginalTitle = @OriginalTitle, "
                        + "Synopsis = @Synopsis, "
                        + "MovieYear = @MovieYear, "
                        + "Duration = @Duration, "
                        + "AgeRating = @AgeRating, "
                        + "Image = @Image "
                    + "where Id = @Id";
        MySqlCommand command = new(sql, connection)
        {
            CommandType = CommandType.Text
        };
        command.Parameters.AddWithValue("@Id", model.Id);
        command.Parameters.AddWithValue("@Title", model.Title);
        command.Parameters.AddWithValue("@OriginalTitle", model.OriginalTitle);
        command.Parameters.AddWithValue("@Synopsis", model.Synopsis);
        command.Parameters.AddWithValue("@MovieYear", model.MovieYear);
        command.Parameters.AddWithValue("@Duration", model.Duration);
        command.Parameters.AddWithValue("@AgeRating", model.AgeRating);
        command.Parameters.AddWithValue("@Image", model.Image);
        
        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
    }
}