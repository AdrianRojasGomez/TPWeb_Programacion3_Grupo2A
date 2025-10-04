using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{

    public class VoucherNegocio
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
                datosVerif.SetearSP("Sp_listarmarcas");
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

        public void ActualizarVoucher(string codigoVoucher, int IdCliente, int IdArticulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta(@"
                    UPDATE dbo.Vouchers
                    SET IdCliente  = @IdCliente,
                        FechaCanje = @FechaCanje,
                        IdArticulo = @IdArticulo
                    WHERE CodigoVoucher = @CodigoVoucher;
                ");

                datos.SetearParametros("@CodigoVoucher", codigoVoucher);
                datos.SetearParametros("@IdCliente", IdCliente);
                datos.SetearParametros("@FechaCanje", DateTime.Today);
                datos.SetearParametros("@IdArticulo", IdArticulo);

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
