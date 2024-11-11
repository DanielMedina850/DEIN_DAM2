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
    /// Lógica de interacción para EliminarEmpleados.xaml
    /// </summary>
    public partial class EliminarEmpleados : Window
    {
        public EliminarEmpleados()
        {
            InitializeComponent();
        }


        private void EliminarEmpleado_Click(object sender, RoutedEventArgs e)
        {
            int id;

            if (int.TryParse(Id.Text, out id))
            {
                EliminarEmpleado(id);
                Close();
            }
            else
            {
                MessageBox.Show("Por favor introduce un id valida", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void EliminarEmpleado(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["GestionEmpleados2024.Properties.Settings.GestionEmpleadosConnectionString"].ConnectionString))
            {
                string consulta = "DELETE FROM EMPLEADOS WHERE Id = @Id";

                using (SqlCommand cmd = new SqlCommand(consulta, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    try
                    {
                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al eliminar el empleado: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }
    }
}
