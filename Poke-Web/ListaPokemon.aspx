<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListaPokemon.aspx.cs" Inherits="Poke_Web.ListaPokemon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />
    <h2>Lista Pokemon</h2>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-3">
                    <div class="mb-3">
                        <asp:Label ID="lblFiltroRapido" runat="server" Text="Filtrar" CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="txtFiltroRapido" CssClass="form-control" runat="server" AutoPostBack="true" OnTextChanged="txtFiltroRapido_TextChanged" />
                    </div>
                </div>
                <div class="col-6" style="display: flex; flex-direction: column; justify-content: flex-end;">
                    <div class="mb-3">
                        <asp:CheckBox Text="Filtro Avanzado"
                            CssClass="" ID="chkAvanzado" runat="server"
                            AutoPostBack="true" OnCheckedChanged="chkAvanzado_CheckedChanged" />
                    </div>
                </div>
            </div>
            <%-- filtro avanzado, inyectamos codigo c# para que aparezca cuando apretemos el checkbox --%>
            <%if (FiltroAvanzado)
                { %>
            <div class="row">
                <div class="col-3">
                    <div class="mb-3">
                        <asp:Label Text="Campo" runat="server" />
                        <asp:DropDownList runat="server" AutoPostBack="true" ID="ddlCampo" CssClass="form-control" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged">
                            <asp:ListItem Text="Nombre" />
                            <asp:ListItem Text="Tipo" />
                            <asp:ListItem Text="Número" />
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-3">
                    <asp:Label Text="Criterio" ID="lblCriterio" runat="server" />
                    <asp:DropDownList runat="server" ID="ddlCriterio" CssClass="form-control">
                    </asp:DropDownList>
                </div>
                <div class="col-3">
                    <asp:Label Text="Filtro" runat="server" />
                    <asp:TextBox runat="server" ID="txtFiltroAvanzado" CssClass="form-control" />
                </div>
                <div class="col-3">
                    <asp:Label Text="Estado" ID="lblEstado" runat="server" />
                    <asp:DropDownList runat="server" ID="ddlEstado" CssClass="form-control">
                        <asp:ListItem Text="Todos" />
                        <asp:ListItem Text="Activo" />
                        <asp:ListItem Text="Inactivo" />
                    </asp:DropDownList>
                </div>
            </div>
            <div class="mb-3">
                <asp:Button Text="Aceptar" ID="btnFiltroAvanzado" OnClick="btnFiltroAvanzado_Click" CssClass="btn btn-primary" runat="server" />
            </div>
            <% }%>

            <asp:GridView ID="dgvPokemon" runat="server" CssClass="table" AutoGenerateColumns="false" DataKeyNames="Id"
                OnSelectedIndexChanged="dgvPokemon_SelectedIndexChanged"
                OnPageIndexChanging="dgvPokemon_PageIndexChanging"
                AllowPaging="true" PageSize="5">
                <Columns>
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Número" DataField="Numero" />
                    <asp:BoundField HeaderText="Tipo" DataField="Tipo.Descripcion" />
                    <asp:CheckBoxField HeaderText="Activo" DataField="Activo" />
                    <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="👈🏼" />
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <a href="FormularioPokemon.aspx" class="btn btn-primary">Agregar</a>
</asp:Content>
