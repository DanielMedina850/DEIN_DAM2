using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GestionEmpleados2024
{
    /// <summary>
    /// Lógica de interacción para ActualizarEmpleados.xaml
    /// </summary>
    public partial class ActualizarEmpleados : Window
    {
        public ActualizarEmpleados()
        {
            InitializeComponent();
        }


        private void AgregarEmpleado_Click(object sender, RoutedEventArgs e)
        {
            int id;
            string nombre = Nombre.Text;
            string apellidos = Apellidos.Text;
            bool esUsuario = EsUsuario.IsChecked ?? false;
            int edad;

            if (int.TryParse(Edad.Text, out edad))
            {
                if (int.TryParse(Id.Text, out id)) 
                {
                    actualizarEmpleado(id, nombre, apellidos, esUsuario, edad);
                    Close();
                }
                else 
                {
                    MessageBox.Show("Por favor introduce un id valida", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor introduce una edad valida", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }


        private void actualizarEmpleado(int id, string nombre, string apellidos, bool esUsuario, int edad)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["GestionEmpleados2024.Properties.Settings.GestionEmpleadosConnectionString"].ConnectionString))
            {
                string consulta = "UPDATE EMPLEADOS SET Nombre = @Nombre, Apellidos = @Apellidos, EsUsuario = @EsUsuario, Edad = @Edad WHERE Id = @Id";

                using (SqlCommand cmd = new SqlCommand(consulta, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@Apellidos", apellidos);
                    cmd.Parameters.AddWithValue("@EsUsuario", esUsuario);
                    cmd.Parameters.AddWithValue("@Edad", edad);

                    try
                    {
                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al agregar empleado: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }

            }
        }
    }
}
