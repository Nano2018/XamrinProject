using projetXamarin2020.Requete;
using System;
using System.Collections.Generic;
using System.Text;
using TD.Api.Dtos;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Storm.Mvvm;
namespace projetXamarin2020
{
    class DetailItemViewModel : ViewModelBase
    {
        public PlaceItem Item { get; set; }
        public bool Refresh { get; private set; }
        private string _labelTest;
        public string LabelTest
        {
            get => _labelTest;
            set => SetProperty(ref _labelTest, value);
        }
        public Map MyMap { get; set; }
        public RestService restService;
        public Command LoadMap { get; set; }
        public DetailItemViewModel(PlaceItem item, Map myMap)
        {
            restService = new RestService();
            item.ImageUrl = "https://td-api.julienmialon.com/images/" + item.ImageId;
            Item = item;
            MyMap = myMap;
            OnLoadMapAction();
        }

        void OnLoadMapAction()
        {

            MyMap.Pins.Add(new Pin
            {
                Label = Item.Title,
                Position = new Position(Item.Latitude, Item.Longitude)
            });
            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(Item.Latitude, Item.Longitude), Distance.FromMiles(0.1)));
        }
    }
}
