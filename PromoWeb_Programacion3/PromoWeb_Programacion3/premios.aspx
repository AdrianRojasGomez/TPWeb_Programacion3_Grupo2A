<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="premios.aspx.cs" Inherits="PromoWeb_Programacion3.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Content/premios.css" rel="stylesheet" />

    <div class="container">
        <div class="header">
            <h1><i class="fas fa-gift"></i>Gran Promoción</h1>
            <p class="mb-0">¡Participa y gana increíbles premios!</p>

            <div class="d-grid boton-animado-contenedor">
                <asp:Button class="boton-animado" ID="btnIrCanjearCupon" runat="server" OnClick="btnIrCanjearCupon_Click" Text="¡Canjea tu Cupon Aqui!" />
            </div>
        </div>
        <div>
            <h1 class="titulo"><i class="fas fa-gift"></i>Conoce nuestros Premios </h1>
        </div>

        <hr />
        <div class="row row-cols-1 row-cols-md-3 g-4">
            <asp:Repeater ID="rptArticulos" runat="server">
                <ItemTemplate>
                    <div class="col">
                        <div class="card h-100">
                            <img src="<%# Eval("ImagenUrl.ImagenUrl") %>" class="card-img-top" alt="...">
                            <div class="card-body">
                                <h5 class="card-title"><%# Eval("Nombre") %></h5>
                                <p class="card-text"><%# Eval("Descripcion") %></p>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
         <hr />

    </div>
</asp:Content>
