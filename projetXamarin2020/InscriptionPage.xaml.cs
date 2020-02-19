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
    public partial class InscriptionPage : ContentPage
    {
        InscriptionViewModel inscriptionVieModel;
        public InscriptionPage()
        {
            InitializeComponent();
            BindingContext = this.inscriptionVieModel = new InscriptionViewModel();
        }

        async void OnValidationInscription(Object sender, EventArgs e)
        {
            bool value = await inscriptionVieModel.InscriptionAction(sender, e);
            if (value)
            {
               await Navigation.PopAsync();   
            }
        }
    }
}