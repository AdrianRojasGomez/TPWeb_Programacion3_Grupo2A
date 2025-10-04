using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PromoWeb_Programacion3
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string voucherUsado = Session["voucher"] as string ?? string.Empty;

            if (!IsPostBack)
            {
                string premioId = Request.QueryString["premioId"];


                if (!string.IsNullOrEmpty(premioId))
                {
                    int id = int.Parse(premioId);

                    // Buscar el artículo por ID
                    ArchivoNegocio negocio = new ArchivoNegocio();
                    List<Articulo> articulos = negocio.ListarConSP();

                    Articulo seleccionado = articulos.Find(a => a.Id == id);

                    if (seleccionado != null)
                    {
                        lblVoucherUSado.Text = $"Voucher Usado: {voucherUsado}";
                        lblNombrePremio.Text = $"Premio seleccionado: {seleccionado.Nombre}";
                    }
                    else
                    {
                        lblNombrePremio.Text = "Premio no encontrado.";
                    }
                }
            }



        }

        protected void btnParticipar_Click(object sender, EventArgs e)
        {

        }
    }
}