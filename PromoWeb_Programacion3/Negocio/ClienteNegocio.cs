using dominio;
using negocio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace negocio
{
    public class ClienteNegocio
    {
        public List<Cliente> clientes()
        {

            List<Cliente> lista = new List<Cliente>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {

                comando.CommandType = System.Data.CommandType.Text;

                comando.CommandText = "SELECT " +
               "    ISNULL(C.ID, 0)        AS ID, " +
               "    ISNULL(C.Nombre, '')   AS Nombre, " +
               "    ISNULL(C.Apellido, '') AS Apellido, " +
               "    ISNULL(C.Dni, '')      AS Dni, " +
               "    ISNULL(C.Email, '')    AS Email, " +
               "    ISNULL(C.ciudad, '')   AS ciudad, " +
               "    ISNULL(C.cp, '')       AS cp, " +
               "    ISNULL(C.direccion, '') AS direccion " +
               "FROM Clientes C";

                comando.Connection = conexion;
                conexion.Open();

                lector = comando.ExecuteReader();

                while (lector.Read())
                {

                    Cliente aux = new Cliente();

                    aux.Id = (int)lector["ID"];
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Apellido = (string)lector["Apellido"];
                    aux.Documento = (string)lector["Dni"];
                    aux.Email = (string)lector["Email"];

                    aux.Ciudad = (string)lector["ciudad"];
                    aux.CP = (int)lector["cp"];
                    aux.Direccion = (string)lector["direccion"];

                    aux.Voucher = new Voucher();

                    lista.Add(aux);

                }
                conexion.Close();

                return lista;


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Cliente BuscarPorDocumento(string documento)
        {
            if (string.IsNullOrWhiteSpace(documento))
                return null;

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta(@"
            SELECT TOP (1)
                Id,
                Documento,
                Nombre,
                Apellido,
                Email,
                Direccion,
                Ciudad,
                CP
            FROM Clientes
            WHERE Documento = @doc;");

                datos.SetearParametros("@doc", documento.Trim());
                datos.EjecutarLectura();

                if (!datos.Lector.Read())
                    return null;

                var reader = datos.Lector;

               
                int GetColumnIndex(string name) => reader.GetOrdinal(name);
                string GetStringOrEmpty(string name) => reader.IsDBNull(GetColumnIndex(name)) ? string.Empty : reader[name].ToString();

                int cp = reader.IsDBNull(GetColumnIndex("CP")) ? 0 : reader.GetInt32(GetColumnIndex("CP"));

                return new Cliente
                {
                    Id = reader.IsDBNull(GetColumnIndex("Id")) ? 0 : reader.GetInt32(GetColumnIndex("Id")),
                    Documento = GetStringOrEmpty("Documento"),
                    Nombre = GetStringOrEmpty("Nombre"),
                    Apellido = GetStringOrEmpty("Apellido"),
                    Email = GetStringOrEmpty("Email"),
                    Direccion = GetStringOrEmpty("Direccion"),
                    Ciudad = GetStringOrEmpty("Ciudad"),
                    CP = cp,
                    Voucher = null
                };
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public void AgregarCliente(Cliente cliente)
        {

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta(
                    "INSERT INTO dbo.Clientes(Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP)" +
                    "VALUES(@Documento, @Nombre, @Apellido, @Email, @Direccion, @Ciudad, @CP);"
                    );

                datos.SetearParametros("@Documento", cliente.Documento);
                datos.SetearParametros("@Nombre", cliente.Nombre);
                datos.SetearParametros("@Apellido", cliente.Apellido);
                datos.SetearParametros("@Email", cliente.Email);
                datos.SetearParametros("@Direccion", cliente.Direccion);
                datos.SetearParametros("@Ciudad", cliente.Ciudad);
                datos.SetearParametros("@CP", cliente.CP);

                datos.EjecutarAccion();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
    }
}

