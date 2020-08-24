using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Jornal.UI
{
    public partial class ComentarioUsuario : System.Web.UI.Page
    {
        BLL.Comentario co = new BLL.Comentario();
        DAL.ComentarioDAL coDAL = new DAL.ComentarioDAL();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            co.Nome = txtNome.Text;
            co.Email = txtEmail.Text;
            co.Mensagem = txtMensagem.Text;
            co.Data = Convert.ToDateTime("13/11/2019");
            co.Visibilidade = 2;
            co.IdNoticia = 1;

            coDAL.Cadastrar(co);
            Response.Write("<script>alert('Comentário enviado!')</script>");

            txtNome.Text = "";
            txtEmail.Text = "";
            txtMensagem.Text = "";
            txtNome.Focus();
        }
    }
}