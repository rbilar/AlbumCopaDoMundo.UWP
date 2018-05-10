using AlbumCopaDoMundo.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace AlbumCopaDoMundo.UWP.UserControls
{
    public sealed partial class FigurinhaItemUserControl : UserControl
    {
        public FigurinhaItemUserControl()
        {
            this.InitializeComponent();
        }

        public Figurinha Figurinha
        {
            get { return (Figurinha)GetValue(FigurinhaProperty); }
            set { SetValue(FigurinhaProperty, value); }
        }

        public static readonly DependencyProperty FigurinhaProperty =
            DependencyProperty.Register("Figurinha", typeof(Figurinha), typeof(FigurinhaItemUserControl), new PropertyMetadata(null));
    }
}
