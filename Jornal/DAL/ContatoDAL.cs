using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Jornal.DAL
{
    public class ContatoDAL
    {
        Conexao con = new Conexao();

        public void Cadastrar(BLL.Contato cont)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.Conectar();

            cmd.CommandText = @"INSERT INTO Contato(Nome, Email, Mensagem) VALUES(@nome, @email, @Mensagem)";

            cmd.Parameters.AddWithValue("@nome", cont.Nome);
            cmd.Parameters.AddWithValue("@email", cont.Email);
            cmd.Parameters.AddWithValue("@mensagem", cont.Mensagem);

            cmd.ExecuteNonQuery();
            con.Desconectar();
        }

        public DataTable Listar()
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.Conectar();
            cmd.CommandText = @"SELECT Id_Contato, Nome, Email, mensagem FROM Contato";

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Desconectar();
            return dt;
        }

        public DataTable Listar(BLL.Contato cont)
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.Conectar();
            cmd.CommandText = @"SELECT Id_Contato, Nome, Email, Mensagem FROM Contato WHERE Nome LIKE @nome";

            cmd.Parameters.AddWithValue("@nome", "%" + cont.Nome + "%");

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Desconectar();
            return dt;
        }
    }
}