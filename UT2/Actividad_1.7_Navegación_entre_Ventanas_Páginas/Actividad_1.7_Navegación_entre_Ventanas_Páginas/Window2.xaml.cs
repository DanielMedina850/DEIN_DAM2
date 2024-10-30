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

namespace Actividad_1._7_Navegación_entre_Ventanas_Páginas
{
    /// <summary>
    /// Lógica de interacción para Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        public void MainWindow(object sender, EventArgs e) { 
        MainWindow abrirWindow = new MainWindow();
            this.Close();
            abrirWindow.Show();
        }


        public void Boton_AbrirPágina(object sender, EventArgs e)
        {
            MyFrame.NavigationService.Navigate(new Page1());
        }

    }
}
