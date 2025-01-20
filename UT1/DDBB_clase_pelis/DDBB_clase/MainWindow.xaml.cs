using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Data;
using System.Data.SqlClient;

namespace DDBB_clase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        // Cambia el nombre de tu servidor e instancia, y el nombre de la base de datos aquí
        private string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=testDDBB;Integrated Security=True;TrustServerCertificate=True";

        //private string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=Clientes;Integrated Security=True;TrustServerCertificate=True";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CargarClientes_Click(object sender, RoutedEventArgs e)
        {
            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT TOP 10 * FROM pixar_movies", connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridClientes.ItemsSource = dataTable.DefaultView;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error de conexión: " + ex.Message);
                }
            }
        }

        private void CargarPeliculas_Click(object sender, RoutedEventArgs e)
        {
            Window1 win1 = new Window1();
            win1.Show();
        }

    }
}