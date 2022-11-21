using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace WebMvcSql.Models
{
    public class cMantenimientoArticulo
    {
        private SqlConnection conn;
        private void Conectar()
        {
            string cadena = ConfigurationManager.ConnectionStrings["Administracion"].ToString();
            conn = new SqlConnection(cadena);
        }

    public List<cArticulo> RecuperarTodos()
            {
            Conectar();
            List<cArticulo> articulo = new List<cArticulo>();
            SqlCommand comando = new SqlCommand("select Id,nombre,apellido,telefono,cargo from Conexion", conn);
            conn.Open();
            SqlDataReader registro = comando.ExecuteReader();
            while(registro.Read())
            {
                cArticulo art = new cArticulo
                {
                Codigo = int.Parse(registro["Id"].ToString()),
                Nombre = registro["nombre"].ToString(),
                Apellido = registro["apellido"].ToString(),
                Telefono = registro["telefono"].ToString(),
                Cargo = registro["cargo"].ToString()
                };
            articulo.Add(art);
            }
            conn.Close();
            return articulo;
            }
        public cArticulo RecuperarUno(int pCod)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("select Id,nombre,apellido,telefono,cargo from Conexion where Id=@Id",conn);
            comando.Parameters.Add("@Id", SqlDbType.Int);
            comando.Parameters["@Id"].Value = pCod;
            conn.Open();
            SqlDataReader registro = comando.ExecuteReader();
            cArticulo art = new cArticulo();
            if(registro.Read())
            {
                art.Codigo = int.Parse(registro["Id"].ToString());
                art.Nombre = registro["nombre"].ToString();
                art.Apellido = registro["apellido"].ToString();
                art.Telefono = registro["telefono"].ToString();
                art.Cargo = registro["cargo"].ToString();
            }
            conn.Close();
            return art;
        }
        public int Insertar (cArticulo art)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("insert into Conexion (nombre,apellido,telefono,cargo) values (@nombre,@apellido,@telefono,@cargo)", conn);
            comando.Parameters.Add("@nombre", SqlDbType.VarChar);
            comando.Parameters.Add("@apellido", SqlDbType.VarChar);
            comando.Parameters.Add("@telefono", SqlDbType.VarChar);
            comando.Parameters.Add("@cargo", SqlDbType.VarChar);
            comando.Parameters["@nombre"].Value = art.Nombre;
            comando.Parameters["@apellido"].Value = art.Apellido;
            comando.Parameters["@telefono"].Value = art.Telefono;
            comando.Parameters["@cargo"].Value = art.Cargo;
            conn.Open();
            int i = comando.ExecuteNonQuery();
            conn.Close();
            return i;
        }
        public int Modifica(cArticulo art)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("update articulos set nombre=@nombre,apellido=@apellido,telefono=@telefono,cargo=@cargo where Id=@Id", conn);
            comando.Parameters.Add("@nombre", SqlDbType.VarChar);
            comando.Parameters["@nombre"].Value = art.Nombre;
            comando.Parameters.Add("@apellido", SqlDbType.VarChar);
            comando.Parameters["@apellido"].Value = art.Apellido;
            comando.Parameters.Add("@telefono", SqlDbType.VarChar);
            comando.Parameters["@telefono"].Value = art.Telefono;
            comando.Parameters.Add("@cargo", SqlDbType.VarChar);
            comando.Parameters["@cargo"].Value = art.Cargo;
            conn.Open();
            int i = comando.ExecuteNonQuery();
            conn.Close();
            return i;
        }
        public int Elimina (int pCod)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("delete from Conexion where Id=@Id", conn);
            comando.Parameters.Add("@Id", SqlDbType.Int);
            comando.Parameters["@Id"].Value = pCod;
            conn.Open();
            int i = comando.ExecuteNonQuery();
            conn.Close();
            return i;

        }
    }
}