<%@ Page Title="Default" Language="C#" MasterPageFile="~/MiMaster.Master"
    AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PromoWeb_Programacion3.Default" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
    <title>Inicio</title>
</asp:Content>

<asp:Content ID="ContentMain" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="Content/style.css" rel="stylesheet" />

    <div class="container">
        <div class="header">
            <h1><i class="fas fa-gift"></i>Introduce tu codigo Promocional Aqui!</h1>
            <p class="mb-0">¡Participa y gana increíbles premios!</p>

        </div>

        <div class="mt-4">
            <h1 class="titulo"><i class="fas fa-gift"></i>Ingrese el Codigo del Voucher</h1>
        </div>

        <hr />
        <div class="d-flex align-items-center mb-3">

            <asp:TextBox ID="txtCodigo" runat="server"
                OnTextChanged="txtCodigo_TextChanged"
                CssClass="form-control me-3 flex-grow-1"
                onfocus="if(this.value==='Ingrese el código aquí'){ this.value=''; }"
                onblur="if(this.value===''){ this.value='Ingrese el código aqui'; }" />

            <asp:Button ID="BtnConfigVouchers"
                CssClass="btn btn-primary flex-shrink-0"
                runat="server"
                Text="Confirmar Voucher"
                OnClick="BtnConfigVouchers_Click" />

            <asp:Label ID="lblPassword" runat="server" CssClass="visually-hidden" AssociatedControlID="txtCodigo"></asp:Label>

        </div>

        <div>
            <asp:Label ID="LblMensaje" runat="server" CssClass="text-danger"></asp:Label>
        </div>


        <hr />

    </div>


</asp:Content>
