<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="SeleccionPremio.aspx.cs" Inherits="PromoWeb_Programacion3.SeleccionPremio" %>

<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="dominio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="Content/premios.css" rel="stylesheet" />

    <div class="container">
        <div class="header-premios">
            <h1><i class="fas fa-gift"></i>¡Selecciona un premio que te gustaría ganar!</h1>
        </div>

        <hr />

        <div class="row row-cols-1 row-cols-md-3 g-4">
            <asp:Repeater ID="rptArticulos" runat="server">
                <ItemTemplate>
                    <div class="col">
                        <div class="card h-100">

                            <div class="card-img-top-container">

                                <div id="carousel-<%# Eval("Id") %>" class="carousel slide" data-bs-ride="carousel">

                                    <div class="carousel-inner">
                                        <asp:Repeater ID="rptImagenes" runat="server" DataSource='<%# Eval("Imagenes") %>'>
                                            <ItemTemplate>
                                                <div class='carousel-item <%# Container.ItemIndex == 0 ? "active" : "" %>'>

                                                    <img src='<%# Eval("Url") %>' class="d-block w-100" alt="Imagen del premio" />
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>

                                    <button class="carousel-control-prev" type="button" data-bs-target="#carousel-<%# Eval("Id") %>" data-bs-slide="prev">
                                        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                        <span class="visually-hidden">Anterior</span>
                                    </button>
                                    <button class="carousel-control-next" type="button" data-bs-target="#carousel-<%# Eval("Id") %>" data-bs-slide="next">
                                        <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                        <span class="visually-hidden">Siguiente</span>
                                    </button>

                                </div>
                            </div>
                            <div class="card-body">
                                <h5 class="card-title"><%# Eval("Nombre") %></h5>
                                <p class="card-text"><%# Eval("Descripcion") %></p>

                                <button type="button" class="btn btn-primary"
                                    onclick="mostrarModal(
                                        '<%# Eval("Id") %>', 
                                        '<%# Eval("Nombre") %>', 
                                        '<%# Eval("Descripcion") %>', 
                                        /* CORRECCIÓN 2: Volver a usar la propiedad de conveniencia ImagenUrl.Url para asegurar string */
                                        '<%# Eval("ImagenUrl.Url") %>'
                                    )">
                                    Quiero Este!
                                </button>

                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>

        <hr />

    </div>

    <div class="modal fade" id="confirmacionModal" tabindex="-1" aria-labelledby="modalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="modalLabel">Confirmar Selección de Premio</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="text-center">
                        <img id="modalImg" src="#" class="img-fluid mb-3" style="max-height: 150px;" alt="Imagen del Premio" />
                        <h4 id="modalTitulo"></h4>
                        <p id="modalDescripcion" class="text-muted"></p>
                    </div>

                    <p class="mt-3">¿Deseas confirmar la selección de este premio y pasar a ingresar tus datos?</p>

                    <asp:HiddenField ID="HiddenArticuloId" runat="server" />
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Volver</button>
                    <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar" CssClass="btn btn-success" OnClick="btnConfirmar_Click" />
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        function mostrarModal(id, nombre, descripcion, imagenUrl) {
            document.getElementById('modalTitulo').innerText = nombre;
            document.getElementById('modalDescripcion').innerText = descripcion;
            document.getElementById('modalImg').src = imagenUrl;
            document.getElementById('<%= HiddenArticuloId.ClientID %>').value = id;
            var modal = new bootstrap.Modal(document.getElementById('confirmacionModal'));
            modal.show();
        }
    </script>

</asp:Content>
