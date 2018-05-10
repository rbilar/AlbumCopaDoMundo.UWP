using AlbumCopaDoMundo.Models.Abstracts;
using AlbumCopaDoMundo.UWP.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbumCopaDoMundo.UWP.ViewModels
{
    public class ConfiguracoesViewModel : NotifyableClass
    {
        //private bool? _esconderFigurinhaPreenchidaConfiguracao;

        public bool? EsconderFigurinhaPreenchidaConfiguracao
        {
            get
            {
                return StorageService.LerConfiguracao(StorageService.Configuracoes.EsconderFigurinhaPreenchida, false);
            }
            set
            {
                StorageService.GravarConfiguracao(StorageService.Configuracoes.EsconderFigurinhaPreenchida, value);
            }
        }
    }
}
