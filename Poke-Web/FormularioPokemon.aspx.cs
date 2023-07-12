using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Poke_Web
{
    public partial class FormularioPokemon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //desabilitar la carga de Id (se genera automaticamente en la db)
            txtId.Enabled = false;

            //cargar desplegables
            try
            {
                if (!IsPostBack)
                {
                    ElementoNegocio negocio = new ElementoNegocio();
                    List<Elemento> lista = negocio.listar();

                    ddlTipo.DataSource = lista;
                    ddlTipo.DataValueField = "Id";
                    ddlTipo.DataTextField = "Descripcion";
                    ddlTipo.DataBind();

                    ddlDebilidad.DataSource = lista;
                    ddlDebilidad.DataValueField = "Id";
                    ddlDebilidad.DataTextField = "Descripcion";
                    ddlDebilidad.DataBind();
                }
            }
            catch (Exception ex)
            {

                Session.Add("error",ex);
                //redireccion si lanza excepcion
                
            }

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                //crear la instancia del poke q voy a agregar
                Pokemon nuevo = new Pokemon();
                //crear la instancia de negocio para listar
                PokemonNegocio negocio = new PokemonNegocio();

                nuevo.Nombre = txtNombre.Text;
                nuevo.Numero = int.Parse(txtNumero.Text);
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.UrlImagen = txtUrlImagen.Text;

                //capturar desplegables
                nuevo.Tipo = new Elemento();
                nuevo.Tipo.Id = int.Parse(ddlTipo.SelectedValue);
                nuevo.Debilidad = new Elemento();
                nuevo.Debilidad.Id = int.Parse(ddlDebilidad.SelectedValue);

                negocio.agregarConSp(nuevo);
                Response.Redirect("ListaPokemon.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }

        protected void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {
            imgPokemon.ImageUrl = txtUrlImagen.Text;
            
        }
    }
}