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
    /// Lógica de interacción para Eliminar.xaml
    /// </summary>
    public partial class Eliminar : Window
    {
        public Eliminar()
        {
            InitializeComponent();
        }

        private void BtRegresar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Alta a = new Alta();
            a.Show();
        }

        private void BtEliminar_Click(object sender, RoutedEventArgs e)
        {
            Actividad a = new Actividad();
            int res = a.eliminar(Convert.ToInt16(txIdAct.Text));
            if (res < 0)
                MessageBox.Show("Actividad no encontrado");
            else
                MessageBox.Show("se dio de baja la actividad " + txIdAct.Text);
        }

        private void TxIdAct_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
