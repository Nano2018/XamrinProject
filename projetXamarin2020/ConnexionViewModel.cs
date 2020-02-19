using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using projetXamarin2020.Requete;
using Storm.Mvvm;
using TD.Api.Dtos;

namespace projetXamarin2020
{
    class ConnexionViewModel: ViewModelBase
    {
        private string _errorMessage;
        public LoginRequest Login { get; set; }
        private RestService restService;

        public string ErrorMessage
        {
                get => _errorMessage;
            set => SetProperty(ref _errorMessage, value);
        }
        public ConnexionViewModel()
        {
            Login = new LoginRequest();
            restService = new RestService();

        }
      
        public  async Task<bool> Connexion(object sender, EventArgs e)
        {
            var loginResult = await restService.Connexion(Login);

            if (loginResult.ExpiresIn == 0)
            {
                ErrorMessage = "identifiant ou mot de passe incorrect";
                return await Task.FromResult(false);
            }
            App.Result = loginResult;
            return await Task.FromResult(true);
        }
       
    }

}
