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
    public partial class ClienteFormulario : System.Web.UI.Page
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

        private void MostrarEstadoDocumento(bool encontrado, string documento)
        {

            string clasesBase = "alert mt-2 py-2 px-3 ";
            if (encontrado)
            {
                docStatus.Attributes["class"] = clasesBase + "alert-success";
                docStatus.InnerHtml = $"Cliente encontrado para Documento <strong>{documento}</strong>.";
            }
            else
            {
                docStatus.Attributes["class"] = clasesBase + "alert-warning";
                docStatus.InnerHtml = $"No se encontró cliente con Documento <strong>{documento}</strong>. " +
                                      $"Puedes completar los datos para registrarlo.";
            }
        }

        private void AplicarEstadoParticipar(bool habilitar)
        {
            string textoDefault = (string)(ViewState["BtnParticiparDefault"] ?? "Participar");

            btnParticipar.Enabled = habilitar;
            btnParticipar.Text = habilitar ? textoDefault : "No disponible";
            btnParticipar.CssClass = habilitar ? "btn btn-primary" : "btn btn-secondary disabled";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string voucherUsado = Session["voucher"] as string ?? string.Empty;
            lblVoucherUSado.Text = $"Voucher Usado: {voucherUsado}";
            if (voucherUsado == string.Empty)
            {
                btnParticipar.Enabled = false;
                btnParticipar.Text = "INGRESA EL VOUCHER CORRECTAMENTE";
                btnParticipar.CssClass = "btn btn-secondary disabled";
            }


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
            string documento = txtDocumento.Text?.Trim();

            if (string.IsNullOrEmpty(documento))
            {
                LimpiarCamposCliente();
                ClienteEncontrado = false;
                docStatus.Attributes["class"] = "alert d-none mt-2 py-2 px-3";
                docStatus.InnerHtml = string.Empty;
                return;
            }

            ClienteNegocio negocio = new ClienteNegocio();
            Cliente cliente = negocio.BuscarPorDocumento(documento);

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
                MostrarEstadoDocumento(true, documento);
            }
            else
            {
                LimpiarCamposCliente();
                ClienteEncontrado = false;
                BloquearCamposCliente(false);
                MostrarEstadoDocumento(false, documento);
            }
        }


        protected void btnParticipar_Click(object sender, EventArgs e)
        {

            ClienteNegocio clienteNegocio = new ClienteNegocio();
            VoucherNegocio voucherNegocio = new VoucherNegocio();

            if (!ClienteEncontrado)
            {
                Cliente nuevoCliente = new Cliente();
                nuevoCliente.Documento = txtDocumento.Text;
                nuevoCliente.Nombre = txtNombre.Text;
                nuevoCliente.Apellido = txtApellido.Text;
                nuevoCliente.Email = txtEmail.Text;
                nuevoCliente.Direccion = txtDireccion.Text;
                nuevoCliente.Ciudad = txtCiudad.Text;
                nuevoCliente.CP = int.Parse(txtCP.Text);

                clienteNegocio.AgregarCliente(nuevoCliente);

            }
            string documento = txtDocumento.Text?.Trim();
            voucherNegocio.ActualizarVoucher(Session["voucher"] as string,
                clienteNegocio.BuscarPorDocumento(documento).Id,
                int.Parse(Request.QueryString["premioId"])
                );

            Session["MsgOK"] = "Voucher usado correctamente, ¡Buena suerte!";
            //aqui va funcion de correo 

            Response.Redirect("Premios.aspx");


        }
    }
}