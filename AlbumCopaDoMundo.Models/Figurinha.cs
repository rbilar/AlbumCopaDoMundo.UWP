using AlbumCopaDoMundo.Models.Abstracts;
using System;
using System.Collections.Generic;

namespace AlbumCopaDoMundo.Models
{
    public class Figurinha : NotifyableClass
    {
        private Guid _id;
        public Guid Id
        {
            get { return _id; }
            set { Set(ref _id, value); }
        }

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

        private string _grupo;
        public string Grupo
        {
            get { return _grupo; }
            set { Set(ref _grupo, value); }
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
