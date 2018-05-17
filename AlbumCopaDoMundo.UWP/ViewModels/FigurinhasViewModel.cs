using AlbumCopaDoMundo.Models;
using AlbumCopaDoMundo.Models.Abstracts;
using AlbumCopaDoMundo.UWP.Pages;
using AlbumCopaDoMundo.UWP.Repository;
using AlbumCopaDoMundo.UWP.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace AlbumCopaDoMundo.UWP.ViewModels
{
    public class FigurinhasViewModel : NotifyableClass
    {
        private EFFigurinhaRepository FigurinhaRepository { get; set; } = EFFigurinhaRepository.Instance;

        public ObservableCollection<Figurinha> Figurinhas => FigurinhaRepository.Items;

        public async Task Initialize(string parameter)
        {
            await Repository.EFFigurinhaRepository.Instance.BuscarFigurinhas(parameter);
        }
    }
}
