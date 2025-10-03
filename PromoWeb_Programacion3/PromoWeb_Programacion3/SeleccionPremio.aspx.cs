using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace PromoWeb_Programacion3
{
    public partial class SeleccionPremio : System.Web.UI.Page
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

        
        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            
            string idArticulo = HiddenArticuloId.Value; 

            if (!string.IsNullOrEmpty(idArticulo))
            {
                
                Response.Redirect($"CLienteFOrmulario.aspx?premioId={idArticulo}");
            }
            
        }
    }
}