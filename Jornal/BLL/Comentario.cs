using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jornal.BLL
{
    public class Comentario
    {
        private int _IdComentario;
        public int IdComentario
        {
            get { return _IdComentario; }
            set { _IdComentario = value; }
        }

        private string _Nome;
        public string Nome
        {
            get { return _Nome; }
            set { _Nome = value; }
        }

        private string _Email;
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        private string _Mensagem;
        public string Mensagem
        {
            get { return _Mensagem; }
            set { _Mensagem = value; }
        }

        private DateTime _Data;
        public DateTime Data
        {
            get { return _Data; }
            set { _Data = value; }
        }

        private int _Visibilidade;
        public int Visibilidade
        {
            get { return _Visibilidade; }
            set { _Visibilidade = value; }
        }

        private int _IdNoticia;
        public int IdNoticia
        {
            get { return _IdNoticia; }
            set { _IdNoticia = value; }
        }
    }
}