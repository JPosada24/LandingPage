using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;

namespace LandingPage.Models
{
    public class DatosUsuarios
    {
        private SqlConnection con;

        private void Conectar()
        {
            string constr = ConfigurationManager.ConnectionStrings["admin"].ToString();
            con = new SqlConnection(constr);
        }

        // INGRESAR USUARIO

        public int AgregarUsuario(Usuario usu)
        {
            Conectar();
            SqlCommand com = new SqlCommand("INSERT INTO usuarios(nombre, apellido, email, telefono, edad) VALUES(@nombre, @apellido, @email, @telefono, @edad)", con);

            com.Parameters.Add("@nombre", SqlDbType.VarChar);
            com.Parameters.Add("@apellido", SqlDbType.VarChar);
            com.Parameters.Add("@email", SqlDbType.VarChar);
            com.Parameters.Add("@telefono", SqlDbType.BigInt);
            com.Parameters.Add("@edad", SqlDbType.Int);

            com.Parameters["@nombre"].Value = usu.Nombre;
            com.Parameters["@apellido"].Value = usu.Apellido;
            com.Parameters["@email"].Value = usu.Email;
            com.Parameters["@telefono"].Value = usu.Telefono;
            com.Parameters["@edad"].Value = usu.Edad;

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            return i;
        }

        // RECUPERAR USUARIOS

        public List<Usuario> RecuperarUsuarios()
        {
            Conectar();
            List<Usuario> usuarios = new List<Usuario>();

            SqlCommand com = new SqlCommand("SELECT * FROM usuarios", con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();

            while (registros.Read())
            {
                Usuario usu = new Usuario
                {
                    Id = int.Parse(registros["id"].ToString()),
                    Nombre = registros["nombre"].ToString(),
                    Apellido = registros["apellido"].ToString(),
                    Email = registros["email"].ToString(),
                    Telefono = long.Parse(registros["telefono"].ToString()),
                    Edad = int.Parse(registros["edad"].ToString())
                };
                usuarios.Add(usu);
            }
            con.Close();
            return usuarios;
        }

        //OBTENER ID

        public Usuario RecuperarId(int id)
        {
            Conectar();
            SqlCommand com = new SqlCommand("SELECT * FROM usuarios WHERE id = @id", con);
            com.Parameters.Add("@id", SqlDbType.Int);
            com.Parameters["@id"].Value = id;

            con.Open();

            SqlDataReader registro = com.ExecuteReader();
            Usuario usu = new Usuario();

            if (registro.Read())
            {
                usu.Nombre = registro["nombre"].ToString();
                usu.Apellido = registro["apellido"].ToString();
                usu.Email = registro["email"].ToString();
                usu.Telefono = long.Parse(registro["telefono"].ToString());
                usu.Edad = int.Parse(registro["edad"].ToString());

            }

            con.Close();
            return usu;
        }

        //DELETE

        public int Eliminar(int id)
        {
            Conectar();

            SqlCommand com = new SqlCommand("DELETE FROM usuarios WHERE id = @id", con);

            com.Parameters.Add("@id", SqlDbType.Int);
            com.Parameters["@id"].Value = id;

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}