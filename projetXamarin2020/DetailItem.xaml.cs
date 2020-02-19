using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD.Api.Dtos;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;

namespace projetXamarin2020
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailItem : ContentPage
    {
        public DetailItem(PlaceItem item)
        {
            InitializeComponent();
            BindingContext = new DetailItemViewModel(item, myMap);
        }
    }
}