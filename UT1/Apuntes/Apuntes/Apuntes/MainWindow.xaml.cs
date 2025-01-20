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

namespace Apuntes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<Estudiante> estudiantes = new List<Estudiante>();
            estudiantes.Add(new Estudiante() { id = 1, name = "Daniel", apellido1 = "Medina", apellido2 = "Colmenares", hobbie = "correr" });
            estudiantes.Add(new Estudiante() { id = 2, name = "Aimar", apellido1 = "Huici", apellido2 = "Colmenares", hobbie = "correr" });
            estudiantes.Add(new Estudiante() { id = 3, name = "Sergio", apellido1 = "Sajona", apellido2 = "Colmenares", hobbie = "correr" });

            alumnos.ItemsSource = estudiantes;
        }




        public class Estudiante
        {
            public int id { get; set; }

            public string name { get; set; }

            public string apellido1 { get; set; }

            public string apellido2 { get; set; }
            public string hobbie { get; set; }
        }

        public class Carro
        {
            public string marca { get; set; }

            public string modelo { get; set; }

            public string color { get; set; }

        }

        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            Carro carro = new Carro() { marca = txtMarca.Text, modelo = txtModelo.Text, color = txtColor.Text };

            dataGridCoches.Items.Add(carro);

            txtMarca.Text = "";
            txtModelo.Text = "";
            txtColor.Text = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(GridIndex?.Text, out int columnIndex))
            {

                if (columnIndex >= 0 && columnIndex < 2) // El Grid tiene 2 columnas en este caso
                {
                   Grid.SetColumn(MovableCanvas, columnIndex);
                }
                else
                {
                    MessageBox.Show("Introduce un número entre 0 y 1."); // Mensaje de validación
                }
            }
            else
            {
                // Si el texto no es un número válido, maneja el error
                MessageBox.Show("Por favor, introduce un número válido.");
            }
            
        }

    }
}