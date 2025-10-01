using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using dominio;
using negocio;

namespace PromoWeb_Programacion3
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { txtCodigo.Text = "Ingrese el codigo aqui"; }

        }

        protected void BtnConfigVouchers_Click(object sender, EventArgs e)
        {

            List<Voucher> lista = new List<Voucher>();

            if (txtCodigo.Text.ToLower() == "" || txtCodigo.Text.ToLower() == "Ingrese el codigo aqui")
            {
                LblMensaje.Text = "ponga un codigo por favor";

                return;
            }
            try
            {
                lista = listavoucher(txtCodigo.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (lista == null || lista.Count == 0)
            {

                LblMensaje.Text = "no se encontro el vouchers";
            }
            else if (lista[0].FechaCanje != null)
            {
                LblMensaje.Text = "el voucher ya se uso";


            }
            else
            { LblMensaje.Text = "el voucher se puede usar"; }

            if (LblMensaje.Text == "el voucher se puede usar")
            {
                Response.Redirect("premios.aspx");


            }


        }

        protected void txtCodigo_TextChanged(object sender, EventArgs e)
        {






        }


        public List<Voucher> listavoucher(string voucher)
        {

            AccesoDatos accesoDatos = new AccesoDatos();

            List<Voucher> listavoucher = new List<Voucher>();







            try
            {


                accesoDatos.SetearConsulta("select CodigoVoucher,FechaCanje  " + " from Vouchers  " + "WHERE CodigoVoucher = @CodigoVoucher");

               /// accesoDatos.SetearConsulta("select CodigoVoucher,FechaCanje  " + " from Vouchers  " + "WHERE CodigoVoucher = @CodigoVoucher");
                accesoDatos.SetearSP("SP_ObtenerVoucherPorCodigo");

                accesoDatos.SetearParametros("@CodigoVoucher", voucher.Trim());
                accesoDatos.EjecutarLectura();



                while (accesoDatos.Lector.Read())
                {


                    Voucher aux = new Voucher();

                    aux.CodigoVouchers = (string)accesoDatos.Lector["CodigoVoucher"];

                    if (accesoDatos.Lector["FechaCanje"] != DBNull.Value)
                        aux.FechaCanje = (DateTime)accesoDatos.Lector["FechaCanje"];
                    else
                        aux.FechaCanje = null;


                    listavoucher.Add(aux);


                }
                return listavoucher;

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