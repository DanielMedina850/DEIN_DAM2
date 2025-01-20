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

namespace Actividad_1._7_Navegación_entre_Ventanas_Páginas
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

        private void Boton1_MainWindow_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Boton_Window1(object sender, RoutedEventArgs e)
        {
            Window1 abrirVentana = new Window1();
            this.Close();
            abrirVentana.Show();
        }
        private void Boton_Window2(object sender, RoutedEventArgs e)
        {
            Window2 abrirVentana = new Window2();
            this.Close();
            abrirVentana.Show();
        }
        private void Boton_Salir(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}