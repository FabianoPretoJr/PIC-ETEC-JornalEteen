using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Jornal.UI
{
    public partial class AtualizarNoticia : System.Web.UI.Page
    {
        BLL.Noticia no = new BLL.Noticia();
        DAL.NoticiaDAL noDAL = new DAL.NoticiaDAL();

        protected void Page_Load(object sender, EventArgs e)
        {        
            if(!IsPostBack)
            {
                if(Session["usuario"] != null)
                {
                    if(Session["usuario"].ToString() != string.Empty)
                    {
                        if(Request.QueryString["id"] != null)
                        {
                            if(Request.QueryString["id"].ToString() != "")
                            {
                                int idRecebido;
                                int.TryParse(Request.QueryString["id"], out idRecebido);

                                no.IdNoticia = idRecebido;
                                no = noDAL.PreencherPeloID(no);

                                if(no.IdNoticia != 0)
                                {
                                    lblId.Text = no.IdNoticia.ToString();
                                    txtNome.Text = no.Nome;
                                    txtAutor.Text = no.Autor;
                                    ddlCategoria.Text = no.Categoria;
                                    Image.ImageUrl = no.Imagem;
                                    txtMateria.Text = no.Materia;
                                }
                                else
                                {
                                    lblId.Text = "ID INVÁLIDO";
                                }
                            }
                            else
                            {
                                lblId.Text = "ID INVÁLIDO";
                            }
                        }
                        else
                        {
                            lblId.Text = "ID INVÁLIDO";
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
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (fulImagem.HasFile)
            {
                if (fulImagem.PostedFile.ContentLength < 625000) // Menor que 5MB (625000 megabyte)
                {
                    try
                    {
                        if (fulImagem.HasFile)//Verifica se algum arquivo foi selecionado
                        {
                            try
                            {
                                //Aqui ele vai filtrar pelo tipo de arquivo
                                if (fulImagem.PostedFile.ContentType == "image/jpeg" ||
                                    fulImagem.PostedFile.ContentType == "image/png" ||
                                    fulImagem.PostedFile.ContentType == "image/gif" ||
                                    fulImagem.PostedFile.ContentType == "image/bmp")
                                {
                                    try
                                    {
                                        //Obtem o  HttpFileCollection (Lista de arquivos)
                                        HttpFileCollection hfc = Request.Files;
                                        for (int i = 0; i < hfc.Count; i++)
                                        {
                                            HttpPostedFile hpf = hfc[i];
                                            if (hpf.ContentLength > 0) //Verifica se o arquivo é maior que 0 bytes
                                            {
                                                //Pega o nome do arquivo
                                                string nome = System.IO.Path.GetFileName(hpf.FileName);
                                                //Pega a extensão do arquivo
                                                string extensao = Path.GetExtension(hpf.FileName);
                                                //Gera nome novo do Arquivo numericamente

                                                //string filename = string.Format("{0:00000000000000}", GerarID());

                                                string filename = DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(" ", "_");

                                                //Caminho a onde será salvo
                                                hpf.SaveAs(Server.MapPath("~/UI/imagens/") + filename + "_" + i + extensao);

                                                no.IdNoticia = Convert.ToInt32(lblId.Text);
                                                no.Nome = txtNome.Text;
                                                no.Autor = txtAutor.Text;
                                                no.Categoria = ddlCategoria.SelectedValue;
                                                no.Data = Convert.ToDateTime("12/09/2019");
                                                no.Imagem = "/UI/imagens/" + filename + "_" + i + extensao;
                                                no.Materia = txtMateria.Text;
                                                no.Visibilidade = 2;

                                                noDAL.Atualizar(no);
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        lblMensagem.Text = "Erro: " + ex.Message;
                                    }
                                    // Mensagem se tudo ocorreu bem                              
                                    Response.Redirect("NoticiaAdm.aspx");
                                }
                                else
                                {
                                    // Mensagem notifica que é permitido carregar apenas 
                                    // as imagens definida la em cima.
                                    lblMensagem.Text = "É permitido carregar apenas imagens!";
                                }
                            }
                            catch (Exception ex)
                            {
                                // Mensagem notifica quando ocorre erros
                                lblMensagem.Text = @"O arquivo não pôde ser carregado. 
                            O seguinte erro ocorreu: " + ex.Message;
                            }
                        }
                        else
                        {
                            lblMensagem.Text = "Nenhum arquivo selecionado";
                        }
                    }
                    catch (Exception ex)
                    {
                        // Mensagem notifica quando ocorre erros
                        lblMensagem.Text = @"O arquivo não pôde ser carregado. 
                    O seguinte erro ocorreu: " + ex.Message;
                    }
                }

                else
                {
                    // Mensagem notifica quando imagem é superior a 3 MB
                    lblMensagem.Text = "Não é permitido carregar imagem maior que 3 MB";
                }
            }
            else
            {

                no.IdNoticia = Convert.ToInt32(lblId.Text);
                no.Imagem = Image.ImageUrl;
                no.Nome = txtNome.Text;
                no.Autor = txtAutor.Text;
                no.Categoria = ddlCategoria.SelectedValue;
                no.Data = Convert.ToDateTime("12/09/2019");
                no.Materia = txtMateria.Text;
                no.Visibilidade = 2;

                noDAL.Atualizar(no);
                Response.Redirect("NoticiaAdm.aspx");
            }
        }

        protected void btnSair_Click(object sender, EventArgs e)
        {
            Session.Remove("usuario");
            Response.Redirect("Login.aspx");
        }
    }
}