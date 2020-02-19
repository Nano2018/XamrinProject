using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using projetXamarin2020.Requete;
using Storm.Mvvm;
using TD.Api.Dtos;
using Xamarin.Forms;

namespace projetXamarin2020
{
    class MenuViewModel:ViewModelBase
    {
        public bool IsRefreshing { get; set; }
        public bool Refresh { get; set; }
        public ObservableCollection<PlaceItemSummary> Items { get; set; }
        public Command LoadCommand { get; set; }
        public RestService restService;
        public MenuViewModel()
        {
            restService = new RestService();
            Items = new ObservableCollection<PlaceItemSummary>();
            LoadCommand = new Command(async () => await ExecuteCommand());
        }
        public async Task<bool> ExecuteCommand()
        {
            if (Refresh)
                return false;

            Refresh = true;

            try
            {
                Items.Clear();
                var items = await restService.RefreshDataAsync();

                foreach (var item in items)
                {
                    string image_url = "https://td-api.julienmialon.com/images/" + item.ImageId;
                    item.ImageUrl = image_url;
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                Refresh = false;
            }
            return Refresh;
        }
    }
}
