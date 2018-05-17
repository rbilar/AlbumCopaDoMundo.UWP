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
        public int? OrdernarPorNumeroConfiguracao
        {
            get
            {
                return StorageService.LerConfiguracao(StorageService.Configuracoes.OrdernarPorNumeroConfiguracao, 0);
            }
            set
            {
                StorageService.GravarConfiguracao(StorageService.Configuracoes.OrdernarPorNumeroConfiguracao, value);
            }
        }
    }
}
