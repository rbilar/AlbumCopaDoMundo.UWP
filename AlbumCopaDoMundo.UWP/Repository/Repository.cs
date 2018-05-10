using AlbumCopaDoMundo.Models.Abstracts;
using AlbumCopaDoMundo.UWP.Repository.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AlbumCopaDoMundo.UWP.Repository
{
    public abstract class Repository<T> : NotifyableClass, IRepository<T> where T : class
    {
        private ObservableCollection<T> _items = new ObservableCollection<T>();
        public ObservableCollection<T> Items
        {
            protected set { Set(ref _items, value); }
            get { return _items; }
        }

        public abstract Task AtualizarAsync(T entity);
        public abstract Task ConfigurarAlbum(bool reiniciar);
    }
}
