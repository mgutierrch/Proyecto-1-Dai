using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace VistasP1
{
    class Conexion
    {
        SqlCommand cmd;
        SqlDataReader rd;

        public static SqlConnection conectar()
        {
            SqlConnection cnn;
            try
            {
                cnn = new SqlConnection("Data Source=MAURICIO-PC;Initial Catalog=lumap;Integrated Security=True");
                cnn.Open();
                MessageBox.Show("si se pudo hacer la conexión");
            }
            catch (Exception ex)
            {
                cnn = null;
                MessageBox.Show("no se pudo hacer la conexión" + ex);
            }
            return cnn;
        }

        public static String comprabarPwd(String usuario, String contra)
        {
            String res = "error";
            SqlDataReader rd;
            SqlConnection con;
            try
            {
                con = Conexion.conectar();
               SqlCommand cmd = new SqlCommand(String.Format("select contra from Usuario where usuario= '{0}'", usuario), con);
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    if (rd.GetString(0).Equals(contra))
                        res = "contraseña correcta";
                    else
                        res = "contraseña Incorrecta";
                }

                else
                {
                    res = "usuario incorrecto";
                }
                con.Close();
                rd.Close();

            }
            catch (Exception ex)
            {
                res = "error" + ex;
            }
            return res;

        }

        public void llenarComboAlta(ComboBox cb)
        {
            try
            {
                SqlConnection con;
                con = Conexion.conectar();
                cmd = new SqlCommand("select nomTipo from Tipo", con);
                rd = cmd.ExecuteReader();
                while (rd.Read())
              {
                    cb.Items.Add(rd["nomTipo"].ToString());
                }
                cb.SelectedIndex = 0;
                rd.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("no se pudo llenar el combo" + ex);
            }
        }


    }
}



