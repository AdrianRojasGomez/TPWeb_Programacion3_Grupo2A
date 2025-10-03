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
    public partial class WebForm1 : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulo { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArchivoNegocio negocio = new ArchivoNegocio();
            List<Articulo> lista = negocio.ListarArticulosConImagenes();
           

            if (!IsPostBack)
            {
                try
                {
                    rptArticulos.DataSource = lista;
                    rptArticulos.DataBind();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

                    
        

        }


        protected void btnIrCanjearCupon_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}