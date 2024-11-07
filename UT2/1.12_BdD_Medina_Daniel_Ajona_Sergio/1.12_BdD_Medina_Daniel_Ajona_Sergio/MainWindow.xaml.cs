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
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Media.Animation;

namespace _1._12_BdD_Medina_Daniel_Ajona_Sergio
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection SqlConnection;
        public MainWindow()
        {
            InitializeComponent();
            string miConexion = ConfigurationManager.ConnectionStrings["_1._12_BdD_Medina_Daniel_Ajona_Sergio.Properties.Settings.BdD_Medina_Daniel_Ajona_SergioConnectionString"].ConnectionString;
            SqlConnection = new SqlConnection(miConexion);
            muestraCiclos();

        }

        private void muestraCiclos() 
        {
            string consulta = "SELECT * FROM CICLOS";
            SqlDataAdapter adapter = new SqlDataAdapter(consulta, SqlConnection);
            using (adapter)
            {

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                listaCiclos.DisplayMemberPath = "Nombre";
                listaCiclos.SelectedValuePath = "Id";
                listaCiclos.ItemsSource = dt.DefaultView;
            }
        }
    }
}
