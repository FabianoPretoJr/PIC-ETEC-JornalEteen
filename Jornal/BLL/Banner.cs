using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jornal.BLL
{
    public class Banner
    {
        private int _IdBanner;
        public int IdBanner
        {
            get { return _IdBanner; }
            set { _IdBanner = value; }
        }

        private string _Imagem;
        public string Imagem
        {
            get { return _Imagem; }
            set { _Imagem = value; }
        }

        private string _Categoria;
        public string Categoria
        {
            get { return _Categoria; }
            set { _Categoria = value; }
        }
    }
}