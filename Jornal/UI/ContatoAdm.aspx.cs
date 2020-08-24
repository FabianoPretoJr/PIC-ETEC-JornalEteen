using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Jornal.UI
{
    public partial class ContatoAdm : System.Web.UI.Page
    {
        BLL.Contato cont = new BLL.Contato();
        DAL.ContatoDAL contDAL = new DAL.ContatoDAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvJornal.DataSource = contDAL.Listar();
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
            cont.Nome = txtFiltro.Text;
            gvJornal.DataSource = contDAL.Listar(cont);
            gvJornal.DataBind();
        }

        protected void gvResultado_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            cont.IdContato = Convert.ToInt32(e.CommandArgument);

            if(e.CommandName == "cmdResponder")
            {
                Response.Write("<script>Alert('Em breve!')</script>");
            }
        }

        protected void btnSair_Click(object sender, EventArgs e)
        {
            Session.Remove("usuario");
            Response.Redirect("Login.aspx");
        }
    }
}