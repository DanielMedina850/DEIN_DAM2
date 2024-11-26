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

namespace Databinding_clase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            // Obtener los datos ingresados en el formulario
            string marca = txtMarca.Text;
            string modelo = txtModelo.Text;
            string color = txtColor.Text;

            // Crear un nuevo objeto Coche con los datos
            Coche nuevoCoche = new Coche(marca, modelo, color);
            // Agregar el nuevo coche al DataGrid
            dataGridCoches.Items.Add(nuevoCoche);

            txtMarca.Text = "";
            txtModelo.Text = "";
            txtColor.Text = "";
        }



        public class Coche
        {
            public string Marca { get; set; }
            public string Modelo { get; set; }
            public string Color { get; set; }
            // Otros campos

            // Constructor para crear un objeto Empleado
            public Coche(string marca, string modelo, string color)
            {
                Marca = marca;
                Modelo = modelo;
                Color = color;
            }
        }

    }
}