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

namespace MUGARRI_DANIEL_AIMAR_SERGIO
{
    public class Usuario
    {
        public string nombre { get; set; }
        public string pass { get; set; }
    }
    public partial class Login : Window
    {
        SqlConnection conn;
        public Login()
        {
            InitializeComponent();
            establecerConnection();
        }

        private void establecerConnection()
        {
            string miConexion = ConfigurationManager.ConnectionStrings["MUGARRI_DANIEL_AIMAR_SERGIO.Properties.Settings.MUGARRIConnectionString"].ConnectionString;
            conn = new SqlConnection(miConexion);
        }



        private void VerificarUsuario(string usuario, string password)
        {
            try
            {

                establecerConnection();


                string consulta = "SELECT COUNT(*) FROM login WHERE Usuario = @usuario AND Contraseña = @password";

                conn.Open();

     
                using (SqlCommand command = new SqlCommand(consulta, conn))
                {

                    command.Parameters.AddWithValue("@usuario", usuario);
                    command.Parameters.AddWithValue("@password", password);

                    int count = Convert.ToInt32(command.ExecuteScalar());

                    if (count > 0)
                    {
                        Producto producto = new Producto(1);
                        producto.Show();
                    }
                    else
                    {
                        texto.Text = "Usuario no encontrado, Crea un usuario para acceder";
                        texto.Foreground = Brushes.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                texto.Text = "Error: " + ex.Message;
            }
        }



        private void Guardar_usuario(object sender, RoutedEventArgs e)
        {
            VerificarUsuario(username.Text, password.Password);

        }

        private void Salir_pagina(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Crear_Usuario(object sender, RoutedEventArgs e)
        {
            AgregarUsuario(username.Text, password.Password);
        }


        private void AgregarUsuario(string username, string password)
        {
            establecerConnection();

            string consulta = "INSERT INTO LOGIN (Usuario, Contraseña) VALUES (@username, @password)";

            using (SqlCommand cmd = new SqlCommand(consulta, conn))
            {
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    texto.Text = "¡Usuario agregado exitosamente!";
                    texto.Foreground = Brushes.Green;
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        texto.Text = "El usuario ya existe, cambia el nombre";
                    }
                    else
                    {
                        texto.Text = "Error SQL: " + ex.Message;
                    }
                }
            }
        }
    }
}
