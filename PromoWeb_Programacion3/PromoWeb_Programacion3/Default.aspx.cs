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
            
            

        }

        protected void BtnConfigVouchers_Click(object sender, EventArgs e)
        {

            List<Voucher> lista = new List<Voucher>();
            Voucher voucher = new Voucher();    
            ArchivoNegocio archivoNegocio = new ArchivoNegocio();

            if (txtCodigo.Text.ToLower() == "" )
            {
                LblMensaje.Text = "Ponga un codigo por favor";

                return;
            }
            try
            {
                lista = archivoNegocio.listavoucher(txtCodigo.Text.ToLower());
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (lista == null || lista.Count == 0)
            {

                LblMensaje.Text = "no se encontro el vouchers";

                Response.Redirect("VouchersInvalido.aspx");
            }
            else if (lista[0].FechaCanje != null)
            {
                LblMensaje.Text = "el voucher ya se uso";

                Response.Redirect("VouchersInvalido.aspx");
            }
            else
            {
                Session["HoraActual"] = DateTime.Now;


                Session.Add("voucher", txtCodigo.Text.ToLower());
                string NombreVoucher = Session["voucher"].ToString();

                Response.Redirect("SeleccionPremio.aspx");
                return;
            }

        


        }

        protected void txtCodigo_TextChanged(object sender, EventArgs e)
        {






        }


    }
}