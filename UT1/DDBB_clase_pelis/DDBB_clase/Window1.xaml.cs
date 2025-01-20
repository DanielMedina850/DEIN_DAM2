using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
//using Microsoft.Data.SqlClient;
using System.Windows;


namespace DDBB_clase
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=testDDBB;Integrated Security=True;TrustServerCertificate=True";

        public ObservableCollection<Movie> Movies { get; set; }

        public Window1()
        {
            InitializeComponent();
            Movies = new ObservableCollection<Movie>();
            DataContext = this;
            LoadMovies();
        }

        private void LoadMovies()
        {
            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT TOP 10 movie, date_released, director, length_min, movie_genre, imdb_rating FROM pixar_movies", connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Movies.Add(new Movie
                        {
                            Title = reader["movie"].ToString(),
                            DateReleased = reader["date_released"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["date_released"]),
                            Director = reader["director"].ToString(),
                            LengthMin = reader["length_min"] == DBNull.Value ? 0 : Convert.ToInt32(reader["length_min"]),
                            MovieGenre = reader["movie_genre"].ToString(),
                            ImdbRating = reader["imdb_rating"].ToString()
                        });
                    }

                    reader.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error de conexión: " + ex.Message);
                }
            }
        }
    }

    public class Movie
    {
        public string Title { get; set; }
        public DateTime DateReleased { get; set; }
        public string Director { get; set; }
        public int LengthMin { get; set; }
        public string MovieGenre { get; set; }
        public string ImdbRating { get; set; }
    }
}
