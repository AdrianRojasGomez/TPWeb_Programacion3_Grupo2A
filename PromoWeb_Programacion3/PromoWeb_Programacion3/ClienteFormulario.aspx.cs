using dominio;
using negocio;
using Negocio;
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
        protected bool ClienteEncontrado
        {
            get
            {
                if (ViewState["ClienteEncontrado"] == null)
                    return false;
                return (bool)ViewState["ClienteEncontrado"];
            }
            set
            {
                ViewState["ClienteEncontrado"] = value;
            }
        }

        private void BloquearCamposCliente(bool bloquear)
        {
            
            txtDocumento.ReadOnly = false;

            txtNombre.ReadOnly = bloquear;
            txtApellido.ReadOnly = bloquear;
            txtEmail.ReadOnly = bloquear;
            txtCiudad.ReadOnly = bloquear;
            txtCP.ReadOnly = bloquear;
            txtDireccion.ReadOnly = bloquear;
        }

        private void LimpiarCamposCliente()
        {
            string defaultStyle = "form-control";
            txtNombre.Text = "";
            txtNombre.CssClass = defaultStyle;
            txtApellido.Text = "";
            txtApellido.CssClass = defaultStyle;
            txtEmail.Text = "";
            txtEmail.CssClass = defaultStyle;
            txtCiudad.Text = "";
            txtCiudad.CssClass = defaultStyle;
            txtCP.Text = "";
            txtCP.CssClass = defaultStyle;
            txtDireccion.Text = "";
            txtDireccion.CssClass = defaultStyle;
        }

        private void MostrarEstadoDocumento(bool encontrado, string dni)
        {
            if (string.IsNullOrWhiteSpace(dni))
            {
                // Ocultar el mensaje si no hay DNI
                docStatus.Attributes["class"] = "alert d-none mt-2 py-2 px-3";
                docStatus.InnerHtml = string.Empty;
                return;
            }

            string clasesBase = "alert mt-2 py-2 px-3 ";
            if (encontrado)
            {
                docStatus.Attributes["class"] = clasesBase + "alert-success";
                docStatus.InnerHtml = $"Cliente encontrado para DNI <strong>{dni}</strong>.";
            }
            else
            {
                docStatus.Attributes["class"] = clasesBase + "alert-warning";
                docStatus.InnerHtml = $"No se encontró cliente con DNI <strong>{dni}</strong>. " +
                                      $"Puedes completar los datos para registrarlo.";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            string voucherUsado = Session["voucher"] as string ?? string.Empty;
            lblVoucherUSado.Text = $"Voucher Usado: {voucherUsado}";
            if (!IsPostBack)
            {
                string premioId = Request.QueryString["premioId"];


                if (!string.IsNullOrEmpty(premioId))
                {
                    int id = int.Parse(premioId);

                    // Buscar el artículo por ID
                    ArchivoNegocio negocio = new ArchivoNegocio();
                    List<Articulo> articulos = negocio.Listar();

                    Articulo seleccionado = articulos.Find(a => a.Id == id);

                    if (seleccionado != null)
                    {
                        
                        lblNombrePremio.Text = $"Premio seleccionado: {seleccionado.Nombre}";
                    }
                    else
                    {
                        lblNombrePremio.Text = "Premio no encontrado.";
                    }

                }


            }


        }

        protected void txtDocumento_TextChanged(object sender, EventArgs e)
        {
            string dni = txtDocumento.Text?.Trim();

            if (string.IsNullOrEmpty(dni))
            {
                LimpiarCamposCliente();
                return;
            }

            var negocio = new ClienteNegocio();
            var cliente = negocio.BuscarPorDocumento(dni);

            if (cliente != null)
            {
                string newStyle = (txtNombre.CssClass + " bg-light text-muted").Trim();
                txtNombre.Text = cliente.Nombre;
                txtNombre.CssClass = newStyle;
                txtApellido.Text = cliente.Apellido;
                txtApellido.CssClass = newStyle;
                txtEmail.Text = cliente.Email;
                txtEmail.CssClass = newStyle;
                txtCiudad.Text = cliente.Ciudad;
                txtCiudad.CssClass = newStyle;
                txtCP.Text = cliente.CP.ToString();
                txtCP.CssClass = newStyle;
                txtDireccion.Text = cliente.Direccion;
                txtDireccion.CssClass = newStyle;

                ClienteEncontrado = true;
                BloquearCamposCliente(true);
                MostrarEstadoDocumento(true, dni);
            }
            else
            {
                LimpiarCamposCliente();
                ClienteEncontrado = false;
                BloquearCamposCliente(false);
                MostrarEstadoDocumento(false, dni);
            }
        }




        protected void btnParticipar_Click(object sender, EventArgs e)
        {

        }
    }
}