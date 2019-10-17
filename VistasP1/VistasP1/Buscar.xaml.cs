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

namespace VistasP1
{
    /// <summary>
    /// Lógica de interacción para Buscar.xaml
    /// </summary>
    public partial class Buscar : Window
    {
        public Buscar()
        {
            InitializeComponent();
        }

        private void BtBuscar_Click(object sender, RoutedEventArgs e)
        {
            List<Actividad> lis = Actividad.buscar(txActividad.Text);

            dgBusqueda.ItemsSource = lis;
        }

        private void BtRegresar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Alta a = new Alta();
            a.Show();

        }
    }
}
