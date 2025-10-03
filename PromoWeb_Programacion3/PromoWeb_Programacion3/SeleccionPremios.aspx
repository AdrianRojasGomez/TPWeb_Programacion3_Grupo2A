<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="SeleccionPremios.aspx.cs" Inherits="PromoWeb_Programacion3.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <link href="Content/premios.css" rel="stylesheet" />

 <div class="container">
     <div class="header-premios">
         <h1><i class="fas fa-gift"></i>¡Selecciona un premio que te gustaría ganar!</h1>
     
     </div>
     <div>
      
     </div>

     <hr />
    <div class="row row-cols-1 row-cols-md-3 g-4">
    <asp:Repeater ID="rptArticulos" runat="server">
        <ItemTemplate>
            <div class="col">
                <div class="card h-100">
                    
                    <div class="card-img-top-container">
                        <img src="<%# Eval("ImagenUrl.ImagenUrl") %>" class="card-img-top" alt="...">
                    </div>
                    <div class="card-body">
                        <h5 class="card-title"><%# Eval("Nombre") %></h5>
                        <p class="card-text"><%# Eval("Descripcion") %></p>
                        <a href="#" class="btn btn-primary">Quiero Este!</a>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
      <hr />

 </div>
</asp:Content>
