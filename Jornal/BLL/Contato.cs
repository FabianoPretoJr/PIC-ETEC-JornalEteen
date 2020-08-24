using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jornal.BLL
{
    public class Contato
    {
        private int _idContato;
        public int IdContato
        {
            get { return _idContato; }
            set { _idContato = value; }
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
    }
}