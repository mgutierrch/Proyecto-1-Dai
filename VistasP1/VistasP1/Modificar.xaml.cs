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
    /// Lógica de interacción para Modificar.xaml
    /// </summary>
    public partial class Modificar : Window
    {
        public Modificar()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 7; i <= 22; i++)
            {
                this.cbHora.Items.Add(Convert.ToString(i) + ":");
            }
            for (int i = 0; i <= 59; i++)
            {
                this.cbMinutos.Items.Add(Convert.ToString(i));
            }
        }
        private void BtRegresar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Alta a = new Alta();
            a.Show();
        }

        private void BtModificar_Click(object sender, RoutedEventArgs e)
        {
            Actividad a = new Actividad();

            int res = a.modificar(Convert.ToInt32(txIdAct.Text), tbSalon.Text, dpFecha.SelectedDate.ToString(), cbHora.Text + cbMinutos.Text);
            if (res > 0)
                MessageBox.Show("Se modificó la actividad");
            else
                MessageBox.Show("No se encontro la actividad");



        }

       
    }
}
