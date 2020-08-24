using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Jornal.UI
{
    public partial class Login : System.Web.UI.Page
    {
        BLL.Administrador adm = new BLL.Administrador();
        DAL.AdministradorDAL admDAL = new DAL.AdministradorDAL();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogar_Click(object sender, EventArgs e)
        {
            adm.Usuario = txtUsuario.Text;
            adm.Senha = txtSenha.Text;      

            adm = admDAL.Login(adm);

            if (adm.IdAdm == 0)
            {
                Response.Write("<script>alert('Login inválido')</script>");

                txtUsuario.Text = "";
                txtSenha.Text = "";
                txtUsuario.Focus();
            }
            else
            {
                Response.Write("<script>alert('Acesso permitido!')</script>");

                Session.Add("idadm", adm.IdAdm);
                Session.Add("usuario", adm.Usuario);

                Response.Redirect("NoticiaAdm.aspx");
            }
        }
    }
}