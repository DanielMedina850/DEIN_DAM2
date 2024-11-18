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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace MiparteDelProyecto
{

    public class Usuario
    { 
        public string nombre { get; set; } 
        public string pass { get; set; } 
    }
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {
        SqlConnection conn;
        public Login()
        {
            InitializeComponent();
            establecerConnection();
            mostrarUsuarios();
        }

        private void establecerConnection()
        {
            string miConexion = ConfigurationManager.ConnectionStrings["MiparteDelProyecto.Properties.Settings.MUGARRIConnectionString"].ConnectionString;
            conn = new SqlConnection(miConexion);
        }

        private void mostrarUsuarios()
        {
            string consulta = "select * from login";

            DataTable usuarios = new DataTable();

            List<Usuario> listUsuarios = new List<Usuario>();
            SqlDataAdapter adapter = new SqlDataAdapter(consulta, conn);

            using (adapter)
            { 
            adapter.Fill(usuarios);
            }

            listUsuarios = usuarios.AsEnumerable().Select(row => new Usuario
            {
                nombre = row.Field<string>("Usuario"),
                pass = row.Field<string>("Contraseña")
             }).ToList();


            dataGrid.ItemsSource = listUsuarios;
        }

        private void Guardar_usuario(object sender, RoutedEventArgs e)
        {

        }

        private void Salir_pagina(object sender, RoutedEventArgs e)
        {

        }

        private void Crear_Usuario(object sender, RoutedEventArgs e)
        {

        }
    }
}
