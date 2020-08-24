using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Jornal.UI
{
    public partial class ContatoUsuario : System.Web.UI.Page
    {
        BLL.Contato cont = new BLL.Contato();
        DAL.ContatoDAL contDAL = new DAL.ContatoDAL();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            cont.Nome = txtNome.Text;
            cont.Email = txtEmail.Text;
            cont.Mensagem = txtMensagem.Text;

            contDAL.Cadastrar(cont);
            Response.Write("<script>alert('Mensagem enviada!')</script>");

            txtNome.Text = "";
            txtEmail.Text = "";
            txtMensagem.Text = "";
            txtNome.Focus();
        }
    }
}