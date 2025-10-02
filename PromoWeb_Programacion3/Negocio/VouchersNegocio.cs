using dominio;
using negocio;
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

        public List<Voucher> ListarVourches()
        {
            List<Voucher> lista = new List<Voucher>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                AccesoDatos datosVerif = new AccesoDatos();
                datosVerif.SetearConsulta("select id, descripcion from MARCAS");
                datosVerif.EjecutarLectura();

                while (datosVerif.Lector.Read())
                {
                    Voucher aux = new Voucher();
                    aux.Id = (int)datosVerif.Lector["Id"];
                    aux.CodigoVouchers = (string)datosVerif.Lector["CodigoVouchers"];
                    
                    aux.FechaCanje = (DateTime)datosVerif.Lector["FechaCanje"];
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConexion();

            }

        }



    }
}
