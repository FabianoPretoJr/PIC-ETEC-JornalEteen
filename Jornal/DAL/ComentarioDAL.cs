using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Jornal.DAL
{
    public class ComentarioDAL
    {
        Conexao con = new Conexao();

        public void Cadastrar(BLL.Comentario co)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.Conectar();
            cmd.CommandText = @"INSERT INTO Comentario(Nome, Email, Mensagem, Data, Visibilidade, Id_Noticia) VALUES(@nome, @email, @mensagem, @data, @visibilidade, @idnoticia)";

            cmd.Parameters.AddWithValue("@nome", co.Nome);
            cmd.Parameters.AddWithValue("@email", co.Email);
            cmd.Parameters.AddWithValue("@mensagem", co.Mensagem);
            cmd.Parameters.AddWithValue("@data", co.Data);
            cmd.Parameters.AddWithValue("@visibilidade", co.Visibilidade);
            cmd.Parameters.AddWithValue("@idnoticia", co.IdNoticia);

            cmd.ExecuteNonQuery();
            con.Desconectar();
        }

        public DataTable Listar()
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.Conectar();
            cmd.CommandText = @"SELECT Id_Comentario, Nome, Email, Mensagem, Data, Visibilidade, Id_Noticia FROM Comentario";

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Desconectar();
            return dt;
        }

        public DataTable Listar(BLL.Comentario co)
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.Conectar();
            cmd.CommandText = @"SELECT Id_Comentario, Nome, Email, Mensagem, Data, Visibilidade, Id_Noticia FROM Comentario WHERE Nome LIKE @nome";

            cmd.Parameters.AddWithValue("@nome", "%" + co.Nome + "%");

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Desconectar();
            return dt;
        }

        /*public void Excluir(BLL.Comentario co)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.Conectar();
            cmd.CommandText = @"DELETE FROM Comentario WHERE Id_Comentario = @idcomentario";

            cmd.Parameters.AddWithValue("@idcmentario", co.IdComentario);

            cmd.ExecuteNonQuery();
            con.Desconectar();
        }*/

        public BLL.Comentario PreencherPeloID(BLL.Comentario co)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.Conectar();
            cmd.CommandText = @"SELECT Id_Comentario, Nome, Email, Mensagem, Data, Id_Noticia FROM Comentario WHERE Id_Comentario = @idcomentario";
            cmd.Parameters.AddWithValue("@idcomentario", co.IdComentario);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                dr.Read();
                co.IdComentario = Convert.ToInt32(dr["Id_Comentario"]);
                co.Nome = dr["Nome"].ToString();
                co.Email = dr["Email"].ToString();
                co.Mensagem = dr["Mensagem"].ToString();
                co.Data = Convert.ToDateTime(dr["Data"]);
                co.IdNoticia = Convert.ToInt32(dr["Id_Noticia"]);
                dr.Close();
            }
            else
            {
                co.IdNoticia = 0;
            }

            con.Desconectar();
            return co;
        }

        public void Atualizar(BLL.Comentario co)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.Conectar();
            cmd.CommandText = @"UPDATE Comentario SET Nome = @nome, Email = @email, Mensagem = @mensagem, Data = @data WHERE Id_Comentario = @idcomentario";

            cmd.Parameters.AddWithValue("@idcomentario", co.IdComentario);
            cmd.Parameters.AddWithValue("@nome", co.Nome);
            cmd.Parameters.AddWithValue("@email", co.Email);
            cmd.Parameters.AddWithValue("@mensagem", co.Mensagem);
            cmd.Parameters.AddWithValue("@data", co.Data);

            cmd.ExecuteNonQuery();
            con.Desconectar();
        }

        public void Ocultar(BLL.Comentario co)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.Conectar();
            cmd.CommandText = @"UPDATE Comentario SET Visibilidade = @visibilidade WHERE Id_Comentario = @idcomentario";

            cmd.Parameters.AddWithValue("@idcomentario", co.IdComentario);
            cmd.Parameters.AddWithValue("@visibilidade", co.Visibilidade);

            cmd.ExecuteNonQuery();
            con.Desconectar();
        }
    }
}