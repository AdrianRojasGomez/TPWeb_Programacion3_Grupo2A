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

namespace Negocio
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

            var datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta(@" SELECT TOP (1)
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

                var r = datos.Lector;

                int Ord(string name) => r.GetOrdinal(name);
                string S(string name) => r.IsDBNull(Ord(name)) ? string.Empty : r[name].ToString();

                int cp = r.IsDBNull(Ord("CP")) ? 0 : r.GetInt32(Ord("CP"));

                return new Cliente
                {
                    Id = r.IsDBNull(Ord("Id")) ? 0 : r.GetInt32(Ord("Id")),
                    Documento = S("Documento"),
                    Nombre = S("Nombre"),
                    Apellido = S("Apellido"),
                    Email = S("Email"),
                    Direccion = S("Direccion"),
                    Ciudad = S("Ciudad"),
                    CP = cp,
                    Voucher = null
                };
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
    }
}

