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

        protected void txtDocumento_TextChanged(object sender, EventArgs e)
        {
            string dni = txtDocumento.Text?.Trim();

            if (string.IsNullOrEmpty(dni))
                return;

            var negocio = new ClienteNegocio();
            var cliente = negocio.BuscarPorDocumento(dni);

            if (cliente != null)
            {
                txtNombre.Text = cliente.Nombre;
                txtApellido.Text = cliente.Apellido;
                txtEmail.Text = cliente.Email;
                txtCiudad.Text = cliente.Ciudad;
                txtCP.Text = cliente.CP.ToString();
                txtDireccion.Text = cliente.Direccion;
                // Si quieres, puedes deshabilitar campos o mostrar un mensaje de "Cliente encontrado".
            }
            else
            {
                // Limpia o deja lo que el usuario haya escrito; a tu gusto:
                txtNombre.Text = txtApellido.Text = txtEmail.Text = txtCiudad.Text = txtCP.Text = txtDireccion.Text = string.Empty;
                // También podrías mostrar un Label con "DNI no encontrado".
            }
        }




        protected void btnParticipar_Click(object sender, EventArgs e)
        {

        }
    }
}