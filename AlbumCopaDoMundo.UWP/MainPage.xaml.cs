using AlbumCopaDoMundo.UWP.Pages;
using AlbumCopaDoMundo.UWP.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace AlbumCopaDoMundo.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            Repository.EFFigurinhaRepository.Instance.ConfigurarAlbum();

            NavigationService.Frame = ContentFrame;
            NavigationService.Navigated += On_Navigated;
            
            //Mensagem de boas vindas
            string mensagemBoasVindas = string.Empty;
            if (Repository.EFFigurinhaRepository.TotalColadas == 0)
                mensagemBoasVindas = "Olá, você ainda não colou nenhuma figurinha.";
            else if (Repository.EFFigurinhaRepository.TotalColadas == 682)
                mensagemBoasVindas = "Olá, você já completou o seu album.";
            else 
                mensagemBoasVindas = string.Format("Olá, você já colou {0} figurinhas.", Repository.EFFigurinhaRepository.TotalColadas.ToString());

            ContentDialog dialog = new ContentDialog()
            {
                Content = mensagemBoasVindas,
                CloseButtonText = "Fechar"
            };
            dialog.ShowAsync();

            NavigationService.Navigate<FigurinhasPage>("Introdução");
        }

        private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            NavView.Header = args.InvokedItem is NavigationViewItem ?
                ((NavigationViewItem)args.InvokedItem).Content : (string)args.InvokedItem;

            if (args.IsSettingsInvoked)
            {
                NavigationService.Navigate<ConfiguracoesPage>();
            }
            else
            {
                var item = sender.MenuItems.OfType<NavigationViewItem>().First(x => (string)x.Content == (string)args.InvokedItem);
                NavView_Navigate(item as NavigationViewItem);
            }
        }

        private void NavView_Navigate(NavigationViewItem item)
        {
            switch (item.Tag)
            {
                case "Introdução":
                case "Estádios":
                case "A":
                case "B":
                case "C":
                case "D":
                case "E":
                case "F":
                case "G":
                case "H":
                case "FIFA World Cup Legends":
                    NavigationService.Navigate<FigurinhasPage>(item.Tag);
                    break;
            }
        }

        private void On_Navigated(object sender, NavigationEventArgs e)
        {
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                ContentFrame.CanGoBack ? AppViewBackButtonVisibility.Visible : AppViewBackButtonVisibility.Collapsed;

            if (ContentFrame.SourcePageType == typeof(ConfiguracoesPage))
            {
                NavView.SelectedItem = NavView.SettingsItem as NavigationViewItem;
            }
            else
            {
                Dictionary<Type, string> lookup = new Dictionary<Type, string>()
                {
                    {typeof(FigurinhasPage), "Figurinhas"},
                };

                String stringTag = lookup[ContentFrame.SourcePageType];

                var navItem = NavView.MenuItems.FirstOrDefault(item => item is NavigationViewItem && ((NavigationViewItem)item).Tag.Equals(stringTag)) as NavigationViewItem;

                if (navItem != null)
                {
                    navItem.IsSelected = true;
                }
            }
        }

        private void NavView_Loaded(object sender, RoutedEventArgs e)
        {
            ((NavigationViewItem)NavView.SettingsItem).Content = "Configurações";
        }
    }
}
