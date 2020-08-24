using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Jornal.DAL
{
    public class NoticiaDAL
    {
        Conexao con = new Conexao();

        public void Cadastrar(BLL.Noticia no)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.Conectar();
            cmd.CommandText = @"INSERT INTO Noticia(Nome, Autor, Categoria, Data, Imagem, Materia, Visibilidade) VALUES(@nome, @autor, @categoria, @data, @imagem, @materia, @visibilidade)";

            cmd.Parameters.AddWithValue("@nome", no.Nome);
            cmd.Parameters.AddWithValue("@autor", no.Autor);
            cmd.Parameters.AddWithValue("@categoria", no.Categoria);
            cmd.Parameters.AddWithValue("@data", no.Data);
            cmd.Parameters.AddWithValue("@imagem", no.Imagem);
            cmd.Parameters.AddWithValue("@materia", no.Materia);
            cmd.Parameters.AddWithValue("Visibilidade", no.Visibilidade);

            cmd.ExecuteNonQuery();
            con.Desconectar();
        }

        public DataTable Listar()
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.Conectar();
            cmd.CommandText = @"SELECT Id_Noticia, Nome, Autor, Categoria, Data, Imagem, Materia, Visibilidade FROM Noticia";

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Desconectar();
            return dt;
        }

        public DataTable Listar(BLL.Noticia no)
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.Conectar();
            cmd.CommandText = @"SELECT Id_Noticia, Nome, Autor, Categoria, Data, Imagem, Materia, Visibilidade FROM Noticia WHERE Nome LIKE @nome";

            cmd.Parameters.AddWithValue("@nome", "%" + no.Nome + "%");

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Desconectar();
            return dt;
        }

        /*public void Excluir(BLL.Noticia no)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.Conectar();
            cmd.CommandText = @"DELETE FROM Noticia WHERE Id_Noticia = @idnoticia";

            cmd.Parameters.AddWithValue("@idnoticia", no.IdNoticia);

            cmd.ExecuteNonQuery();
            con.Desconectar();
        }*/

        public BLL.Noticia PreencherPeloID(BLL.Noticia no)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.Conectar();
            cmd.CommandText = @"SELECT Id_Noticia, Nome, Autor, Categoria, Data, Imagem, Materia FROM Noticia WHERE Id_Noticia = @idnoticia";
            cmd.Parameters.AddWithValue("@idnoticia", no.IdNoticia);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                dr.Read();
                no.IdNoticia = Convert.ToInt32(dr["Id_Noticia"]);
                no.Nome = dr["Nome"].ToString();
                no.Autor = dr["Autor"].ToString();
                no.Categoria = dr["Categoria"].ToString();
                no.Data = Convert.ToDateTime(dr["Data"]);
                no.Imagem = dr["Imagem"].ToString();
                no.Materia = dr["Materia"].ToString();
                dr.Close();
            }
            else
            {
                no.IdNoticia = 0;
            }

            con.Desconectar();
            return no;
        }

        public void Atualizar(BLL.Noticia no)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.Conectar();
            cmd.CommandText = @"UPDATE Noticia SET Nome = @nome, Autor = @autor, Categoria = @categoria, Data = @data, Imagem = @imagem, Materia = @materia WHERE Id_Noticia = @idnoticia";

            cmd.Parameters.AddWithValue("@idnoticia", no.IdNoticia);
            cmd.Parameters.AddWithValue("@nome", no.Nome);
            cmd.Parameters.AddWithValue("@autor", no.Autor);
            cmd.Parameters.AddWithValue("@categoria", no.Categoria);
            cmd.Parameters.AddWithValue("@data", no.Data);
            cmd.Parameters.AddWithValue("@imagem", no.Imagem);
            cmd.Parameters.AddWithValue("@materia", no.Materia);

            cmd.ExecuteNonQuery();
            con.Desconectar();
        }

        public void Ocultar(BLL.Noticia no)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.Conectar();
            cmd.CommandText = @"UPDATE Noticia SET Visibilidade = @visibilidade WHERE Id_Noticia = @idnoticia";

            cmd.Parameters.AddWithValue("@idnoticia", no.IdNoticia);
            cmd.Parameters.AddWithValue("@visibilidade", no.Visibilidade);

            cmd.ExecuteNonQuery();
            con.Desconectar();
        }
    }
}