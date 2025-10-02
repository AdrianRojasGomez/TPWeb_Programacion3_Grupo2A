<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="VouchersInvalido.aspx.cs" Inherits="PromoWeb_Programacion3.VouchersInvalido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  <div class="alert alert-danger" role="alert">
   ❌ El código ingresado no existe o ya fue utilizado.
</div>

    <asp:Button ID="btnInicio" OnClick="Button1_Click" runat="server"  CssClass="btn btn-primary mb-3"    Text="presione para volver al inicio"  />


</asp:Content>
