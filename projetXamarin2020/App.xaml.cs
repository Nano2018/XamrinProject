using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Storm.Mvvm;
namespace projetXamarin2020
{
    public partial class App : MvvmApplication
    {
        public static object Result { get; internal set; }

        public App()
            : base(() => new ConnexionPage())
        {
            InitializeComponent();
        }
    }
}
