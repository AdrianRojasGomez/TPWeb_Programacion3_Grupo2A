<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="premios.aspx.cs" Inherits="PromoWeb_Programacion3.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .main-container {
            background: white;
            border-radius: 15px;
            box-shadow: 0 15px 35px rgba(0,0,0,0.1);
            margin: 50px auto;
            max-width: 600px;
            overflow: hidden;
        }

        .header {
            background: linear-gradient(45deg, #FF6B6B, #4ECDC4);
            color: white;
            padding: 30px;
            text-align: center;
            border-radius: 0% 0% 10px 10px;
        }

        .btn-primary {
            background: linear-gradient(45deg, #4ECDC4, #FF6B6B);
            margin: 30px;
            border: none;
            border-radius: 25px;
            padding: 12px 30px;
            font-weight: bold;
            transition: all 0.3s ease;
        }

            .btn-primary:hover {
                transform: translateY(-2px);
                box-shadow: 0 5px 15px rgba(0,0,0,0.2);
            }

        .titulo {
            text-align: center;
            margin: 30px auto 30px auto;
        }
    </style>

    <div class="container">
        <div class="header">
            <h1><i class="fas fa-gift"></i>Gran Promoción</h1>
            <p class="mb-0">¡Participa y gana increíbles premios!</p>
            <div class="d-grid">
                <asp:Button class="btn btn-primary" ID="btnIrCanjearCupon" runat="server" OnClick="btnIrCanjearCupon_Click" Text="¡Canjea tu Cupon Aqui!" />
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

    </div>
</asp:Content>
