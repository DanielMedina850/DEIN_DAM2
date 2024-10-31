using System.Data.Common;
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

namespace A1._9_Menu_despeglables_navegacion_DANIEL_MEDINA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Copy, M_Copiar_Click));
        }


        private void M_Nuevo_Click(object sender, RoutedEventArgs e)
        {
            MainWindow nuevaVentana = new MainWindow();
            nuevaVentana.Show();
        }


        private void M_Abrir_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
            ofd.ShowDialog();
        }


        private void M_Guardar_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(" Guardar "); ;
        }

        private void M_Guardar_como_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog sfd = new Microsoft.Win32.SaveFileDialog();
            sfd.ShowDialog();
        }
        private void M_Imprimir_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.PrintDialog dlg = new System.Windows.Controls.PrintDialog();
            dlg.ShowDialog();
        }

        private void M_Salir_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void M_Usuarios_Click(object sender, RoutedEventArgs e)
        {
            Usuarios open = new Usuarios();
            open.Show();
        }

        private void M_Copiar_Click(object sender, RoutedEventArgs e) {
            MessageBox.Show(" Copiado ");        
        }
        private void M_Cortar_Click(object sender, RoutedEventArgs e) {
            MessageBox.Show(" Cortado ");        
        }
        private void M_Pegar_Click(object sender, RoutedEventArgs e) {
            MessageBox.Show(" Pegado ");        
        }
        private void M_Eliminar_Click(object sender, RoutedEventArgs e) {
            MessageBox.Show(" Eliminado ");        
        }

    }
}