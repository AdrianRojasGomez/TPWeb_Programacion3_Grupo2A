<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="ClienteFormulario.aspx.cs" Inherits="PromoWeb_Programacion3.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="Content/style.css" rel="stylesheet" />

    <div class="container">

        <div class="header">
            <h1><i class="fas fa-gift"></i>Introduce tus datos!</h1>
            <p class="mb-0">es obligarotio completar los datos para participar</p>

        </div>

        <div class="form-container">
          <div class="col-12">            
            <h1>Ingresa tus datos:</h1>

            <div class="mb-3 row">
                <label for="Voucher" class="col-sm-2 col-form-label">Voucher</label>
                <div class="col-sm-10">
                    <input type="text" readonly class="form-control-plaintext" id="Voucher" value="Codigo0N" />
                    <asp:Label ID="lblNombrePremio" runat="server" CssClass="form-label text-success" />
                </div>
            </div>

            <div class="mb-3">
                <label for="txtDocumento" class="form-label">Documento</label>
                <asp:TextBox runat="server" ID="txtDocumento" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label for="txtApellido" class="form-label">Apellido</label>
                <asp:TextBox runat="server" ID="txtApellido" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label for="txtEmail" class="form-label">Email address</label>
                <input type="email" class="form-control" id="txtEmail" placeholder="name@example.com" />
            </div>

            <div class="mb-3">
                <label for="txtDireccion" class="form-label">Direccion</label>
                <textarea class="form-control" id="txtDireccion" rows="3"></textarea>
            </div>

            <div class="mb-3">
                <label for="txtCiudad" class="form-label">Ciudad</label>
                <asp:TextBox runat="server" ID="txtCiudad" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label for="txtCP" class="form-label">Codigo Postal</label>
                <asp:TextBox runat="server" ID="txtCP" CssClass="form-control" />
            </div>

            <div class="form-check mb-3">
                <input class="form-check-input" type="checkbox" value="" id="checkDefault" />
                <label class="form-check-label" for="checkDefault">
                    Acepto los términos y condiciones.
                </label>
            </div>

            <div class="col-12">
                <asp:Button Text="Participar" ID="btnParticipar" CssClass="btn btn-primary" OnClick="btnParticipar_Click" runat="server" />
            </div>
            </div>
        </div>
    </div>
</asp:Content>
