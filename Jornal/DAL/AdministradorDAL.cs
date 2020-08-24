using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Jornal.DAL
{
    public class AdministradorDAL
    {
        Conexao con = new Conexao();

        public BLL.Administrador PreencherPeloID(BLL.Administrador adm)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.Conectar();
            cmd.CommandText = @"SELECT Id_Adm, Usuario, Senha from Administrador Where Id_Adm = @idadm";
            cmd.Parameters.AddWithValue("@idadm", adm.IdAdm);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                dr.Read();
                adm.IdAdm = Convert.ToInt32(dr["Id_Adm"]);
                adm.Usuario = dr["Usuario"].ToString();
                adm.Senha = dr["Senha"].ToString();
                dr.Close();
            }
            else
            {
                adm.IdAdm = 0;
            }

            con.Desconectar();
            return adm;
        }

        public void Atualizar(BLL.Administrador adm)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.Conectar();
            cmd.CommandText = @"UPDATE Administradoor SET Usuario = @usuario, Senha = @senha WHERE Id_Adm = @idadm";

            cmd.Parameters.AddWithValue("@usuario", adm.Usuario);
            cmd.Parameters.AddWithValue("@senha", adm.Senha);

            cmd.ExecuteNonQuery();
            con.Desconectar();
        }

        public BLL.Administrador Login(BLL.Administrador adm)
        {
            SqlDataReader dr;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.Conectar();

            cmd.CommandText = @"SELECT Id_Adm, Usuario, Senha from Administrador Where Usuario = @usuario and Senha = @senha";

            cmd.Parameters.AddWithValue("@usuario", adm.Usuario);
            cmd.Parameters.AddWithValue("@senha", adm.Senha);

            dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                dr.Read();
                adm.IdAdm = Convert.ToInt32(dr["Id_Adm"]);
                adm.Usuario = dr["Usuario"].ToString();
                adm.Senha = dr["Senha"].ToString();
            }
            else
            {
                adm.IdAdm = 0;
            }

            return adm;
        }
    }
}