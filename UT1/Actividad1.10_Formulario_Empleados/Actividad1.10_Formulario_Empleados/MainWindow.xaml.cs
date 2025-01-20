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

namespace Actividad1._10_Formulario_Empleados
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Empleado> empleados;
        public MainWindow()
        {
            InitializeComponent();

            empleados = new List<Empleado>();
            Datagrid.ItemsSource = empleados;
        }

        private void Guardar_Click(object sender, RoutedEventArgs e)
        {

            var nuevoEmpleado = new Empleado
            {
                Nombre = txtNombre.Text,
                Apellidos = txtApellidos.Text,
                Email = txtEmail.Text,
                Telefono = txtTelefono.Text
            };

            empleados.Add(nuevoEmpleado);


            Datagrid.Items.Refresh();

            txtNombre.Clear();
            txtApellidos.Clear();
            txtEmail.Clear();
            txtTelefono.Clear();
        }
    }

    public class Empleado
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
    }
}