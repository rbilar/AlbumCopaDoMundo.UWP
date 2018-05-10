using AlbumCopaDoMundo.Models.Abstracts;
using System;
using System.Collections.Generic;

namespace AlbumCopaDoMundo.Models
{
    public class Figurinha : NotifyableClass
    {
        private int _numero;
        public int Numero
        {
            get { return _numero; }
            set { Set(ref _numero, value); }
        }
        
        private string _nome;
        public string Nome
        {
            get { return _nome; }
            set { Set(ref _nome, value); }
        }

        private string _nacionalidade;
        public string Nacionalidade
        {
            get { return _nacionalidade; }
            set { Set(ref _nacionalidade, value); }
        }

        private bool _colada;
        public bool Colada
        {
            get { return _colada; }
            set { Set(ref _colada, value); }
        }
    }
}
