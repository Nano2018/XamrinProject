
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD.Api.Dtos;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace projetXamarin2020
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddItem : ContentPage
    {
        public PlaceItem Item { get; set; }
        public AddItem()
        {
            InitializeComponent();
        }

         async void OnPickPhoto(object sender, EventArgs args)
            {
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsPickPhotoSupported)
                {
                    errorLabel.Text = "téléchargement des photos depuis la galerie non supporté par l'appareil";
                }
                var file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Full,
                    CompressionQuality = 40
                    //Directory = "Sample",
                    // Name = "test.jpg"
                });

               // byte[] imageArray = System.IO.File.ReadAllBytes(file.Path);
         }

        async void OnTakePhoto(object sender, EventArgs args)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                errorLabel.Text = "Prise de photo non supporté par l'appareil";
                return;
            }
         
            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {

                Directory = "Sample",
                Name = "test.jpg"
            });

            // byte[] imageArray = System.IO.File.ReadAllBytes(file.Path);
        }
    }
}