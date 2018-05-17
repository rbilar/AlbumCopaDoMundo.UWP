using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace AlbumCopaDoMundo.UWP.Services
{
    public static class StorageService
    {
        private static ApplicationDataContainer _localSettings => ApplicationData.Current.LocalSettings;

        public enum Configuracoes
        {
            OrdernarPorNumeroConfiguracao
        }

        public static T LerConfiguracao<T>(Configuracoes configuracao, T defaultValue)
        {
            var value = _localSettings.Values[configuracao.ToString()];

            if (value != null)
            {
                return (T)value;
            }
            else
            {
                return defaultValue;
            }
        }

        public static void GravarConfiguracao(Configuracoes configuracao, object value)
        {
            _localSettings.Values[configuracao.ToString()] = value;
        }
    }
}
