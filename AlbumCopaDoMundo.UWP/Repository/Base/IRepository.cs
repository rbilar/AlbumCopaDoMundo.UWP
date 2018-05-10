using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbumCopaDoMundo.UWP.Repository.Base
{
    public interface IRepository<T>
    {
        Task AtualizarAsync(T entity);
        Task ConfigurarAlbum(bool reiniciar);
    }
}
