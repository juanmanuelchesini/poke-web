using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace Poke_Web
{
    public partial class ListaPokemon : System.Web.UI.Page
    {
        public bool FiltroAvanzado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.esAdmin(Session["trainee"]))
            {
                Session.Add("error", "Se requiere ser admin para ingresar a esta pantalla");
                Response.Redirect("Error.aspx", false);
            }

            FiltroAvanzado = chkAvanzado.Checked;
            if (!IsPostBack)
            {
                PokemonNegocio negocio = new PokemonNegocio();
                //guardar listado en session
                Session.Add("listaPokemons", negocio.ListarConSP());
                dgvPokemon.DataSource = Session["listaPokemons"];
                dgvPokemon.DataBind();
            }
        }
        protected void dgvPokemon_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvPokemon.PageIndex = e.NewPageIndex;
            dgvPokemon.DataBind();

        }
        protected void dgvPokemon_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvPokemon.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioPokemon.aspx?id=" + id);
        }

        protected void txtFiltroRapido_TextChanged(object sender, EventArgs e)
        {
            List<Pokemon> lista = (List<Pokemon>)Session["listaPokemons"];
            List<Pokemon> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltroRapido.Text.ToUpper()));
            dgvPokemon.DataSource = listaFiltrada;
            dgvPokemon.DataBind();
        }

        protected void chkAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            FiltroAvanzado = chkAvanzado.Checked;
            txtFiltroRapido.Enabled = !FiltroAvanzado;
            ddlCampo_SelectedIndexChanged(sender, e);


        }

        protected void btnFiltroAvanzado_Click(object sender, EventArgs e)
        {
            try
            {
                PokemonNegocio negocio = new PokemonNegocio();
                dgvPokemon.DataSource = negocio.filtrar(ddlCampo.SelectedItem.ToString(), ddlCriterio.SelectedItem.ToString(), txtFiltroAvanzado.Text, ddlEstado.SelectedItem.ToString());
                dgvPokemon.DataBind();
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();
            if(ddlCampo.SelectedItem.ToString() == "Número")
            {
                ddlCriterio.Items.Add("Igual a");
                ddlCriterio.Items.Add("Mayor a");
                ddlCriterio.Items.Add("Menor a");
            }
            else
            {
                ddlCriterio.Items.Add("Contiene");
                ddlCriterio.Items.Add("Comienza con");
                ddlCriterio.Items.Add("Termina con");
            }
        }
    }
}