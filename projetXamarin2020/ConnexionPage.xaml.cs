using Storm.Mvvm.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace projetXamarin2020
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConnexionPage : ContentPage
    {
        ConnexionViewModel connexionViewModel;
        public ConnexionPage()
        {
            InitializeComponent();
            BindingContext = this.connexionViewModel =  new ConnexionViewModel();
        }
        
        async void OnConnexionApi(object sender, EventArgs e)
        {
            var value = await this.connexionViewModel.Connexion(sender, e);
            if (value)
            {
                Navigation.InsertPageBefore(new MenuPage(), this);
                await Navigation.PopAsync();
            }
        }

        async void OnInscriptionClick(object sender, EventArgs e)

        {
            await Navigation.PushAsync(new InscriptionPage());

        }
    }
}