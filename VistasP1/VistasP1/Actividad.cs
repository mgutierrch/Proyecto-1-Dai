using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VistasP1
{
    class Actividad
    {

        public Int16 idAct { get; set; }
        public String nombreAct { get; set; }
        public Int16 maxAsistentes { get; set; }
        public String salon { get; set; }
        public String descripcion { get; set; }

        public String instructor { get; set; }
        public String tipo { get; set; }
        public String hora { get; set; }
        public String fecha { get; set; }

        public Int16 idTipo { get; set; }


        //    public String tipo2 { get; set; }


        // public Int16 idIn { get; set; }

        public Actividad()
        {
        }

        public Actividad(short idAct, string nombreAct, short maxAsistentes, string hora, string fecha,string salon, string descripcion, string tipo,Int16 idTipo)
        {
            this.idAct = idAct;
            this.nombreAct = nombreAct;
            this.maxAsistentes = maxAsistentes;
            this.hora = hora;
            this.fecha = fecha;
            this.salon = salon;
            this.descripcion = descripcion;
            this.idTipo = idTipo;
            this.tipo = tipo;
            // this.tipo2 = tipo2;
            //this.idIn = idIn;
        }


        public Actividad(short idAct)
        {
            this.idAct = idAct;
        }

        //Funcion de agregar una actividad a la tabla ACTIVIDAD y regresar un entero positivo si lo pudo agregar
        //o un enterp negativo si no lo pudo agregar
        public int agregar(Actividad a)
        {
            int res = 0;
            //abrir la conexion 
            SqlConnection con;
            con = Conexion.conectar();
            //command para ejecutar el query (insert)
            SqlCommand cmd = new SqlCommand(String.Format("insert into Actividad (idAct, nombreAct, maxAsistentes,hora,fecha, salón, descripcion, tipo,idTipo) values({0}, '{1}', {2}, '{3}', '{4}','{5}','{6}','{7}',{8})", a.idAct, a.nombreAct, a.maxAsistentes,a.hora,a.fecha, a.salon, a.descripcion, a.tipo ,a.idTipo), con);
            res = cmd.ExecuteNonQuery(); //num de colunas(registros) afectados (-1 indica no modificaciones

            //cerrar la conexion 
            con.Close();

            return res;
        }

        public int eliminar(int cu)
        {
            int res = 0;
            //abrir la conexion 
            SqlConnection con;
            con = Conexion.conectar();

            //command para ejecutar el query (insert)
            SqlCommand cmd = new SqlCommand(String.Format("delete from Actividad where idAct={0} ", cu), con);
            res = cmd.ExecuteNonQuery(); //num de colunas(registros) afectados (-1 indica no modificaciones)
            //cerrar la conexion 
            con.Close();

            return res;
        }



        //Para que yo pueda usar un DataGrid tengo que tener una lista.
        public static List<Actividad> buscar(String nombre)
        {
            List<Actividad> lis = new List<Actividad>();
            Actividad a;
            SqlDataReader rd;
            SqlConnection con;

            try
            {
                con = Conexion.conectar();
                //Command para ejecutar el Query (insert)
                SqlCommand cmd = new SqlCommand(String.Format("select idAct, nombreAct, maxAsistentes,   hora, fecha,salón,descripcion, tipo  from Actividad where nombreAct like '%{0}%'",nombre), con);
                //Ejecutar el Query
                rd = cmd.ExecuteReader(); // num de columnas afectadas, o -1 si no se modifico nada 
                while (rd.Read())
                {
                    a = new Actividad();
                    a.idAct = rd.GetInt16(0);
                    a.nombreAct = rd.GetString(1);
                    a.maxAsistentes = rd.GetInt16(2);
                    a.hora = rd.GetString(3);
                    a.fecha = rd.GetString(4);
                    a.salon = rd.GetString(5);
                    a.descripcion = rd.GetString(6);
                    a.tipo = rd.GetString(7);

                    //Va revisando los datos en la columna 
                    lis.Add(a);
                }
                //Cerrar la conexión
                con.Close();
            }
            catch (Exception e)
            {
                
            }
            return lis;
        }


        public int modificar(Int32 idAct, string sal, string fecha, string hora )
        {
            //Crear un constructor solamente de clave única y correo
            int res = 0;
            //Abrir la conexión
            SqlConnection con;
            try
            {
                con = Conexion.conectar();
                //Command para ejecutar el Query (insert)
                SqlCommand cmd = new SqlCommand(String.Format("update Actividad set salón='{0}', fecha='{1}', hora='{2}' where idAct={3}",sal , fecha, hora, idAct), con);
                //Ejecutar el Query
                res = cmd.ExecuteNonQuery(); // num de columnas afectadas, o -1 si no se modifico nada 
                //Cerrar la conexión
                con.Close();
            }
            catch (Exception e)
            {

            }
            return res;
        }



    }
}






