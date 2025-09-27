<%@ Page Title="Default" Language="C#" MasterPageFile="~/MiMaster.Master"
    AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PromoWeb_Programacion3.Default" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
    <title>Inicio</title>
</asp:Content>

<asp:Content ID="ContentMain" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Arrancamos</h1>

    <form class="row g-3">
  <div class="col-auto">
    <label for="staticEmail2" class="visually-hidden">Email</label>
    <input type="text" readonly class="form-control-plaintext" id="staticEmail2" value="Ingrese el Codigo del Vouchers">
  </div>
  <div class="col-auto">
  

      <asp:Label ID="lblPassword" runat="server" CssClass="visually-hidden" AssociatedControlID="txtCodigo" ></asp:Label>
<asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control"  ></asp:TextBox>


  </div>
        <hr class="d-none" />  
  <div class="col-auto">
    
    <asp:Button ID="BtnConfigVouchers" CssClass="btn btn-primary mb-3"  runat="server" Text="Confirmar Vouchers" OnClick="BtnConfigVouchers_Click" />
  </div>

        <div> <asp:Label ID="LblMensaje"  runat="server"  Text="Label"></asp:Label>  </div>
        
</form>

</asp:Content>
