<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioPokemon.aspx.cs" Inherits="Poke_Web.FormularioPokemon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="scriptManager1"/>
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <asp:Label for="txtId" ID="lblId" runat="server" Text="Id" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtId" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Label for="txtNombre" ID="lblNombre" runat="server" Text="Nombre" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Label for="txtNumero" ID="lblNumero" runat="server" Text="Numero" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtNumero" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Label for="ddlTipo" ID="lbltipo" runat="server" Text="Tipo" CssClass="form-label"></asp:Label>
                <asp:DropDownList ID="ddlTipo" runat="server" CssClass="form-select"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <asp:Label for="ddlDebilidad" ID="lblDebilidad" runat="server" Text="Debilidad" CssClass="form-label"></asp:Label>
                <asp:DropDownList ID="ddlDebilidad" runat="server" CssClass="form-select"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <asp:Button ID="btnAceptar" Text="Aceptar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" runat="server" />
                <a href="Default.aspx">Cancelar</a>
            </div>
        </div>
        <div class="col-6">
            <div class="mb-3">
                <asp:Label for="txtDescripcion" ID="lblDescripcion" runat="server" Text="Descripcion" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtDescripcion" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
            </div>            
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="mb-3">
                            <asp:Label for="txtUrlImagen" ID="lblUrlImagen" Text="UrlImagen" runat="server" CssClass="form-label" />
                            <asp:TextBox OnTextChanged="txtUrlImagen_TextChanged" ID="txtUrlImagen" runat="server" 
                                CssClass="form-control" AutoPostBack="true" />
                        </div>
                        <asp:Image ImageUrl="https://media.istockphoto.com/id/1128826884/vector/no-image-vector-symbol-missing-available-icon-no-gallery-for-this-moment.jpg?s=612x612&w=0&k=20&c=390e76zN_TJ7HZHJpnI7jNl7UBpO3UP7hpR2meE1Qd4="
                            runat="server" ID="imgPokemon" Width="60%" />
                    </ContentTemplate>
                </asp:UpdatePanel>            
        </div>
    </div>
</asp:Content>
