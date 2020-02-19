using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD.Api.Dtos;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace projetXamarin2020
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        MenuViewModel menuViewModel;

        public MenuPage()
        {
            InitializeComponent();
            BindingContext = this.menuViewModel = new MenuViewModel();
        }

      
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (menuViewModel.Items.Count == 0)
                menuViewModel.LoadCommand.Execute(null);
        }
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as PlaceItemSummary;
            if (item == null)
                return;
            PlaceItem place = await menuViewModel.restService.FindPlaceItemById(item.Id);
            await Navigation.PushAsync(new DetailItem(place));

            // Manually deselect item.
            ItemsListPlaceView.SelectedItem = null;
        }

        async void OnItemAdded(object sender, EventArgs a)
        {
           await Navigation.PushModalAsync(new NavigationPage(new AddItem()));
        }
        
        async void OnEditProfil(object sender, EventArgs a)
        {
            //await Navigation.PushModalAsync(new NavigationPage(new AddItemPage()));
        }
        async void OnDeconnexion(object sender, EventArgs a)
        {
            App.Result = null;
            Navigation.InsertPageBefore(new ConnexionPage(), this);
            await Navigation.PopAsync();
            
         }
    }
}