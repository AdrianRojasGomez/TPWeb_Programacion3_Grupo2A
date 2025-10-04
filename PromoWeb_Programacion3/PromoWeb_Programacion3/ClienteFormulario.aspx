<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="ClienteFormulario.aspx.cs" Inherits="PromoWeb_Programacion3.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="Content/style.css" rel="stylesheet" />

    <div class="container">

        <div class="header">
            <h1><i class="fas fa-gift"></i>Introduce tus datos!</h1>
            <p class="mb-0">Ingresa el numero de Documento para buscar o agregar un cliente</p>

        </div>

        <div class="form-container">
            <div class="col-12">
                <h1>Ingresa tus datos:</h1>

                <div class="mb-3 row">

                    <div class="col-sm-10">
                        <asp:Label ID="lblNombrePremio" runat="server" CssClass=" text-success" />
                    </div>
                    <div class="col-sm-10">
                        <asp:Label ID="lblVoucherUSado" runat="server" CssClass="form-label" />
                    </div>
                </div>

                <!-- Documento: solo números -->
                <div class="mb-3">
                    <label for="<%= txtDocumento.ClientID %>" class="form-label">Documento</label>
                    <asp:TextBox runat="server" ID="txtDocumento" CssClass="form-control"
                        AutoPostBack="true" OnTextChanged="txtDocumento_TextChanged"
                        required="required" pattern="^\d+$" inputmode="numeric" />
                    <div class="invalid-feedback">Ingresa solo números.</div>
                </div>

                <!-- Mensaje de estado (Bootstrap alert) -->
                <div id="docStatus" runat="server" class="alert d-none mt-2 py-2 px-3" role="alert"></div>
            </div>

            <!-- Nombre: solo letras (incluye acentos) y espacios -->
            <div class="mb-3">
                <label for="<%= txtNombre.ClientID %>" class="form-label">Nombre</label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control"
                    required="required"
                    pattern="^[A-Za-zÁÉÍÓÚáéíóúÑñÜü ]+$" />
                <div class="invalid-feedback">Usa solo letras y espacios.</div>
            </div>

            <!-- Apellido: solo letras (incluye acentos) y espacios -->
            <div class="mb-3">
                <label for="<%= txtApellido.ClientID %>" class="form-label">Apellido</label>
                <asp:TextBox runat="server" ID="txtApellido" CssClass="form-control"
                    required="required"
                    pattern="^[A-Za-zÁÉÍÓÚáéíóúÑñÜü ]+$" />
                <div class="invalid-feedback">Usa solo letras y espacios.</div>
            </div>

            <!-- Email: solo email -->
            <div class="mb-3">
                <label for="<%= txtEmail.ClientID %>" class="form-label">Email</label>
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control"
                    TextMode="Email" required="required" />
                <div class="invalid-feedback">Ingresa un correo válido.</div>
            </div>

            <!-- Dirección: letras, números y espacios -->
            <div class="mb-3">
                <label for="<%= txtDireccion.ClientID %>" class="form-label">Dirección</label>
                <asp:TextBox runat="server" ID="txtDireccion" CssClass="form-control"
                    TextMode="MultiLine" Rows="3"
                    required="required"
                    pattern="^[A-Za-zÁÉÍÓÚáéíóúÑñÜü0-9 ]+$" />
                <div class="invalid-feedback">Usa solo letras, números y espacios.</div>
            </div>

            <!-- Ciudad: solo letras y espacios -->
            <div class="mb-3">
                <label for="<%= txtCiudad.ClientID %>" class="form-label">Ciudad</label>
                <asp:TextBox runat="server" ID="txtCiudad" CssClass="form-control"
                    required="required"
                    pattern="^[A-Za-zÁÉÍÓÚáéíóúÑñÜü ]+$" />
                <div class="invalid-feedback">Usa solo letras y espacios.</div>
            </div>

            <!-- Código Postal: solo números -->
            <div class="mb-3">
                <label for="<%= txtCP.ClientID %>" class="form-label">Código Postal</label>
                <asp:TextBox runat="server" ID="txtCP" CssClass="form-control"
                    required="required" pattern="^\d+$" inputmode="numeric" />
                <div class="invalid-feedback">Ingresa solo números.</div>
            </div>

            <!-- Términos -->
            <div class="form-check mb-3">
                <input class="form-check-input" type="checkbox" id="checkDefault" required>
                <label class="form-check-label" for="checkDefault">
                    Acepto los términos y condiciones.
                </label>
                <div class="invalid-feedback">Debes aceptar los términos para continuar.</div>
            </div>

            <div class="col-12">
                <asp:Button Text="Participar" ID="btnParticipar" CssClass="btn btn-primary" OnClick="btnParticipar_Click" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>
