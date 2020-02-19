using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using projetXamarin2020.Requete;
using Storm.Mvvm;
using TD.Api.Dtos;

namespace projetXamarin2020
{
    class InscriptionViewModel:ViewModelBase
    {
        private string _confirmPassword;
        private string _labelError;
        public RestService restService;
        public RegisterRequest RequestRegister { get; set; }
        /*
         System.NullReferenceException
        Message=Object reference not set to an instance of an object
             */
        public string ConfirmPassword
        {
            get => _confirmPassword;
            set => SetProperty(ref _confirmPassword, value);
        }

        public string LabelError
        {
            get => _labelError;
            set => SetProperty(ref _labelError, value);
        }

        public InscriptionViewModel()
        {
            restService = new RestService();
            RequestRegister = new RegisterRequest();

        }

        public async Task<bool> InscriptionAction(object sender, EventArgs e)
        {
             if (string.IsNullOrEmpty(RequestRegister.FirstName) || string.IsNullOrEmpty(RequestRegister.LastName) || string.IsNullOrEmpty(RequestRegister.Password) || string.IsNullOrEmpty(RequestRegister.Email))
             {
                 LabelError = "veuillez remplir tous les champs SVP!!";
                 return await Task.FromResult(false);
             }

            bool isEmail = Regex.IsMatch(RequestRegister.Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            if (!isEmail)
             {
                 LabelError = "veuillez resaisir votre email";
                 return await Task.FromResult(false);
             }
            if (ConfirmPassword != null && !ConfirmPassword.Equals(RequestRegister.Password))
            {
                LabelError = "mots de passe non identique :(";
                return await Task.FromResult(false);
            }

            LoginResult result = await restService.Inscription(RequestRegister);
            if (result.ExpiresIn == 0)
            {
                
                LabelError = "erruer inconnu";
                return await Task.FromResult(false);
            }

            App.Result = result;
            return await Task.FromResult(true);
        }
    }
}
