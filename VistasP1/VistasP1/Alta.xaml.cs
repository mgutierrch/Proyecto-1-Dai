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
    /// Interaction logic for Alta.xaml
    /// </summary>
    public partial class Alta : Window
    {
        public Alta()
        {
            InitializeComponent();
        }


    private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Conexion c = new Conexion();
            c.llenarComboAlta(cbTipo);
            for (int i=7;i<=22;i++){
                this.cbHora.Items.Add(Convert.ToString(i)+":");
            }
            for (int i = 0; i <= 59; i++)
            {
                this.cbMinutos.Items.Add(Convert.ToString(i));
            }
        }
        
 

        private void BtAgregar_Click(object sender, RoutedEventArgs e)
        {

            int res;
            Actividad a =  new Actividad(Int16.Parse(tbidActividad.Text),tbActividad.Text, Int16.Parse(tbAsistentes.Text), cbHora.Text+cbMinutos.Text,dpFecha.SelectedDate.ToString(), tbSalon.Text, tbDesc.Text,cbTipo.Text,Convert.ToInt16(cbTipo.SelectedIndex) );
            res = a.agregar(a);
            if (res > 0)
                MessageBox.Show("Actividad dada de alta");
            else
                MessageBox.Show("No se pudo dar de alta");
        }

        private void BtEliminar_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Eliminar w = new Eliminar();
            w.Show();

        }

    private void BtSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtModificar_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Modificar p = new Modificar();
            p.Show();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Calendar_Drop(object sender, DragEventArgs e)
        {

        }

        private void cbInstructor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            


        }

        private void BtBuscar_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Buscar p = new Buscar();
            p.Show();
        }
    }
    }
    

