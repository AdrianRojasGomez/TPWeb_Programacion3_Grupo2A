<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="DniCliente.aspx.cs" Inherits="PromoWeb_Programacion3.DniCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Ingrese su numero de documento para terminar el proceso</h1>
    <h2>Si usted tiene usuario sera automatico su premio,de lo contrario tendra que registrarse como usario</h2>
    <div>
        <asp:DropDownList ID="ddlTipoDoc" runat="server" CssClass="form-select">
    <asp:ListItem Text="-- Seleccione --" Value="" Selected="True" />
    <asp:ListItem Text="DNI"      Value="DNI" />
    <asp:ListItem Text="Cédula"   Value="CE" />
    <asp:ListItem Text="Pasaporte" Value="PA" />
</asp:DropDownList>


    </div>
     <hr class="my-3 border-0" />
     
       <asp:TextBox ID="txtDni" CssClass="form-control" runat="server"></asp:TextBox>

   <hr class="my-3 border-0" />
    <asp:Button ID="Button1" runat="server" Text="Button" />
</asp:Content>
