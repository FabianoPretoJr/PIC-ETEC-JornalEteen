using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Jornal.DAL
{
    public class BannerDAL
    {
        Conexao con = new Conexao();

        public void Cadastrar(BLL.Banner ba)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.Conectar();
            cmd.CommandText = @"INSERT INTO Banner(Imagem, Categoria) VALUES(@imagem, @categoria)";

            cmd.Parameters.AddWithValue("@imagem", ba.Imagem);
            cmd.Parameters.AddWithValue("@categoria", ba.Categoria);

            cmd.ExecuteNonQuery();
            con.Desconectar();
        }

        public DataTable Listar()
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.Conectar();
            cmd.CommandText = @"SELECT Id_Banner, Imagem, Categoria FROM Banner";

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Desconectar();
            return dt;
        }

        public DataTable Listar(BLL.Banner ba)
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.Conectar();
            cmd.CommandText = @"SELECT Id_Banner, Imagem, Categoria FROM Banner WHERE Categoria LIKE @categoria";

            cmd.Parameters.AddWithValue("@categoria", "%" + ba.Categoria + "%");

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Desconectar();
            return dt;
        }

        public BLL.Banner PreencherPeloID(BLL.Banner ba)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.Conectar();
            cmd.CommandText = @"SELECT Id_Banner, Imagem, Categoria FROM Banner WHERE Id_Banner = @idbanner";
            cmd.Parameters.AddWithValue("@idbanner", ba.IdBanner);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                dr.Read();
                ba.IdBanner = Convert.ToInt32(dr["Id_Banner"]);
                ba.Imagem = dr["Imagem"].ToString();
                ba.Categoria = dr["Categoria"].ToString();
                dr.Close();
            }
            else
            {
                ba.IdBanner = 0;
            }

            con.Desconectar();
            return ba;
        }

        public void Atualizar(BLL.Banner ba)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.Conectar();
            cmd.CommandText = @"UPDATE Banner SET Imagem = @imagem, Categoria = @categoria WHERE Id_Banner = @idbanner";

            cmd.Parameters.AddWithValue("@idbanner", ba.IdBanner);
            cmd.Parameters.AddWithValue("@imagem", ba.Imagem);
            cmd.Parameters.AddWithValue("@categoria", ba.Categoria);

            cmd.ExecuteNonQuery();
            con.Desconectar();
        }
    }
}