using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Jornal.UI
{
    public partial class ComentarioAdm : System.Web.UI.Page
    {
        BLL.Comentario co = new BLL.Comentario();
        DAL.ComentarioDAL coDAL = new DAL.ComentarioDAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvJornal.DataSource = coDAL.Listar();
                gvJornal.DataBind();

                if (Session["usuario"] != null)
                {
                    if (Session["usuario"].ToString() != string.Empty)
                    {

                    }
                    else
                    {
                        Response.Redirect("Login.aspx");
                    }
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            co.Nome = txtFiltro.Text;
            gvJornal.DataSource = coDAL.Listar(co);
            gvJornal.DataBind();
        }

        protected void gvResultado_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            co.IdComentario = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "cmdOcultar")
            {
                co.Visibilidade = 1;

                coDAL.Ocultar(co);
                Response.Write("<script>Alert('Curso ocultado com sucesso!')</script>");

                btnFiltrar_Click(null, null);
            }
        }

        protected void btnSair_Click(object sender, EventArgs e)
        {
            Session.Remove("usuario");
            Response.Redirect("Login.aspx");
        }
    }
}