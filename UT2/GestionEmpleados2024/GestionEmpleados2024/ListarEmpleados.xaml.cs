using System;
using System.Collections.Generic;
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


    public class Empleado
    {
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public bool esUsuario { get; set; }
        public int edad { get; set; }
    }

    public partial class ListarEmpleados : Window
    {

        private MainWindow main;
        public ListarEmpleados()
        {
            InitializeComponent();
            main = new MainWindow();
            cargarEmpleadosEnDataGrid();   
        }

        private void cargarEmpleadosEnDataGrid()
        { 
            List<Empleado> empleados = new List<Empleado>();
            empleados = main.obtenerEmpleados();
            text.Text = empleados.Count.ToString();
            dataGrid.ItemsSource = empleados;
        }
    }
}
