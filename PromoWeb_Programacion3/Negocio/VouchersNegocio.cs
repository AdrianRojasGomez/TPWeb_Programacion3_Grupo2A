using Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class VouchersNegocio
    {
        List<Cliente> lista = new List<Cliente>();
        SqlConnection conexion = new SqlConnection();
        SqlCommand comando = new SqlCommand();
        SqlDataReader lector;

        public List<Vouchers> ListarVourches()
        {
            List<Vouchers> lista = new List<Vouchers>();
            Accesodatos accesoDatos = new Accesodatos();

            try
            {
                accesoDatos.SetearConsulta("select id, descripcion from MARCAS");
                accesoDatos.EjecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    Vouchers aux = new Vouchers();
                    aux.Id = (int)accesoDatos.Lector["Id"];
                    aux.CodigoVouchers = (string)accesoDatos.Lector["CodigoVouchers"];
                    
                    aux.FechaCanje = (DateTime)accesoDatos.Lector["FechaCanje"];
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                accesoDatos.CerrarConexion();

            }

        }



    }
}
