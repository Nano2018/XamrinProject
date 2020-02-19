using System;
using System.Collections.Generic;
using System.Text;
using TD.Api.Dtos;
using System.Threading.Tasks;
namespace projetXamarin2020.Requete
{
    interface IRestService
    {
        Task<List<PlaceItemSummary>> RefreshDataAsync();
        Task<PlaceItem> FindPlaceItemById(int Id);

        Task<bool> Add_comment(int Id, CreateCommentRequest commentItem);
        Task<LoginResult> Connexion(LoginRequest login);
        Task<LoginResult> Inscription(RegisterRequest register);
    }
}
