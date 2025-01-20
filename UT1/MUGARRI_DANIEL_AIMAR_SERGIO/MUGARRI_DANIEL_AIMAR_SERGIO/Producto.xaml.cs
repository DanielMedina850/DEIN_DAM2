using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using System.Configuration;
using System.Net.NetworkInformation;
using PruebaProyecto;

namespace MUGARRI_DANIEL_AIMAR_SERGIO
{

    public partial class Producto : Window
    {
        SqlConnection miConexionSql;
        ModeloProducto modeloProducto;
        public Producto(int id)
        {
            InitializeComponent();
            string miConexion = ConfigurationManager.ConnectionStrings["MUGARRI_DANIEL_AIMAR_SERGIO.Properties.Settings.MUGARRIConnectionString"].ConnectionString;
            miConexionSql = new SqlConnection(miConexion);

            MostrarProducto(id);

            RellenarPagina();
        }

        private void MostrarProducto(int id)
        {
            string consulta = "SELECT * FROM PRODUCTO WHERE Id = " + id;

            DataTable tablaProducto = new DataTable();

            SqlDataAdapter miAdaptadorSql = new SqlDataAdapter(consulta, miConexionSql);

            using (miAdaptadorSql)
            {
                miAdaptadorSql.Fill(tablaProducto);
            }

            if (tablaProducto.Rows.Count > 0)
            {
                DataRow fila = tablaProducto.Rows[0];

                string nombre = fila["Nombre"].ToString();
                string marca = fila["Marca"].ToString();
                decimal precio = Convert.ToDecimal(fila["Precio"]);
                string descripcionProducto = fila["Descripcion"].ToString();

                string rutaImagen = $"img/imagen{id}.jpg"; // Ajusta la extensión según sea necesario
                ImageSource imagenSource;

                if (System.IO.File.Exists(rutaImagen))
                {
                    imagenSource = new BitmapImage(new Uri(rutaImagen, UriKind.Relative));
                }
                else
                {
                    MessageBox.Show($"Imagen no encontrada en la ruta: {rutaImagen}");
                    imagenSource = null; // O usa una imagen predeterminada
                }

                modeloProducto = new ModeloProducto(nombre, marca, precio, imagenSource, descripcionProducto);
            }
            else { MessageBox.Show("Error: Producto no encontrado"); }
        }

        private void RellenarPagina()
        {
            txtNombre.Text = modeloProducto.getNombre();
            txtMarca.Text = "MARCA: " + modeloProducto.getMarca();
            txtPrecio.Text = modeloProducto.getPrecio().ToString() + "€";
            txtDescripcion.Text = modeloProducto.getDescripcion();

            imgProducto.Source = modeloProducto.getImagen();
        }
    }
}
