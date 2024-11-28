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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Controles
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<string> lista = new List<string>();
            lista.Add("Wifi");

            cmbColors.ItemsSource = lista;



            List<Persona> items = new List<Persona>();
            items.Add(new Persona() { Nombre = "John Doe", Edad = 42, Mail = "john@doe-family.com" });
            items.Add(new Persona() { Nombre = "Jane Doe", Edad = 39, Mail = "jane@doe-family.com" });
            items.Add(new Persona() { Nombre = "Sammy Doe", Edad = 7, Mail = "sammy.doe@gmail.com" });
            listaViweUsuarios.ItemsSource = items;
        }


        public class Persona
        {
            public string Nombre { get; set; }

            public int Edad { get; set; }

            public string Mail { get; set; }
        }
    }
}
