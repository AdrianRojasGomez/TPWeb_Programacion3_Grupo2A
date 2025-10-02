using dominio;
using System;
using System.Collections;
using System.Collections.Generic;
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

                // matias
                //conexion.ConnectionString = "server = .\\SQLEXPRESS02; database = CATALOGO_P3_DB; integrated security =true ;";


                comando.CommandType = System.Data.CommandType.Text;

                /// ////matias
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




    }
}
