using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GestionEmpleados2024
{


    public partial class MainWindow : Window
    {

        private SqlConnection _connection;
        public MainWindow()
        {
            InitializeComponent();
            EstablecerConexion();
        }

        private void EstablecerConexion()
        {
            string cadenaDeConexion = ConfigurationManager.ConnectionStrings["GestionEmpleados2024.Properties.Settings.GestionEmpleadosConnectionString"].ConnectionString;
            _connection = new SqlConnection(cadenaDeConexion);
        }


        public List<Empleado> obtenerEmpleados()
        {
            EstablecerConexion();

            string consulta = "SELECT * FROM EMPLEADOS";

            DataTable empleados = new DataTable();
            List<Empleado> listaEmpleados = new List<Empleado>();

            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, _connection);

            adaptador.Fill(empleados);

            using (adaptador)
            {
                listaEmpleados = empleados.AsEnumerable().Select(row => new Empleado
                {
                    id = row.Field<int>("id"),
                    nombre = row.Field<string>("Nombre"),
                    apellidos = row.Field<string>("Apellidos"),
                    esUsuario = (row["EsUsuario"] != DBNull.Value) ? row.Field<bool>("EsUsuario") : false,
                    edad = row.Field<int>("Edad")
                }).ToList();
                return listaEmpleados;
            }
        }

        private void Button_insertar(object sender, RoutedEventArgs e)
        {
            AgregarEmpleado agregar = new AgregarEmpleado();
            agregar.Show();
        }

        private void Button_eliminar(object sender, RoutedEventArgs e)
        {
            EliminarEmpleados eliminar = new EliminarEmpleados();
            eliminar.Show();
        }

        private void Button_actualizar(object sender, RoutedEventArgs e)
        {
            ActualizarEmpleados actualizar = new ActualizarEmpleados();
            actualizar.Show();
        }

        private void Button_listar(object sender, RoutedEventArgs e)
        {
            ListarEmpleados listar = new ListarEmpleados();
            listar.Show();
        }

    }
}
