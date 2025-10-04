<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="VouchersInvalido.aspx.cs" Inherits="PromoWeb_Programacion3.VouchersInvalido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container">
  <div class="header text-center p-5">
    <h1 class="fw-bold" 
        style="color:#e63946;">
        Voucher inválido
    </h1>
    <p class="mt-3" 
       style="color:#6c757d; font-size:1.2rem;">
       El código que ingresaste no existe o ya fue utilizado.
    </p>
    <p class="mt-2" 
       style="color:#457b9d;">
       Verificá el número y volvé a intentarlo para no perder la oportunidad de ganar <b>grandes premios</b>.
    </p>
  </div>
</div>



    <div class="d-flex justify-content-center p-4">
        <asp:Button ID="Button1" OnClick="Button1_Click" runat="server"   CssClass=" btn btn-primary mb-3"    Text="presione para volver al inicio"  />

    </div>

    <div class="header text-center p-4">

        <img src="https://www.shutterstock.com/image-vector/ip-address-concept-404-error-600nw-2388197959.jpg" alt="Alternate Text"  height="550" />

    </div>

  
    


</asp:Content>
