using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MySqlConnector;

namespace Asistencia.Clases
{
    internal class Datos
    {
        string cadenaConexion = "server=localhost;user=andres;password=safe;database=asistencia_db";
        MySqlConnection conexion;

        private void Conectar()
        {
            try
            {
                conexion = new MySqlConnection(cadenaConexion);
                conexion.Open();
            }catch(Exception ex)
            {
                MessageBox.Show("Error al conectar a la base de datos: " + ex.Message);
            }
        }

        private void Desconectar()
        {
            try
            {
                if(conexion != null)
                {
                    conexion.Close();
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Error al desconectar de la base de datos: " + ex.Message);
            }
        }

        public DataSet ejecutar(string comando)
        {
            try
            {
                Conectar();
                MySqlDataAdapter da = new MySqlDataAdapter(comando, conexion);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }catch(Exception ex) {
                MessageBox.Show("Error al ejecutar el comando: " + ex.Message);
                return null;
            }
            finally  
            {
                Desconectar();
            }
        }

        public bool ejecutarComando(string comando)
        {
            try
            {
                Conectar();
                MySqlCommand cmd = new MySqlCommand(comando, conexion);
                cmd.ExecuteNonQuery();
                return true;

            }catch(Exception ex)
            {
                MessageBox.Show("Error al ejecutar el comando: " + ex.Message);
                return false;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }
        
    }
}
