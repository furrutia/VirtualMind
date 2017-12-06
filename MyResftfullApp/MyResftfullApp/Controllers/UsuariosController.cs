using MyResftfullApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace MyResftfullApp.Controllers
{
    public class UsuariosController : ApiController
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        private JsonMediaTypeFormatter JSONMediaFormatter = new JsonMediaTypeFormatter();

        public IEnumerable<Usuario> GetAllUsers()
        {
            Usuario[] usuariosBD = obtenerUsuariosBD();
            return usuariosBD;
        }

        private Usuario[] obtenerUsuariosBD()
        {
            if (string.IsNullOrEmpty(_connectionString)) throw new Exception("El Connection String no puede ser nulo o vacio, revise el archivo de configuración");
            SqlConnection sqlConnection = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand();
            //SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM USUARIO";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            //reader = cmd.ExecuteReader();
            // Data is accessible through the DataReader object here.

            IDataReader dr = cmd.ExecuteReader();

            List<Usuario> listUsers = new List<Usuario>();

            if (dr.FieldCount > 0)
            {
                while (dr.Read())
                {
                    Usuario user = new Usuario()
                    {
                        Id = (int)dr["Id"],
                        Nombre = dr["Nombre"].ToString(),
                        Apellido = dr["Apellido"].ToString(),
                        Email = dr["Email"].ToString(),
                        Password = dr["Password"].ToString()
                    };

                    listUsers.Add(user);
                }
            }

            sqlConnection.Close();

            return listUsers.ToArray();
        }

        public HttpResponseMessage GetUser(int id)
        {
            Usuario[] usuariosBD = obtenerUsuariosBD();

            HttpResponseMessage Response = this.Request.CreateResponse(HttpStatusCode.OK);

            var usuario = usuariosBD.FirstOrDefault((p) => p.Id == id);
            if (usuario == null)
            {
                Response.StatusCode = HttpStatusCode.NotFound;
                return Response;
            }

            Response.Content = new ObjectContent(typeof(Usuario), usuario, JSONMediaFormatter, "application/json");
            return Response;
        }
    }
}
