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

namespace A1._8_Diseño_Controles
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
            estudiantes.Add(new Estudiante() { id = 1, name = "Daniel", apellido1 = "Medina", apellido2 = "Colmenares", hobbie = "correr"});
            estudiantes.Add(new Estudiante() { id = 2, name = "Aimar", apellido1 = "Huici", apellido2 = "Colmenares", hobbie = "correr"});
            estudiantes.Add(new Estudiante() { id = 3, name = "Sergio", apellido1 = "Sajona", apellido2 = "Colmenares", hobbie = "correr"});

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

        private void Peliculas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}