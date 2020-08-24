using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jornal.BLL
{
    public class Noticia
    {
        private int _IdNoticia;
        public int IdNoticia
        {
            get { return _IdNoticia; }
            set { _IdNoticia = value; }
        }

        private string _Nome;
        public string Nome
        {
            get { return _Nome; }
            set { _Nome = value; }
        }

        private string _Autor;
        public string Autor
        {
            get { return _Autor; }
            set { _Autor = value; }
        }

        private string _Categoria;
        public string Categoria
        {
            get { return _Categoria; }
            set { _Categoria = value; }
        }

        private DateTime _Data;
        public DateTime Data
        {
            get { return _Data; }
            set { _Data = value; }
        }

        private string _Imagem;
        public string Imagem
        {
            get { return _Imagem; }
            set { _Imagem = value; }
        }

        private string _Materia;
        public string Materia
        {
            get { return _Materia; }
            set { _Materia = value; }
        }

        private int _Visibilidade;
        public int Visibilidade
        {
            get { return _Visibilidade; }
            set { _Visibilidade = value; }
        }
    }
}