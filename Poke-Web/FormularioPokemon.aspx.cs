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
        public bool ConfirmaEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            //desabilitar la carga de Id (se genera automaticamente en la db)
            txtId.Enabled = false;
            //confirma eliminacion en false cuando carga la pagina
            ConfirmaEliminacion = false;
            //cargar desplegables
            try
            {   
                //configuracion inicial de la pantalla
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

                //configuracion si estamos modificando.
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != "" && !IsPostBack) 
                {
                    PokemonNegocio negocio = new PokemonNegocio();
                    //achicamos lo de las listas
                    //List<Pokemon> lista = negocio.Listar(id);
                    //Pokemon seleccionado = lista[0];
                    Pokemon seleccionado = (negocio.Listar(id))[0];

                    //guardo el poke seleccionado en session
                    Session.Add("pokeSeleccionado", seleccionado);

                    //pre cargar todos los campos
                    txtId.Text = id;
                    txtNumero.Text = seleccionado.Numero.ToString();
                    txtNombre.Text = seleccionado.Nombre;
                    txtDescripcion.Text = seleccionado.Descripcion;
                    txtUrlImagen.Text = seleccionado.UrlImagen;
                    

                    ddlTipo.SelectedValue = seleccionado.Tipo.Id.ToString();
                    ddlDebilidad.SelectedValue = seleccionado.Debilidad.Id.ToString();
                    txtUrlImagen_TextChanged(sender, e);

                    //configurar acciones
                    if (!seleccionado.Activo)
                        btnDesactivar.Text = "Activar";
                    
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

                if (Request.QueryString["id"] != null)
                { 
                    nuevo.Id = int.Parse(txtId.Text);
                    negocio.modificarConSP(nuevo);
                }
                else
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
        protected void btnEliminar_Click1(object sender, EventArgs e)
        {
            ConfirmaEliminacion = true;
        }

        protected void btnConfirmaEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if(chkConfirmarEliminacion.Checked)
                {
                    PokemonNegocio negocio = new PokemonNegocio();
                    negocio.eliminar(int.Parse(txtId.Text));
                    Response.Redirect("ListaPokemon.aspx", false);
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }
        }

        protected void btnDesactivar_Click(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();
            Pokemon seleccionado = (Pokemon)Session["pokeSeleccionado"];
            try
            {

                negocio.elminarLogico(seleccionado.Id, !seleccionado.Activo);
                Response.Redirect("ListaPokemon.aspx");
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }
        }
    }
}