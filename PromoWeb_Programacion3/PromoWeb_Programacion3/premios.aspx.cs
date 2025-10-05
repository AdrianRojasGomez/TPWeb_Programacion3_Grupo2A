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
    public partial class Premios : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulo { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArchivoNegocio negocio = new ArchivoNegocio();
            List<Articulo> lista = negocio.ListarArticulosConImagenes();

            //Logica de Mensaje de Exito
            string ok = Session["MsgOK"] as string;
            if (!string.IsNullOrEmpty(ok))
            {
                premiosStatus.Attributes["class"] = "alert alert-success mt-3 py-2 px-3";
                premiosStatus.InnerHtml = ok;
                Session.Remove("MsgOK");
            }

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