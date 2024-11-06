using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace A1._11_Aplicación_Orla_de_clase
{
    /// <summary>
    /// Lógica de interacción para Puesto.xaml
    /// </summary>
    public partial class Puesto : UserControl
    {

        public Puesto()
        {
            InitializeComponent();
        }
        public static DependencyProperty NombreProperty = DependencyProperty.Register("Nombre", typeof(string), typeof(Puesto), new PropertyMetadata(string.Empty));
        public static DependencyProperty ApellidosProperty = DependencyProperty.Register("Apellidos", typeof(string), typeof(Puesto), new PropertyMetadata(string.Empty));
        public static DependencyProperty EmailProperty = DependencyProperty.Register("Email", typeof(string), typeof(Puesto), new PropertyMetadata(string.Empty));
        public static readonly DependencyProperty FotoProperty = DependencyProperty.Register(
            "Foto", typeof(string), typeof(Puesto), new PropertyMetadata(string.Empty, OnFotoChanged));

        public string Nombre
        {
            get { return (string)GetValue(NombreProperty); }
            set { SetValue(NombreProperty, value); }
        }
        public string Apellidos
        {
            get { return (string)GetValue(ApellidosProperty); }
            set { SetValue(ApellidosProperty, value); }
        }
        public string Email
        {
            get { return (string)GetValue(EmailProperty); }
            set { SetValue(EmailProperty, value); }
        }
        public string Foto
        {
            get { return (string)GetValue(FotoProperty); }
            set { SetValue(FotoProperty, value); }
        }

        private static void OnFotoChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (Puesto)d;
            var imagePath = e.NewValue as string;

            if (!string.IsNullOrEmpty(imagePath))
            {
                try
                {
                    // Crear una imagen de fondo para el botón usando la ruta de la propiedad Foto
                    var imageBrush = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri(imagePath, UriKind.Absolute)),
                        Stretch = Stretch.Uniform
                    };
                    control.Persona.Background = imageBrush;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar la imagen: {ex.Message}");
                }
            }
        }

        private void Persona_MouseEnter(object sender, MouseEventArgs e)
        {
            LabelPuesto.Text = Nombre + " " + Apellidos;
        }

        private void Persona_MouseLeave(object sender, MouseEventArgs e)
        {
            LabelPuesto.Text = "";
        }

        private void Persona_Click(object sender, RoutedEventArgs e)
        {
            LabelPuesto.Text = Email;
        }

        private void Persona_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            profile win2 = new profile(Nombre, Apellidos, Email, Foto);
            win2.Show();
        }
    }
}
