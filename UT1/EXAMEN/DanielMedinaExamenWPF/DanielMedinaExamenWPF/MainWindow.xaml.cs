using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace DanielMedinaExamenWPF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private int idProductos;
        public MainWindow()
        {
            InitializeComponent();

            List<Producto> products = new List<Producto>();
            Producto producto1 = new Producto() { id = 1, name = "Televisor", precio = 500, cantidad = 10 };
            Producto producto2 = new Producto() { id = 2, name = "Silla", precio = 49, cantidad = 20 };
            idProductos = 2;
            dataGridProductos.Items.Add(producto1);
            dataGridProductos.Items.Add(producto2);

        }

        

        public class Producto
        {
            public int id { get; set; }

            public string name { get; set; }

            public int precio { get; set; }

            public Double cantidad { get; set; }
        }

        private void Button_Click_Guardar(object sender, RoutedEventArgs e)
        {

            if (int.TryParse(txtPrecio?.Text, out int precio))
            {

                Producto producto = new Producto() { id = idProductos, name = txtProducto.Text, precio = precio, cantidad = sliderControl.Value };
                idProductos++;
                dataGridProductos.Items.Add(producto);
                txtProducto.Text = "";
                txtPrecio.Text = "";
                sliderControl.Value = 0;
            }
            else
            {
                MessageBox.Show("Por favor, introduce un precio válido.");
            }

        }

        private void Button_Click_Limpiar(object sender, RoutedEventArgs e)
        {
            txtProducto.Text = "";
            txtPrecio.Text = "";
            sliderControl.Value = 0;
        }
    }
}
