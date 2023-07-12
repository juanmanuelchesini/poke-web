<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Poke_Web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Bienvenidos a Poke-web!!!</h2>
    <p>Toda la info sobre tus Pokemon, está acá</p>
    <%--//main con las cartas--%>
    <div class="row row-cols-1 row-cols-md-3 g-4">

        <%-- Listar con foreach las tarjetas --%>
        <%--<%
            foreach (dominio.Pokemon poke in ListaPokemon)
            {
        %>
                <div class="col">
                    <div class="card">
                        <img src="<%: poke.UrlImagen %>" class="card-img-top" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><%: poke.Nombre  %></h5>
                            <p class="card-text"><%: poke.Descripcion %></p>
                            <a href="DetallePokemon.aspx?id=<%: poke.Id %>" class="btn btn-primary">Detalle</a>
                        </div>
                    </div>
                </div>
        <% } %>--%>

        <%-- Listar con Repeater las tarjetas --%>

        <asp:Repeater runat="server" ID="repRepetidor">
            <ItemTemplate>
                <div class="col">
                    <div class="card">
                        <img src="<%# Eval("UrlImagen")%>" class="card-img-top" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><%# Eval("Nombre")%></h5>
                            <p class="card-text"><%# Eval("Descripcion")%></p>
                            <a href="DetallePokemon.aspx?id=<%# Eval("Id")%>" class="btn btn-primary">Detalle</a>
                            <asp:Button Text="Ejemplo" runat="server" CssClass="btn btn-primary" ID="btnEjemplo" CommandArgument='<%#Eval("Id") %>' CommandName="PokemonId" OnClick="btnEjemplo_Click"/>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>
