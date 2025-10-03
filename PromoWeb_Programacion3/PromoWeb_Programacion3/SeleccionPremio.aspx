<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="SeleccionPremio.aspx.cs" Inherits="PromoWeb_Programacion3.SeleccionPremio" %>

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
                                <img src="<%# Eval("ImagenUrl.ImagenUrl") %>" class="card-img-top" alt="...">
                            </div>

                            <div class="card-body">
                                <h5 class="card-title"><%# Eval("Nombre") %></h5>
                                <p class="card-text"><%# Eval("Descripcion") %></p>

                                <button type="button" class="btn btn-primary"
                                    onclick="mostrarModal(
                                        '<%# Eval("Id") %>', 
                                        '<%# Eval("Nombre") %>', 
                                        '<%# Eval("Descripcion") %>', 
                                        '<%# Eval("ImagenUrl.ImagenUrl") %>'
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
